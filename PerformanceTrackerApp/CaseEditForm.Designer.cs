using System;
using System.Windows.Forms;

namespace PerformanceTrackerApp
{
    partial class CaseEditForm
    {
        private System.ComponentModel.IContainer components = null;

        private TextBox txtId;
        private CheckBox chkOwnership;
        private CheckBox chkClosed;
        private DateTimePicker dtpCreatedDate;
        private TextBox txtTeam;
        private TextBox txtSummary;
        private TextBox txtWentRight;
        private TextBox txtWentWrong;
        private TextBox txtHelpNeeded;
        private TextBox txtNotNeeded;

        private Label lblId;
        private Label lblOwnership;
        private Label lblClosed;
        private Label lblCreatedDate;
        private Label lblTeam;
        private Label lblSummary;
        private Label lblWentRight;
        private Label lblWentWrong;
        private Label lblHelpNeeded;
        private Label lblNotNeeded;

        private Button btnSave;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblId = new Label();
            this.txtId = new TextBox();
            this.lblOwnership = new Label();
            this.chkOwnership = new CheckBox();
            this.lblClosed = new Label();
            this.chkClosed = new CheckBox();
            this.lblCreatedDate = new Label();
            this.dtpCreatedDate = new DateTimePicker();
            this.lblTeam = new Label();
            this.txtTeam = new TextBox();
            this.lblSummary = new Label();
            this.txtSummary = new TextBox();
            this.lblWentRight = new Label();
            this.txtWentRight = new TextBox();
            this.lblWentWrong = new Label();
            this.txtWentWrong = new TextBox();
            this.lblHelpNeeded = new Label();
            this.txtHelpNeeded = new TextBox();
            this.lblNotNeeded = new Label();
            this.txtNotNeeded = new TextBox();
            this.btnSave = new Button();

            // lblId
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(10, 10);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(53, 13);
            this.lblId.TabIndex = 0;
            this.lblId.Text = "Case ID:";

            // txtId
            this.txtId.Location = new System.Drawing.Point(120, 7);
            this.txtId.Name = "txtId";
            this.txtId.ReadOnly = true; // case ID should not be editable
            this.txtId.Size = new System.Drawing.Size(200, 20);
            this.txtId.TabIndex = 1;

            // lblOwnership
            this.lblOwnership.AutoSize = true;
            this.lblOwnership.Location = new System.Drawing.Point(10, 40);
            this.lblOwnership.Name = "lblOwnership";
            this.lblOwnership.Size = new System.Drawing.Size(94, 13);
            this.lblOwnership.TabIndex = 2;
            this.lblOwnership.Text = "Taken Ownership:";

            // chkOwnership
            this.chkOwnership.AutoSize = true;
            this.chkOwnership.Location = new System.Drawing.Point(120, 39);
            this.chkOwnership.Name = "chkOwnership";
            this.chkOwnership.Size = new System.Drawing.Size(15, 14);
            this.chkOwnership.TabIndex = 3;
            this.chkOwnership.UseVisualStyleBackColor = true;

            // lblClosed
            this.lblClosed.AutoSize = true;
            this.lblClosed.Location = new System.Drawing.Point(10, 70);
            this.lblClosed.Name = "lblClosed";
            this.lblClosed.Size = new System.Drawing.Size(53, 13);
            this.lblClosed.TabIndex = 4;
            this.lblClosed.Text = "Is Closed:";

            // chkClosed
            this.chkClosed.AutoSize = true;
            this.chkClosed.Location = new System.Drawing.Point(120, 69);
            this.chkClosed.Name = "chkClosed";
            this.chkClosed.Size = new System.Drawing.Size(15, 14);
            this.chkClosed.TabIndex = 5;
            this.chkClosed.UseVisualStyleBackColor = true;

            // lblCreatedDate
            this.lblCreatedDate.AutoSize = true;
            this.lblCreatedDate.Location = new System.Drawing.Point(10, 100);
            this.lblCreatedDate.Name = "lblCreatedDate";
            this.lblCreatedDate.Size = new System.Drawing.Size(74, 13);
            this.lblCreatedDate.TabIndex = 6;
            this.lblCreatedDate.Text = "Created Date:";

            // dtpCreatedDate
            this.dtpCreatedDate.Enabled = false; // readonly
            this.dtpCreatedDate.Location = new System.Drawing.Point(120, 97);
            this.dtpCreatedDate.Name = "dtpCreatedDate";
            this.dtpCreatedDate.Size = new System.Drawing.Size(200, 20);
            this.dtpCreatedDate.TabIndex = 7;

            // lblTeam
            this.lblTeam.AutoSize = true;
            this.lblTeam.Location = new System.Drawing.Point(10, 130);
            this.lblTeam.Name = "lblTeam";
            this.lblTeam.Size = new System.Drawing.Size(37, 13);
            this.lblTeam.TabIndex = 8;
            this.lblTeam.Text = "Team:";

            // txtTeam
            this.txtTeam.Location = new System.Drawing.Point(120, 127);
            this.txtTeam.Name = "txtTeam";
            this.txtTeam.Size = new System.Drawing.Size(200, 20);
            this.txtTeam.TabIndex = 9;

            // lblSummary
            this.lblSummary.AutoSize = true;
            this.lblSummary.Location = new System.Drawing.Point(10, 160);
            this.lblSummary.Name = "lblSummary";
            this.lblSummary.Size = new System.Drawing.Size(53, 13);
            this.lblSummary.TabIndex = 10;
            this.lblSummary.Text = "Summary:";

            // txtSummary
            this.txtSummary.Location = new System.Drawing.Point(120, 160);
            this.txtSummary.Multiline = true;
            this.txtSummary.Name = "txtSummary";
            this.txtSummary.ScrollBars = ScrollBars.Vertical;
            this.txtSummary.Size = new System.Drawing.Size(300, 60);
            this.txtSummary.TabIndex = 11;

            // lblWentRight
            this.lblWentRight.AutoSize = true;
            this.lblWentRight.Location = new System.Drawing.Point(10, 230);
            this.lblWentRight.Name = "lblWentRight";
            this.lblWentRight.Size = new System.Drawing.Size(82, 13);
            this.lblWentRight.TabIndex = 12;
            this.lblWentRight.Text = "What Went Right:";

            // txtWentRight
            this.txtWentRight.Location = new System.Drawing.Point(120, 230);
            this.txtWentRight.Multiline = true;
            this.txtWentRight.Name = "txtWentRight";
            this.txtWentRight.ScrollBars = ScrollBars.Vertical;
            this.txtWentRight.Size = new System.Drawing.Size(300, 60);
            this.txtWentRight.TabIndex = 13;

            // lblWentWrong
            this.lblWentWrong.AutoSize = true;
            this.lblWentWrong.Location = new System.Drawing.Point(10, 300);
            this.lblWentWrong.Name = "lblWentWrong";
            this.lblWentWrong.Size = new System.Drawing.Size(88, 13);
            this.lblWentWrong.TabIndex = 14;
            this.lblWentWrong.Text = "What Went Wrong:";

            // txtWentWrong
            this.txtWentWrong.Location = new System.Drawing.Point(120, 300);
            this.txtWentWrong.Multiline = true;
            this.txtWentWrong.Name = "txtWentWrong";
            this.txtWentWrong.ScrollBars = ScrollBars.Vertical;
            this.txtWentWrong.Size = new System.Drawing.Size(300, 60);
            this.txtWentWrong.TabIndex = 15;

            // lblHelpNeeded
            this.lblHelpNeeded.AutoSize = true;
            this.lblHelpNeeded.Location = new System.Drawing.Point(10, 370);
            this.lblHelpNeeded.Name = "lblHelpNeeded";
            this.lblHelpNeeded.Size = new System.Drawing.Size(90, 13);
            this.lblHelpNeeded.TabIndex = 16;
            this.lblHelpNeeded.Text = "Where Help Needed:";

            // txtHelpNeeded
            this.txtHelpNeeded.Location = new System.Drawing.Point(120, 370);
            this.txtHelpNeeded.Multiline = true;
            this.txtHelpNeeded.Name = "txtHelpNeeded";
            this.txtHelpNeeded.ScrollBars = ScrollBars.Vertical;
            this.txtHelpNeeded.Size = new System.Drawing.Size(300, 60);
            this.txtHelpNeeded.TabIndex = 17;

            // lblNotNeeded
            this.lblNotNeeded.AutoSize = true;
            this.lblNotNeeded.Location = new System.Drawing.Point(10, 440);
            this.lblNotNeeded.Name = "lblNotNeeded";
            this.lblNotNeeded.Size = new System.Drawing.Size(82, 13);
            this.lblNotNeeded.TabIndex = 18;
            this.lblNotNeeded.Text = "Where Not Needed:";

            // txtNotNeeded
            this.txtNotNeeded.Location = new System.Drawing.Point(120, 440);
            this.txtNotNeeded.Multiline = true;
            this.txtNotNeeded.Name = "txtNotNeeded";
            this.txtNotNeeded.ScrollBars = ScrollBars.Vertical;
            this.txtNotNeeded.Size = new System.Drawing.Size(300, 60);
            this.txtNotNeeded.TabIndex = 19;

            // btnSave
            this.btnSave.Location = new System.Drawing.Point(350, 510);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(70, 25);
            this.btnSave.TabIndex = 20;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            // CaseEditForm
            this.ClientSize = new System.Drawing.Size(450, 550);
            this.Controls.Add(this.lblId);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.lblOwnership);
            this.Controls.Add(this.chkOwnership);
            this.Controls.Add(this.lblClosed);
            this.Controls.Add(this.chkClosed);
            this.Controls.Add(this.lblCreatedDate);
            this.Controls.Add(this.dtpCreatedDate);
            this.Controls.Add(this.lblTeam);
            this.Controls.Add(this.txtTeam);
            this.Controls.Add(this.lblSummary);
            this.Controls.Add(this.txtSummary);
            this.Controls.Add(this.lblWentRight);
            this.Controls.Add(this.txtWentRight);
            this.Controls.Add(this.lblWentWrong);
            this.Controls.Add(this.txtWentWrong);
            this.Controls.Add(this.lblHelpNeeded);
            this.Controls.Add(this.txtHelpNeeded);
            this.Controls.Add(this.lblNotNeeded);
            this.Controls.Add(this.txtNotNeeded);
            this.Controls.Add(this.btnSave);

            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Edit Case";
        }
    }
}
