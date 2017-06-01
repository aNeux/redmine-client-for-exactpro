namespace RedmineClient
{
    partial class UserInformationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserInformationForm));
            this.labelLogin = new System.Windows.Forms.Label();
            this.tbLogin = new System.Windows.Forms.TextBox();
            this.tbFirstName = new System.Windows.Forms.TextBox();
            this.labelFirstName = new System.Windows.Forms.Label();
            this.tbLastName = new System.Windows.Forms.TextBox();
            this.labelLastName = new System.Windows.Forms.Label();
            this.tbEmail = new System.Windows.Forms.TextBox();
            this.labelEmail = new System.Windows.Forms.Label();
            this.tbCreationDate = new System.Windows.Forms.TextBox();
            this.labelCreationDate = new System.Windows.Forms.Label();
            this.tbAPIKey = new System.Windows.Forms.TextBox();
            this.labelAPIKey = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.tbID = new System.Windows.Forms.TextBox();
            this.labelID = new System.Windows.Forms.Label();
            this.labelInfo = new System.Windows.Forms.Label();
            this.btnLogOut = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelLogin
            // 
            this.labelLogin.Location = new System.Drawing.Point(12, 58);
            this.labelLogin.Name = "labelLogin";
            this.labelLogin.Size = new System.Drawing.Size(75, 20);
            this.labelLogin.TabIndex = 3;
            this.labelLogin.Text = "Login:";
            this.labelLogin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbLogin
            // 
            this.tbLogin.Location = new System.Drawing.Point(93, 58);
            this.tbLogin.Name = "tbLogin";
            this.tbLogin.ReadOnly = true;
            this.tbLogin.Size = new System.Drawing.Size(207, 20);
            this.tbLogin.TabIndex = 4;
            // 
            // tbFirstName
            // 
            this.tbFirstName.Location = new System.Drawing.Point(93, 84);
            this.tbFirstName.Name = "tbFirstName";
            this.tbFirstName.ReadOnly = true;
            this.tbFirstName.Size = new System.Drawing.Size(207, 20);
            this.tbFirstName.TabIndex = 6;
            // 
            // labelFirstName
            // 
            this.labelFirstName.Location = new System.Drawing.Point(12, 84);
            this.labelFirstName.Name = "labelFirstName";
            this.labelFirstName.Size = new System.Drawing.Size(75, 20);
            this.labelFirstName.TabIndex = 5;
            this.labelFirstName.Text = "First name:";
            this.labelFirstName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbLastName
            // 
            this.tbLastName.Location = new System.Drawing.Point(93, 110);
            this.tbLastName.Name = "tbLastName";
            this.tbLastName.ReadOnly = true;
            this.tbLastName.Size = new System.Drawing.Size(207, 20);
            this.tbLastName.TabIndex = 8;
            // 
            // labelLastName
            // 
            this.labelLastName.Location = new System.Drawing.Point(12, 110);
            this.labelLastName.Name = "labelLastName";
            this.labelLastName.Size = new System.Drawing.Size(75, 20);
            this.labelLastName.TabIndex = 7;
            this.labelLastName.Text = "Last name:";
            this.labelLastName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbEmail
            // 
            this.tbEmail.Location = new System.Drawing.Point(93, 136);
            this.tbEmail.Name = "tbEmail";
            this.tbEmail.ReadOnly = true;
            this.tbEmail.Size = new System.Drawing.Size(207, 20);
            this.tbEmail.TabIndex = 10;
            // 
            // labelEmail
            // 
            this.labelEmail.Location = new System.Drawing.Point(12, 136);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new System.Drawing.Size(75, 20);
            this.labelEmail.TabIndex = 9;
            this.labelEmail.Text = "E-mail:";
            this.labelEmail.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbCreationDate
            // 
            this.tbCreationDate.Location = new System.Drawing.Point(94, 162);
            this.tbCreationDate.Name = "tbCreationDate";
            this.tbCreationDate.ReadOnly = true;
            this.tbCreationDate.Size = new System.Drawing.Size(206, 20);
            this.tbCreationDate.TabIndex = 12;
            // 
            // labelCreationDate
            // 
            this.labelCreationDate.Location = new System.Drawing.Point(12, 162);
            this.labelCreationDate.Name = "labelCreationDate";
            this.labelCreationDate.Size = new System.Drawing.Size(75, 20);
            this.labelCreationDate.TabIndex = 11;
            this.labelCreationDate.Text = "Creation date:";
            this.labelCreationDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbAPIKey
            // 
            this.tbAPIKey.Location = new System.Drawing.Point(93, 188);
            this.tbAPIKey.Name = "tbAPIKey";
            this.tbAPIKey.ReadOnly = true;
            this.tbAPIKey.Size = new System.Drawing.Size(207, 20);
            this.tbAPIKey.TabIndex = 14;
            // 
            // labelAPIKey
            // 
            this.labelAPIKey.Location = new System.Drawing.Point(12, 188);
            this.labelAPIKey.Name = "labelAPIKey";
            this.labelAPIKey.Size = new System.Drawing.Size(75, 20);
            this.labelAPIKey.TabIndex = 13;
            this.labelAPIKey.Text = "API key:";
            this.labelAPIKey.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(225, 214);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 15;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // tbID
            // 
            this.tbID.Location = new System.Drawing.Point(93, 32);
            this.tbID.Name = "tbID";
            this.tbID.ReadOnly = true;
            this.tbID.Size = new System.Drawing.Size(207, 20);
            this.tbID.TabIndex = 2;
            // 
            // labelID
            // 
            this.labelID.Location = new System.Drawing.Point(12, 32);
            this.labelID.Name = "labelID";
            this.labelID.Size = new System.Drawing.Size(75, 20);
            this.labelID.TabIndex = 1;
            this.labelID.Text = "ID:";
            this.labelID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelInfo
            // 
            this.labelInfo.Location = new System.Drawing.Point(12, 7);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(288, 19);
            this.labelInfo.TabIndex = 0;
            this.labelInfo.Text = "You could edit personal info at your own Redmine page.";
            this.labelInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnLogOut
            // 
            this.btnLogOut.Location = new System.Drawing.Point(144, 213);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(75, 23);
            this.btnLogOut.TabIndex = 16;
            this.btnLogOut.Text = "Log out";
            this.btnLogOut.UseVisualStyleBackColor = true;
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click);
            // 
            // UserInformationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(312, 243);
            this.Controls.Add(this.btnLogOut);
            this.Controls.Add(this.tbID);
            this.Controls.Add(this.labelID);
            this.Controls.Add(this.labelInfo);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.tbAPIKey);
            this.Controls.Add(this.labelAPIKey);
            this.Controls.Add(this.tbCreationDate);
            this.Controls.Add(this.labelCreationDate);
            this.Controls.Add(this.tbEmail);
            this.Controls.Add(this.labelEmail);
            this.Controls.Add(this.tbLastName);
            this.Controls.Add(this.labelLastName);
            this.Controls.Add(this.tbFirstName);
            this.Controls.Add(this.labelFirstName);
            this.Controls.Add(this.tbLogin);
            this.Controls.Add(this.labelLogin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UserInformationForm";
            this.ShowInTaskbar = false;
            this.Text = "User information";
            this.Shown += new System.EventHandler(this.UserInformationForm_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelLogin;
        private System.Windows.Forms.TextBox tbLogin;
        private System.Windows.Forms.TextBox tbFirstName;
        private System.Windows.Forms.Label labelFirstName;
        private System.Windows.Forms.TextBox tbLastName;
        private System.Windows.Forms.Label labelLastName;
        private System.Windows.Forms.TextBox tbEmail;
        private System.Windows.Forms.Label labelEmail;
        private System.Windows.Forms.TextBox tbCreationDate;
        private System.Windows.Forms.Label labelCreationDate;
        private System.Windows.Forms.TextBox tbAPIKey;
        private System.Windows.Forms.Label labelAPIKey;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox tbID;
        private System.Windows.Forms.Label labelID;
        private System.Windows.Forms.Label labelInfo;
        private System.Windows.Forms.Button btnLogOut;
    }
}