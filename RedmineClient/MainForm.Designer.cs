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
            this.newProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeAPITokenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.labelSelectProject = new System.Windows.Forms.Label();
            this.cbSelectProject = new System.Windows.Forms.ComboBox();
            this.lvIssues = new System.Windows.Forms.ListView();
            this.columnHeaderID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderSubject = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderCreatedOn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnProjectInfo = new System.Windows.Forms.Button();
            this.newIssuetoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStripIssue = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.issueInfotoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.columnHeaderTracker = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.menuStrip.SuspendLayout();
            this.contextMenuStripIssue.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolsToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(482, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "Menu";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newProjectToolStripMenuItem,
            this.newIssuetoolStripMenuItem,
            this.refreshStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newProjectToolStripMenuItem
            // 
            this.newProjectToolStripMenuItem.Name = "newProjectToolStripMenuItem";
            this.newProjectToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.newProjectToolStripMenuItem.Text = "New project";
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
            this.changeAPITokenToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // changeAPITokenToolStripMenuItem
            // 
            this.changeAPITokenToolStripMenuItem.Name = "changeAPITokenToolStripMenuItem";
            this.changeAPITokenToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.changeAPITokenToolStripMenuItem.Text = "Change API token";
            this.changeAPITokenToolStripMenuItem.Click += new System.EventHandler(this.changeAPITokenToolStripMenuItem_Click);
            // 
            // labelSelectProject
            // 
            this.labelSelectProject.AutoSize = true;
            this.labelSelectProject.Location = new System.Drawing.Point(13, 28);
            this.labelSelectProject.Name = "labelSelectProject";
            this.labelSelectProject.Size = new System.Drawing.Size(75, 13);
            this.labelSelectProject.TabIndex = 1;
            this.labelSelectProject.Text = "Select project:";
            // 
            // cbSelectProject
            // 
            this.cbSelectProject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSelectProject.FormattingEnabled = true;
            this.cbSelectProject.Location = new System.Drawing.Point(13, 45);
            this.cbSelectProject.Name = "cbSelectProject";
            this.cbSelectProject.Size = new System.Drawing.Size(188, 21);
            this.cbSelectProject.TabIndex = 2;
            this.cbSelectProject.SelectedIndexChanged += new System.EventHandler(this.cbSelectProject_SelectedIndexChanged);
            // 
            // lvIssues
            // 
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
            this.lvIssues.Size = new System.Drawing.Size(457, 202);
            this.lvIssues.TabIndex = 4;
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
            this.btnProjectInfo.Enabled = false;
            this.btnProjectInfo.Location = new System.Drawing.Point(207, 44);
            this.btnProjectInfo.Name = "btnProjectInfo";
            this.btnProjectInfo.Size = new System.Drawing.Size(85, 23);
            this.btnProjectInfo.TabIndex = 3;
            this.btnProjectInfo.Text = "Project info";
            this.btnProjectInfo.UseVisualStyleBackColor = true;
            this.btnProjectInfo.Click += new System.EventHandler(this.btnProjectInfo_Click);
            // 
            // newIssuetoolStripMenuItem
            // 
            this.newIssuetoolStripMenuItem.Enabled = false;
            this.newIssuetoolStripMenuItem.Name = "newIssuetoolStripMenuItem";
            this.newIssuetoolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.newIssuetoolStripMenuItem.Text = "New issue";
            // 
            // refreshStripMenuItem
            // 
            this.refreshStripMenuItem.Name = "refreshStripMenuItem";
            this.refreshStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.refreshStripMenuItem.Text = "Refresh";
            // 
            // contextMenuStripIssue
            // 
            this.contextMenuStripIssue.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.issueInfotoolStripMenuItem});
            this.contextMenuStripIssue.Name = "contextMenuStripIssue";
            this.contextMenuStripIssue.Size = new System.Drawing.Size(125, 26);
            // 
            // issueInfotoolStripMenuItem
            // 
            this.issueInfotoolStripMenuItem.Name = "issueInfotoolStripMenuItem";
            this.issueInfotoolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.issueInfotoolStripMenuItem.Text = "Issue info";
            this.issueInfotoolStripMenuItem.Click += new System.EventHandler(this.issueInfotoolStripMenuItem_Click);
            // 
            // columnHeaderTracker
            // 
            this.columnHeaderTracker.Text = "Tracker";
            this.columnHeaderTracker.Width = 72;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 289);
            this.Controls.Add(this.btnProjectInfo);
            this.Controls.Add(this.lvIssues);
            this.Controls.Add(this.cbSelectProject);
            this.Controls.Add(this.labelSelectProject);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainForm";
            this.Text = "Redmine Client";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.contextMenuStripIssue.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeAPITokenToolStripMenuItem;
        private System.Windows.Forms.Label labelSelectProject;
        private System.Windows.Forms.ComboBox cbSelectProject;
        private System.Windows.Forms.ListView lvIssues;
        private System.Windows.Forms.ColumnHeader columnHeaderID;
        private System.Windows.Forms.ColumnHeader columnHeaderSubject;
        private System.Windows.Forms.ColumnHeader columnHeaderStatus;
        private System.Windows.Forms.ColumnHeader columnHeaderCreatedOn;
        private System.Windows.Forms.Button btnProjectInfo;
        private System.Windows.Forms.ToolStripMenuItem newProjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newIssuetoolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem refreshStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripIssue;
        private System.Windows.Forms.ToolStripMenuItem issueInfotoolStripMenuItem;
        private System.Windows.Forms.ColumnHeader columnHeaderTracker;
    }
}

