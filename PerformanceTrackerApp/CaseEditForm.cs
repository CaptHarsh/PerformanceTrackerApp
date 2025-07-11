using System;
using System.Windows.Forms;

namespace PerformanceTrackerApp
{
    public partial class CaseEditForm : Form
    {
        private Case caseToEdit;

        public CaseEditForm(Case c)
        {
            InitializeComponent();
            caseToEdit = c ?? throw new ArgumentNullException(nameof(c));
            LoadCaseData();
        }

        private void LoadCaseData()
        {
            txtId.Text = caseToEdit.Id.ToString();
            chkOwnership.Checked = caseToEdit.TakenOwnership;
            chkClosed.Checked = caseToEdit.IsClosed;
            dtpCreatedDate.Value = caseToEdit.CreatedDate;
            txtTeam.Text = caseToEdit.Team ?? "";

            txtSummary.Text = caseToEdit.Summary ?? "";
            txtWentRight.Text = caseToEdit.WhatWentRight ?? "";
            txtWentWrong.Text = caseToEdit.WhatWentWrong ?? "";
            txtHelpNeeded.Text = caseToEdit.WhereHelpNeeded ?? "";
            txtNotNeeded.Text = caseToEdit.WhereNotNeeded ?? "";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            caseToEdit.TakenOwnership = chkOwnership.Checked;
            caseToEdit.IsClosed = chkClosed.Checked;
            caseToEdit.Team = txtTeam.Text.Trim();
            caseToEdit.Summary = txtSummary.Text.Trim();
            caseToEdit.WhatWentRight = txtWentRight.Text.Trim();
            caseToEdit.WhatWentWrong = txtWentWrong.Text.Trim();
            caseToEdit.WhereHelpNeeded = txtHelpNeeded.Text.Trim();
            caseToEdit.WhereNotNeeded = txtNotNeeded.Text.Trim();

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
