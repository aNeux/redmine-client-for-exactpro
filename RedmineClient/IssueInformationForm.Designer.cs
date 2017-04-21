namespace RedmineClient
{
    partial class IssueInformationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IssueInformationForm));
            this.tbSubject = new System.Windows.Forms.TextBox();
            this.labelSubject = new System.Windows.Forms.Label();
            this.tbID = new System.Windows.Forms.TextBox();
            this.labelID = new System.Windows.Forms.Label();
            this.cbTracker = new System.Windows.Forms.ComboBox();
            this.cbStatus = new System.Windows.Forms.ComboBox();
            this.cbPriority = new System.Windows.Forms.ComboBox();
            this.cbAssignedTo = new System.Windows.Forms.ComboBox();
            this.labelTracker = new System.Windows.Forms.Label();
            this.labelStatus = new System.Windows.Forms.Label();
            this.labelPriority = new System.Windows.Forms.Label();
            this.labelAssignedTo = new System.Windows.Forms.Label();
            this.tbLastUpdate = new System.Windows.Forms.TextBox();
            this.labelLastUpdate = new System.Windows.Forms.Label();
            this.tbDescription = new System.Windows.Forms.TextBox();
            this.labelDescription = new System.Windows.Forms.Label();
            this.labelCreationDate = new System.Windows.Forms.Label();
            this.tbCreationDate = new System.Windows.Forms.TextBox();
            this.tbAuthor = new System.Windows.Forms.TextBox();
            this.labelAuthor = new System.Windows.Forms.Label();
            this.tbStartDate = new System.Windows.Forms.TextBox();
            this.labelStartDate = new System.Windows.Forms.Label();
            this.labelDoneRatio = new System.Windows.Forms.Label();
            this.nudDoneRatio = new System.Windows.Forms.NumericUpDown();
            this.labelPercentage = new System.Windows.Forms.Label();
            this.tbClosedDate = new System.Windows.Forms.TextBox();
            this.labelClosesDate = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnRemoveIssue = new System.Windows.Forms.Button();
            this.btnShowHistory = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.cbAddNote = new System.Windows.Forms.CheckBox();
            this.tbAddNote = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudDoneRatio)).BeginInit();
            this.SuspendLayout();
            // 
            // tbSubject
            // 
            this.tbSubject.Enabled = false;
            this.tbSubject.Location = new System.Drawing.Point(92, 42);
            this.tbSubject.Name = "tbSubject";
            this.tbSubject.Size = new System.Drawing.Size(125, 20);
            this.tbSubject.TabIndex = 3;
            // 
            // labelSubject
            // 
            this.labelSubject.Location = new System.Drawing.Point(12, 42);
            this.labelSubject.Name = "labelSubject";
            this.labelSubject.Size = new System.Drawing.Size(74, 20);
            this.labelSubject.TabIndex = 2;
            this.labelSubject.Text = "Subject:";
            this.labelSubject.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbID
            // 
            this.tbID.Enabled = false;
            this.tbID.Location = new System.Drawing.Point(92, 16);
            this.tbID.Name = "tbID";
            this.tbID.ReadOnly = true;
            this.tbID.Size = new System.Drawing.Size(125, 20);
            this.tbID.TabIndex = 1;
            // 
            // labelID
            // 
            this.labelID.Location = new System.Drawing.Point(12, 16);
            this.labelID.Name = "labelID";
            this.labelID.Size = new System.Drawing.Size(74, 20);
            this.labelID.TabIndex = 0;
            this.labelID.Text = "ID:";
            this.labelID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbTracker
            // 
            this.cbTracker.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTracker.Enabled = false;
            this.cbTracker.FormattingEnabled = true;
            this.cbTracker.Location = new System.Drawing.Point(92, 69);
            this.cbTracker.Name = "cbTracker";
            this.cbTracker.Size = new System.Drawing.Size(125, 21);
            this.cbTracker.TabIndex = 5;
            // 
            // cbStatus
            // 
            this.cbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStatus.Enabled = false;
            this.cbStatus.FormattingEnabled = true;
            this.cbStatus.Location = new System.Drawing.Point(92, 96);
            this.cbStatus.Name = "cbStatus";
            this.cbStatus.Size = new System.Drawing.Size(125, 21);
            this.cbStatus.TabIndex = 7;
            // 
            // cbPriority
            // 
            this.cbPriority.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPriority.Enabled = false;
            this.cbPriority.FormattingEnabled = true;
            this.cbPriority.Location = new System.Drawing.Point(92, 123);
            this.cbPriority.Name = "cbPriority";
            this.cbPriority.Size = new System.Drawing.Size(125, 21);
            this.cbPriority.TabIndex = 9;
            // 
            // cbAssignedTo
            // 
            this.cbAssignedTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAssignedTo.Enabled = false;
            this.cbAssignedTo.FormattingEnabled = true;
            this.cbAssignedTo.Location = new System.Drawing.Point(92, 150);
            this.cbAssignedTo.Name = "cbAssignedTo";
            this.cbAssignedTo.Size = new System.Drawing.Size(125, 21);
            this.cbAssignedTo.TabIndex = 11;
            // 
            // labelTracker
            // 
            this.labelTracker.Location = new System.Drawing.Point(12, 69);
            this.labelTracker.Name = "labelTracker";
            this.labelTracker.Size = new System.Drawing.Size(74, 21);
            this.labelTracker.TabIndex = 4;
            this.labelTracker.Text = "Tracker:";
            this.labelTracker.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelStatus
            // 
            this.labelStatus.Location = new System.Drawing.Point(12, 96);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(74, 19);
            this.labelStatus.TabIndex = 6;
            this.labelStatus.Text = "Status:";
            this.labelStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelPriority
            // 
            this.labelPriority.Location = new System.Drawing.Point(12, 123);
            this.labelPriority.Name = "labelPriority";
            this.labelPriority.Size = new System.Drawing.Size(74, 21);
            this.labelPriority.TabIndex = 8;
            this.labelPriority.Text = "Priority:";
            this.labelPriority.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelAssignedTo
            // 
            this.labelAssignedTo.Location = new System.Drawing.Point(12, 150);
            this.labelAssignedTo.Name = "labelAssignedTo";
            this.labelAssignedTo.Size = new System.Drawing.Size(74, 21);
            this.labelAssignedTo.TabIndex = 10;
            this.labelAssignedTo.Text = "Assigned to:";
            this.labelAssignedTo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbLastUpdate
            // 
            this.tbLastUpdate.Enabled = false;
            this.tbLastUpdate.Location = new System.Drawing.Point(317, 125);
            this.tbLastUpdate.Name = "tbLastUpdate";
            this.tbLastUpdate.ReadOnly = true;
            this.tbLastUpdate.Size = new System.Drawing.Size(125, 20);
            this.tbLastUpdate.TabIndex = 21;
            // 
            // labelLastUpdate
            // 
            this.labelLastUpdate.Location = new System.Drawing.Point(237, 125);
            this.labelLastUpdate.Name = "labelLastUpdate";
            this.labelLastUpdate.Size = new System.Drawing.Size(74, 20);
            this.labelLastUpdate.TabIndex = 20;
            this.labelLastUpdate.Text = "Last update:";
            this.labelLastUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbDescription
            // 
            this.tbDescription.Enabled = false;
            this.tbDescription.Location = new System.Drawing.Point(237, 26);
            this.tbDescription.Multiline = true;
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbDescription.Size = new System.Drawing.Size(205, 41);
            this.tbDescription.TabIndex = 15;
            // 
            // labelDescription
            // 
            this.labelDescription.Location = new System.Drawing.Point(242, 5);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(81, 19);
            this.labelDescription.TabIndex = 14;
            this.labelDescription.Text = "Description:";
            this.labelDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelCreationDate
            // 
            this.labelCreationDate.Location = new System.Drawing.Point(237, 99);
            this.labelCreationDate.Name = "labelCreationDate";
            this.labelCreationDate.Size = new System.Drawing.Size(74, 20);
            this.labelCreationDate.TabIndex = 18;
            this.labelCreationDate.Text = "Creation date:";
            this.labelCreationDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbCreationDate
            // 
            this.tbCreationDate.Enabled = false;
            this.tbCreationDate.Location = new System.Drawing.Point(317, 99);
            this.tbCreationDate.Name = "tbCreationDate";
            this.tbCreationDate.ReadOnly = true;
            this.tbCreationDate.Size = new System.Drawing.Size(125, 20);
            this.tbCreationDate.TabIndex = 19;
            // 
            // tbAuthor
            // 
            this.tbAuthor.Enabled = false;
            this.tbAuthor.Location = new System.Drawing.Point(92, 177);
            this.tbAuthor.Name = "tbAuthor";
            this.tbAuthor.ReadOnly = true;
            this.tbAuthor.Size = new System.Drawing.Size(125, 20);
            this.tbAuthor.TabIndex = 13;
            // 
            // labelAuthor
            // 
            this.labelAuthor.Location = new System.Drawing.Point(12, 176);
            this.labelAuthor.Name = "labelAuthor";
            this.labelAuthor.Size = new System.Drawing.Size(74, 20);
            this.labelAuthor.TabIndex = 12;
            this.labelAuthor.Text = "Author:";
            this.labelAuthor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbStartDate
            // 
            this.tbStartDate.Enabled = false;
            this.tbStartDate.Location = new System.Drawing.Point(317, 73);
            this.tbStartDate.Name = "tbStartDate";
            this.tbStartDate.ReadOnly = true;
            this.tbStartDate.Size = new System.Drawing.Size(125, 20);
            this.tbStartDate.TabIndex = 17;
            // 
            // labelStartDate
            // 
            this.labelStartDate.Location = new System.Drawing.Point(237, 73);
            this.labelStartDate.Name = "labelStartDate";
            this.labelStartDate.Size = new System.Drawing.Size(74, 20);
            this.labelStartDate.TabIndex = 16;
            this.labelStartDate.Text = "Start date:";
            this.labelStartDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelDoneRatio
            // 
            this.labelDoneRatio.Location = new System.Drawing.Point(237, 151);
            this.labelDoneRatio.Name = "labelDoneRatio";
            this.labelDoneRatio.Size = new System.Drawing.Size(74, 20);
            this.labelDoneRatio.TabIndex = 22;
            this.labelDoneRatio.Text = "Done ratio:";
            this.labelDoneRatio.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // nudDoneRatio
            // 
            this.nudDoneRatio.Enabled = false;
            this.nudDoneRatio.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudDoneRatio.Location = new System.Drawing.Point(317, 151);
            this.nudDoneRatio.Name = "nudDoneRatio";
            this.nudDoneRatio.Size = new System.Drawing.Size(99, 20);
            this.nudDoneRatio.TabIndex = 23;
            this.nudDoneRatio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // labelPercentage
            // 
            this.labelPercentage.Location = new System.Drawing.Point(422, 149);
            this.labelPercentage.Name = "labelPercentage";
            this.labelPercentage.Size = new System.Drawing.Size(20, 20);
            this.labelPercentage.TabIndex = 24;
            this.labelPercentage.Text = "%";
            this.labelPercentage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbClosedDate
            // 
            this.tbClosedDate.Enabled = false;
            this.tbClosedDate.Location = new System.Drawing.Point(317, 177);
            this.tbClosedDate.Name = "tbClosedDate";
            this.tbClosedDate.ReadOnly = true;
            this.tbClosedDate.Size = new System.Drawing.Size(125, 20);
            this.tbClosedDate.TabIndex = 26;
            this.tbClosedDate.Visible = false;
            // 
            // labelClosesDate
            // 
            this.labelClosesDate.Location = new System.Drawing.Point(237, 177);
            this.labelClosesDate.Name = "labelClosesDate";
            this.labelClosesDate.Size = new System.Drawing.Size(74, 20);
            this.labelClosesDate.TabIndex = 25;
            this.labelClosesDate.Text = "Closed date:";
            this.labelClosesDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelClosesDate.Visible = false;
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(30, 249);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(96, 23);
            this.btnSave.TabIndex = 29;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnRemoveIssue
            // 
            this.btnRemoveIssue.Enabled = false;
            this.btnRemoveIssue.Location = new System.Drawing.Point(132, 249);
            this.btnRemoveIssue.Name = "btnRemoveIssue";
            this.btnRemoveIssue.Size = new System.Drawing.Size(94, 23);
            this.btnRemoveIssue.TabIndex = 30;
            this.btnRemoveIssue.Text = "Remove issue";
            this.btnRemoveIssue.UseVisualStyleBackColor = true;
            this.btnRemoveIssue.Click += new System.EventHandler(this.btnRemoveIssue_Click);
            // 
            // btnShowHistory
            // 
            this.btnShowHistory.Enabled = false;
            this.btnShowHistory.Location = new System.Drawing.Point(232, 249);
            this.btnShowHistory.Name = "btnShowHistory";
            this.btnShowHistory.Size = new System.Drawing.Size(94, 23);
            this.btnShowHistory.TabIndex = 31;
            this.btnShowHistory.Text = "Show history";
            this.btnShowHistory.UseVisualStyleBackColor = true;
            this.btnShowHistory.Click += new System.EventHandler(this.btnShowHistory_Click);
            // 
            // btnClose
            // 
            this.btnClose.Enabled = false;
            this.btnClose.Location = new System.Drawing.Point(332, 249);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(94, 23);
            this.btnClose.TabIndex = 32;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // cbAddNote
            // 
            this.cbAddNote.AutoSize = true;
            this.cbAddNote.Enabled = false;
            this.cbAddNote.Location = new System.Drawing.Point(18, 204);
            this.cbAddNote.Name = "cbAddNote";
            this.cbAddNote.Size = new System.Drawing.Size(78, 17);
            this.cbAddNote.TabIndex = 27;
            this.cbAddNote.Text = "Add a note";
            this.cbAddNote.UseVisualStyleBackColor = true;
            this.cbAddNote.CheckedChanged += new System.EventHandler(this.cbAddNote_CheckedChanged);
            // 
            // tbAddNote
            // 
            this.tbAddNote.Enabled = false;
            this.tbAddNote.Location = new System.Drawing.Point(13, 222);
            this.tbAddNote.Name = "tbAddNote";
            this.tbAddNote.Size = new System.Drawing.Size(429, 20);
            this.tbAddNote.TabIndex = 28;
            // 
            // IssueInformationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(454, 281);
            this.Controls.Add(this.tbAddNote);
            this.Controls.Add(this.cbAddNote);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnShowHistory);
            this.Controls.Add(this.btnRemoveIssue);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.tbClosedDate);
            this.Controls.Add(this.labelClosesDate);
            this.Controls.Add(this.labelPercentage);
            this.Controls.Add(this.nudDoneRatio);
            this.Controls.Add(this.labelDoneRatio);
            this.Controls.Add(this.tbStartDate);
            this.Controls.Add(this.labelStartDate);
            this.Controls.Add(this.tbAuthor);
            this.Controls.Add(this.labelAuthor);
            this.Controls.Add(this.tbDescription);
            this.Controls.Add(this.labelDescription);
            this.Controls.Add(this.tbLastUpdate);
            this.Controls.Add(this.tbCreationDate);
            this.Controls.Add(this.labelLastUpdate);
            this.Controls.Add(this.labelCreationDate);
            this.Controls.Add(this.labelAssignedTo);
            this.Controls.Add(this.labelPriority);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.labelTracker);
            this.Controls.Add(this.cbAssignedTo);
            this.Controls.Add(this.cbPriority);
            this.Controls.Add(this.cbStatus);
            this.Controls.Add(this.cbTracker);
            this.Controls.Add(this.tbSubject);
            this.Controls.Add(this.labelSubject);
            this.Controls.Add(this.tbID);
            this.Controls.Add(this.labelID);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "IssueInformationForm";
            this.ShowInTaskbar = false;
            this.Text = "Issue information [please, wait..]";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.IssueInformationForm_FormClosing);
            this.Shown += new System.EventHandler(this.IssueInformationForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.nudDoneRatio)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbSubject;
        private System.Windows.Forms.Label labelSubject;
        private System.Windows.Forms.TextBox tbID;
        private System.Windows.Forms.Label labelID;
        private System.Windows.Forms.ComboBox cbTracker;
        private System.Windows.Forms.ComboBox cbStatus;
        private System.Windows.Forms.ComboBox cbPriority;
        private System.Windows.Forms.ComboBox cbAssignedTo;
        private System.Windows.Forms.Label labelTracker;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Label labelPriority;
        private System.Windows.Forms.Label labelAssignedTo;
        private System.Windows.Forms.TextBox tbLastUpdate;
        private System.Windows.Forms.Label labelLastUpdate;
        private System.Windows.Forms.TextBox tbDescription;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.Label labelCreationDate;
        private System.Windows.Forms.TextBox tbCreationDate;
        private System.Windows.Forms.TextBox tbAuthor;
        private System.Windows.Forms.Label labelAuthor;
        private System.Windows.Forms.TextBox tbStartDate;
        private System.Windows.Forms.Label labelStartDate;
        private System.Windows.Forms.Label labelDoneRatio;
        private System.Windows.Forms.NumericUpDown nudDoneRatio;
        private System.Windows.Forms.Label labelPercentage;
        private System.Windows.Forms.TextBox tbClosedDate;
        private System.Windows.Forms.Label labelClosesDate;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnRemoveIssue;
        private System.Windows.Forms.Button btnShowHistory;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.CheckBox cbAddNote;
        private System.Windows.Forms.TextBox tbAddNote;

    }
}