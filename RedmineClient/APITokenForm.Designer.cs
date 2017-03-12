namespace RedmineClient
{
    partial class APITokenForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(APITokenForm));
            this.labelAboutAPIToken = new System.Windows.Forms.Label();
            this.tbAPIToken = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCacnel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelAboutAPIToken
            // 
            this.labelAboutAPIToken.Location = new System.Drawing.Point(12, 9);
            this.labelAboutAPIToken.Name = "labelAboutAPIToken";
            this.labelAboutAPIToken.Size = new System.Drawing.Size(256, 58);
            this.labelAboutAPIToken.TabIndex = 0;
            this.labelAboutAPIToken.Text = "API token uses when application requesting Redmine services based on your actions" +
    ". For proper work, please, enter your token in box below (you could find it in y" +
    "our own Redmine page):";
            // 
            // tbAPIToken
            // 
            this.tbAPIToken.Location = new System.Drawing.Point(12, 70);
            this.tbAPIToken.Name = "tbAPIToken";
            this.tbAPIToken.Size = new System.Drawing.Size(256, 20);
            this.tbAPIToken.TabIndex = 1;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(12, 96);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(125, 22);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCacnel
            // 
            this.btnCacnel.Location = new System.Drawing.Point(143, 96);
            this.btnCacnel.Name = "btnCacnel";
            this.btnCacnel.Size = new System.Drawing.Size(125, 23);
            this.btnCacnel.TabIndex = 3;
            this.btnCacnel.Text = "Cancel";
            this.btnCacnel.UseVisualStyleBackColor = true;
            this.btnCacnel.Click += new System.EventHandler(this.btnCacnel_Click);
            // 
            // APITokenForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(280, 129);
            this.Controls.Add(this.btnCacnel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.tbAPIToken);
            this.Controls.Add(this.labelAboutAPIToken);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "APITokenForm";
            this.ShowInTaskbar = false;
            this.Text = "API Token";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EnterAPITokenForm_FormClosing);
            this.Shown += new System.EventHandler(this.APITokenForm_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelAboutAPIToken;
        private System.Windows.Forms.TextBox tbAPIToken;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCacnel;
    }
}