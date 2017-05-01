namespace RedmineClient
{
    partial class IssuesForCertainUserForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IssuesForCertainUserForm));
            this.lvIssues = new System.Windows.Forms.ListView();
            this.columnHeaderID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderSubject = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderProject = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderTracker = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderPriority = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.labelEnterUserNameToSearch = new System.Windows.Forms.Label();
            this.labelFoundIssuesCount = new System.Windows.Forms.Label();
            this.cbUsers = new System.Windows.Forms.ComboBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lvIssues
            // 
            this.lvIssues.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderID,
            this.columnHeaderSubject,
            this.columnHeaderProject,
            this.columnHeaderTracker,
            this.columnHeaderStatus,
            this.columnHeaderPriority});
            this.lvIssues.Enabled = false;
            this.lvIssues.FullRowSelect = true;
            this.lvIssues.GridLines = true;
            this.lvIssues.Location = new System.Drawing.Point(12, 57);
            this.lvIssues.Name = "lvIssues";
            this.lvIssues.Size = new System.Drawing.Size(479, 206);
            this.lvIssues.TabIndex = 3;
            this.lvIssues.UseCompatibleStateImageBehavior = false;
            this.lvIssues.View = System.Windows.Forms.View.Details;
            this.lvIssues.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvIssues_MouseDoubleClick);
            // 
            // columnHeaderID
            // 
            this.columnHeaderID.Text = "ID";
            this.columnHeaderID.Width = 30;
            // 
            // columnHeaderSubject
            // 
            this.columnHeaderSubject.Text = "Subject";
            this.columnHeaderSubject.Width = 105;
            // 
            // columnHeaderProject
            // 
            this.columnHeaderProject.Text = "Project";
            this.columnHeaderProject.Width = 120;
            // 
            // columnHeaderTracker
            // 
            this.columnHeaderTracker.Text = "Tracker";
            this.columnHeaderTracker.Width = 70;
            // 
            // columnHeaderStatus
            // 
            this.columnHeaderStatus.Text = "Status";
            this.columnHeaderStatus.Width = 70;
            // 
            // columnHeaderPriority
            // 
            this.columnHeaderPriority.Text = "Priority";
            this.columnHeaderPriority.Width = 70;
            // 
            // labelEnterUserNameToSearch
            // 
            this.labelEnterUserNameToSearch.AutoSize = true;
            this.labelEnterUserNameToSearch.Location = new System.Drawing.Point(12, 14);
            this.labelEnterUserNameToSearch.Name = "labelEnterUserNameToSearch";
            this.labelEnterUserNameToSearch.Size = new System.Drawing.Size(135, 13);
            this.labelEnterUserNameToSearch.TabIndex = 0;
            this.labelEnterUserNameToSearch.Text = "Select user to show issues:";
            // 
            // labelFoundIssuesCount
            // 
            this.labelFoundIssuesCount.Location = new System.Drawing.Point(219, 30);
            this.labelFoundIssuesCount.Name = "labelFoundIssuesCount";
            this.labelFoundIssuesCount.Size = new System.Drawing.Size(272, 21);
            this.labelFoundIssuesCount.TabIndex = 2;
            this.labelFoundIssuesCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbUsers
            // 
            this.cbUsers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbUsers.Enabled = false;
            this.cbUsers.FormattingEnabled = true;
            this.cbUsers.Location = new System.Drawing.Point(12, 30);
            this.cbUsers.Name = "cbUsers";
            this.cbUsers.Size = new System.Drawing.Size(198, 21);
            this.cbUsers.TabIndex = 1;
            this.cbUsers.SelectedIndexChanged += new System.EventHandler(this.cbUsers_SelectedIndexChanged);
            // 
            // btnClose
            // 
            this.btnClose.Enabled = false;
            this.btnClose.Location = new System.Drawing.Point(416, 269);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // IssuesForCertainUserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(503, 299);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.cbUsers);
            this.Controls.Add(this.labelFoundIssuesCount);
            this.Controls.Add(this.labelEnterUserNameToSearch);
            this.Controls.Add(this.lvIssues);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "IssuesForCertainUserForm";
            this.ShowInTaskbar = false;
            this.Text = "Issues for user [please, wait..]";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.IssuesForCertainUserForm_FormClosing);
            this.Shown += new System.EventHandler(this.IssuesForCertainUserForm_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvIssues;
        private System.Windows.Forms.Label labelEnterUserNameToSearch;
        private System.Windows.Forms.Label labelFoundIssuesCount;
        private System.Windows.Forms.ColumnHeader columnHeaderID;
        private System.Windows.Forms.ColumnHeader columnHeaderSubject;
        private System.Windows.Forms.ColumnHeader columnHeaderTracker;
        private System.Windows.Forms.ColumnHeader columnHeaderStatus;
        private System.Windows.Forms.ColumnHeader columnHeaderPriority;
        private System.Windows.Forms.ColumnHeader columnHeaderProject;
        private System.Windows.Forms.ComboBox cbUsers;
        private System.Windows.Forms.Button btnClose;
    }
}