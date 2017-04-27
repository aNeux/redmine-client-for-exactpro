namespace RedmineClient
{
    partial class ProjectInformation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProjectInformation));
            this.labelID = new System.Windows.Forms.Label();
            this.tbID = new System.Windows.Forms.TextBox();
            this.labelName = new System.Windows.Forms.Label();
            this.labelIdentifier = new System.Windows.Forms.Label();
            this.labelDescription = new System.Windows.Forms.Label();
            this.labelStatus = new System.Windows.Forms.Label();
            this.labelCreationDate = new System.Windows.Forms.Label();
            this.labelLastUpdate = new System.Windows.Forms.Label();
            this.labelMembers = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.tbIdentifier = new System.Windows.Forms.TextBox();
            this.tbDescription = new System.Windows.Forms.TextBox();
            this.tbStatus = new System.Windows.Forms.TextBox();
            this.tbCreationDate = new System.Windows.Forms.TextBox();
            this.tbLastUpdate = new System.Windows.Forms.TextBox();
            this.lbMembers = new System.Windows.Forms.ListBox();
            this.tbHomepage = new System.Windows.Forms.TextBox();
            this.labelHomepage = new System.Windows.Forms.Label();
            this.cbIsPublic = new System.Windows.Forms.CheckBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelID
            // 
            this.labelID.Location = new System.Drawing.Point(12, 11);
            this.labelID.Name = "labelID";
            this.labelID.Size = new System.Drawing.Size(74, 20);
            this.labelID.TabIndex = 0;
            this.labelID.Text = "ID:";
            this.labelID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbID
            // 
            this.tbID.Location = new System.Drawing.Point(92, 11);
            this.tbID.Name = "tbID";
            this.tbID.ReadOnly = true;
            this.tbID.Size = new System.Drawing.Size(125, 20);
            this.tbID.TabIndex = 1;
            // 
            // labelName
            // 
            this.labelName.Location = new System.Drawing.Point(12, 37);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(74, 20);
            this.labelName.TabIndex = 2;
            this.labelName.Text = "Name:";
            this.labelName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelIdentifier
            // 
            this.labelIdentifier.Location = new System.Drawing.Point(12, 63);
            this.labelIdentifier.Name = "labelIdentifier";
            this.labelIdentifier.Size = new System.Drawing.Size(74, 20);
            this.labelIdentifier.TabIndex = 4;
            this.labelIdentifier.Text = "Identifier:";
            this.labelIdentifier.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelDescription
            // 
            this.labelDescription.Location = new System.Drawing.Point(240, 11);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(81, 20);
            this.labelDescription.TabIndex = 14;
            this.labelDescription.Text = "Description:";
            this.labelDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelStatus
            // 
            this.labelStatus.Location = new System.Drawing.Point(12, 115);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(74, 20);
            this.labelStatus.TabIndex = 8;
            this.labelStatus.Text = "Status:";
            this.labelStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelCreationDate
            // 
            this.labelCreationDate.Location = new System.Drawing.Point(12, 141);
            this.labelCreationDate.Name = "labelCreationDate";
            this.labelCreationDate.Size = new System.Drawing.Size(73, 20);
            this.labelCreationDate.TabIndex = 10;
            this.labelCreationDate.Text = "Creation date:";
            this.labelCreationDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelLastUpdate
            // 
            this.labelLastUpdate.Location = new System.Drawing.Point(12, 166);
            this.labelLastUpdate.Name = "labelLastUpdate";
            this.labelLastUpdate.Size = new System.Drawing.Size(73, 20);
            this.labelLastUpdate.TabIndex = 12;
            this.labelLastUpdate.Text = "Last update:";
            this.labelLastUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelMembers
            // 
            this.labelMembers.Location = new System.Drawing.Point(241, 81);
            this.labelMembers.Name = "labelMembers";
            this.labelMembers.Size = new System.Drawing.Size(81, 20);
            this.labelMembers.TabIndex = 16;
            this.labelMembers.Text = "Members:";
            this.labelMembers.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(92, 37);
            this.tbName.Name = "tbName";
            this.tbName.ReadOnly = true;
            this.tbName.Size = new System.Drawing.Size(125, 20);
            this.tbName.TabIndex = 3;
            // 
            // tbIdentifier
            // 
            this.tbIdentifier.Location = new System.Drawing.Point(92, 63);
            this.tbIdentifier.Name = "tbIdentifier";
            this.tbIdentifier.ReadOnly = true;
            this.tbIdentifier.Size = new System.Drawing.Size(125, 20);
            this.tbIdentifier.TabIndex = 5;
            // 
            // tbDescription
            // 
            this.tbDescription.Location = new System.Drawing.Point(235, 33);
            this.tbDescription.Multiline = true;
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.ReadOnly = true;
            this.tbDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbDescription.Size = new System.Drawing.Size(167, 46);
            this.tbDescription.TabIndex = 15;
            // 
            // tbStatus
            // 
            this.tbStatus.Location = new System.Drawing.Point(92, 115);
            this.tbStatus.Name = "tbStatus";
            this.tbStatus.ReadOnly = true;
            this.tbStatus.Size = new System.Drawing.Size(125, 20);
            this.tbStatus.TabIndex = 9;
            // 
            // tbCreationDate
            // 
            this.tbCreationDate.Location = new System.Drawing.Point(91, 141);
            this.tbCreationDate.Name = "tbCreationDate";
            this.tbCreationDate.ReadOnly = true;
            this.tbCreationDate.Size = new System.Drawing.Size(125, 20);
            this.tbCreationDate.TabIndex = 11;
            // 
            // tbLastUpdate
            // 
            this.tbLastUpdate.Location = new System.Drawing.Point(91, 167);
            this.tbLastUpdate.Name = "tbLastUpdate";
            this.tbLastUpdate.ReadOnly = true;
            this.tbLastUpdate.Size = new System.Drawing.Size(125, 20);
            this.tbLastUpdate.TabIndex = 13;
            // 
            // lbMembers
            // 
            this.lbMembers.Enabled = false;
            this.lbMembers.FormattingEnabled = true;
            this.lbMembers.Location = new System.Drawing.Point(235, 102);
            this.lbMembers.Name = "lbMembers";
            this.lbMembers.Size = new System.Drawing.Size(167, 56);
            this.lbMembers.TabIndex = 17;
            // 
            // tbHomepage
            // 
            this.tbHomepage.Location = new System.Drawing.Point(92, 89);
            this.tbHomepage.Name = "tbHomepage";
            this.tbHomepage.ReadOnly = true;
            this.tbHomepage.Size = new System.Drawing.Size(125, 20);
            this.tbHomepage.TabIndex = 7;
            // 
            // labelHomepage
            // 
            this.labelHomepage.Location = new System.Drawing.Point(12, 89);
            this.labelHomepage.Name = "labelHomepage";
            this.labelHomepage.Size = new System.Drawing.Size(74, 20);
            this.labelHomepage.TabIndex = 6;
            this.labelHomepage.Text = "Homepage:";
            this.labelHomepage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbIsPublic
            // 
            this.cbIsPublic.AutoSize = true;
            this.cbIsPublic.Enabled = false;
            this.cbIsPublic.Location = new System.Drawing.Point(235, 169);
            this.cbIsPublic.Name = "cbIsPublic";
            this.cbIsPublic.Size = new System.Drawing.Size(65, 17);
            this.cbIsPublic.TabIndex = 18;
            this.cbIsPublic.Text = "Is public";
            this.cbIsPublic.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.Enabled = false;
            this.btnClose.Location = new System.Drawing.Point(327, 187);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 19;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ProjectInformation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 217);
            this.Controls.Add(this.cbIsPublic);
            this.Controls.Add(this.tbHomepage);
            this.Controls.Add(this.labelHomepage);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lbMembers);
            this.Controls.Add(this.tbLastUpdate);
            this.Controls.Add(this.tbCreationDate);
            this.Controls.Add(this.tbStatus);
            this.Controls.Add(this.tbDescription);
            this.Controls.Add(this.tbIdentifier);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.labelMembers);
            this.Controls.Add(this.labelLastUpdate);
            this.Controls.Add(this.labelCreationDate);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.labelDescription);
            this.Controls.Add(this.labelIdentifier);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.tbID);
            this.Controls.Add(this.labelID);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProjectInformation";
            this.ShowInTaskbar = false;
            this.Text = "Project Information [please, wait..]";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ProjectInformation_FormClosing);
            this.Shown += new System.EventHandler(this.ProjectInformation_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelID;
        private System.Windows.Forms.TextBox tbID;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelIdentifier;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Label labelCreationDate;
        private System.Windows.Forms.Label labelLastUpdate;
        private System.Windows.Forms.Label labelMembers;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.TextBox tbIdentifier;
        private System.Windows.Forms.TextBox tbDescription;
        private System.Windows.Forms.TextBox tbStatus;
        private System.Windows.Forms.TextBox tbCreationDate;
        private System.Windows.Forms.TextBox tbLastUpdate;
        private System.Windows.Forms.ListBox lbMembers;
        private System.Windows.Forms.TextBox tbHomepage;
        private System.Windows.Forms.Label labelHomepage;
        private System.Windows.Forms.CheckBox cbIsPublic;
        private System.Windows.Forms.Button btnClose;
    }
}