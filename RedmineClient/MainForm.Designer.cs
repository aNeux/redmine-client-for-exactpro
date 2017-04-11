namespace RedmineClient
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newIssueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeAPIKeyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userInformationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.labelSelectProject = new System.Windows.Forms.Label();
            this.cbProjects = new System.Windows.Forms.ComboBox();
            this.lvIssues = new System.Windows.Forms.ListView();
            this.columnHeaderID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderSubject = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderTracker = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderCreatedOn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnProjectInfo = new System.Windows.Forms.Button();
            this.contextMenuIssue = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.issueInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.labelProjectRoles = new System.Windows.Forms.Label();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuNotifyIcon = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.exitFromNotifyIconToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            this.contextMenuIssue.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.contextMenuNotifyIcon.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolsToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(496, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "Menu";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newIssueToolStripMenuItem,
            this.refreshStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newIssueToolStripMenuItem
            // 
            this.newIssueToolStripMenuItem.Enabled = false;
            this.newIssueToolStripMenuItem.Name = "newIssueToolStripMenuItem";
            this.newIssueToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.newIssueToolStripMenuItem.Text = "New issue";
            this.newIssueToolStripMenuItem.Click += new System.EventHandler(this.newIssueToolStripMenuItem_Click);
            // 
            // refreshStripMenuItem
            // 
            this.refreshStripMenuItem.Name = "refreshStripMenuItem";
            this.refreshStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.refreshStripMenuItem.Text = "Refresh";
            this.refreshStripMenuItem.Click += new System.EventHandler(this.refreshStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changeAPIKeyToolStripMenuItem,
            this.userInformationToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // changeAPIKeyToolStripMenuItem
            // 
            this.changeAPIKeyToolStripMenuItem.Name = "changeAPIKeyToolStripMenuItem";
            this.changeAPIKeyToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.changeAPIKeyToolStripMenuItem.Text = "Change API key";
            this.changeAPIKeyToolStripMenuItem.Click += new System.EventHandler(this.changeAPITokenToolStripMenuItem_Click);
            // 
            // userInformationToolStripMenuItem
            // 
            this.userInformationToolStripMenuItem.Enabled = false;
            this.userInformationToolStripMenuItem.Name = "userInformationToolStripMenuItem";
            this.userInformationToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.userInformationToolStripMenuItem.Text = "User information";
            this.userInformationToolStripMenuItem.Click += new System.EventHandler(this.userInformationToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // labelSelectProject
            // 
            this.labelSelectProject.AutoSize = true;
            this.labelSelectProject.Location = new System.Drawing.Point(13, 28);
            this.labelSelectProject.Name = "labelSelectProject";
            this.labelSelectProject.Size = new System.Drawing.Size(84, 13);
            this.labelSelectProject.TabIndex = 1;
            this.labelSelectProject.Text = "Select a project:";
            // 
            // cbProjects
            // 
            this.cbProjects.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbProjects.FormattingEnabled = true;
            this.cbProjects.Items.AddRange(new object[] {
            "< non selected >"});
            this.cbProjects.Location = new System.Drawing.Point(13, 45);
            this.cbProjects.Name = "cbProjects";
            this.cbProjects.Size = new System.Drawing.Size(225, 21);
            this.cbProjects.TabIndex = 2;
            this.cbProjects.SelectedIndexChanged += new System.EventHandler(this.cbSelectProject_SelectedIndexChanged);
            // 
            // lvIssues
            // 
            this.lvIssues.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvIssues.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderID,
            this.columnHeaderSubject,
            this.columnHeaderTracker,
            this.columnHeaderStatus,
            this.columnHeaderCreatedOn});
            this.lvIssues.FullRowSelect = true;
            this.lvIssues.GridLines = true;
            this.lvIssues.Location = new System.Drawing.Point(13, 75);
            this.lvIssues.MultiSelect = false;
            this.lvIssues.Name = "lvIssues";
            this.lvIssues.Size = new System.Drawing.Size(471, 203);
            this.lvIssues.TabIndex = 5;
            this.lvIssues.UseCompatibleStateImageBehavior = false;
            this.lvIssues.View = System.Windows.Forms.View.Details;
            this.lvIssues.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lvIssues_MouseClick);
            // 
            // columnHeaderID
            // 
            this.columnHeaderID.Text = "ID";
            this.columnHeaderID.Width = 31;
            // 
            // columnHeaderSubject
            // 
            this.columnHeaderSubject.Text = "Subject";
            this.columnHeaderSubject.Width = 108;
            // 
            // columnHeaderTracker
            // 
            this.columnHeaderTracker.Text = "Tracker";
            this.columnHeaderTracker.Width = 72;
            // 
            // columnHeaderStatus
            // 
            this.columnHeaderStatus.Text = "Status";
            this.columnHeaderStatus.Width = 78;
            // 
            // columnHeaderCreatedOn
            // 
            this.columnHeaderCreatedOn.Text = "Created On";
            this.columnHeaderCreatedOn.Width = 140;
            // 
            // btnProjectInfo
            // 
            this.btnProjectInfo.Location = new System.Drawing.Point(244, 44);
            this.btnProjectInfo.Name = "btnProjectInfo";
            this.btnProjectInfo.Size = new System.Drawing.Size(85, 23);
            this.btnProjectInfo.TabIndex = 3;
            this.btnProjectInfo.Text = "Project info";
            this.btnProjectInfo.UseVisualStyleBackColor = true;
            this.btnProjectInfo.Visible = false;
            this.btnProjectInfo.Click += new System.EventHandler(this.btnProjectInfo_Click);
            // 
            // contextMenuIssue
            // 
            this.contextMenuIssue.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.issueInfoToolStripMenuItem});
            this.contextMenuIssue.Name = "contextMenuStripIssue";
            this.contextMenuIssue.Size = new System.Drawing.Size(125, 26);
            // 
            // issueInfoToolStripMenuItem
            // 
            this.issueInfoToolStripMenuItem.Name = "issueInfoToolStripMenuItem";
            this.issueInfoToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.issueInfoToolStripMenuItem.Text = "Issue info";
            this.issueInfoToolStripMenuItem.Click += new System.EventHandler(this.issueInfotoolStripMenuItem_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 287);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(496, 22);
            this.statusStrip.SizingGrip = false;
            this.statusStrip.TabIndex = 6;
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // labelProjectRoles
            // 
            this.labelProjectRoles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelProjectRoles.Location = new System.Drawing.Point(335, 45);
            this.labelProjectRoles.Name = "labelProjectRoles";
            this.labelProjectRoles.Size = new System.Drawing.Size(149, 21);
            this.labelProjectRoles.TabIndex = 4;
            this.labelProjectRoles.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.contextMenuNotifyIcon;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "Redmine Client";
            this.notifyIcon.Visible = true;
            // 
            // contextMenuNotifyIcon
            // 
            this.contextMenuNotifyIcon.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitFromNotifyIconToolStripMenuItem});
            this.contextMenuNotifyIcon.Name = "contextMenuNotifyIcon";
            this.contextMenuNotifyIcon.Size = new System.Drawing.Size(93, 26);
            // 
            // exitFromNotifyIconToolStripMenuItem
            // 
            this.exitFromNotifyIconToolStripMenuItem.Name = "exitFromNotifyIconToolStripMenuItem";
            this.exitFromNotifyIconToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitFromNotifyIconToolStripMenuItem.Text = "Exit";
            this.exitFromNotifyIconToolStripMenuItem.Click += new System.EventHandler(this.exitFromNotifyIconToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 309);
            this.Controls.Add(this.labelProjectRoles);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.btnProjectInfo);
            this.Controls.Add(this.lvIssues);
            this.Controls.Add(this.cbProjects);
            this.Controls.Add(this.labelSelectProject);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.MinimumSize = new System.Drawing.Size(512, 348);
            this.Name = "MainForm";
            this.Text = "Redmine Client";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.contextMenuIssue.ResumeLayout(false);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.contextMenuNotifyIcon.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeAPIKeyToolStripMenuItem;
        private System.Windows.Forms.Label labelSelectProject;
        private System.Windows.Forms.ComboBox cbProjects;
        private System.Windows.Forms.ListView lvIssues;
        private System.Windows.Forms.ColumnHeader columnHeaderID;
        private System.Windows.Forms.ColumnHeader columnHeaderSubject;
        private System.Windows.Forms.ColumnHeader columnHeaderStatus;
        private System.Windows.Forms.ColumnHeader columnHeaderCreatedOn;
        private System.Windows.Forms.Button btnProjectInfo;
        private System.Windows.Forms.ToolStripMenuItem newIssueToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem refreshStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuIssue;
        private System.Windows.Forms.ToolStripMenuItem issueInfoToolStripMenuItem;
        private System.Windows.Forms.ColumnHeader columnHeaderTracker;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.Label labelProjectRoles;
        private System.Windows.Forms.ToolStripMenuItem userInformationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip contextMenuNotifyIcon;
        private System.Windows.Forms.ToolStripMenuItem exitFromNotifyIconToolStripMenuItem;
    }
}

