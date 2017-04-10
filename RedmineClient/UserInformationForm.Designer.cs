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
            this.btnOk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelLogin
            // 
            this.labelLogin.Location = new System.Drawing.Point(12, 12);
            this.labelLogin.Name = "labelLogin";
            this.labelLogin.Size = new System.Drawing.Size(38, 20);
            this.labelLogin.TabIndex = 0;
            this.labelLogin.Text = "Login:";
            this.labelLogin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbLogin
            // 
            this.tbLogin.Location = new System.Drawing.Point(56, 12);
            this.tbLogin.Name = "tbLogin";
            this.tbLogin.ReadOnly = true;
            this.tbLogin.Size = new System.Drawing.Size(182, 20);
            this.tbLogin.TabIndex = 1;
            // 
            // tbFirstName
            // 
            this.tbFirstName.Location = new System.Drawing.Point(80, 38);
            this.tbFirstName.Name = "tbFirstName";
            this.tbFirstName.ReadOnly = true;
            this.tbFirstName.Size = new System.Drawing.Size(158, 20);
            this.tbFirstName.TabIndex = 3;
            // 
            // labelFirstName
            // 
            this.labelFirstName.Location = new System.Drawing.Point(12, 38);
            this.labelFirstName.Name = "labelFirstName";
            this.labelFirstName.Size = new System.Drawing.Size(62, 20);
            this.labelFirstName.TabIndex = 2;
            this.labelFirstName.Text = "First name:";
            this.labelFirstName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbLastName
            // 
            this.tbLastName.Location = new System.Drawing.Point(80, 64);
            this.tbLastName.Name = "tbLastName";
            this.tbLastName.ReadOnly = true;
            this.tbLastName.Size = new System.Drawing.Size(158, 20);
            this.tbLastName.TabIndex = 5;
            // 
            // labelLastName
            // 
            this.labelLastName.Location = new System.Drawing.Point(12, 64);
            this.labelLastName.Name = "labelLastName";
            this.labelLastName.Size = new System.Drawing.Size(62, 20);
            this.labelLastName.TabIndex = 4;
            this.labelLastName.Text = "Last Name:";
            this.labelLastName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbEmail
            // 
            this.tbEmail.Location = new System.Drawing.Point(56, 90);
            this.tbEmail.Name = "tbEmail";
            this.tbEmail.ReadOnly = true;
            this.tbEmail.Size = new System.Drawing.Size(182, 20);
            this.tbEmail.TabIndex = 7;
            // 
            // labelEmail
            // 
            this.labelEmail.Location = new System.Drawing.Point(12, 90);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new System.Drawing.Size(38, 20);
            this.labelEmail.TabIndex = 6;
            this.labelEmail.Text = "E-mail:";
            this.labelEmail.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbCreationDate
            // 
            this.tbCreationDate.Location = new System.Drawing.Point(94, 116);
            this.tbCreationDate.Name = "tbCreationDate";
            this.tbCreationDate.ReadOnly = true;
            this.tbCreationDate.Size = new System.Drawing.Size(144, 20);
            this.tbCreationDate.TabIndex = 9;
            // 
            // labelCreationDate
            // 
            this.labelCreationDate.Location = new System.Drawing.Point(13, 116);
            this.labelCreationDate.Name = "labelCreationDate";
            this.labelCreationDate.Size = new System.Drawing.Size(75, 20);
            this.labelCreationDate.TabIndex = 8;
            this.labelCreationDate.Text = "Creation date:";
            this.labelCreationDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbAPIKey
            // 
            this.tbAPIKey.Location = new System.Drawing.Point(70, 142);
            this.tbAPIKey.Name = "tbAPIKey";
            this.tbAPIKey.ReadOnly = true;
            this.tbAPIKey.Size = new System.Drawing.Size(168, 20);
            this.tbAPIKey.TabIndex = 11;
            // 
            // labelAPIKey
            // 
            this.labelAPIKey.Location = new System.Drawing.Point(14, 142);
            this.labelAPIKey.Name = "labelAPIKey";
            this.labelAPIKey.Size = new System.Drawing.Size(50, 20);
            this.labelAPIKey.TabIndex = 10;
            this.labelAPIKey.Text = "API key:";
            this.labelAPIKey.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(93, 169);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 12;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // UserInformationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(254, 201);
            this.Controls.Add(this.btnOk);
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
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
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
        private System.Windows.Forms.Button btnOk;
    }
}