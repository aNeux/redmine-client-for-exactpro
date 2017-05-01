namespace RedmineClient
{
    partial class AuthorizationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AuthorizationForm));
            this.labelInfo = new System.Windows.Forms.Label();
            this.tbAPIKey = new System.Windows.Forms.TextBox();
            this.btnLogIn = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.cbUseAPIKeyInstead = new System.Windows.Forms.CheckBox();
            this.labelLogin = new System.Windows.Forms.Label();
            this.tbLogin = new System.Windows.Forms.TextBox();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.labelPassword = new System.Windows.Forms.Label();
            this.labelAPIKey = new System.Windows.Forms.Label();
            this.linkLabelForgotPassword = new System.Windows.Forms.LinkLabel();
            this.tbRedmineHost = new System.Windows.Forms.TextBox();
            this.labelRedmineHost = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelInfo
            // 
            this.labelInfo.Location = new System.Drawing.Point(12, 9);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(256, 57);
            this.labelInfo.TabIndex = 0;
            this.labelInfo.Text = "To use this Redmine client you should be logged in. Please fill in your login and" +
    " password in boxes below or use authorization by API key if you want. Also you c" +
    "ould change Redmine host URL address.";
            // 
            // tbAPIKey
            // 
            this.tbAPIKey.Enabled = false;
            this.tbAPIKey.Location = new System.Drawing.Point(12, 221);
            this.tbAPIKey.Name = "tbAPIKey";
            this.tbAPIKey.Size = new System.Drawing.Size(256, 20);
            this.tbAPIKey.TabIndex = 10;
            // 
            // btnLogIn
            // 
            this.btnLogIn.Location = new System.Drawing.Point(112, 247);
            this.btnLogIn.Name = "btnLogIn";
            this.btnLogIn.Size = new System.Drawing.Size(75, 23);
            this.btnLogIn.TabIndex = 11;
            this.btnLogIn.Text = "Log In";
            this.btnLogIn.UseVisualStyleBackColor = true;
            this.btnLogIn.Click += new System.EventHandler(this.btnLogIn_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(193, 247);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCacnel_Click);
            // 
            // cbUseAPIKeyInstead
            // 
            this.cbUseAPIKeyInstead.AutoSize = true;
            this.cbUseAPIKeyInstead.Location = new System.Drawing.Point(86, 192);
            this.cbUseAPIKeyInstead.Name = "cbUseAPIKeyInstead";
            this.cbUseAPIKeyInstead.Size = new System.Drawing.Size(122, 17);
            this.cbUseAPIKeyInstead.TabIndex = 8;
            this.cbUseAPIKeyInstead.Text = "Use API key instead";
            this.cbUseAPIKeyInstead.UseVisualStyleBackColor = true;
            this.cbUseAPIKeyInstead.CheckedChanged += new System.EventHandler(this.cbUseAPIKeyInstead_CheckedChanged);
            // 
            // labelLogin
            // 
            this.labelLogin.AutoSize = true;
            this.labelLogin.Location = new System.Drawing.Point(12, 106);
            this.labelLogin.Name = "labelLogin";
            this.labelLogin.Size = new System.Drawing.Size(94, 13);
            this.labelLogin.TabIndex = 3;
            this.labelLogin.Text = "Login (user name):";
            // 
            // tbLogin
            // 
            this.tbLogin.Location = new System.Drawing.Point(12, 123);
            this.tbLogin.Name = "tbLogin";
            this.tbLogin.Size = new System.Drawing.Size(256, 20);
            this.tbLogin.TabIndex = 4;
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(12, 163);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.PasswordChar = '*';
            this.tbPassword.Size = new System.Drawing.Size(206, 20);
            this.tbPassword.TabIndex = 6;
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Location = new System.Drawing.Point(12, 146);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(56, 13);
            this.labelPassword.TabIndex = 5;
            this.labelPassword.Text = "Password:";
            // 
            // labelAPIKey
            // 
            this.labelAPIKey.AutoSize = true;
            this.labelAPIKey.Enabled = false;
            this.labelAPIKey.Location = new System.Drawing.Point(12, 205);
            this.labelAPIKey.Name = "labelAPIKey";
            this.labelAPIKey.Size = new System.Drawing.Size(47, 13);
            this.labelAPIKey.TabIndex = 9;
            this.labelAPIKey.Text = "API key:";
            // 
            // linkLabelForgotPassword
            // 
            this.linkLabelForgotPassword.Location = new System.Drawing.Point(224, 163);
            this.linkLabelForgotPassword.Name = "linkLabelForgotPassword";
            this.linkLabelForgotPassword.Size = new System.Drawing.Size(44, 20);
            this.linkLabelForgotPassword.TabIndex = 7;
            this.linkLabelForgotPassword.TabStop = true;
            this.linkLabelForgotPassword.Text = "Forgot?";
            this.linkLabelForgotPassword.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.linkLabelForgotPassword.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelForgotPassword_LinkClicked);
            // 
            // tbRedmineHost
            // 
            this.tbRedmineHost.Location = new System.Drawing.Point(12, 83);
            this.tbRedmineHost.Name = "tbRedmineHost";
            this.tbRedmineHost.Size = new System.Drawing.Size(256, 20);
            this.tbRedmineHost.TabIndex = 2;
            this.tbRedmineHost.TextChanged += new System.EventHandler(this.tbRedmineHost_TextChanged);
            // 
            // labelRedmineHost
            // 
            this.labelRedmineHost.AutoSize = true;
            this.labelRedmineHost.Location = new System.Drawing.Point(12, 66);
            this.labelRedmineHost.Name = "labelRedmineHost";
            this.labelRedmineHost.Size = new System.Drawing.Size(100, 13);
            this.labelRedmineHost.TabIndex = 1;
            this.labelRedmineHost.Text = "Redmine host URL:";
            // 
            // AuthorizationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(280, 277);
            this.Controls.Add(this.tbRedmineHost);
            this.Controls.Add(this.labelRedmineHost);
            this.Controls.Add(this.linkLabelForgotPassword);
            this.Controls.Add(this.labelAPIKey);
            this.Controls.Add(this.tbPassword);
            this.Controls.Add(this.labelPassword);
            this.Controls.Add(this.tbLogin);
            this.Controls.Add(this.labelLogin);
            this.Controls.Add(this.cbUseAPIKeyInstead);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnLogIn);
            this.Controls.Add(this.tbAPIKey);
            this.Controls.Add(this.labelInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AuthorizationForm";
            this.ShowInTaskbar = false;
            this.Text = "Authorization";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EnterAPITokenForm_FormClosing);
            this.Shown += new System.EventHandler(this.APITokenForm_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelInfo;
        private System.Windows.Forms.TextBox tbAPIKey;
        private System.Windows.Forms.Button btnLogIn;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.CheckBox cbUseAPIKeyInstead;
        private System.Windows.Forms.Label labelLogin;
        private System.Windows.Forms.TextBox tbLogin;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.Label labelAPIKey;
        private System.Windows.Forms.LinkLabel linkLabelForgotPassword;
        private System.Windows.Forms.TextBox tbRedmineHost;
        private System.Windows.Forms.Label labelRedmineHost;
    }
}