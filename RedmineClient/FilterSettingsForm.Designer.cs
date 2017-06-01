namespace RedmineClient
{
    partial class FilterSettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FilterSettingsForm));
            this.cbAddStatusFilter = new System.Windows.Forms.CheckBox();
            this.cbStatusFilterVars = new System.Windows.Forms.ComboBox();
            this.cbStatus = new System.Windows.Forms.ComboBox();
            this.cbTracker = new System.Windows.Forms.ComboBox();
            this.cbTrackerFilterVars = new System.Windows.Forms.ComboBox();
            this.cbAddTrackerFilter = new System.Windows.Forms.CheckBox();
            this.cbPriotity = new System.Windows.Forms.ComboBox();
            this.cbPriorityFilterVars = new System.Windows.Forms.ComboBox();
            this.cbAddPriorityFilter = new System.Windows.Forms.CheckBox();
            this.cbAuthor = new System.Windows.Forms.ComboBox();
            this.cbAuthorFilterVars = new System.Windows.Forms.ComboBox();
            this.cbAddAuthorFilter = new System.Windows.Forms.CheckBox();
            this.cbAssignee = new System.Windows.Forms.ComboBox();
            this.cbAssigneeFilterVars = new System.Windows.Forms.ComboBox();
            this.cbAddAssigneeFilter = new System.Windows.Forms.CheckBox();
            this.cbSubjectFilterVars = new System.Windows.Forms.ComboBox();
            this.cbAddSubjectFilter = new System.Windows.Forms.CheckBox();
            this.tbSubject = new System.Windows.Forms.TextBox();
            this.cbEstimatedTimeFilterVars = new System.Windows.Forms.ComboBox();
            this.cbAddEstimatedTimeFilter = new System.Windows.Forms.CheckBox();
            this.nudEstimatedTime1 = new System.Windows.Forms.NumericUpDown();
            this.nudEstimatedTime2 = new System.Windows.Forms.NumericUpDown();
            this.cbDoneRatioFilterVars = new System.Windows.Forms.ComboBox();
            this.cbAddDoneRatioFilter = new System.Windows.Forms.CheckBox();
            this.nudDoneRatio1 = new System.Windows.Forms.NumericUpDown();
            this.nudDoneRatio2 = new System.Windows.Forms.NumericUpDown();
            this.cbPrivacy = new System.Windows.Forms.ComboBox();
            this.cbPrivacyFilterVars = new System.Windows.Forms.ComboBox();
            this.cbAddPrivacyFilter = new System.Windows.Forms.CheckBox();
            this.cbStartDateFilterVars = new System.Windows.Forms.ComboBox();
            this.cbAddStartDateFilter = new System.Windows.Forms.CheckBox();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.btnApply = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.labelInfo = new System.Windows.Forms.Label();
            this.btnResetFilters = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudEstimatedTime1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudEstimatedTime2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDoneRatio1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDoneRatio2)).BeginInit();
            this.SuspendLayout();
            // 
            // cbAddStatusFilter
            // 
            this.cbAddStatusFilter.AutoSize = true;
            this.cbAddStatusFilter.Enabled = false;
            this.cbAddStatusFilter.Location = new System.Drawing.Point(12, 30);
            this.cbAddStatusFilter.Name = "cbAddStatusFilter";
            this.cbAddStatusFilter.Size = new System.Drawing.Size(56, 17);
            this.cbAddStatusFilter.TabIndex = 1;
            this.cbAddStatusFilter.Text = "Status";
            this.cbAddStatusFilter.UseVisualStyleBackColor = true;
            this.cbAddStatusFilter.CheckedChanged += new System.EventHandler(this.cbAddStatusFilter_CheckedChanged);
            // 
            // cbStatusFilterVars
            // 
            this.cbStatusFilterVars.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStatusFilterVars.Enabled = false;
            this.cbStatusFilterVars.FormattingEnabled = true;
            this.cbStatusFilterVars.Items.AddRange(new object[] {
            "is",
            "is not"});
            this.cbStatusFilterVars.Location = new System.Drawing.Point(12, 53);
            this.cbStatusFilterVars.Name = "cbStatusFilterVars";
            this.cbStatusFilterVars.Size = new System.Drawing.Size(70, 21);
            this.cbStatusFilterVars.TabIndex = 2;
            // 
            // cbStatus
            // 
            this.cbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStatus.Enabled = false;
            this.cbStatus.FormattingEnabled = true;
            this.cbStatus.Location = new System.Drawing.Point(88, 53);
            this.cbStatus.Name = "cbStatus";
            this.cbStatus.Size = new System.Drawing.Size(121, 21);
            this.cbStatus.TabIndex = 3;
            // 
            // cbTracker
            // 
            this.cbTracker.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTracker.Enabled = false;
            this.cbTracker.FormattingEnabled = true;
            this.cbTracker.Location = new System.Drawing.Point(88, 103);
            this.cbTracker.Name = "cbTracker";
            this.cbTracker.Size = new System.Drawing.Size(121, 21);
            this.cbTracker.TabIndex = 6;
            // 
            // cbTrackerFilterVars
            // 
            this.cbTrackerFilterVars.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTrackerFilterVars.Enabled = false;
            this.cbTrackerFilterVars.FormattingEnabled = true;
            this.cbTrackerFilterVars.Items.AddRange(new object[] {
            "is",
            "is not"});
            this.cbTrackerFilterVars.Location = new System.Drawing.Point(12, 103);
            this.cbTrackerFilterVars.Name = "cbTrackerFilterVars";
            this.cbTrackerFilterVars.Size = new System.Drawing.Size(70, 21);
            this.cbTrackerFilterVars.TabIndex = 5;
            // 
            // cbAddTrackerFilter
            // 
            this.cbAddTrackerFilter.AutoSize = true;
            this.cbAddTrackerFilter.Enabled = false;
            this.cbAddTrackerFilter.Location = new System.Drawing.Point(12, 80);
            this.cbAddTrackerFilter.Name = "cbAddTrackerFilter";
            this.cbAddTrackerFilter.Size = new System.Drawing.Size(63, 17);
            this.cbAddTrackerFilter.TabIndex = 4;
            this.cbAddTrackerFilter.Text = "Tracker";
            this.cbAddTrackerFilter.UseVisualStyleBackColor = true;
            this.cbAddTrackerFilter.CheckedChanged += new System.EventHandler(this.cbAddTrackerStatus_CheckedChanged);
            // 
            // cbPriotity
            // 
            this.cbPriotity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPriotity.Enabled = false;
            this.cbPriotity.FormattingEnabled = true;
            this.cbPriotity.Location = new System.Drawing.Point(88, 153);
            this.cbPriotity.Name = "cbPriotity";
            this.cbPriotity.Size = new System.Drawing.Size(121, 21);
            this.cbPriotity.TabIndex = 9;
            // 
            // cbPriorityFilterVars
            // 
            this.cbPriorityFilterVars.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPriorityFilterVars.Enabled = false;
            this.cbPriorityFilterVars.FormattingEnabled = true;
            this.cbPriorityFilterVars.Items.AddRange(new object[] {
            "is",
            "is not"});
            this.cbPriorityFilterVars.Location = new System.Drawing.Point(12, 153);
            this.cbPriorityFilterVars.Name = "cbPriorityFilterVars";
            this.cbPriorityFilterVars.Size = new System.Drawing.Size(70, 21);
            this.cbPriorityFilterVars.TabIndex = 8;
            // 
            // cbAddPriorityFilter
            // 
            this.cbAddPriorityFilter.AutoSize = true;
            this.cbAddPriorityFilter.Enabled = false;
            this.cbAddPriorityFilter.Location = new System.Drawing.Point(12, 130);
            this.cbAddPriorityFilter.Name = "cbAddPriorityFilter";
            this.cbAddPriorityFilter.Size = new System.Drawing.Size(57, 17);
            this.cbAddPriorityFilter.TabIndex = 7;
            this.cbAddPriorityFilter.Text = "Priority";
            this.cbAddPriorityFilter.UseVisualStyleBackColor = true;
            this.cbAddPriorityFilter.CheckedChanged += new System.EventHandler(this.cbAddPriorityFilter_CheckedChanged);
            // 
            // cbAuthor
            // 
            this.cbAuthor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAuthor.Enabled = false;
            this.cbAuthor.FormattingEnabled = true;
            this.cbAuthor.Location = new System.Drawing.Point(301, 203);
            this.cbAuthor.Name = "cbAuthor";
            this.cbAuthor.Size = new System.Drawing.Size(153, 21);
            this.cbAuthor.TabIndex = 29;
            // 
            // cbAuthorFilterVars
            // 
            this.cbAuthorFilterVars.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAuthorFilterVars.Enabled = false;
            this.cbAuthorFilterVars.FormattingEnabled = true;
            this.cbAuthorFilterVars.Items.AddRange(new object[] {
            "is",
            "is not"});
            this.cbAuthorFilterVars.Location = new System.Drawing.Point(225, 203);
            this.cbAuthorFilterVars.Name = "cbAuthorFilterVars";
            this.cbAuthorFilterVars.Size = new System.Drawing.Size(70, 21);
            this.cbAuthorFilterVars.TabIndex = 28;
            // 
            // cbAddAuthorFilter
            // 
            this.cbAddAuthorFilter.AutoSize = true;
            this.cbAddAuthorFilter.Enabled = false;
            this.cbAddAuthorFilter.Location = new System.Drawing.Point(225, 180);
            this.cbAddAuthorFilter.Name = "cbAddAuthorFilter";
            this.cbAddAuthorFilter.Size = new System.Drawing.Size(57, 17);
            this.cbAddAuthorFilter.TabIndex = 27;
            this.cbAddAuthorFilter.Text = "Author";
            this.cbAddAuthorFilter.UseVisualStyleBackColor = true;
            this.cbAddAuthorFilter.CheckedChanged += new System.EventHandler(this.cbAddAuthorFilter_CheckedChanged);
            // 
            // cbAssignee
            // 
            this.cbAssignee.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAssignee.Enabled = false;
            this.cbAssignee.FormattingEnabled = true;
            this.cbAssignee.Location = new System.Drawing.Point(301, 253);
            this.cbAssignee.Name = "cbAssignee";
            this.cbAssignee.Size = new System.Drawing.Size(153, 21);
            this.cbAssignee.TabIndex = 32;
            // 
            // cbAssigneeFilterVars
            // 
            this.cbAssigneeFilterVars.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAssigneeFilterVars.Enabled = false;
            this.cbAssigneeFilterVars.FormattingEnabled = true;
            this.cbAssigneeFilterVars.Items.AddRange(new object[] {
            "is",
            "is not"});
            this.cbAssigneeFilterVars.Location = new System.Drawing.Point(225, 253);
            this.cbAssigneeFilterVars.Name = "cbAssigneeFilterVars";
            this.cbAssigneeFilterVars.Size = new System.Drawing.Size(70, 21);
            this.cbAssigneeFilterVars.TabIndex = 31;
            // 
            // cbAddAssigneeFilter
            // 
            this.cbAddAssigneeFilter.AutoSize = true;
            this.cbAddAssigneeFilter.Enabled = false;
            this.cbAddAssigneeFilter.Location = new System.Drawing.Point(225, 230);
            this.cbAddAssigneeFilter.Name = "cbAddAssigneeFilter";
            this.cbAddAssigneeFilter.Size = new System.Drawing.Size(69, 17);
            this.cbAddAssigneeFilter.TabIndex = 30;
            this.cbAddAssigneeFilter.Text = "Assignee";
            this.cbAddAssigneeFilter.UseVisualStyleBackColor = true;
            this.cbAddAssigneeFilter.CheckedChanged += new System.EventHandler(this.cbAddAssigneeFilter_CheckedChanged);
            // 
            // cbSubjectFilterVars
            // 
            this.cbSubjectFilterVars.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSubjectFilterVars.Enabled = false;
            this.cbSubjectFilterVars.FormattingEnabled = true;
            this.cbSubjectFilterVars.Items.AddRange(new object[] {
            "contains",
            "doesn\'t contain"});
            this.cbSubjectFilterVars.Location = new System.Drawing.Point(225, 53);
            this.cbSubjectFilterVars.Name = "cbSubjectFilterVars";
            this.cbSubjectFilterVars.Size = new System.Drawing.Size(100, 21);
            this.cbSubjectFilterVars.TabIndex = 17;
            // 
            // cbAddSubjectFilter
            // 
            this.cbAddSubjectFilter.AutoSize = true;
            this.cbAddSubjectFilter.Enabled = false;
            this.cbAddSubjectFilter.Location = new System.Drawing.Point(225, 30);
            this.cbAddSubjectFilter.Name = "cbAddSubjectFilter";
            this.cbAddSubjectFilter.Size = new System.Drawing.Size(62, 17);
            this.cbAddSubjectFilter.TabIndex = 16;
            this.cbAddSubjectFilter.Text = "Subject";
            this.cbAddSubjectFilter.UseVisualStyleBackColor = true;
            this.cbAddSubjectFilter.CheckedChanged += new System.EventHandler(this.cbAddSubjectFilter_CheckedChanged);
            // 
            // tbSubject
            // 
            this.tbSubject.Enabled = false;
            this.tbSubject.Location = new System.Drawing.Point(331, 54);
            this.tbSubject.Name = "tbSubject";
            this.tbSubject.Size = new System.Drawing.Size(123, 20);
            this.tbSubject.TabIndex = 18;
            // 
            // cbEstimatedTimeFilterVars
            // 
            this.cbEstimatedTimeFilterVars.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEstimatedTimeFilterVars.Enabled = false;
            this.cbEstimatedTimeFilterVars.FormattingEnabled = true;
            this.cbEstimatedTimeFilterVars.Items.AddRange(new object[] {
            "is",
            "is not",
            ">=",
            "<=",
            "beetwen"});
            this.cbEstimatedTimeFilterVars.Location = new System.Drawing.Point(225, 103);
            this.cbEstimatedTimeFilterVars.Name = "cbEstimatedTimeFilterVars";
            this.cbEstimatedTimeFilterVars.Size = new System.Drawing.Size(100, 21);
            this.cbEstimatedTimeFilterVars.TabIndex = 20;
            this.cbEstimatedTimeFilterVars.SelectedIndexChanged += new System.EventHandler(this.cbEstimatedTimeFilterVars_SelectedIndexChanged);
            // 
            // cbAddEstimatedTimeFilter
            // 
            this.cbAddEstimatedTimeFilter.AutoSize = true;
            this.cbAddEstimatedTimeFilter.Enabled = false;
            this.cbAddEstimatedTimeFilter.Location = new System.Drawing.Point(225, 80);
            this.cbAddEstimatedTimeFilter.Name = "cbAddEstimatedTimeFilter";
            this.cbAddEstimatedTimeFilter.Size = new System.Drawing.Size(94, 17);
            this.cbAddEstimatedTimeFilter.TabIndex = 19;
            this.cbAddEstimatedTimeFilter.Text = "Estimated time";
            this.cbAddEstimatedTimeFilter.UseVisualStyleBackColor = true;
            this.cbAddEstimatedTimeFilter.CheckedChanged += new System.EventHandler(this.cbAddEstimatedTimeFilter_CheckedChanged);
            // 
            // nudEstimatedTime1
            // 
            this.nudEstimatedTime1.Enabled = false;
            this.nudEstimatedTime1.Location = new System.Drawing.Point(331, 104);
            this.nudEstimatedTime1.Maximum = new decimal(new int[] {
            9000,
            0,
            0,
            0});
            this.nudEstimatedTime1.Name = "nudEstimatedTime1";
            this.nudEstimatedTime1.Size = new System.Drawing.Size(122, 20);
            this.nudEstimatedTime1.TabIndex = 21;
            this.nudEstimatedTime1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // nudEstimatedTime2
            // 
            this.nudEstimatedTime2.Enabled = false;
            this.nudEstimatedTime2.Location = new System.Drawing.Point(395, 104);
            this.nudEstimatedTime2.Maximum = new decimal(new int[] {
            9000,
            0,
            0,
            0});
            this.nudEstimatedTime2.Name = "nudEstimatedTime2";
            this.nudEstimatedTime2.Size = new System.Drawing.Size(58, 20);
            this.nudEstimatedTime2.TabIndex = 22;
            this.nudEstimatedTime2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cbDoneRatioFilterVars
            // 
            this.cbDoneRatioFilterVars.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDoneRatioFilterVars.Enabled = false;
            this.cbDoneRatioFilterVars.FormattingEnabled = true;
            this.cbDoneRatioFilterVars.Items.AddRange(new object[] {
            "is",
            "is not",
            ">=",
            "<=",
            "beetwen"});
            this.cbDoneRatioFilterVars.Location = new System.Drawing.Point(225, 153);
            this.cbDoneRatioFilterVars.Name = "cbDoneRatioFilterVars";
            this.cbDoneRatioFilterVars.Size = new System.Drawing.Size(100, 21);
            this.cbDoneRatioFilterVars.TabIndex = 24;
            this.cbDoneRatioFilterVars.SelectedIndexChanged += new System.EventHandler(this.cbDoneRationFilterVars_SelectedIndexChanged);
            // 
            // cbAddDoneRatioFilter
            // 
            this.cbAddDoneRatioFilter.AutoSize = true;
            this.cbAddDoneRatioFilter.Enabled = false;
            this.cbAddDoneRatioFilter.Location = new System.Drawing.Point(225, 130);
            this.cbAddDoneRatioFilter.Name = "cbAddDoneRatioFilter";
            this.cbAddDoneRatioFilter.Size = new System.Drawing.Size(75, 17);
            this.cbAddDoneRatioFilter.TabIndex = 23;
            this.cbAddDoneRatioFilter.Text = "Done ratio";
            this.cbAddDoneRatioFilter.UseVisualStyleBackColor = true;
            this.cbAddDoneRatioFilter.CheckedChanged += new System.EventHandler(this.cbAddDoneRatioFilter_CheckedChanged);
            // 
            // nudDoneRatio1
            // 
            this.nudDoneRatio1.Enabled = false;
            this.nudDoneRatio1.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudDoneRatio1.Location = new System.Drawing.Point(331, 153);
            this.nudDoneRatio1.Name = "nudDoneRatio1";
            this.nudDoneRatio1.Size = new System.Drawing.Size(122, 20);
            this.nudDoneRatio1.TabIndex = 25;
            this.nudDoneRatio1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // nudDoneRatio2
            // 
            this.nudDoneRatio2.Enabled = false;
            this.nudDoneRatio2.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudDoneRatio2.Location = new System.Drawing.Point(395, 153);
            this.nudDoneRatio2.Name = "nudDoneRatio2";
            this.nudDoneRatio2.Size = new System.Drawing.Size(58, 20);
            this.nudDoneRatio2.TabIndex = 26;
            this.nudDoneRatio2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cbPrivacy
            // 
            this.cbPrivacy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPrivacy.Enabled = false;
            this.cbPrivacy.FormattingEnabled = true;
            this.cbPrivacy.Items.AddRange(new object[] {
            "private",
            "public"});
            this.cbPrivacy.Location = new System.Drawing.Point(87, 203);
            this.cbPrivacy.Name = "cbPrivacy";
            this.cbPrivacy.Size = new System.Drawing.Size(121, 21);
            this.cbPrivacy.TabIndex = 12;
            // 
            // cbPrivacyFilterVars
            // 
            this.cbPrivacyFilterVars.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPrivacyFilterVars.Enabled = false;
            this.cbPrivacyFilterVars.FormattingEnabled = true;
            this.cbPrivacyFilterVars.Items.AddRange(new object[] {
            "is",
            "is not"});
            this.cbPrivacyFilterVars.Location = new System.Drawing.Point(11, 203);
            this.cbPrivacyFilterVars.Name = "cbPrivacyFilterVars";
            this.cbPrivacyFilterVars.Size = new System.Drawing.Size(70, 21);
            this.cbPrivacyFilterVars.TabIndex = 11;
            // 
            // cbAddPrivacyFilter
            // 
            this.cbAddPrivacyFilter.AutoSize = true;
            this.cbAddPrivacyFilter.Enabled = false;
            this.cbAddPrivacyFilter.Location = new System.Drawing.Point(11, 180);
            this.cbAddPrivacyFilter.Name = "cbAddPrivacyFilter";
            this.cbAddPrivacyFilter.Size = new System.Drawing.Size(61, 17);
            this.cbAddPrivacyFilter.TabIndex = 10;
            this.cbAddPrivacyFilter.Text = "Privacy";
            this.cbAddPrivacyFilter.UseVisualStyleBackColor = true;
            this.cbAddPrivacyFilter.CheckedChanged += new System.EventHandler(this.cbAddPrivacyFilter_CheckedChanged);
            // 
            // cbStartDateFilterVars
            // 
            this.cbStartDateFilterVars.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStartDateFilterVars.Enabled = false;
            this.cbStartDateFilterVars.FormattingEnabled = true;
            this.cbStartDateFilterVars.Items.AddRange(new object[] {
            "is",
            "is not",
            ">=",
            "<="});
            this.cbStartDateFilterVars.Location = new System.Drawing.Point(11, 253);
            this.cbStartDateFilterVars.Name = "cbStartDateFilterVars";
            this.cbStartDateFilterVars.Size = new System.Drawing.Size(70, 21);
            this.cbStartDateFilterVars.TabIndex = 14;
            // 
            // cbAddStartDateFilter
            // 
            this.cbAddStartDateFilter.AutoSize = true;
            this.cbAddStartDateFilter.Enabled = false;
            this.cbAddStartDateFilter.Location = new System.Drawing.Point(11, 230);
            this.cbAddStartDateFilter.Name = "cbAddStartDateFilter";
            this.cbAddStartDateFilter.Size = new System.Drawing.Size(72, 17);
            this.cbAddStartDateFilter.TabIndex = 13;
            this.cbAddStartDateFilter.Text = "Start date";
            this.cbAddStartDateFilter.UseVisualStyleBackColor = true;
            this.cbAddStartDateFilter.CheckedChanged += new System.EventHandler(this.cbAddStartDateFilter_CheckedChanged);
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.CustomFormat = " ";
            this.dtpStartDate.Enabled = false;
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartDate.Location = new System.Drawing.Point(88, 254);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(121, 20);
            this.dtpStartDate.TabIndex = 15;
            this.dtpStartDate.ValueChanged += new System.EventHandler(this.dtpStartDate_ValueChanged);
            this.dtpStartDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtpStartDate_KeyDown);
            this.dtpStartDate.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dtpStartDate_MouseDown);
            // 
            // btnApply
            // 
            this.btnApply.Enabled = false;
            this.btnApply.Location = new System.Drawing.Point(298, 280);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(75, 23);
            this.btnApply.TabIndex = 33;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Enabled = false;
            this.btnCancel.Location = new System.Drawing.Point(379, 280);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 34;
            this.btnCancel.Text = "Cacnel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // labelInfo
            // 
            this.labelInfo.Enabled = false;
            this.labelInfo.Location = new System.Drawing.Point(12, 7);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(442, 19);
            this.labelInfo.TabIndex = 0;
            this.labelInfo.Text = "Please, select filters you want and set up them. You could use several filters.";
            this.labelInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnResetFilters
            // 
            this.btnResetFilters.Enabled = false;
            this.btnResetFilters.Location = new System.Drawing.Point(11, 281);
            this.btnResetFilters.Name = "btnResetFilters";
            this.btnResetFilters.Size = new System.Drawing.Size(81, 23);
            this.btnResetFilters.TabIndex = 35;
            this.btnResetFilters.Text = "Reset filters";
            this.btnResetFilters.UseVisualStyleBackColor = true;
            this.btnResetFilters.Click += new System.EventHandler(this.btnResetFilters_Click);
            // 
            // FilterSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 310);
            this.Controls.Add(this.btnResetFilters);
            this.Controls.Add(this.nudDoneRatio1);
            this.Controls.Add(this.nudEstimatedTime1);
            this.Controls.Add(this.labelInfo);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.dtpStartDate);
            this.Controls.Add(this.cbStartDateFilterVars);
            this.Controls.Add(this.cbAddStartDateFilter);
            this.Controls.Add(this.cbPrivacy);
            this.Controls.Add(this.cbPrivacyFilterVars);
            this.Controls.Add(this.cbAddPrivacyFilter);
            this.Controls.Add(this.nudDoneRatio2);
            this.Controls.Add(this.cbDoneRatioFilterVars);
            this.Controls.Add(this.cbAddDoneRatioFilter);
            this.Controls.Add(this.nudEstimatedTime2);
            this.Controls.Add(this.cbEstimatedTimeFilterVars);
            this.Controls.Add(this.cbAddEstimatedTimeFilter);
            this.Controls.Add(this.tbSubject);
            this.Controls.Add(this.cbSubjectFilterVars);
            this.Controls.Add(this.cbAddSubjectFilter);
            this.Controls.Add(this.cbAssignee);
            this.Controls.Add(this.cbAssigneeFilterVars);
            this.Controls.Add(this.cbAddAssigneeFilter);
            this.Controls.Add(this.cbAuthor);
            this.Controls.Add(this.cbAuthorFilterVars);
            this.Controls.Add(this.cbAddAuthorFilter);
            this.Controls.Add(this.cbPriotity);
            this.Controls.Add(this.cbPriorityFilterVars);
            this.Controls.Add(this.cbAddPriorityFilter);
            this.Controls.Add(this.cbTracker);
            this.Controls.Add(this.cbTrackerFilterVars);
            this.Controls.Add(this.cbAddTrackerFilter);
            this.Controls.Add(this.cbStatus);
            this.Controls.Add(this.cbStatusFilterVars);
            this.Controls.Add(this.cbAddStatusFilter);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FilterSettingsForm";
            this.ShowInTaskbar = false;
            this.Text = "Filter settings [please, wait..]";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FilterSettingsForm_FormClosing);
            this.Shown += new System.EventHandler(this.FilterSettingsForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.nudEstimatedTime1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudEstimatedTime2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDoneRatio1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDoneRatio2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cbAddStatusFilter;
        private System.Windows.Forms.ComboBox cbStatusFilterVars;
        private System.Windows.Forms.ComboBox cbStatus;
        private System.Windows.Forms.ComboBox cbTracker;
        private System.Windows.Forms.ComboBox cbTrackerFilterVars;
        private System.Windows.Forms.CheckBox cbAddTrackerFilter;
        private System.Windows.Forms.ComboBox cbPriotity;
        private System.Windows.Forms.ComboBox cbPriorityFilterVars;
        private System.Windows.Forms.CheckBox cbAddPriorityFilter;
        private System.Windows.Forms.ComboBox cbAuthor;
        private System.Windows.Forms.ComboBox cbAuthorFilterVars;
        private System.Windows.Forms.CheckBox cbAddAuthorFilter;
        private System.Windows.Forms.ComboBox cbAssignee;
        private System.Windows.Forms.ComboBox cbAssigneeFilterVars;
        private System.Windows.Forms.CheckBox cbAddAssigneeFilter;
        private System.Windows.Forms.ComboBox cbSubjectFilterVars;
        private System.Windows.Forms.CheckBox cbAddSubjectFilter;
        private System.Windows.Forms.TextBox tbSubject;
        private System.Windows.Forms.ComboBox cbEstimatedTimeFilterVars;
        private System.Windows.Forms.CheckBox cbAddEstimatedTimeFilter;
        private System.Windows.Forms.NumericUpDown nudEstimatedTime1;
        private System.Windows.Forms.NumericUpDown nudEstimatedTime2;
        private System.Windows.Forms.ComboBox cbDoneRatioFilterVars;
        private System.Windows.Forms.CheckBox cbAddDoneRatioFilter;
        private System.Windows.Forms.NumericUpDown nudDoneRatio1;
        private System.Windows.Forms.NumericUpDown nudDoneRatio2;
        private System.Windows.Forms.ComboBox cbPrivacy;
        private System.Windows.Forms.ComboBox cbPrivacyFilterVars;
        private System.Windows.Forms.CheckBox cbAddPrivacyFilter;
        private System.Windows.Forms.ComboBox cbStartDateFilterVars;
        private System.Windows.Forms.CheckBox cbAddStartDateFilter;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label labelInfo;
        private System.Windows.Forms.Button btnResetFilters;
    }
}