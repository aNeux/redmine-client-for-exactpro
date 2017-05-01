namespace RedmineClient
{
    partial class NotificationsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NotificationsForm));
            this.tbChanges = new System.Windows.Forms.TextBox();
            this.labelHack = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tbChanges
            // 
            this.tbChanges.Location = new System.Drawing.Point(12, 12);
            this.tbChanges.Multiline = true;
            this.tbChanges.Name = "tbChanges";
            this.tbChanges.ReadOnly = true;
            this.tbChanges.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbChanges.Size = new System.Drawing.Size(263, 80);
            this.tbChanges.TabIndex = 0;
            this.tbChanges.Click += new System.EventHandler(this.tbChanges_Click);
            // 
            // labelHack
            // 
            this.labelHack.AutoSize = true;
            this.labelHack.Location = new System.Drawing.Point(13, 13);
            this.labelHack.Name = "labelHack";
            this.labelHack.Size = new System.Drawing.Size(0, 13);
            this.labelHack.TabIndex = 1;
            this.labelHack.Visible = false;
            // 
            // NotificationsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(287, 104);
            this.Controls.Add(this.labelHack);
            this.Controls.Add(this.tbChanges);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NotificationsForm";
            this.ShowInTaskbar = false;
            this.Text = "Redmine Client [notification]";
            this.Shown += new System.EventHandler(this.NotificationsForm_Shown);
            this.MouseLeave += new System.EventHandler(this.NotificationsForm_MouseLeave);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbChanges;
        private System.Windows.Forms.Label labelHack;
    }
}