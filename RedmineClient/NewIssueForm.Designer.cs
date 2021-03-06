﻿namespace RedmineClient
{
    partial class NewIssueForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewIssueForm));
            this.labelTracker = new System.Windows.Forms.Label();
            this.cbTrackers = new System.Windows.Forms.ComboBox();
            this.tbDescription = new System.Windows.Forms.TextBox();
            this.labelDescription = new System.Windows.Forms.Label();
            this.cbPriorities = new System.Windows.Forms.ComboBox();
            this.labelPriority = new System.Windows.Forms.Label();
            this.cbAssignee = new System.Windows.Forms.ComboBox();
            this.labelAssignee = new System.Windows.Forms.Label();
            this.labelProject = new System.Windows.Forms.Label();
            this.cblWatchers = new System.Windows.Forms.CheckedListBox();
            this.labelWatchers = new System.Windows.Forms.Label();
            this.labelInfo = new System.Windows.Forms.Label();
            this.labelSubject = new System.Windows.Forms.Label();
            this.tbSubject = new System.Windows.Forms.TextBox();
            this.btnCreateIssue = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.cbIsPrivate = new System.Windows.Forms.CheckBox();
            this.labelStartDate = new System.Windows.Forms.Label();
            this.labelDueDate = new System.Windows.Forms.Label();
            this.labelPercentage = new System.Windows.Forms.Label();
            this.nudDoneRatio = new System.Windows.Forms.NumericUpDown();
            this.labelDoneRatio = new System.Windows.Forms.Label();
            this.nudEstimatedTime = new System.Windows.Forms.NumericUpDown();
            this.labelHours = new System.Windows.Forms.Label();
            this.labelEstimatedTime = new System.Windows.Forms.Label();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.dtpDueDate = new System.Windows.Forms.DateTimePicker();
            this.btnResetDueDate = new System.Windows.Forms.Button();
            this.cbProjects = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudDoneRatio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudEstimatedTime)).BeginInit();
            this.SuspendLayout();
            // 
            // labelTracker
            // 
            this.labelTracker.Location = new System.Drawing.Point(12, 59);
            this.labelTracker.Name = "labelTracker";
            this.labelTracker.Size = new System.Drawing.Size(54, 21);
            this.labelTracker.TabIndex = 3;
            this.labelTracker.Text = "Tracker*:";
            this.labelTracker.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbTrackers
            // 
            this.cbTrackers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTrackers.Enabled = false;
            this.cbTrackers.FormattingEnabled = true;
            this.cbTrackers.Location = new System.Drawing.Point(71, 59);
            this.cbTrackers.Name = "cbTrackers";
            this.cbTrackers.Size = new System.Drawing.Size(121, 21);
            this.cbTrackers.TabIndex = 4;
            // 
            // tbDescription
            // 
            this.tbDescription.Enabled = false;
            this.tbDescription.Location = new System.Drawing.Point(12, 126);
            this.tbDescription.Multiline = true;
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbDescription.Size = new System.Drawing.Size(373, 53);
            this.tbDescription.TabIndex = 13;
            // 
            // labelDescription
            // 
            this.labelDescription.Location = new System.Drawing.Point(15, 107);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(64, 16);
            this.labelDescription.TabIndex = 12;
            this.labelDescription.Text = "Description:";
            this.labelDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbPriorities
            // 
            this.cbPriorities.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPriorities.Enabled = false;
            this.cbPriorities.FormattingEnabled = true;
            this.cbPriorities.Location = new System.Drawing.Point(264, 32);
            this.cbPriorities.Name = "cbPriorities";
            this.cbPriorities.Size = new System.Drawing.Size(121, 21);
            this.cbPriorities.TabIndex = 8;
            // 
            // labelPriority
            // 
            this.labelPriority.Location = new System.Drawing.Point(207, 32);
            this.labelPriority.Name = "labelPriority";
            this.labelPriority.Size = new System.Drawing.Size(54, 21);
            this.labelPriority.TabIndex = 7;
            this.labelPriority.Text = "Priority*:";
            this.labelPriority.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbAssignee
            // 
            this.cbAssignee.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAssignee.Enabled = false;
            this.cbAssignee.FormattingEnabled = true;
            this.cbAssignee.Location = new System.Drawing.Point(264, 59);
            this.cbAssignee.Name = "cbAssignee";
            this.cbAssignee.Size = new System.Drawing.Size(121, 21);
            this.cbAssignee.TabIndex = 10;
            // 
            // labelAssignee
            // 
            this.labelAssignee.Location = new System.Drawing.Point(206, 59);
            this.labelAssignee.Name = "labelAssignee";
            this.labelAssignee.Size = new System.Drawing.Size(54, 21);
            this.labelAssignee.TabIndex = 9;
            this.labelAssignee.Text = "Assignee:";
            this.labelAssignee.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelProject
            // 
            this.labelProject.Location = new System.Drawing.Point(12, 32);
            this.labelProject.Name = "labelProject";
            this.labelProject.Size = new System.Drawing.Size(54, 21);
            this.labelProject.TabIndex = 1;
            this.labelProject.Text = "Project*:";
            this.labelProject.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cblWatchers
            // 
            this.cblWatchers.Enabled = false;
            this.cblWatchers.FormattingEnabled = true;
            this.cblWatchers.Location = new System.Drawing.Point(12, 254);
            this.cblWatchers.MultiColumn = true;
            this.cblWatchers.Name = "cblWatchers";
            this.cblWatchers.Size = new System.Drawing.Size(373, 64);
            this.cblWatchers.TabIndex = 26;
            // 
            // labelWatchers
            // 
            this.labelWatchers.Location = new System.Drawing.Point(15, 236);
            this.labelWatchers.Name = "labelWatchers";
            this.labelWatchers.Size = new System.Drawing.Size(64, 16);
            this.labelWatchers.TabIndex = 25;
            this.labelWatchers.Text = "Watchers:";
            this.labelWatchers.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelInfo
            // 
            this.labelInfo.Location = new System.Drawing.Point(12, 6);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(381, 19);
            this.labelInfo.TabIndex = 0;
            this.labelInfo.Text = "Required fields are indicated with an asterisk (*).";
            this.labelInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelSubject
            // 
            this.labelSubject.Location = new System.Drawing.Point(12, 86);
            this.labelSubject.Name = "labelSubject";
            this.labelSubject.Size = new System.Drawing.Size(54, 20);
            this.labelSubject.TabIndex = 5;
            this.labelSubject.Text = "Subject*:";
            this.labelSubject.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbSubject
            // 
            this.tbSubject.Enabled = false;
            this.tbSubject.Location = new System.Drawing.Point(71, 86);
            this.tbSubject.Name = "tbSubject";
            this.tbSubject.Size = new System.Drawing.Size(121, 20);
            this.tbSubject.TabIndex = 6;
            // 
            // btnCreateIssue
            // 
            this.btnCreateIssue.Enabled = false;
            this.btnCreateIssue.Location = new System.Drawing.Point(229, 324);
            this.btnCreateIssue.Name = "btnCreateIssue";
            this.btnCreateIssue.Size = new System.Drawing.Size(75, 23);
            this.btnCreateIssue.TabIndex = 27;
            this.btnCreateIssue.Text = "Create issue";
            this.btnCreateIssue.UseVisualStyleBackColor = true;
            this.btnCreateIssue.Click += new System.EventHandler(this.btnCreateIssue_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Enabled = false;
            this.btnCancel.Location = new System.Drawing.Point(310, 324);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 28;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // cbIsPrivate
            // 
            this.cbIsPrivate.AutoSize = true;
            this.cbIsPrivate.Enabled = false;
            this.cbIsPrivate.Location = new System.Drawing.Point(208, 86);
            this.cbIsPrivate.Name = "cbIsPrivate";
            this.cbIsPrivate.Size = new System.Drawing.Size(134, 17);
            this.cbIsPrivate.TabIndex = 11;
            this.cbIsPrivate.Text = "Make this issue private";
            this.cbIsPrivate.UseVisualStyleBackColor = true;
            // 
            // labelStartDate
            // 
            this.labelStartDate.Location = new System.Drawing.Point(12, 187);
            this.labelStartDate.Name = "labelStartDate";
            this.labelStartDate.Size = new System.Drawing.Size(60, 20);
            this.labelStartDate.TabIndex = 14;
            this.labelStartDate.Text = "Start date*:";
            this.labelStartDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelDueDate
            // 
            this.labelDueDate.Location = new System.Drawing.Point(205, 187);
            this.labelDueDate.Name = "labelDueDate";
            this.labelDueDate.Size = new System.Drawing.Size(57, 20);
            this.labelDueDate.TabIndex = 16;
            this.labelDueDate.Text = "Due date:";
            this.labelDueDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelPercentage
            // 
            this.labelPercentage.Location = new System.Drawing.Point(365, 213);
            this.labelPercentage.Name = "labelPercentage";
            this.labelPercentage.Size = new System.Drawing.Size(20, 20);
            this.labelPercentage.TabIndex = 24;
            this.labelPercentage.Text = "%";
            this.labelPercentage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nudDoneRatio
            // 
            this.nudDoneRatio.Enabled = false;
            this.nudDoneRatio.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudDoneRatio.Location = new System.Drawing.Point(290, 212);
            this.nudDoneRatio.Name = "nudDoneRatio";
            this.nudDoneRatio.Size = new System.Drawing.Size(69, 20);
            this.nudDoneRatio.TabIndex = 23;
            this.nudDoneRatio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // labelDoneRatio
            // 
            this.labelDoneRatio.Location = new System.Drawing.Point(223, 212);
            this.labelDoneRatio.Name = "labelDoneRatio";
            this.labelDoneRatio.Size = new System.Drawing.Size(61, 20);
            this.labelDoneRatio.TabIndex = 22;
            this.labelDoneRatio.Text = "Done ratio:";
            this.labelDoneRatio.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // nudEstimatedTime
            // 
            this.nudEstimatedTime.Enabled = false;
            this.nudEstimatedTime.Location = new System.Drawing.Point(98, 212);
            this.nudEstimatedTime.Maximum = new decimal(new int[] {
            9000,
            0,
            0,
            0});
            this.nudEstimatedTime.Name = "nudEstimatedTime";
            this.nudEstimatedTime.Size = new System.Drawing.Size(69, 20);
            this.nudEstimatedTime.TabIndex = 20;
            this.nudEstimatedTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // labelHours
            // 
            this.labelHours.Location = new System.Drawing.Point(173, 212);
            this.labelHours.Name = "labelHours";
            this.labelHours.Size = new System.Drawing.Size(38, 20);
            this.labelHours.TabIndex = 21;
            this.labelHours.Text = "hours";
            this.labelHours.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelEstimatedTime
            // 
            this.labelEstimatedTime.Location = new System.Drawing.Point(12, 212);
            this.labelEstimatedTime.Name = "labelEstimatedTime";
            this.labelEstimatedTime.Size = new System.Drawing.Size(80, 20);
            this.labelEstimatedTime.TabIndex = 19;
            this.labelEstimatedTime.Text = "Estimated time:";
            this.labelEstimatedTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.CustomFormat = " ";
            this.dtpStartDate.Enabled = false;
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartDate.Location = new System.Drawing.Point(71, 187);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(121, 20);
            this.dtpStartDate.TabIndex = 15;
            this.dtpStartDate.ValueChanged += new System.EventHandler(this.dateTimePicker_ValueChanged);
            // 
            // dtpDueDate
            // 
            this.dtpDueDate.CustomFormat = " ";
            this.dtpDueDate.Enabled = false;
            this.dtpDueDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDueDate.Location = new System.Drawing.Point(260, 187);
            this.dtpDueDate.Name = "dtpDueDate";
            this.dtpDueDate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dtpDueDate.Size = new System.Drawing.Size(99, 20);
            this.dtpDueDate.TabIndex = 17;
            this.dtpDueDate.Value = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpDueDate.ValueChanged += new System.EventHandler(this.dateTimePicker_ValueChanged);
            this.dtpDueDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtpDueDate_KeyDown);
            this.dtpDueDate.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dtpDueDate_MouseDown);
            // 
            // btnResetDueDate
            // 
            this.btnResetDueDate.Enabled = false;
            this.btnResetDueDate.Image = ((System.Drawing.Image)(resources.GetObject("btnResetDueDate.Image")));
            this.btnResetDueDate.Location = new System.Drawing.Point(365, 189);
            this.btnResetDueDate.Name = "btnResetDueDate";
            this.btnResetDueDate.Size = new System.Drawing.Size(20, 20);
            this.btnResetDueDate.TabIndex = 18;
            this.btnResetDueDate.UseVisualStyleBackColor = true;
            this.btnResetDueDate.Click += new System.EventHandler(this.btnResetDueDate_Click);
            // 
            // cbProjects
            // 
            this.cbProjects.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbProjects.Enabled = false;
            this.cbProjects.FormattingEnabled = true;
            this.cbProjects.Location = new System.Drawing.Point(71, 32);
            this.cbProjects.Name = "cbProjects";
            this.cbProjects.Size = new System.Drawing.Size(121, 21);
            this.cbProjects.TabIndex = 2;
            this.cbProjects.SelectedIndexChanged += new System.EventHandler(this.cbProject_SelectedIndexChanged);
            // 
            // NewIssueForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(397, 354);
            this.Controls.Add(this.cbProjects);
            this.Controls.Add(this.btnResetDueDate);
            this.Controls.Add(this.dtpDueDate);
            this.Controls.Add(this.dtpStartDate);
            this.Controls.Add(this.labelPercentage);
            this.Controls.Add(this.nudDoneRatio);
            this.Controls.Add(this.labelDoneRatio);
            this.Controls.Add(this.nudEstimatedTime);
            this.Controls.Add(this.labelHours);
            this.Controls.Add(this.labelEstimatedTime);
            this.Controls.Add(this.labelDueDate);
            this.Controls.Add(this.labelStartDate);
            this.Controls.Add(this.cbIsPrivate);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnCreateIssue);
            this.Controls.Add(this.labelInfo);
            this.Controls.Add(this.labelWatchers);
            this.Controls.Add(this.cblWatchers);
            this.Controls.Add(this.labelProject);
            this.Controls.Add(this.cbAssignee);
            this.Controls.Add(this.labelAssignee);
            this.Controls.Add(this.cbPriorities);
            this.Controls.Add(this.labelPriority);
            this.Controls.Add(this.tbDescription);
            this.Controls.Add(this.labelDescription);
            this.Controls.Add(this.tbSubject);
            this.Controls.Add(this.labelSubject);
            this.Controls.Add(this.cbTrackers);
            this.Controls.Add(this.labelTracker);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "NewIssueForm";
            this.Text = "New issue [please, wait..]";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CreateNewIssueForm_FormClosing);
            this.Shown += new System.EventHandler(this.CreateNewIssueForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.nudDoneRatio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudEstimatedTime)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTracker;
        private System.Windows.Forms.ComboBox cbTrackers;
        private System.Windows.Forms.TextBox tbDescription;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.ComboBox cbPriorities;
        private System.Windows.Forms.Label labelPriority;
        private System.Windows.Forms.ComboBox cbAssignee;
        private System.Windows.Forms.Label labelAssignee;
        private System.Windows.Forms.Label labelProject;
        private System.Windows.Forms.CheckedListBox cblWatchers;
        private System.Windows.Forms.Label labelWatchers;
        private System.Windows.Forms.Label labelInfo;
        private System.Windows.Forms.Label labelSubject;
        private System.Windows.Forms.TextBox tbSubject;
        private System.Windows.Forms.Button btnCreateIssue;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.CheckBox cbIsPrivate;
        private System.Windows.Forms.Label labelStartDate;
        private System.Windows.Forms.Label labelDueDate;
        private System.Windows.Forms.Label labelPercentage;
        private System.Windows.Forms.NumericUpDown nudDoneRatio;
        private System.Windows.Forms.Label labelDoneRatio;
        private System.Windows.Forms.NumericUpDown nudEstimatedTime;
        private System.Windows.Forms.Label labelHours;
        private System.Windows.Forms.Label labelEstimatedTime;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.DateTimePicker dtpDueDate;
        private System.Windows.Forms.Button btnResetDueDate;
        private System.Windows.Forms.ComboBox cbProjects;
    }
}