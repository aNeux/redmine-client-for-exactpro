namespace RedmineClient
{
    partial class OptionsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OptionsForm));
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageGeneral = new System.Windows.Forms.TabPage();
            this.gbSecurity = new System.Windows.Forms.GroupBox();
            this.labelEncryptionInfo = new System.Windows.Forms.Label();
            this.cbEnableEncryption = new System.Windows.Forms.CheckBox();
            this.gbAppearance = new System.Windows.Forms.GroupBox();
            this.cbShowLogin = new System.Windows.Forms.CheckBox();
            this.cbShowStatusBar = new System.Windows.Forms.CheckBox();
            this.cbMinimazeToTray = new System.Windows.Forms.CheckBox();
            this.cbAskBeforeExit = new System.Windows.Forms.CheckBox();
            this.tabPageNotifications = new System.Windows.Forms.TabPage();
            this.gbBackgroundUpdater = new System.Windows.Forms.GroupBox();
            this.labelMinutes = new System.Windows.Forms.Label();
            this.nudUpdateInterval = new System.Windows.Forms.NumericUpDown();
            this.labelUpdateInterval = new System.Windows.Forms.Label();
            this.cbEnableBackgroundUpdater = new System.Windows.Forms.CheckBox();
            this.labelBackgroundUpdaterInfo = new System.Windows.Forms.Label();
            this.tabPageRedmine = new System.Windows.Forms.TabPage();
            this.gbProjects = new System.Windows.Forms.GroupBox();
            this.cbShowClosedProjects = new System.Windows.Forms.CheckBox();
            this.gbHostURL = new System.Windows.Forms.GroupBox();
            this.tbHostURL = new System.Windows.Forms.TextBox();
            this.cbEnableEditingHostURL = new System.Windows.Forms.CheckBox();
            this.labelHostURL = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnApply = new System.Windows.Forms.Button();
            this.tabControl.SuspendLayout();
            this.tabPageGeneral.SuspendLayout();
            this.gbSecurity.SuspendLayout();
            this.gbAppearance.SuspendLayout();
            this.tabPageNotifications.SuspendLayout();
            this.gbBackgroundUpdater.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudUpdateInterval)).BeginInit();
            this.tabPageRedmine.SuspendLayout();
            this.gbProjects.SuspendLayout();
            this.gbHostURL.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageGeneral);
            this.tabControl.Controls.Add(this.tabPageNotifications);
            this.tabControl.Controls.Add(this.tabPageRedmine);
            this.tabControl.Location = new System.Drawing.Point(13, 12);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(408, 237);
            this.tabControl.TabIndex = 0;
            // 
            // tabPageGeneral
            // 
            this.tabPageGeneral.Controls.Add(this.gbSecurity);
            this.tabPageGeneral.Controls.Add(this.gbAppearance);
            this.tabPageGeneral.Location = new System.Drawing.Point(4, 22);
            this.tabPageGeneral.Name = "tabPageGeneral";
            this.tabPageGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageGeneral.Size = new System.Drawing.Size(400, 211);
            this.tabPageGeneral.TabIndex = 0;
            this.tabPageGeneral.Text = "General";
            this.tabPageGeneral.UseVisualStyleBackColor = true;
            // 
            // gbSecurity
            // 
            this.gbSecurity.Controls.Add(this.labelEncryptionInfo);
            this.gbSecurity.Controls.Add(this.cbEnableEncryption);
            this.gbSecurity.Location = new System.Drawing.Point(6, 120);
            this.gbSecurity.Name = "gbSecurity";
            this.gbSecurity.Size = new System.Drawing.Size(388, 84);
            this.gbSecurity.TabIndex = 6;
            this.gbSecurity.TabStop = false;
            this.gbSecurity.Text = "Security";
            // 
            // labelEncryptionInfo
            // 
            this.labelEncryptionInfo.Location = new System.Drawing.Point(8, 16);
            this.labelEncryptionInfo.Name = "labelEncryptionInfo";
            this.labelEncryptionInfo.Size = new System.Drawing.Size(374, 40);
            this.labelEncryptionInfo.TabIndex = 7;
            this.labelEncryptionInfo.Text = resources.GetString("labelEncryptionInfo.Text");
            // 
            // cbEnableEncryption
            // 
            this.cbEnableEncryption.AutoSize = true;
            this.cbEnableEncryption.Location = new System.Drawing.Point(11, 59);
            this.cbEnableEncryption.Name = "cbEnableEncryption";
            this.cbEnableEncryption.Size = new System.Drawing.Size(137, 17);
            this.cbEnableEncryption.TabIndex = 8;
            this.cbEnableEncryption.Text = "Enable XOR-encryption";
            this.cbEnableEncryption.UseVisualStyleBackColor = true;
            // 
            // gbAppearance
            // 
            this.gbAppearance.Controls.Add(this.cbShowLogin);
            this.gbAppearance.Controls.Add(this.cbShowStatusBar);
            this.gbAppearance.Controls.Add(this.cbMinimazeToTray);
            this.gbAppearance.Controls.Add(this.cbAskBeforeExit);
            this.gbAppearance.Location = new System.Drawing.Point(6, 6);
            this.gbAppearance.Name = "gbAppearance";
            this.gbAppearance.Size = new System.Drawing.Size(388, 109);
            this.gbAppearance.TabIndex = 1;
            this.gbAppearance.TabStop = false;
            this.gbAppearance.Text = "Appearance";
            // 
            // cbShowLogin
            // 
            this.cbShowLogin.AutoSize = true;
            this.cbShowLogin.Location = new System.Drawing.Point(8, 64);
            this.cbShowLogin.Name = "cbShowLogin";
            this.cbShowLogin.Size = new System.Drawing.Size(256, 17);
            this.cbShowLogin.TabIndex = 4;
            this.cbShowLogin.Text = "Show login of current user at title of main window";
            this.cbShowLogin.UseVisualStyleBackColor = true;
            // 
            // cbShowStatusBar
            // 
            this.cbShowStatusBar.AutoSize = true;
            this.cbShowStatusBar.Location = new System.Drawing.Point(8, 87);
            this.cbShowStatusBar.Name = "cbShowStatusBar";
            this.cbShowStatusBar.Size = new System.Drawing.Size(181, 17);
            this.cbShowStatusBar.TabIndex = 5;
            this.cbShowStatusBar.Text = "Show status bar on main window";
            this.cbShowStatusBar.UseVisualStyleBackColor = true;
            // 
            // cbMinimazeToTray
            // 
            this.cbMinimazeToTray.AutoSize = true;
            this.cbMinimazeToTray.Location = new System.Drawing.Point(8, 41);
            this.cbMinimazeToTray.Name = "cbMinimazeToTray";
            this.cbMinimazeToTray.Size = new System.Drawing.Size(176, 17);
            this.cbMinimazeToTray.TabIndex = 3;
            this.cbMinimazeToTray.Text = "Minimaze window to system tray";
            this.cbMinimazeToTray.UseVisualStyleBackColor = true;
            // 
            // cbAskBeforeExit
            // 
            this.cbAskBeforeExit.AutoSize = true;
            this.cbAskBeforeExit.Location = new System.Drawing.Point(8, 18);
            this.cbAskBeforeExit.Name = "cbAskBeforeExit";
            this.cbAskBeforeExit.Size = new System.Drawing.Size(155, 17);
            this.cbAskBeforeExit.TabIndex = 2;
            this.cbAskBeforeExit.Text = "Ask before exit the program";
            this.cbAskBeforeExit.UseVisualStyleBackColor = true;
            // 
            // tabPageNotifications
            // 
            this.tabPageNotifications.Controls.Add(this.gbBackgroundUpdater);
            this.tabPageNotifications.Location = new System.Drawing.Point(4, 22);
            this.tabPageNotifications.Name = "tabPageNotifications";
            this.tabPageNotifications.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageNotifications.Size = new System.Drawing.Size(400, 211);
            this.tabPageNotifications.TabIndex = 1;
            this.tabPageNotifications.Text = "Notifications";
            this.tabPageNotifications.UseVisualStyleBackColor = true;
            // 
            // gbBackgroundUpdater
            // 
            this.gbBackgroundUpdater.Controls.Add(this.labelMinutes);
            this.gbBackgroundUpdater.Controls.Add(this.nudUpdateInterval);
            this.gbBackgroundUpdater.Controls.Add(this.labelUpdateInterval);
            this.gbBackgroundUpdater.Controls.Add(this.cbEnableBackgroundUpdater);
            this.gbBackgroundUpdater.Controls.Add(this.labelBackgroundUpdaterInfo);
            this.gbBackgroundUpdater.Location = new System.Drawing.Point(6, 6);
            this.gbBackgroundUpdater.Name = "gbBackgroundUpdater";
            this.gbBackgroundUpdater.Size = new System.Drawing.Size(388, 109);
            this.gbBackgroundUpdater.TabIndex = 9;
            this.gbBackgroundUpdater.TabStop = false;
            this.gbBackgroundUpdater.Text = "Background updater";
            // 
            // labelMinutes
            // 
            this.labelMinutes.Enabled = false;
            this.labelMinutes.Location = new System.Drawing.Point(194, 78);
            this.labelMinutes.Name = "labelMinutes";
            this.labelMinutes.Size = new System.Drawing.Size(59, 20);
            this.labelMinutes.TabIndex = 14;
            this.labelMinutes.Text = "minute(-s)";
            this.labelMinutes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // nudUpdateInterval
            // 
            this.nudUpdateInterval.Enabled = false;
            this.nudUpdateInterval.Location = new System.Drawing.Point(144, 78);
            this.nudUpdateInterval.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.nudUpdateInterval.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudUpdateInterval.Name = "nudUpdateInterval";
            this.nudUpdateInterval.Size = new System.Drawing.Size(45, 20);
            this.nudUpdateInterval.TabIndex = 13;
            this.nudUpdateInterval.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudUpdateInterval.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // labelUpdateInterval
            // 
            this.labelUpdateInterval.Enabled = false;
            this.labelUpdateInterval.Location = new System.Drawing.Point(6, 78);
            this.labelUpdateInterval.Name = "labelUpdateInterval";
            this.labelUpdateInterval.Size = new System.Drawing.Size(132, 20);
            this.labelUpdateInterval.TabIndex = 12;
            this.labelUpdateInterval.Text = "Interval between updates:";
            this.labelUpdateInterval.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbEnableBackgroundUpdater
            // 
            this.cbEnableBackgroundUpdater.AutoSize = true;
            this.cbEnableBackgroundUpdater.Location = new System.Drawing.Point(9, 60);
            this.cbEnableBackgroundUpdater.Name = "cbEnableBackgroundUpdater";
            this.cbEnableBackgroundUpdater.Size = new System.Drawing.Size(158, 17);
            this.cbEnableBackgroundUpdater.TabIndex = 11;
            this.cbEnableBackgroundUpdater.Text = "Enable background updater";
            this.cbEnableBackgroundUpdater.UseVisualStyleBackColor = true;
            this.cbEnableBackgroundUpdater.CheckedChanged += new System.EventHandler(this.cbEnableBackgroundUpdater_CheckedChanged);
            // 
            // labelBackgroundUpdaterInfo
            // 
            this.labelBackgroundUpdaterInfo.Location = new System.Drawing.Point(6, 16);
            this.labelBackgroundUpdaterInfo.Name = "labelBackgroundUpdaterInfo";
            this.labelBackgroundUpdaterInfo.Size = new System.Drawing.Size(378, 40);
            this.labelBackgroundUpdaterInfo.TabIndex = 10;
            this.labelBackgroundUpdaterInfo.Text = resources.GetString("labelBackgroundUpdaterInfo.Text");
            // 
            // tabPageRedmine
            // 
            this.tabPageRedmine.Controls.Add(this.gbProjects);
            this.tabPageRedmine.Controls.Add(this.gbHostURL);
            this.tabPageRedmine.Location = new System.Drawing.Point(4, 22);
            this.tabPageRedmine.Name = "tabPageRedmine";
            this.tabPageRedmine.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageRedmine.Size = new System.Drawing.Size(400, 211);
            this.tabPageRedmine.TabIndex = 2;
            this.tabPageRedmine.Text = "Redmine";
            this.tabPageRedmine.UseVisualStyleBackColor = true;
            // 
            // gbProjects
            // 
            this.gbProjects.Controls.Add(this.cbShowClosedProjects);
            this.gbProjects.Location = new System.Drawing.Point(6, 119);
            this.gbProjects.Name = "gbProjects";
            this.gbProjects.Size = new System.Drawing.Size(388, 38);
            this.gbProjects.TabIndex = 19;
            this.gbProjects.TabStop = false;
            this.gbProjects.Text = "Projects";
            // 
            // cbShowClosedProjects
            // 
            this.cbShowClosedProjects.AutoSize = true;
            this.cbShowClosedProjects.Location = new System.Drawing.Point(7, 17);
            this.cbShowClosedProjects.Name = "cbShowClosedProjects";
            this.cbShowClosedProjects.Size = new System.Drawing.Size(127, 17);
            this.cbShowClosedProjects.TabIndex = 20;
            this.cbShowClosedProjects.Text = "Show closed projects";
            this.cbShowClosedProjects.UseVisualStyleBackColor = true;
            // 
            // gbHostURL
            // 
            this.gbHostURL.Controls.Add(this.tbHostURL);
            this.gbHostURL.Controls.Add(this.cbEnableEditingHostURL);
            this.gbHostURL.Controls.Add(this.labelHostURL);
            this.gbHostURL.Enabled = false;
            this.gbHostURL.Location = new System.Drawing.Point(6, 6);
            this.gbHostURL.Name = "gbHostURL";
            this.gbHostURL.Size = new System.Drawing.Size(388, 108);
            this.gbHostURL.TabIndex = 15;
            this.gbHostURL.TabStop = false;
            this.gbHostURL.Text = "Host URL";
            // 
            // tbHostURL
            // 
            this.tbHostURL.Location = new System.Drawing.Point(6, 79);
            this.tbHostURL.Name = "tbHostURL";
            this.tbHostURL.ReadOnly = true;
            this.tbHostURL.Size = new System.Drawing.Size(375, 20);
            this.tbHostURL.TabIndex = 18;
            // 
            // cbEnableEditingHostURL
            // 
            this.cbEnableEditingHostURL.AutoSize = true;
            this.cbEnableEditingHostURL.Location = new System.Drawing.Point(9, 60);
            this.cbEnableEditingHostURL.Name = "cbEnableEditingHostURL";
            this.cbEnableEditingHostURL.Size = new System.Drawing.Size(93, 17);
            this.cbEnableEditingHostURL.TabIndex = 17;
            this.cbEnableEditingHostURL.Text = "Enable editing";
            this.cbEnableEditingHostURL.UseVisualStyleBackColor = true;
            this.cbEnableEditingHostURL.CheckedChanged += new System.EventHandler(this.cbEnableEditHostURL_CheckedChanged);
            // 
            // labelHostURL
            // 
            this.labelHostURL.Location = new System.Drawing.Point(6, 16);
            this.labelHostURL.Name = "labelHostURL";
            this.labelHostURL.Size = new System.Drawing.Size(375, 41);
            this.labelHostURL.TabIndex = 16;
            this.labelHostURL.Text = resources.GetString("labelHostURL.Text");
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(346, 253);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 22;
            this.btnCancel.Text = "Cacnel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(265, 253);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(75, 23);
            this.btnApply.TabIndex = 21;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // OptionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(433, 283);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.tabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OptionsForm";
            this.ShowInTaskbar = false;
            this.Text = "Options";
            this.Shown += new System.EventHandler(this.OptionsForm_Shown);
            this.tabControl.ResumeLayout(false);
            this.tabPageGeneral.ResumeLayout(false);
            this.gbSecurity.ResumeLayout(false);
            this.gbSecurity.PerformLayout();
            this.gbAppearance.ResumeLayout(false);
            this.gbAppearance.PerformLayout();
            this.tabPageNotifications.ResumeLayout(false);
            this.gbBackgroundUpdater.ResumeLayout(false);
            this.gbBackgroundUpdater.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudUpdateInterval)).EndInit();
            this.tabPageRedmine.ResumeLayout(false);
            this.gbProjects.ResumeLayout(false);
            this.gbProjects.PerformLayout();
            this.gbHostURL.ResumeLayout(false);
            this.gbHostURL.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageGeneral;
        private System.Windows.Forms.TabPage tabPageNotifications;
        private System.Windows.Forms.TabPage tabPageRedmine;
        private System.Windows.Forms.CheckBox cbEnableEncryption;
        private System.Windows.Forms.GroupBox gbSecurity;
        private System.Windows.Forms.Label labelEncryptionInfo;
        private System.Windows.Forms.GroupBox gbAppearance;
        private System.Windows.Forms.CheckBox cbShowLogin;
        private System.Windows.Forms.CheckBox cbShowStatusBar;
        private System.Windows.Forms.CheckBox cbMinimazeToTray;
        private System.Windows.Forms.CheckBox cbAskBeforeExit;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.GroupBox gbBackgroundUpdater;
        private System.Windows.Forms.Label labelMinutes;
        private System.Windows.Forms.NumericUpDown nudUpdateInterval;
        private System.Windows.Forms.Label labelUpdateInterval;
        private System.Windows.Forms.CheckBox cbEnableBackgroundUpdater;
        private System.Windows.Forms.Label labelBackgroundUpdaterInfo;
        private System.Windows.Forms.GroupBox gbHostURL;
        private System.Windows.Forms.TextBox tbHostURL;
        private System.Windows.Forms.CheckBox cbEnableEditingHostURL;
        private System.Windows.Forms.Label labelHostURL;
        private System.Windows.Forms.GroupBox gbProjects;
        private System.Windows.Forms.CheckBox cbShowClosedProjects;
    }
}