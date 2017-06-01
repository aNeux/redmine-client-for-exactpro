using System;
using System.Collections.Generic;
using System.Windows.Forms;
using RedmineClient.Models;

namespace RedmineClient
{
    public partial class FilterSettingsForm : Form
    {
        private Controller controller;
        private long projectID;

        public List<Filter> FilterSettings { set; get; }

        public FilterSettingsForm(long projectID, List<Filter> lastFilterSettings)
        {
            InitializeComponent();
            this.projectID = projectID;
            this.FilterSettings = lastFilterSettings;
            this.StartPosition = FormStartPosition.CenterParent;
        }

        private void FilterSettingsForm_Shown(object sender, EventArgs e)
        {
            controller = Program.controllerGlobal;
            controller.OnPreparedToSetFilters += controller_OnPreparedToSetFilters;
            controller.LoadDataToSetFilters(projectID);
        }

        private void FilterSettingsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            controller.OnPreparedToSetFilters -= controller_OnPreparedToSetFilters;
        }

        private void cbAddStatusFilter_CheckedChanged(object sender, EventArgs e)
        {
            cbStatusFilterVars.Enabled = cbAddStatusFilter.Checked;
            cbStatus.Enabled = cbAddStatusFilter.Checked;
        }

        private void cbAddTrackerStatus_CheckedChanged(object sender, EventArgs e)
        {
            cbTrackerFilterVars.Enabled = cbAddTrackerFilter.Checked;
            cbTracker.Enabled = cbAddTrackerFilter.Checked;
        }

        private void cbAddPriorityFilter_CheckedChanged(object sender, EventArgs e)
        {
            cbPriorityFilterVars.Enabled = cbAddPriorityFilter.Checked;
            cbPriotity.Enabled = cbAddPriorityFilter.Checked;
        }

        private void cbAddPrivacyFilter_CheckedChanged(object sender, EventArgs e)
        {
            cbPrivacyFilterVars.Enabled = cbAddPrivacyFilter.Checked;
            cbPrivacy.Enabled = cbAddPrivacyFilter.Checked;
        }

        private void cbAddStartDateFilter_CheckedChanged(object sender, EventArgs e)
        {
            cbStartDateFilterVars.Enabled = cbAddStartDateFilter.Checked;
            dtpStartDate.Enabled = cbAddStartDateFilter.Checked;
        }

        private void cbAddSubjectFilter_CheckedChanged(object sender, EventArgs e)
        {
            cbSubjectFilterVars.Enabled = cbAddSubjectFilter.Checked;
            tbSubject.Enabled = cbAddSubjectFilter.Checked;
        }

        private void cbAddEstimatedTimeFilter_CheckedChanged(object sender, EventArgs e)
        {
            cbEstimatedTimeFilterVars.Enabled = cbAddEstimatedTimeFilter.Checked;
            nudEstimatedTime1.Enabled = cbAddEstimatedTimeFilter.Checked;
        }

        private void cbAddDoneRatioFilter_CheckedChanged(object sender, EventArgs e)
        {
            cbDoneRatioFilterVars.Enabled = cbAddDoneRatioFilter.Checked;
            nudDoneRatio1.Enabled = cbAddDoneRatioFilter.Checked;
        }

        private void cbAddAuthorFilter_CheckedChanged(object sender, EventArgs e)
        {
            cbAuthorFilterVars.Enabled = cbAddAuthorFilter.Checked;
            cbAuthor.Enabled = cbAddAuthorFilter.Checked;
        }

        private void cbAddAssigneeFilter_CheckedChanged(object sender, EventArgs e)
        {
            cbAssigneeFilterVars.Enabled = cbAddAssigneeFilter.Checked;
            cbAssignee.Enabled = cbAddAssigneeFilter.Checked;
        }

        private void dtpStartDate_ValueChanged(object sender, EventArgs e)
        {
            if (dtpStartDate.Format == DateTimePickerFormat.Custom)
                dtpStartDate.Format = DateTimePickerFormat.Short;
        }

        private void dtpStartDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                dtpStartDate.Value = DateTime.Now;
        }

        private void dtpStartDate_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left || e.Button == MouseButtons.Right)
                dtpStartDate.Value = DateTime.Now;
        }

        private void cbEstimatedTimeFilterVars_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbEstimatedTimeFilterVars.SelectedIndex == 4)
            {
                nudEstimatedTime2.Enabled = true;
                nudEstimatedTime1.Size = new System.Drawing.Size(nudEstimatedTime2.Size.Width, nudEstimatedTime2.Size.Height);
            }
            else
            {
                nudEstimatedTime1.Size = new System.Drawing.Size(121, nudEstimatedTime2.Size.Height);
                nudEstimatedTime2.Enabled = false;
            }
        }

        private void cbDoneRationFilterVars_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbDoneRatioFilterVars.SelectedIndex == 4)
            {
                nudDoneRatio2.Enabled = true;
                nudDoneRatio1.Size = new System.Drawing.Size(nudDoneRatio2.Size.Width, nudDoneRatio2.Size.Height);
            }
            else
            {
                nudDoneRatio1.Size = new System.Drawing.Size(121, nudDoneRatio2.Size.Height);
                nudDoneRatio2.Enabled = false;
            }
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            FilterSettings = new List<Filter>();
            Filter filter;
            if (cbAddStatusFilter.Checked)
                if (cbStatusFilterVars.SelectedIndex >= 0)
                    if (cbStatus.SelectedIndex >= 0)
                    {
                        FilterConditions condition = FilterConditions.IS;
                        switch (cbStatusFilterVars.SelectedIndex)
                        {
                            case 0:
                                condition = FilterConditions.IS;
                                break;
                            case 1:
                                condition = FilterConditions.ISNOT;
                                break;
                        }
                        filter = new Filter(FilterObjects.Status, condition, (cbStatus.SelectedItem as TextAndValueItem).Value);
                        FilterSettings.Add(filter);
                    }
                    else
                    {
                        MessageBox.Show("Please, specify a value for \"Status\" filter.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                else
                {
                    MessageBox.Show("Please, specify a condition for \"Status\" filter.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            if (cbAddTrackerFilter.Checked)
                if (cbTrackerFilterVars.SelectedIndex >= 0)
                    if (cbTracker.SelectedIndex >= 0)
                    {
                        FilterConditions condition = FilterConditions.IS;
                        switch (cbTrackerFilterVars.SelectedIndex)
                        {
                            case 0:
                                condition = FilterConditions.IS;
                                break;
                            case 1:
                                condition = FilterConditions.ISNOT;
                                break;
                        }
                        filter = new Filter(FilterObjects.Tracker, condition, (cbTracker.SelectedItem as TextAndValueItem).Value);
                        FilterSettings.Add(filter);
                    }
                    else
                    {
                        MessageBox.Show("Please, specify a value for \"Tracker\" filter.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                else
                {
                    MessageBox.Show("Please, specify a condition for \"Tracker\" filter.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            if (cbAddPriorityFilter.Checked)
                if (cbPriorityFilterVars.SelectedIndex >= 0)
                    if (cbPriotity.SelectedIndex >= 0)
                    {
                        FilterConditions condition = FilterConditions.IS;
                        switch (cbPriorityFilterVars.SelectedIndex)
                        {
                            case 0:
                                condition = FilterConditions.IS;
                                break;
                            case 1:
                                condition = FilterConditions.ISNOT;
                                break;
                        }
                        filter = new Filter(FilterObjects.Priority, condition, (cbPriotity.SelectedItem as TextAndValueItem).Value);
                        FilterSettings.Add(filter);
                    }
                    else
                    {
                        MessageBox.Show("Please, specify a value for \"Priority\" filter.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                else
                {
                    MessageBox.Show("Please, specify a condition for \"Priority\" filter.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            if (cbAddPrivacyFilter.Checked)
                if (cbPrivacyFilterVars.SelectedIndex >= 0)
                    if (cbPrivacy.SelectedIndex >= 0)
                    {
                        FilterConditions condition = FilterConditions.IS;
                        switch (cbPrivacyFilterVars.SelectedIndex)
                        {
                            case 0:
                                condition = FilterConditions.IS;
                                break;
                            case 1:
                                condition = FilterConditions.ISNOT;
                                break;
                        }
                        filter = new Filter(FilterObjects.Privacy, condition, cbPrivacy.SelectedIndex == 0);
                        FilterSettings.Add(filter);
                    }
                    else
                    {
                        MessageBox.Show("Please, specify a value for \"Privacy\" filter.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                else
                {
                    MessageBox.Show("Please, specify a condition for \"Privacy\" filter.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            if (cbAddStartDateFilter.Checked)
                if (cbStartDateFilterVars.SelectedIndex >= 0)
                    if (dtpStartDate.Format != DateTimePickerFormat.Custom)
                    {
                        FilterConditions condition = FilterConditions.IS;
                        switch (cbStartDateFilterVars.SelectedIndex)
                        {
                            case 0:
                                condition = FilterConditions.IS;
                                break;
                            case 1:
                                condition = FilterConditions.ISNOT;
                                break;
                            case 2:
                                condition = FilterConditions.MORE_OR_EQUAL;
                                break;
                            case 3:
                                condition = FilterConditions.LESS_OR_EQUAL;
                                break;
                        }
                        filter = new Filter(FilterObjects.StartDate, condition, dtpStartDate.Value.Subtract(dtpStartDate.Value.TimeOfDay));
                        FilterSettings.Add(filter);
                    }
                    else
                    {
                        MessageBox.Show("Please, specify a value for \"Start date\" filter.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                else
                {
                    MessageBox.Show("Please, specify a condition for \"Start date\" filter.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            if (cbAddSubjectFilter.Checked)
                if (cbSubjectFilterVars.SelectedIndex >= 0)
                    if (tbSubject.Text.Length > 0)
                    {
                        FilterConditions condition = FilterConditions.IS;
                        switch (cbSubjectFilterVars.SelectedIndex)
                        {
                            case 0:
                                condition = FilterConditions.CONTAINS;
                                break;
                            case 1:
                                condition = FilterConditions.DOESNT_CONTAIN;
                                break;
                        }
                        filter = new Filter(FilterObjects.Subject, condition, tbSubject.Text);
                        FilterSettings.Add(filter);
                    }
                    else
                    {
                        MessageBox.Show("Please, specify a value for \"Subject\" filter.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                else
                {
                    MessageBox.Show("Please, specify a condition for \"Subject\" filter.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            if (cbAddEstimatedTimeFilter.Checked)
                if (cbEstimatedTimeFilterVars.SelectedIndex >= 0)
                {
                    FilterConditions condition = FilterConditions.IS;
                    switch (cbEstimatedTimeFilterVars.SelectedIndex)
                    {
                        case 0:
                            condition = FilterConditions.IS;
                            break;
                        case 1:
                            condition = FilterConditions.ISNOT;
                            break;
                        case 2:
                            condition = FilterConditions.MORE_OR_EQUAL;
                            break;
                        case 3:
                            condition = FilterConditions.LESS_OR_EQUAL;
                            break;
                        case 4:
                            condition = FilterConditions.BEETWEN;
                            break;
                    }
                    if (condition == FilterConditions.BEETWEN)
                        filter = new Filter(FilterObjects.EstimatedTime, condition, new double[] { (double)nudEstimatedTime1.Value, (double)nudEstimatedTime2.Value });
                    else
                        filter = new Filter(FilterObjects.EstimatedTime, condition, (double)nudEstimatedTime1.Value);
                    FilterSettings.Add(filter);
                }
                else
                {
                    MessageBox.Show("Please, specify a condition for \"Estimated time\" filter.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            if (cbAddDoneRatioFilter.Checked)
                if (cbDoneRatioFilterVars.SelectedIndex >= 0)
                {
                    FilterConditions condition = FilterConditions.IS;
                    switch (cbDoneRatioFilterVars.SelectedIndex)
                    {
                        case 0:
                            condition = FilterConditions.IS;
                            break;
                        case 1:
                            condition = FilterConditions.ISNOT;
                            break;
                        case 2:
                            condition = FilterConditions.MORE_OR_EQUAL;
                            break;
                        case 3:
                            condition = FilterConditions.LESS_OR_EQUAL;
                            break;
                        case 4:
                            condition = FilterConditions.BEETWEN;
                            break;
                    }
                    if (condition == FilterConditions.BEETWEN)
                        filter = new Filter(FilterObjects.DoneRatio, condition, new int[] { (int)nudDoneRatio1.Value, (int)nudDoneRatio2.Value });
                    else
                        filter = new Filter(FilterObjects.DoneRatio, condition, (int)nudDoneRatio1.Value);
                    FilterSettings.Add(filter);
                }
                else
                {
                    MessageBox.Show("Please, specify a condition for \"Done ratio\" filter.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            if (cbAddAuthorFilter.Checked)
                if (cbAuthorFilterVars.SelectedIndex >= 0)
                    if (cbAuthor.SelectedIndex >= 0)
                    {
                        FilterConditions condition = FilterConditions.IS;
                        switch (cbAuthorFilterVars.SelectedIndex)
                        {
                            case 0:
                                condition = FilterConditions.IS;
                                break;
                            case 1:
                                condition = FilterConditions.ISNOT;
                                break;
                        }
                        filter = new Filter(FilterObjects.Author, condition, (cbAuthor.SelectedItem as TextAndValueItem).Value);
                        FilterSettings.Add(filter);
                    }
                    else
                    {
                        MessageBox.Show("Please, specify a value for \"Author\" filter.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                else
                {
                    MessageBox.Show("Please, specify a condition for \"Author\" filter.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            if (cbAddAssigneeFilter.Checked)
                if (cbAssigneeFilterVars.SelectedIndex >= 0)
                    if (cbAssignee.SelectedIndex >= 0)
                    {
                        FilterConditions condition = FilterConditions.IS;
                        switch (cbAssigneeFilterVars.SelectedIndex)
                        {
                            case 0:
                                condition = FilterConditions.IS;
                                break;
                            case 1:
                                condition = FilterConditions.ISNOT;
                                break;
                        }
                        filter = new Filter(FilterObjects.Assignee, condition, (cbAssignee.SelectedItem as TextAndValueItem).Value);
                        FilterSettings.Add(filter);
                    }
                    else
                    {
                        MessageBox.Show("Please, specify a value for \"Assignee\" filter.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                else
                {
                    MessageBox.Show("Please, specify a condition for \"Assignee\" filter.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            this.DialogResult = FilterSettings.Count > 0 ? DialogResult.OK : DialogResult.Abort;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnResetFilters_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Abort;
            this.Close();
        }

        private void controller_OnPreparedToSetFilters(ErrorTypes error, List<IssueStatus> issueStatuses, List<IssueTracker> issueTrackers, List<IssuePriority> issuePriorities, List<Membership> memberships)
        {
            Action action = () =>
            {
                switch (error)
                {
                    case ErrorTypes.NoErrors:
                        foreach (IssueStatus currentStatus in issueStatuses)
                            cbStatus.Items.Add(new TextAndValueItem { Text = currentStatus.Name, Value = currentStatus.ID });
                        foreach (IssueTracker currentTracker in issueTrackers)
                            cbTracker.Items.Add(new TextAndValueItem { Text = currentTracker.Name, Value = currentTracker.ID });
                        foreach (IssuePriority currentPriority in issuePriorities)
                            cbPriotity.Items.Add(new TextAndValueItem { Text = currentPriority.Name, Value = currentPriority.ID });
                        cbAssignee.Items.Add(new TextAndValueItem { Text = "< none >", Value = (long)-1 });
                        foreach (Membership currentMembership in memberships)
                        {
                            cbAuthor.Items.Add(new TextAndValueItem { Text = currentMembership.User.Name, Value = currentMembership.User.ID });
                            cbAssignee.Items.Add(new TextAndValueItem { Text = currentMembership.User.Name, Value = currentMembership.User.ID });
                        }
                        if (FilterSettings != null)
                            ReadLastFilterSettings();
                        labelInfo.Enabled = true;
                        cbAddStatusFilter.Enabled = true;
                        cbAddTrackerFilter.Enabled = true;
                        cbAddPriorityFilter.Enabled = true;
                        cbAddPrivacyFilter.Enabled = true;
                        cbAddStartDateFilter.Enabled = true;
                        cbAddSubjectFilter.Enabled = true;
                        cbAddEstimatedTimeFilter.Enabled = true;
                        cbAddDoneRatioFilter.Enabled = true;
                        cbAddAuthorFilter.Enabled = true;
                        cbAddAssigneeFilter.Enabled = true;
                        btnApply.Enabled = true;
                        btnCancel.Enabled = true;
                        btnResetFilters.Enabled = true;
                        this.Text = "Filter settings";
                        break;
                    case ErrorTypes.ConnectionError:
                        this.Text = "Filter settings";
                        MessageBox.Show("Cannot connect to Redmine services. Please check your Internet connection and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Close();
                        break;
                    case ErrorTypes.UnathorizedAccess:
                        this.Text = "Filter settings";
                        MessageBox.Show("You have the wrong authorization data. Please change it and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        controller.NeedToReAuthenticate(false);
                        this.Close();
                        break;
                    case ErrorTypes.UnknownError:
                        this.Text = "Filter settings";
                        MessageBox.Show("An unknown error occurred. Please, try again one more time.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Close();
                        break;
                }
            };
            if (InvokeRequired)
                Invoke(action);
            else
                action();
        }

        private void ReadLastFilterSettings()
        {
            foreach (Filter currentFilter in FilterSettings)
            {
                int indexToSelect;
                switch (currentFilter.Obj)
                {
                    case FilterObjects.Status:
                        if (currentFilter.Condition == FilterConditions.IS)
                            cbStatusFilterVars.SelectedIndex = 0;
                        else if (currentFilter.Condition == FilterConditions.ISNOT)
                            cbStatusFilterVars.SelectedIndex = 1;
                        indexToSelect = -1;
                        for (int i = 0; i < cbStatus.Items.Count; i++)
                            if ((int)(cbStatus.Items[i] as TextAndValueItem).Value == (int)currentFilter.Value)
                            {
                                indexToSelect = i;
                                break;
                            }
                        if (indexToSelect != -1)
                            cbStatus.SelectedIndex = indexToSelect;
                        cbAddStatusFilter.Checked = true;
                        break;
                    case FilterObjects.Tracker:
                        if (currentFilter.Condition == FilterConditions.IS)
                            cbTrackerFilterVars.SelectedIndex = 0;
                        else if (currentFilter.Condition == FilterConditions.ISNOT)
                            cbTrackerFilterVars.SelectedIndex = 1;
                        indexToSelect = -1;
                        for (int i = 0; i < cbTracker.Items.Count; i++)
                            if ((int)(cbTracker.Items[i] as TextAndValueItem).Value == (int)currentFilter.Value)
                            {
                                indexToSelect = i;
                                break;
                            }
                        if (indexToSelect != -1)
                            cbTracker.SelectedIndex = indexToSelect;
                        cbAddTrackerFilter.Checked = true;
                        break;
                    case FilterObjects.Priority:
                        if (currentFilter.Condition == FilterConditions.IS)
                            cbPriorityFilterVars.SelectedIndex = 0;
                        else if (currentFilter.Condition == FilterConditions.ISNOT)
                            cbPriorityFilterVars.SelectedIndex = 1;
                        indexToSelect = -1;
                        for (int i = 0; i < cbPriotity.Items.Count; i++)
                            if ((int)(cbPriotity.Items[i] as TextAndValueItem).Value == (int)currentFilter.Value)
                            {
                                indexToSelect = i;
                                break;
                            }
                        if (indexToSelect != -1)
                            cbPriotity.SelectedIndex = indexToSelect;
                        cbAddPriorityFilter.Checked = true;
                        break;
                    case FilterObjects.Privacy:
                        if (currentFilter.Condition == FilterConditions.IS)
                            cbPrivacyFilterVars.SelectedIndex = 0;
                        else if (currentFilter.Condition == FilterConditions.ISNOT)
                            cbPrivacyFilterVars.SelectedIndex = 1;
                        cbPrivacy.SelectedIndex = (bool)currentFilter.Value ? 0 : 1;
                        cbAddPrivacyFilter.Checked = true;
                        break;
                    case FilterObjects.StartDate:
                        if (currentFilter.Condition == FilterConditions.IS)
                            cbStartDateFilterVars.SelectedIndex = 0;
                        else if (currentFilter.Condition == FilterConditions.ISNOT)
                            cbStartDateFilterVars.SelectedIndex = 1;
                        else if (currentFilter.Condition == FilterConditions.MORE_OR_EQUAL)
                            cbStartDateFilterVars.SelectedIndex = 2;
                        else if (currentFilter.Condition == FilterConditions.LESS_OR_EQUAL)
                            cbStartDateFilterVars.SelectedIndex = 3;
                        dtpStartDate.Value = (DateTime)currentFilter.Value;
                        cbAddStartDateFilter.Checked = true;
                        break;
                    case FilterObjects.Subject:
                        if (currentFilter.Condition == FilterConditions.CONTAINS)
                            cbSubjectFilterVars.SelectedIndex = 0;
                        else if (currentFilter.Condition == FilterConditions.DOESNT_CONTAIN)
                            cbSubjectFilterVars.SelectedIndex = 1;
                        tbSubject.Text = (string)currentFilter.Value;
                        cbAddSubjectFilter.Checked = true;
                        break;
                    case FilterObjects.EstimatedTime:
                        if (currentFilter.Condition == FilterConditions.IS)
                            cbEstimatedTimeFilterVars.SelectedIndex = 0;
                        else if (currentFilter.Condition == FilterConditions.ISNOT)
                            cbEstimatedTimeFilterVars.SelectedIndex = 1;
                        else if (currentFilter.Condition == FilterConditions.MORE_OR_EQUAL)
                            cbEstimatedTimeFilterVars.SelectedIndex = 2;
                        else if (currentFilter.Condition == FilterConditions.LESS_OR_EQUAL)
                            cbEstimatedTimeFilterVars.SelectedIndex = 3;
                        else if (currentFilter.Condition == FilterConditions.BEETWEN)
                            cbEstimatedTimeFilterVars.SelectedIndex = 4;
                        if (currentFilter.Condition == FilterConditions.BEETWEN)
                        {
                            nudEstimatedTime1.Value = Convert.ToDecimal(((double[])currentFilter.Value)[0]);
                            nudEstimatedTime2.Value = Convert.ToDecimal(((double[])currentFilter.Value)[1]);
                        }
                        else
                            nudEstimatedTime1.Value = Convert.ToDecimal((double)currentFilter.Value);
                        cbAddEstimatedTimeFilter.Checked = true;
                        break;
                    case FilterObjects.DoneRatio:
                        if (currentFilter.Condition == FilterConditions.IS)
                            cbDoneRatioFilterVars.SelectedIndex = 0;
                        else if (currentFilter.Condition == FilterConditions.ISNOT)
                            cbDoneRatioFilterVars.SelectedIndex = 1;
                        else if (currentFilter.Condition == FilterConditions.MORE_OR_EQUAL)
                            cbDoneRatioFilterVars.SelectedIndex = 2;
                        else if (currentFilter.Condition == FilterConditions.LESS_OR_EQUAL)
                            cbDoneRatioFilterVars.SelectedIndex = 3;
                        else if (currentFilter.Condition == FilterConditions.BEETWEN)
                            cbDoneRatioFilterVars.SelectedIndex = 4;
                        if (currentFilter.Condition == FilterConditions.BEETWEN)
                        {
                            nudDoneRatio1.Value = Convert.ToDecimal(((int[])currentFilter.Value)[0]);
                            nudDoneRatio2.Value = Convert.ToDecimal(((int[])currentFilter.Value)[1]);
                        }
                        else
                            nudDoneRatio1.Value = Convert.ToDecimal((int)currentFilter.Value);
                        cbAddDoneRatioFilter.Checked = true;
                        break;
                    case FilterObjects.Author:
                        if (currentFilter.Condition == FilterConditions.IS)
                            cbAuthorFilterVars.SelectedIndex = 0;
                        else if (currentFilter.Condition == FilterConditions.ISNOT)
                            cbAuthorFilterVars.SelectedIndex = 1;
                        indexToSelect = -1;
                        for (int i = 0; i < cbAuthor.Items.Count; i++)
                            if ((long)(cbAuthor.Items[i] as TextAndValueItem).Value == (long)currentFilter.Value)
                            {
                                indexToSelect = i;
                                break;
                            }
                        if (indexToSelect != -1)
                            cbAuthor.SelectedIndex = indexToSelect;
                        cbAddAuthorFilter.Checked = true;
                        break;
                    case FilterObjects.Assignee:
                        if (currentFilter.Condition == FilterConditions.IS)
                            cbAssigneeFilterVars.SelectedIndex = 0;
                        else if (currentFilter.Condition == FilterConditions.ISNOT)
                            cbAssigneeFilterVars.SelectedIndex = 1;
                        indexToSelect = -1;
                        for (int i = 0; i < cbAssignee.Items.Count; i++)
                            if ((long)(cbAssignee.Items[i] as TextAndValueItem).Value == (long)currentFilter.Value)
                            {
                                indexToSelect = i;
                                break;
                            }
                        if (indexToSelect != -1)
                            cbAssignee.SelectedIndex = indexToSelect;
                        cbAddAssigneeFilter.Checked = true;
                        break;
                }
            }
        }
    }
}
