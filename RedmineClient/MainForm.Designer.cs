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
            this.findIssuesForUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reAuthenticateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userInformationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.labelSelectProject = new System.Windows.Forms.Label();
            this.cbProjects = new System.Windows.Forms.ComboBox();
            this.lvIssues = new System.Windows.Forms.ListView();
            this.columnHeaderID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderSubject = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderTracker = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderPriority = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderAssignee = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderLastUpdate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnProjectInfo = new System.Windows.Forms.Button();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.labelProjectRoles = new System.Windows.Forms.Label();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuNotifyIcon = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.accountNIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logOutNIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NIToolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.refreshNIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitNIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cbFilterSettings = new System.Windows.Forms.CheckBox();
            this.menuStrip.SuspendLayout();
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
            this.menuStrip.Size = new System.Drawing.Size(644, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "Menu";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newIssueToolStripMenuItem,
            this.findIssuesForUserToolStripMenuItem,
            this.refreshToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newIssueToolStripMenuItem
            // 
            this.newIssueToolStripMenuItem.Enabled = false;
            this.newIssueToolStripMenuItem.Name = "newIssueToolStripMenuItem";
            this.newIssueToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.newIssueToolStripMenuItem.Text = "New issue";
            this.newIssueToolStripMenuItem.Click += new System.EventHandler(this.newIssueToolStripMenuItem_Click);
            // 
            // findIssuesForUserToolStripMenuItem
            // 
            this.findIssuesForUserToolStripMenuItem.Enabled = false;
            this.findIssuesForUserToolStripMenuItem.Name = "findIssuesForUserToolStripMenuItem";
            this.findIssuesForUserToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.findIssuesForUserToolStripMenuItem.Text = "Find issues for user";
            this.findIssuesForUserToolStripMenuItem.Click += new System.EventHandler(this.findIssuesForUserToolStripMenuItem_Click);
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Enabled = false;
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.refreshToolStripMenuItem.Text = "Refresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reAuthenticateToolStripMenuItem,
            this.userInformationToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // reAuthenticateToolStripMenuItem
            // 
            this.reAuthenticateToolStripMenuItem.Name = "reAuthenticateToolStripMenuItem";
            this.reAuthenticateToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.reAuthenticateToolStripMenuItem.Text = "Re-authenticate";
            this.reAuthenticateToolStripMenuItem.Click += new System.EventHandler(this.changeAPITokenToolStripMenuItem_Click);
            // 
            // userInformationToolStripMenuItem
            // 
            this.userInformationToolStripMenuItem.Enabled = false;
            this.userInformationToolStripMenuItem.Name = "userInformationToolStripMenuItem";
            this.userInformationToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.userInformationToolStripMenuItem.Text = "User information";
            this.userInformationToolStripMenuItem.Click += new System.EventHandler(this.userInformationToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.optionsToolStripMenuItem.Text = "Options";
            this.optionsToolStripMenuItem.Click += new System.EventHandler(this.optionsToolStripMenuItem_Click);
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
            this.cbProjects.Size = new System.Drawing.Size(231, 21);
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
            this.columnHeaderPriority,
            this.columnHeaderAssignee,
            this.columnHeaderLastUpdate});
            this.lvIssues.FullRowSelect = true;
            this.lvIssues.GridLines = true;
            this.lvIssues.Location = new System.Drawing.Point(12, 73);
            this.lvIssues.MultiSelect = false;
            this.lvIssues.Name = "lvIssues";
            this.lvIssues.Size = new System.Drawing.Size(620, 255);
            this.lvIssues.TabIndex = 6;
            this.lvIssues.UseCompatibleStateImageBehavior = false;
            this.lvIssues.View = System.Windows.Forms.View.Details;
            this.lvIssues.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvIssues_ColumnClick);
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
            this.columnHeaderSubject.Width = 150;
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
            // columnHeaderAssignee
            // 
            this.columnHeaderAssignee.Text = "Assignee";
            this.columnHeaderAssignee.Width = 100;
            // 
            // columnHeaderLastUpdate
            // 
            this.columnHeaderLastUpdate.Text = "Last update";
            this.columnHeaderLastUpdate.Width = 110;
            // 
            // btnProjectInfo
            // 
            this.btnProjectInfo.Location = new System.Drawing.Point(250, 45);
            this.btnProjectInfo.Name = "btnProjectInfo";
            this.btnProjectInfo.Size = new System.Drawing.Size(85, 21);
            this.btnProjectInfo.TabIndex = 3;
            this.btnProjectInfo.Text = "Project info";
            this.btnProjectInfo.UseVisualStyleBackColor = true;
            this.btnProjectInfo.Visible = false;
            this.btnProjectInfo.Click += new System.EventHandler(this.btnProjectInfo_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 339);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(644, 22);
            this.statusStrip.TabIndex = 7;
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
            this.labelProjectRoles.Location = new System.Drawing.Point(395, 45);
            this.labelProjectRoles.Name = "labelProjectRoles";
            this.labelProjectRoles.Size = new System.Drawing.Size(237, 21);
            this.labelProjectRoles.TabIndex = 5;
            this.labelProjectRoles.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.contextMenuNotifyIcon;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "Redmine Client";
            this.notifyIcon.Visible = true;
            this.notifyIcon.BalloonTipClicked += new System.EventHandler(this.notifyIcon_BalloonTipClicked);
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
            // 
            // contextMenuNotifyIcon
            // 
            this.contextMenuNotifyIcon.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.accountNIToolStripMenuItem,
            this.logOutNIToolStripMenuItem,
            this.NIToolStripSeparator,
            this.refreshNIToolStripMenuItem,
            this.exitNIToolStripMenuItem});
            this.contextMenuNotifyIcon.Name = "contextMenuNotifyIcon";
            this.contextMenuNotifyIcon.Size = new System.Drawing.Size(116, 98);
            // 
            // accountNIToolStripMenuItem
            // 
            this.accountNIToolStripMenuItem.Enabled = false;
            this.accountNIToolStripMenuItem.Name = "accountNIToolStripMenuItem";
            this.accountNIToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.accountNIToolStripMenuItem.Visible = false;
            // 
            // logOutNIToolStripMenuItem
            // 
            this.logOutNIToolStripMenuItem.Name = "logOutNIToolStripMenuItem";
            this.logOutNIToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.logOutNIToolStripMenuItem.Text = "Log out";
            this.logOutNIToolStripMenuItem.Visible = false;
            this.logOutNIToolStripMenuItem.Click += new System.EventHandler(this.logOutIOToolStripMenuItem_Click);
            // 
            // NIToolStripSeparator
            // 
            this.NIToolStripSeparator.Name = "NIToolStripSeparator";
            this.NIToolStripSeparator.Size = new System.Drawing.Size(112, 6);
            this.NIToolStripSeparator.Visible = false;
            // 
            // refreshNIToolStripMenuItem
            // 
            this.refreshNIToolStripMenuItem.Enabled = false;
            this.refreshNIToolStripMenuItem.Name = "refreshNIToolStripMenuItem";
            this.refreshNIToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.refreshNIToolStripMenuItem.Text = "Refresh";
            this.refreshNIToolStripMenuItem.Click += new System.EventHandler(this.refreshStripMenuItem_Click);
            // 
            // exitNIToolStripMenuItem
            // 
            this.exitNIToolStripMenuItem.Name = "exitNIToolStripMenuItem";
            this.exitNIToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.exitNIToolStripMenuItem.Text = "Exit";
            this.exitNIToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // cbFilterSettings
            // 
            this.cbFilterSettings.AutoSize = true;
            this.cbFilterSettings.Location = new System.Drawing.Point(341, 48);
            this.cbFilterSettings.Name = "cbFilterSettings";
            this.cbFilterSettings.Size = new System.Drawing.Size(48, 17);
            this.cbFilterSettings.TabIndex = 4;
            this.cbFilterSettings.Text = "Filter";
            this.cbFilterSettings.UseVisualStyleBackColor = true;
            this.cbFilterSettings.Visible = false;
            this.cbFilterSettings.Click += new System.EventHandler(this.cbFilterSettings_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 361);
            this.Controls.Add(this.cbFilterSettings);
            this.Controls.Add(this.labelProjectRoles);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.btnProjectInfo);
            this.Controls.Add(this.lvIssues);
            this.Controls.Add(this.cbProjects);
            this.Controls.Add(this.labelSelectProject);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.MinimumSize = new System.Drawing.Size(660, 400);
            this.Name = "MainForm";
            this.Text = "Redmine Client";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
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
        private System.Windows.Forms.ToolStripMenuItem reAuthenticateToolStripMenuItem;
        private System.Windows.Forms.Label labelSelectProject;
        private System.Windows.Forms.ComboBox cbProjects;
        private System.Windows.Forms.ListView lvIssues;
        private System.Windows.Forms.ColumnHeader columnHeaderID;
        private System.Windows.Forms.ColumnHeader columnHeaderSubject;
        private System.Windows.Forms.ColumnHeader columnHeaderStatus;
        private System.Windows.Forms.ColumnHeader columnHeaderLastUpdate;
        private System.Windows.Forms.Button btnProjectInfo;
        private System.Windows.Forms.ToolStripMenuItem newIssueToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.ColumnHeader columnHeaderTracker;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.Label labelProjectRoles;
        private System.Windows.Forms.ToolStripMenuItem userInformationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip contextMenuNotifyIcon;
        private System.Windows.Forms.ToolStripMenuItem exitNIToolStripMenuItem;
        private System.Windows.Forms.ColumnHeader columnHeaderPriority;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ColumnHeader columnHeaderAssignee;
        private System.Windows.Forms.ToolStripMenuItem refreshNIToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator NIToolStripSeparator;
        private System.Windows.Forms.ToolStripMenuItem accountNIToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logOutNIToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem findIssuesForUserToolStripMenuItem;
        private System.Windows.Forms.CheckBox cbFilterSettings;
    }
}

