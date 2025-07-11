using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Windows.Forms;

namespace PerformanceTrackerApp
{
    public partial class Form1 : Form
    {
        private BindingList<Case> cases = new BindingList<Case>();
        private readonly string dataFile = "cases.json";

        public Form1()
        {
            InitializeComponent();
            SetupDataGrid();
            SetupButtons();
            LoadData();
        }

        private void SetupDataGrid()
        {
            dataGridCases.AutoGenerateColumns = true;
            dataGridCases.DataSource = cases;
            dataGridCases.CellValueChanged += DataGridCases_CellValueChanged;
            dataGridCases.CurrentCellDirtyStateChanged += DataGridCases_CurrentCellDirtyStateChanged;
            dataGridCases.CellClick += DataGridCases_CellClick;
        }

        private void SetupButtons()
        {
            btnAdd.Click += btnAdd_Click;
            btnEdit.Click += btnEdit_Click;
            btnCalculate.Click += btnCalculate_Click;
            btnWeeklySummary.Click += btnWeeklySummary_Click;
            btnExportCsv.Click += btnExportCsv_Click;
        }

        private void DataGridCases_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dataGridCases.IsCurrentCellDirty)
                dataGridCases.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void DataGridCases_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            var colName = dataGridCases.Columns[e.ColumnIndex].Name;
            var updatedCase = dataGridCases.Rows[e.RowIndex].DataBoundItem as Case;

            if (updatedCase == null)
                return;

            if (colName == "IsClosed" && updatedCase.IsClosed)
            {
                string summary = InputHelper.ShowDialog("Enter Closure Summary", "Closure");
                updatedCase.ClosureSummary = summary;
            }
            else if (colName == "IsHandedOver" && updatedCase.IsHandedOver)
            {
                string summary = InputHelper.ShowDialog("Enter Handover Summary", "Handover");
                updatedCase.HandoverSummary = summary;
            }

            SaveData();
            RefreshGrid();
        }

        private void DataGridCases_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;
            dataGridCases.BeginEdit(true);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string input = InputHelper.ShowDialog("Enter Case ID:", "Add Case");
            if (!int.TryParse(input, out int id))
            {
                MessageBox.Show("Invalid ID");
                return;
            }

            bool ownership = MessageBox.Show("Have you taken ownership?", "Ownership", MessageBoxButtons.YesNo) == DialogResult.Yes;
            bool closed = MessageBox.Show("Is it closed?", "Status", MessageBoxButtons.YesNo) == DialogResult.Yes;
            string closureSummary = closed ? InputHelper.ShowDialog("Closure Summary:", "Provide Summary") : "";

            cases.Add(new Case
            {
                Id = id,
                TakenOwnership = ownership,
                IsClosed = closed,
                IsHandedOver = false,
                ClosureSummary = closureSummary,
                HandoverSummary = "",
                CreatedDate = DateTime.Now
            });

            SaveData();
            RefreshGrid();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridCases.CurrentRow == null)
                return;

            int id = (int)dataGridCases.CurrentRow.Cells["Id"].Value;
            var selectedCase = cases.FirstOrDefault(c => c.Id == id);

            if (selectedCase == null)
                return;

            using (var editForm = new CaseEditForm(selectedCase))
            {
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    SaveData();
                    RefreshGrid();
                }
            }
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            var weeklyGroups = cases
                .Where(c => c.TakenOwnership)
                .GroupBy(c => c.WeekGroup)
                .OrderBy(g => g.Key);

            var summaryLines = new List<string>();
            foreach (var group in weeklyGroups)
            {
                int total = group.Count();
                int closed = group.Count(c => c.IsClosed);
                double ratio = total == 0 ? 0 : (double)closed / total;
                summaryLines.Add($"{group.Key}: Closure Rate = {ratio:P2} ({closed}/{total})");
            }

            if (summaryLines.Count == 0)
                MessageBox.Show("No cases with ownership found.", "Weekly Closure Rate");
            else
                MessageBox.Show(string.Join(Environment.NewLine, summaryLines), "Weekly Closure Rate");
        }

        private void btnWeeklySummary_Click(object sender, EventArgs e)
        {
            var grouped = cases
                .Where(c => c.TakenOwnership && c.IsClosed)
                .GroupBy(c => c.WeekGroup)
                .Select(g => new { Week = g.Key, Closed = g.Count() })
                .OrderBy(g => g.Week);

            string summary = string.Join(Environment.NewLine, grouped.Select(g => $"{g.Week}: {g.Closed} closed"));
            txtWeeklySummary.Text = summary;
        }

        private (DateTime Start, DateTime End) GetStartAndEndDateOfWeek(string weekGroup)
        {
            var parts = weekGroup.Split(new[] { "-W" }, StringSplitOptions.None);
            int year = int.Parse(parts[0]);
            int week = int.Parse(parts[1]);

            DateTime jan4 = new DateTime(year, 1, 4);
            int daysOffset = DayOfWeek.Monday - jan4.DayOfWeek;
            DateTime firstMonday = jan4.AddDays(daysOffset);
            DateTime startOfWeek = firstMonday.AddDays((week - 1) * 7);
            DateTime endOfWeek = startOfWeek.AddDays(6);

            return (startOfWeek, endOfWeek);
        }

        private void btnClearData_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to clear all data? This cannot be undone.",
                "Confirm Clear Data", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                cases.Clear();

                try
                {
                    if (File.Exists(dataFile))
                        File.Delete(dataFile);

                    RefreshGrid();
                    MessageBox.Show("Data cleared successfully.", "Success");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error clearing data: " + ex.Message, "Error");
                }
            }
        }


        private void btnExportCsv_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "CSV files (*.csv)|*.csv",
                FileName = "cases_export.csv"
            };

            if (sfd.ShowDialog() != DialogResult.OK)
                return;

            try
            {
                using (StreamWriter sw = new StreamWriter(sfd.FileName))
                {
                    // Weekly Closure Summary
                    sw.WriteLine("Weekly Closure Summary:");
                    sw.WriteLine("Week,StartDate,EndDate,Owned,Closed,ClosureRate");

                    var weeklyGroups = cases
                        .GroupBy(c => c.WeekGroup)
                        .OrderBy(g => g.Key);

                    foreach (var group in weeklyGroups)
                    {
                        var (start, end) = GetStartAndEndDateOfWeek(group.Key);
                        int owned = group.Count(c => c.TakenOwnership);
                        int closed = group.Count(c => c.TakenOwnership && c.IsClosed);
                        double rate = owned == 0 ? 0 : (double)closed / owned;

                        sw.WriteLine($"{group.Key},{start:yyyy-MM-dd},{end:yyyy-MM-dd},{owned},{closed},{rate:P2}");
                    }

                    sw.WriteLine(); // Empty line between summary and detail

                    // Case Details
                    sw.WriteLine("Id,TakenOwnership,IsClosed,IsHandedOver,ClosureSummary,HandoverSummary,CreatedDate,WeekGroup");

                    foreach (var c in cases)
                    {
                        sw.WriteLine($"{c.Id},{c.TakenOwnership},{c.IsClosed},{c.IsHandedOver}," +
                                     $"\"{c.ClosureSummary}\",\"{c.HandoverSummary}\",{c.CreatedDate:yyyy-MM-dd},{c.WeekGroup}");
                    }
                }

                MessageBox.Show("Export successful!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Export failed: " + ex.Message);
            }
        }

        private void RefreshGrid()
        {
            dataGridCases.Refresh();
        }

        private void SaveData()
        {
            try
            {
                string json = JsonSerializer.Serialize(cases.ToList());
                File.WriteAllText(dataFile, json);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to save data: " + ex.Message);
            }
        }

        private void LoadData()
        {
            try
            {
                if (File.Exists(dataFile))
                {
                    string json = File.ReadAllText(dataFile);
                    var loadedCases = JsonSerializer.Deserialize<List<Case>>(json) ?? new List<Case>();
                    cases = new BindingList<Case>(loadedCases);
                    dataGridCases.DataSource = cases;
                }
                else
                {
                    cases = new BindingList<Case>();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load data: " + ex.Message);
                cases = new BindingList<Case>();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Optional - any startup logic
        }
    }

    // InputHelper from previous messages to prompt for input
    public static class InputHelper
    {
        public static string ShowDialog(string text, string caption)
        {
            using (Form prompt = new Form())
            {
                prompt.Width = 320;
                prompt.Height = 150;
                prompt.FormBorderStyle = FormBorderStyle.FixedDialog;
                prompt.Text = caption;
                prompt.StartPosition = FormStartPosition.CenterParent;

                Label textLabel = new Label() { Left = 10, Top = 10, Text = text, AutoSize = true };
                TextBox inputBox = new TextBox() { Left = 10, Top = 35, Width = 280 };
                Button confirmation = new Button() { Text = "Ok", Left = 210, Width = 80, Top = 70, DialogResult = DialogResult.OK };

                confirmation.Click += (sender, e) => { prompt.Close(); };

                prompt.Controls.Add(textLabel);
                prompt.Controls.Add(inputBox);
                prompt.Controls.Add(confirmation);
                prompt.AcceptButton = confirmation;

                return prompt.ShowDialog() == DialogResult.OK ? inputBox.Text : "";
            }
        }
    }
}
