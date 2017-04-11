namespace RedmineClient
{
    partial class AboutForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutForm));
            this.pbRedmineLogo = new System.Windows.Forms.PictureBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.labelAbout = new System.Windows.Forms.Label();
            this.labelPavelTropinov = new System.Windows.Forms.Label();
            this.linkLabelPavelTropinovVK = new System.Windows.Forms.LinkLabel();
            this.linkLabelIlyaIlichevVK = new System.Windows.Forms.LinkLabel();
            this.labelIlyaIlichev = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbRedmineLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // pbRedmineLogo
            // 
            this.pbRedmineLogo.Image = ((System.Drawing.Image)(resources.GetObject("pbRedmineLogo.Image")));
            this.pbRedmineLogo.Location = new System.Drawing.Point(13, 13);
            this.pbRedmineLogo.Name = "pbRedmineLogo";
            this.pbRedmineLogo.Size = new System.Drawing.Size(336, 98);
            this.pbRedmineLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbRedmineLogo.TabIndex = 0;
            this.pbRedmineLogo.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(274, 221);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // labelAbout
            // 
            this.labelAbout.Location = new System.Drawing.Point(13, 118);
            this.labelAbout.Name = "labelAbout";
            this.labelAbout.Size = new System.Drawing.Size(336, 92);
            this.labelAbout.TabIndex = 1;
            this.labelAbout.Text = resources.GetString("labelAbout.Text");
            // 
            // labelPavelTropinov
            // 
            this.labelPavelTropinov.AutoSize = true;
            this.labelPavelTropinov.Location = new System.Drawing.Point(13, 210);
            this.labelPavelTropinov.Name = "labelPavelTropinov";
            this.labelPavelTropinov.Size = new System.Drawing.Size(98, 13);
            this.labelPavelTropinov.TabIndex = 2;
            this.labelPavelTropinov.Text = "● Pavel Tropinov - ";
            // 
            // linkLabelPavelTropinovVK
            // 
            this.linkLabelPavelTropinovVK.AutoSize = true;
            this.linkLabelPavelTropinovVK.Location = new System.Drawing.Point(107, 210);
            this.linkLabelPavelTropinovVK.Name = "linkLabelPavelTropinovVK";
            this.linkLabelPavelTropinovVK.Size = new System.Drawing.Size(112, 13);
            this.linkLabelPavelTropinovVK.TabIndex = 3;
            this.linkLabelPavelTropinovVK.TabStop = true;
            this.linkLabelPavelTropinovVK.Text = "https://vk.com/aneux";
            this.linkLabelPavelTropinovVK.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_LinkClicked);
            // 
            // linkLabelIlyaIlichevVK
            // 
            this.linkLabelIlyaIlichevVK.AutoSize = true;
            this.linkLabelIlyaIlichevVK.Location = new System.Drawing.Point(85, 226);
            this.linkLabelIlyaIlichevVK.Name = "linkLabelIlyaIlichevVK";
            this.linkLabelIlyaIlichevVK.Size = new System.Drawing.Size(131, 13);
            this.linkLabelIlyaIlichevVK.TabIndex = 5;
            this.linkLabelIlyaIlichevVK.TabStop = true;
            this.linkLabelIlyaIlichevVK.Text = "https://vk.com/ilichev.ilya";
            this.linkLabelIlyaIlichevVK.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_LinkClicked);
            // 
            // labelIlyaIlichev
            // 
            this.labelIlyaIlichev.AutoSize = true;
            this.labelIlyaIlichev.Location = new System.Drawing.Point(13, 226);
            this.labelIlyaIlichev.Name = "labelIlyaIlichev";
            this.labelIlyaIlichev.Size = new System.Drawing.Size(76, 13);
            this.labelIlyaIlichev.TabIndex = 4;
            this.labelIlyaIlichev.Text = "● Ilya Ilichev - ";
            // 
            // AboutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(361, 253);
            this.Controls.Add(this.linkLabelIlyaIlichevVK);
            this.Controls.Add(this.labelIlyaIlichev);
            this.Controls.Add(this.linkLabelPavelTropinovVK);
            this.Controls.Add(this.labelPavelTropinov);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.labelAbout);
            this.Controls.Add(this.pbRedmineLogo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AboutForm";
            this.ShowInTaskbar = false;
            this.Text = "About";
            ((System.ComponentModel.ISupportInitialize)(this.pbRedmineLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbRedmineLogo;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label labelAbout;
        private System.Windows.Forms.Label labelPavelTropinov;
        private System.Windows.Forms.LinkLabel linkLabelPavelTropinovVK;
        private System.Windows.Forms.LinkLabel linkLabelIlyaIlichevVK;
        private System.Windows.Forms.Label labelIlyaIlichev;
    }
}