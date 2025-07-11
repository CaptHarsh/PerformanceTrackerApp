namespace PerformanceTrackerApp
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.DataGridView dataGridCases;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.Button btnWeeklySummary;
        private System.Windows.Forms.Button btnExportCsv;
        private System.Windows.Forms.Button btnClearData;  // <-- Added Clear Data button
        private System.Windows.Forms.Label lblPerformance;
        private System.Windows.Forms.TextBox txtWeeklySummary;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();

            this.dataGridCases = new System.Windows.Forms.DataGridView();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.btnWeeklySummary = new System.Windows.Forms.Button();
            this.btnExportCsv = new System.Windows.Forms.Button();
            this.btnClearData = new System.Windows.Forms.Button();  // <-- instantiate button here
            this.lblPerformance = new System.Windows.Forms.Label();
            this.txtWeeklySummary = new System.Windows.Forms.TextBox();

            ((System.ComponentModel.ISupportInitialize)(this.dataGridCases)).BeginInit();
            this.SuspendLayout();

            // 
            // dataGridCases
            // 
            this.dataGridCases.Location = new System.Drawing.Point(12, 12);
            this.dataGridCases.Size = new System.Drawing.Size(600, 300);
            this.dataGridCases.Name = "dataGridCases";
            this.dataGridCases.TabIndex = 0;

            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(12, 320);
            this.btnAdd.Size = new System.Drawing.Size(80, 30);
            this.btnAdd.Text = "Add Case";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.TabIndex = 1;

            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(110, 320);
            this.btnEdit.Size = new System.Drawing.Size(80, 30);
            this.btnEdit.Text = "Edit Case";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.TabIndex = 2;

            // 
            // btnCalculate
            // 
            this.btnCalculate.Location = new System.Drawing.Point(210, 320);
            this.btnCalculate.Size = new System.Drawing.Size(120, 30);
            this.btnCalculate.Text = "Calculate Closure %";
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.TabIndex = 3;

            // 
            // btnWeeklySummary
            // 
            this.btnWeeklySummary.Location = new System.Drawing.Point(350, 320);
            this.btnWeeklySummary.Size = new System.Drawing.Size(120, 30);
            this.btnWeeklySummary.Text = "Weekly Summary";
            this.btnWeeklySummary.UseVisualStyleBackColor = true;
            this.btnWeeklySummary.TabIndex = 4;

            // 
            // btnExportCsv
            // 
            this.btnExportCsv.Location = new System.Drawing.Point(490, 320);
            this.btnExportCsv.Size = new System.Drawing.Size(120, 30);
            this.btnExportCsv.Text = "Export to CSV";
            this.btnExportCsv.UseVisualStyleBackColor = true;
            this.btnExportCsv.TabIndex = 5;

            // 
            // btnClearData
            // 
            this.btnClearData.Location = new System.Drawing.Point(490, 360);  // Below Export CSV button
            this.btnClearData.Size = new System.Drawing.Size(120, 30);
            this.btnClearData.Text = "Clear Data";
            this.btnClearData.UseVisualStyleBackColor = true;
            this.btnClearData.TabIndex = 6;
            this.btnClearData.Click += new System.EventHandler(this.btnClearData_Click);

            // 
            // lblPerformance
            // 
            this.lblPerformance.Location = new System.Drawing.Point(12, 360);
            this.lblPerformance.Size = new System.Drawing.Size(460, 23);
            this.lblPerformance.Name = "lblPerformance";
            this.lblPerformance.TabIndex = 7;
            this.lblPerformance.Text = "";

            // 
            // txtWeeklySummary
            // 
            this.txtWeeklySummary.Location = new System.Drawing.Point(12, 400);
            this.txtWeeklySummary.Size = new System.Drawing.Size(600, 120);
            this.txtWeeklySummary.Multiline = true;
            this.txtWeeklySummary.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtWeeklySummary.Name = "txtWeeklySummary";
            this.txtWeeklySummary.TabIndex = 8;

            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(630, 530);
            this.Controls.Add(this.dataGridCases);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnCalculate);
            this.Controls.Add(this.btnWeeklySummary);
            this.Controls.Add(this.btnExportCsv);
            this.Controls.Add(this.btnClearData);  // <-- add Clear Data button to controls
            this.Controls.Add(this.lblPerformance);
            this.Controls.Add(this.txtWeeklySummary);
            this.Name = "Form1";
            this.Text = "Performance Tracker";

            ((System.ComponentModel.ISupportInitialize)(this.dataGridCases)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
