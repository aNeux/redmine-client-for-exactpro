namespace RedmineClient
{
    partial class IssueHistoryForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IssueHistoryForm));
            this.tbHistory = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // tbHistory
            // 
            this.tbHistory.Location = new System.Drawing.Point(12, 12);
            this.tbHistory.Multiline = true;
            this.tbHistory.Name = "tbHistory";
            this.tbHistory.ReadOnly = true;
            this.tbHistory.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbHistory.Size = new System.Drawing.Size(265, 153);
            this.tbHistory.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(91, 171);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(106, 23);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(301, 12);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(132, 20);
            this.dateTimePicker1.TabIndex = 2;
            // 
            // IssueHistoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 312);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.tbHistory);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "IssueHistoryForm";
            this.ShowInTaskbar = false;
            this.Text = "Issue history";
            this.Shown += new System.EventHandler(this.IssueHistoryForm_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbHistory;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
    }
}