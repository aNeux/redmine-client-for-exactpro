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
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageInfo = new System.Windows.Forms.TabPage();
            this.cbIsPrivate = new System.Windows.Forms.CheckBox();
            this.tbClosedDate = new System.Windows.Forms.TextBox();
            this.labelClosesDate = new System.Windows.Forms.Label();
            this.nudEstimatedTime = new System.Windows.Forms.NumericUpDown();
            this.labelHours = new System.Windows.Forms.Label();
            this.labelEstimatedTime = new System.Windows.Forms.Label();
            this.btnResetDueDate = new System.Windows.Forms.Button();
            this.dtpDueDate = new System.Windows.Forms.DateTimePicker();
            this.labelDueDate = new System.Windows.Forms.Label();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.tbLastUpdate = new System.Windows.Forms.TextBox();
            this.tbCreationDate = new System.Windows.Forms.TextBox();
            this.labelLastUpdate = new System.Windows.Forms.Label();
            this.labelCreationDate = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbProject = new System.Windows.Forms.ComboBox();
            this.tbSubject = new System.Windows.Forms.TextBox();
            this.labelSubject = new System.Windows.Forms.Label();
            this.cbIsNotePrivate = new System.Windows.Forms.CheckBox();
            this.tbAddNote = new System.Windows.Forms.TextBox();
            this.cbAddNote = new System.Windows.Forms.CheckBox();
            this.labelPercentage = new System.Windows.Forms.Label();
            this.nudDoneRatio = new System.Windows.Forms.NumericUpDown();
            this.labelDoneRatio = new System.Windows.Forms.Label();
            this.tbAuthor = new System.Windows.Forms.TextBox();
            this.labelAuthor = new System.Windows.Forms.Label();
            this.tbDescription = new System.Windows.Forms.TextBox();
            this.labelDescription = new System.Windows.Forms.Label();
            this.labelAssignedTo = new System.Windows.Forms.Label();
            this.labelPriority = new System.Windows.Forms.Label();
            this.labelStatus = new System.Windows.Forms.Label();
            this.labelTracker = new System.Windows.Forms.Label();
            this.cbAssignedTo = new System.Windows.Forms.ComboBox();
            this.cbPriority = new System.Windows.Forms.ComboBox();
            this.cbStatus = new System.Windows.Forms.ComboBox();
            this.cbTracker = new System.Windows.Forms.ComboBox();
            this.tbID = new System.Windows.Forms.TextBox();
            this.labelID = new System.Windows.Forms.Label();
            this.tabPageHistory = new System.Windows.Forms.TabPage();
            this.tbHistory = new System.Windows.Forms.TextBox();
            this.tabControl.SuspendLayout();
            this.tabPageInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudEstimatedTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDoneRatio)).BeginInit();
            this.tabPageHistory.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(314, 341);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 40;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Enabled = false;
            this.btnClose.Location = new System.Drawing.Point(395, 341);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 41;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageInfo);
            this.tabControl.Controls.Add(this.tabPageHistory);
            this.tabControl.Enabled = false;
            this.tabControl.Location = new System.Drawing.Point(13, 12);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(457, 325);
            this.tabControl.TabIndex = 0;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);
            // 
            // tabPageInfo
            // 
            this.tabPageInfo.Controls.Add(this.cbIsPrivate);
            this.tabPageInfo.Controls.Add(this.tbClosedDate);
            this.tabPageInfo.Controls.Add(this.labelClosesDate);
            this.tabPageInfo.Controls.Add(this.nudEstimatedTime);
            this.tabPageInfo.Controls.Add(this.labelHours);
            this.tabPageInfo.Controls.Add(this.labelEstimatedTime);
            this.tabPageInfo.Controls.Add(this.btnResetDueDate);
            this.tabPageInfo.Controls.Add(this.dtpDueDate);
            this.tabPageInfo.Controls.Add(this.labelDueDate);
            this.tabPageInfo.Controls.Add(this.dtpStartDate);
            this.tabPageInfo.Controls.Add(this.label2);
            this.tabPageInfo.Controls.Add(this.tbLastUpdate);
            this.tabPageInfo.Controls.Add(this.tbCreationDate);
            this.tabPageInfo.Controls.Add(this.labelLastUpdate);
            this.tabPageInfo.Controls.Add(this.labelCreationDate);
            this.tabPageInfo.Controls.Add(this.label1);
            this.tabPageInfo.Controls.Add(this.cbProject);
            this.tabPageInfo.Controls.Add(this.tbSubject);
            this.tabPageInfo.Controls.Add(this.labelSubject);
            this.tabPageInfo.Controls.Add(this.cbIsNotePrivate);
            this.tabPageInfo.Controls.Add(this.tbAddNote);
            this.tabPageInfo.Controls.Add(this.cbAddNote);
            this.tabPageInfo.Controls.Add(this.labelPercentage);
            this.tabPageInfo.Controls.Add(this.nudDoneRatio);
            this.tabPageInfo.Controls.Add(this.labelDoneRatio);
            this.tabPageInfo.Controls.Add(this.tbAuthor);
            this.tabPageInfo.Controls.Add(this.labelAuthor);
            this.tabPageInfo.Controls.Add(this.tbDescription);
            this.tabPageInfo.Controls.Add(this.labelDescription);
            this.tabPageInfo.Controls.Add(this.labelAssignedTo);
            this.tabPageInfo.Controls.Add(this.labelPriority);
            this.tabPageInfo.Controls.Add(this.labelStatus);
            this.tabPageInfo.Controls.Add(this.labelTracker);
            this.tabPageInfo.Controls.Add(this.cbAssignedTo);
            this.tabPageInfo.Controls.Add(this.cbPriority);
            this.tabPageInfo.Controls.Add(this.cbStatus);
            this.tabPageInfo.Controls.Add(this.cbTracker);
            this.tabPageInfo.Controls.Add(this.tbID);
            this.tabPageInfo.Controls.Add(this.labelID);
            this.tabPageInfo.Location = new System.Drawing.Point(4, 22);
            this.tabPageInfo.Name = "tabPageInfo";
            this.tabPageInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageInfo.Size = new System.Drawing.Size(449, 299);
            this.tabPageInfo.TabIndex = 0;
            this.tabPageInfo.Text = "Information";
            this.tabPageInfo.UseVisualStyleBackColor = true;
            // 
            // cbIsPrivate
            // 
            this.cbIsPrivate.AutoSize = true;
            this.cbIsPrivate.Enabled = false;
            this.cbIsPrivate.Location = new System.Drawing.Point(232, 96);
            this.cbIsPrivate.Name = "cbIsPrivate";
            this.cbIsPrivate.Size = new System.Drawing.Size(115, 17);
            this.cbIsPrivate.TabIndex = 22;
            this.cbIsPrivate.Text = "Is this issue private";
            this.cbIsPrivate.UseVisualStyleBackColor = true;
            // 
            // tbClosedDate
            // 
            this.tbClosedDate.Enabled = false;
            this.tbClosedDate.Location = new System.Drawing.Point(314, 271);
            this.tbClosedDate.Name = "tbClosedDate";
            this.tbClosedDate.ReadOnly = true;
            this.tbClosedDate.Size = new System.Drawing.Size(125, 20);
            this.tbClosedDate.TabIndex = 39;
            this.tbClosedDate.Visible = false;
            // 
            // labelClosesDate
            // 
            this.labelClosesDate.Location = new System.Drawing.Point(232, 271);
            this.labelClosesDate.Name = "labelClosesDate";
            this.labelClosesDate.Size = new System.Drawing.Size(74, 20);
            this.labelClosesDate.TabIndex = 38;
            this.labelClosesDate.Text = "Closed date:";
            this.labelClosesDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelClosesDate.Visible = false;
            // 
            // nudEstimatedTime
            // 
            this.nudEstimatedTime.Enabled = false;
            this.nudEstimatedTime.Location = new System.Drawing.Point(314, 167);
            this.nudEstimatedTime.Maximum = new decimal(new int[] {
            9000,
            0,
            0,
            0});
            this.nudEstimatedTime.Name = "nudEstimatedTime";
            this.nudEstimatedTime.Size = new System.Drawing.Size(82, 20);
            this.nudEstimatedTime.TabIndex = 29;
            this.nudEstimatedTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // labelHours
            // 
            this.labelHours.Location = new System.Drawing.Point(402, 167);
            this.labelHours.Name = "labelHours";
            this.labelHours.Size = new System.Drawing.Size(37, 20);
            this.labelHours.TabIndex = 30;
            this.labelHours.Text = "hours";
            this.labelHours.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelEstimatedTime
            // 
            this.labelEstimatedTime.Location = new System.Drawing.Point(232, 167);
            this.labelEstimatedTime.Name = "labelEstimatedTime";
            this.labelEstimatedTime.Size = new System.Drawing.Size(84, 20);
            this.labelEstimatedTime.TabIndex = 28;
            this.labelEstimatedTime.Text = "Estimated time:";
            this.labelEstimatedTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnResetDueDate
            // 
            this.btnResetDueDate.Enabled = false;
            this.btnResetDueDate.Image = ((System.Drawing.Image)(resources.GetObject("btnResetDueDate.Image")));
            this.btnResetDueDate.Location = new System.Drawing.Point(419, 141);
            this.btnResetDueDate.Name = "btnResetDueDate";
            this.btnResetDueDate.Size = new System.Drawing.Size(20, 20);
            this.btnResetDueDate.TabIndex = 27;
            this.btnResetDueDate.UseVisualStyleBackColor = true;
            this.btnResetDueDate.Click += new System.EventHandler(this.btnResetDueDate_Click);
            // 
            // dtpDueDate
            // 
            this.dtpDueDate.CustomFormat = " ";
            this.dtpDueDate.Enabled = false;
            this.dtpDueDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDueDate.Location = new System.Drawing.Point(314, 141);
            this.dtpDueDate.Name = "dtpDueDate";
            this.dtpDueDate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dtpDueDate.Size = new System.Drawing.Size(99, 20);
            this.dtpDueDate.TabIndex = 26;
            this.dtpDueDate.Value = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpDueDate.ValueChanged += new System.EventHandler(this.dateTimePicker_ValueChanged);
            this.dtpDueDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtpDueDate_KeyDown);
            this.dtpDueDate.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dtpDueDate_MouseDown);
            // 
            // labelDueDate
            // 
            this.labelDueDate.Location = new System.Drawing.Point(232, 141);
            this.labelDueDate.Name = "labelDueDate";
            this.labelDueDate.Size = new System.Drawing.Size(75, 20);
            this.labelDueDate.TabIndex = 25;
            this.labelDueDate.Text = "Due date:";
            this.labelDueDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.CustomFormat = " ";
            this.dtpStartDate.Enabled = false;
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartDate.Location = new System.Drawing.Point(314, 116);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(125, 20);
            this.dtpStartDate.TabIndex = 24;
            this.dtpStartDate.ValueChanged += new System.EventHandler(this.dateTimePicker_ValueChanged);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(232, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 20);
            this.label2.TabIndex = 23;
            this.label2.Text = "Start date:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbLastUpdate
            // 
            this.tbLastUpdate.Enabled = false;
            this.tbLastUpdate.Location = new System.Drawing.Point(314, 245);
            this.tbLastUpdate.Name = "tbLastUpdate";
            this.tbLastUpdate.ReadOnly = true;
            this.tbLastUpdate.Size = new System.Drawing.Size(125, 20);
            this.tbLastUpdate.TabIndex = 37;
            // 
            // tbCreationDate
            // 
            this.tbCreationDate.Enabled = false;
            this.tbCreationDate.Location = new System.Drawing.Point(314, 219);
            this.tbCreationDate.Name = "tbCreationDate";
            this.tbCreationDate.ReadOnly = true;
            this.tbCreationDate.Size = new System.Drawing.Size(125, 20);
            this.tbCreationDate.TabIndex = 35;
            // 
            // labelLastUpdate
            // 
            this.labelLastUpdate.Location = new System.Drawing.Point(232, 245);
            this.labelLastUpdate.Name = "labelLastUpdate";
            this.labelLastUpdate.Size = new System.Drawing.Size(74, 20);
            this.labelLastUpdate.TabIndex = 36;
            this.labelLastUpdate.Text = "Last update:";
            this.labelLastUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelCreationDate
            // 
            this.labelCreationDate.Location = new System.Drawing.Point(232, 219);
            this.labelCreationDate.Name = "labelCreationDate";
            this.labelCreationDate.Size = new System.Drawing.Size(74, 20);
            this.labelCreationDate.TabIndex = 34;
            this.labelCreationDate.Text = "Creation date:";
            this.labelCreationDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(7, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 21);
            this.label1.TabIndex = 3;
            this.label1.Text = "Project:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbProject
            // 
            this.cbProject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbProject.Enabled = false;
            this.cbProject.FormattingEnabled = true;
            this.cbProject.Location = new System.Drawing.Point(87, 35);
            this.cbProject.Name = "cbProject";
            this.cbProject.Size = new System.Drawing.Size(125, 21);
            this.cbProject.TabIndex = 4;
            // 
            // tbSubject
            // 
            this.tbSubject.Enabled = false;
            this.tbSubject.Location = new System.Drawing.Point(314, 9);
            this.tbSubject.Name = "tbSubject";
            this.tbSubject.Size = new System.Drawing.Size(125, 20);
            this.tbSubject.TabIndex = 19;
            // 
            // labelSubject
            // 
            this.labelSubject.Location = new System.Drawing.Point(229, 9);
            this.labelSubject.Name = "labelSubject";
            this.labelSubject.Size = new System.Drawing.Size(74, 20);
            this.labelSubject.TabIndex = 18;
            this.labelSubject.Text = "Subject:";
            this.labelSubject.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbIsNotePrivate
            // 
            this.cbIsNotePrivate.AutoSize = true;
            this.cbIsNotePrivate.Enabled = false;
            this.cbIsNotePrivate.Location = new System.Drawing.Point(92, 197);
            this.cbIsNotePrivate.Name = "cbIsNotePrivate";
            this.cbIsNotePrivate.Size = new System.Drawing.Size(112, 17);
            this.cbIsNotePrivate.TabIndex = 16;
            this.cbIsNotePrivate.Text = "Make note private";
            this.cbIsNotePrivate.UseVisualStyleBackColor = true;
            // 
            // tbAddNote
            // 
            this.tbAddNote.Enabled = false;
            this.tbAddNote.Location = new System.Drawing.Point(10, 215);
            this.tbAddNote.Multiline = true;
            this.tbAddNote.Name = "tbAddNote";
            this.tbAddNote.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbAddNote.Size = new System.Drawing.Size(202, 76);
            this.tbAddNote.TabIndex = 17;
            // 
            // cbAddNote
            // 
            this.cbAddNote.AutoSize = true;
            this.cbAddNote.Enabled = false;
            this.cbAddNote.Location = new System.Drawing.Point(13, 197);
            this.cbAddNote.Name = "cbAddNote";
            this.cbAddNote.Size = new System.Drawing.Size(78, 17);
            this.cbAddNote.TabIndex = 15;
            this.cbAddNote.Text = "Add a note";
            this.cbAddNote.UseVisualStyleBackColor = true;
            this.cbAddNote.CheckedChanged += new System.EventHandler(this.cbAddNote_CheckedChanged);
            // 
            // labelPercentage
            // 
            this.labelPercentage.Location = new System.Drawing.Point(419, 192);
            this.labelPercentage.Name = "labelPercentage";
            this.labelPercentage.Size = new System.Drawing.Size(20, 20);
            this.labelPercentage.TabIndex = 33;
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
            this.nudDoneRatio.Location = new System.Drawing.Point(314, 193);
            this.nudDoneRatio.Name = "nudDoneRatio";
            this.nudDoneRatio.Size = new System.Drawing.Size(99, 20);
            this.nudDoneRatio.TabIndex = 32;
            this.nudDoneRatio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // labelDoneRatio
            // 
            this.labelDoneRatio.Location = new System.Drawing.Point(232, 193);
            this.labelDoneRatio.Name = "labelDoneRatio";
            this.labelDoneRatio.Size = new System.Drawing.Size(74, 20);
            this.labelDoneRatio.TabIndex = 31;
            this.labelDoneRatio.Text = "Done ratio:";
            this.labelDoneRatio.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbAuthor
            // 
            this.tbAuthor.Enabled = false;
            this.tbAuthor.Location = new System.Drawing.Point(87, 170);
            this.tbAuthor.Name = "tbAuthor";
            this.tbAuthor.ReadOnly = true;
            this.tbAuthor.Size = new System.Drawing.Size(125, 20);
            this.tbAuthor.TabIndex = 14;
            // 
            // labelAuthor
            // 
            this.labelAuthor.Location = new System.Drawing.Point(7, 169);
            this.labelAuthor.Name = "labelAuthor";
            this.labelAuthor.Size = new System.Drawing.Size(74, 20);
            this.labelAuthor.TabIndex = 13;
            this.labelAuthor.Text = "Author:";
            this.labelAuthor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbDescription
            // 
            this.tbDescription.Enabled = false;
            this.tbDescription.Location = new System.Drawing.Point(232, 50);
            this.tbDescription.Multiline = true;
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbDescription.Size = new System.Drawing.Size(207, 41);
            this.tbDescription.TabIndex = 21;
            // 
            // labelDescription
            // 
            this.labelDescription.Location = new System.Drawing.Point(235, 28);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(81, 19);
            this.labelDescription.TabIndex = 20;
            this.labelDescription.Text = "Description:";
            this.labelDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelAssignedTo
            // 
            this.labelAssignedTo.Location = new System.Drawing.Point(7, 143);
            this.labelAssignedTo.Name = "labelAssignedTo";
            this.labelAssignedTo.Size = new System.Drawing.Size(74, 21);
            this.labelAssignedTo.TabIndex = 11;
            this.labelAssignedTo.Text = "Assigned to:";
            this.labelAssignedTo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelPriority
            // 
            this.labelPriority.Location = new System.Drawing.Point(7, 116);
            this.labelPriority.Name = "labelPriority";
            this.labelPriority.Size = new System.Drawing.Size(74, 21);
            this.labelPriority.TabIndex = 9;
            this.labelPriority.Text = "Priority:";
            this.labelPriority.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelStatus
            // 
            this.labelStatus.Location = new System.Drawing.Point(7, 89);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(74, 19);
            this.labelStatus.TabIndex = 7;
            this.labelStatus.Text = "Status:";
            this.labelStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelTracker
            // 
            this.labelTracker.Location = new System.Drawing.Point(7, 62);
            this.labelTracker.Name = "labelTracker";
            this.labelTracker.Size = new System.Drawing.Size(74, 21);
            this.labelTracker.TabIndex = 5;
            this.labelTracker.Text = "Tracker:";
            this.labelTracker.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbAssignedTo
            // 
            this.cbAssignedTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAssignedTo.Enabled = false;
            this.cbAssignedTo.FormattingEnabled = true;
            this.cbAssignedTo.Location = new System.Drawing.Point(87, 143);
            this.cbAssignedTo.Name = "cbAssignedTo";
            this.cbAssignedTo.Size = new System.Drawing.Size(125, 21);
            this.cbAssignedTo.TabIndex = 12;
            // 
            // cbPriority
            // 
            this.cbPriority.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPriority.Enabled = false;
            this.cbPriority.FormattingEnabled = true;
            this.cbPriority.Location = new System.Drawing.Point(87, 116);
            this.cbPriority.Name = "cbPriority";
            this.cbPriority.Size = new System.Drawing.Size(125, 21);
            this.cbPriority.TabIndex = 10;
            // 
            // cbStatus
            // 
            this.cbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStatus.Enabled = false;
            this.cbStatus.FormattingEnabled = true;
            this.cbStatus.Location = new System.Drawing.Point(87, 89);
            this.cbStatus.Name = "cbStatus";
            this.cbStatus.Size = new System.Drawing.Size(125, 21);
            this.cbStatus.TabIndex = 8;
            // 
            // cbTracker
            // 
            this.cbTracker.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTracker.Enabled = false;
            this.cbTracker.FormattingEnabled = true;
            this.cbTracker.Location = new System.Drawing.Point(87, 62);
            this.cbTracker.Name = "cbTracker";
            this.cbTracker.Size = new System.Drawing.Size(125, 21);
            this.cbTracker.TabIndex = 6;
            // 
            // tbID
            // 
            this.tbID.Enabled = false;
            this.tbID.Location = new System.Drawing.Point(87, 9);
            this.tbID.Name = "tbID";
            this.tbID.ReadOnly = true;
            this.tbID.Size = new System.Drawing.Size(125, 20);
            this.tbID.TabIndex = 2;
            // 
            // labelID
            // 
            this.labelID.Location = new System.Drawing.Point(7, 9);
            this.labelID.Name = "labelID";
            this.labelID.Size = new System.Drawing.Size(74, 20);
            this.labelID.TabIndex = 1;
            this.labelID.Text = "ID:";
            this.labelID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabPageHistory
            // 
            this.tabPageHistory.Controls.Add(this.tbHistory);
            this.tabPageHistory.Location = new System.Drawing.Point(4, 22);
            this.tabPageHistory.Name = "tabPageHistory";
            this.tabPageHistory.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageHistory.Size = new System.Drawing.Size(449, 299);
            this.tabPageHistory.TabIndex = 1;
            this.tabPageHistory.Text = "History";
            this.tabPageHistory.UseVisualStyleBackColor = true;
            // 
            // tbHistory
            // 
            this.tbHistory.Location = new System.Drawing.Point(6, 6);
            this.tbHistory.Multiline = true;
            this.tbHistory.Name = "tbHistory";
            this.tbHistory.ReadOnly = true;
            this.tbHistory.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbHistory.Size = new System.Drawing.Size(437, 292);
            this.tbHistory.TabIndex = 1;
            // 
            // IssueInformationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 371);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "IssueInformationForm";
            this.ShowInTaskbar = false;
            this.Text = "Issue information [please, wait..]";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.IssueInformationForm_FormClosing);
            this.Shown += new System.EventHandler(this.IssueInformationForm_Shown);
            this.tabControl.ResumeLayout(false);
            this.tabPageInfo.ResumeLayout(false);
            this.tabPageInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudEstimatedTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDoneRatio)).EndInit();
            this.tabPageHistory.ResumeLayout(false);
            this.tabPageHistory.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageHistory;
        private System.Windows.Forms.TextBox tbHistory;
        private System.Windows.Forms.TabPage tabPageInfo;
        private System.Windows.Forms.TextBox tbClosedDate;
        private System.Windows.Forms.Label labelClosesDate;
        private System.Windows.Forms.NumericUpDown nudEstimatedTime;
        private System.Windows.Forms.Label labelHours;
        private System.Windows.Forms.Label labelEstimatedTime;
        private System.Windows.Forms.Button btnResetDueDate;
        private System.Windows.Forms.DateTimePicker dtpDueDate;
        private System.Windows.Forms.Label labelDueDate;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbLastUpdate;
        private System.Windows.Forms.TextBox tbCreationDate;
        private System.Windows.Forms.Label labelLastUpdate;
        private System.Windows.Forms.Label labelCreationDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbProject;
        private System.Windows.Forms.TextBox tbSubject;
        private System.Windows.Forms.Label labelSubject;
        private System.Windows.Forms.CheckBox cbIsNotePrivate;
        private System.Windows.Forms.TextBox tbAddNote;
        private System.Windows.Forms.CheckBox cbAddNote;
        private System.Windows.Forms.Label labelPercentage;
        private System.Windows.Forms.NumericUpDown nudDoneRatio;
        private System.Windows.Forms.Label labelDoneRatio;
        private System.Windows.Forms.TextBox tbAuthor;
        private System.Windows.Forms.Label labelAuthor;
        private System.Windows.Forms.TextBox tbDescription;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.Label labelAssignedTo;
        private System.Windows.Forms.Label labelPriority;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Label labelTracker;
        private System.Windows.Forms.ComboBox cbAssignedTo;
        private System.Windows.Forms.ComboBox cbPriority;
        private System.Windows.Forms.ComboBox cbStatus;
        private System.Windows.Forms.ComboBox cbTracker;
        private System.Windows.Forms.TextBox tbID;
        private System.Windows.Forms.Label labelID;
        private System.Windows.Forms.CheckBox cbIsPrivate;

    }
}