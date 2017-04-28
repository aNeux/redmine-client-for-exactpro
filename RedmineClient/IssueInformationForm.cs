using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using RedmineClient.Models;
using Newtonsoft.Json;

namespace RedmineClient
{
    public partial class IssueInformationForm : Form
    {
        private Controller controller;
        private long issueID;
        private bool isManager;

        public IssueInformationForm(long issueID, bool isManager)
        {
            InitializeComponent();
            this.issueID = issueID;
            this.isManager = isManager;
            this.StartPosition = FormStartPosition.CenterParent;
        }
        private void IssueInformationForm_Shown(object sender, EventArgs e)
        {
            cbAssignedTo.Items.Add(new TextAndValueItem { Text = "< none >", Value = "" });
            labelID.Select();
            controller = Program.controllerGlobal;
            controller.OnIssueInformationLoaded += controller_OnIssueInformationLoaded;
            controller.OnIssueUpdated += controller_OnIssueUpdated;
            controller.LoadIssueInformation(issueID);
        }

        private void IssueInformationForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            controller.OnIssueInformationLoaded -= controller_OnIssueInformationLoaded;
            controller.OnIssueUpdated -= controller_OnIssueUpdated;
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl.SelectedIndex == 1)
            {
                tbHistory.Select();
                tbHistory.SelectionStart = tbHistory.Text.Length;
                tbHistory.ScrollToCaret();
                btnSave.Enabled = false;
            }
            else
                btnSave.Enabled = true;
        }

        private void cbAddNote_CheckedChanged(object sender, EventArgs e)
        {
            cbIsNotePrivate.Enabled = cbAddNote.Checked;
            tbAddNote.Enabled = cbAddNote.Checked;
        }

        private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            DateTimePicker dtpCurrent = (DateTimePicker)sender;
            if (dtpCurrent.Format == DateTimePickerFormat.Custom)
                dtpCurrent.Format = DateTimePickerFormat.Short;
        }

        private void dtpDueDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dtpDueDate.Value = DateTime.Now;
                btnResetDueDate.Enabled = true;
            }
        }

        private void dtpDueDate_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left || e.Button == MouseButtons.Right)
            {
                dtpDueDate.Value = DateTime.Now;
                btnResetDueDate.Enabled = true;
            }
        }

        private void btnResetDueDate_Click(object sender, EventArgs e)
        {
            dtpDueDate.Format = DateTimePickerFormat.Custom;
            btnResetDueDate.Enabled = false;
            dtpDueDate.Select();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            NewIssue updatedIssue = new NewIssue();
            updatedIssue.ProjectID = (long)(cbProject.SelectedItem as TextAndValueItem).Value;
            updatedIssue.TrackerID = (int)(cbTracker.SelectedItem as TextAndValueItem).Value;
            updatedIssue.StatusID = (int)(cbStatus.SelectedItem as TextAndValueItem).Value;
            updatedIssue.PriorityID = (int)(cbPriority.SelectedItem as TextAndValueItem).Value;
            updatedIssue.AssignedToID = (cbAssignedTo.SelectedItem as TextAndValueItem).Value.ToString();
            updatedIssue.Subject = tbSubject.Text;
            updatedIssue.Description = tbDescription.Text;
            updatedIssue.IsPrivate = cbIsPrivate.Checked;
            if (dtpStartDate.Format != DateTimePickerFormat.Custom)
                updatedIssue.DueDate = dtpStartDate.Value.ToString("yyyy-MM-dd");
            if (dtpDueDate.Format != DateTimePickerFormat.Custom)
                updatedIssue.DueDate = dtpDueDate.Value.ToString("yyyy-MM-dd");
            updatedIssue.EstimatedHours = (int)nudEstimatedTime.Value;
            updatedIssue.DoneRatio = (int)nudDoneRatio.Value;
            if (cbAddNote.Checked)
            {
                updatedIssue.Note = tbAddNote.Text;
                updatedIssue.IsNotePrivate = cbIsNotePrivate.Checked;
            }
            ChangeUIState(false);
            this.Text = "Issue information [please, wait..]";
            controller.UpdateIssue(issueID, updatedIssue);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void controller_OnIssueInformationLoaded(ErrorTypes error, Issue issue, List<IssueTracker> issueTrackers, List<IssueStatus> issueStatuses, List<IssuePriority> issuePriorities, List<Membership> memberships)
        {
            Action action = () =>
            {
                switch (error)
                {
                    case ErrorTypes.NoErrors:
                        tbID.Text = issue.ID.ToString();
                        int indexToSelect = 0;
                        List<Project> projects = controller.GetProjects();
                        Project projectForThisIssue = projects.Single(temp => temp.ID == issue.Project.ID);
                        if (projectForThisIssue.Status != 5)
                        {
                            if (isManager)
                                projects.RemoveAll(temp1 => temp1.Roles.FindIndex(temp2 => temp2.ID == 3) < 0 || temp1.Status == 5);
                            foreach (Project currentProject in projects)
                            {
                                if (currentProject.Parent == null)
                                    cbProject.Items.Add(new TextAndValueItem { Text = currentProject.Name, Value = currentProject.ID });
                                else
                                    cbProject.Items.Add(new TextAndValueItem { Text = "    └ " + currentProject.Name, Value = currentProject.ID });
                                if (currentProject.ID == issue.Project.ID)
                                    indexToSelect = cbProject.Items.Count - 1;
                            }
                            cbProject.SelectedIndex = indexToSelect;
                        }
                        else
                        {
                            if (projectForThisIssue.Parent == null)
                                cbProject.Items.Add(new TextAndValueItem { Text = projectForThisIssue.Name, Value = projectForThisIssue.ID });
                            else
                                cbProject.Items.Add(new TextAndValueItem { Text = "    └ " + projectForThisIssue.Name, Value = projectForThisIssue.ID });
                            cbProject.SelectedIndex = 0;
                        }
                        indexToSelect = 0;
                        foreach (IssueTracker currentTracker in issueTrackers)
                        {
                            cbTracker.Items.Add(new TextAndValueItem { Text = currentTracker.Name, Value = currentTracker.ID });
                            if (currentTracker.ID == issue.Tracker.ID)
                                indexToSelect = cbTracker.Items.Count - 1;
                        }
                        cbTracker.SelectedIndex = indexToSelect;
                        indexToSelect = 0;
                        List<IssueStatus> availableIssueStatuses = new List<IssueStatus>();
                        availableIssueStatuses.AddRange(issueStatuses);
                        if (!isManager)
                            availableIssueStatuses.RemoveAll(temp => temp.ID < issue.Status.ID || temp.Name == "Closed" || temp.Name == "Rejected");
                        foreach (IssueStatus currentStatus in availableIssueStatuses)
                        {
                            cbStatus.Items.Add(new TextAndValueItem { Text = currentStatus.Name, Value = currentStatus.ID });
                            if (currentStatus.ID == issue.Status.ID)
                                indexToSelect = cbStatus.Items.Count - 1;
                        }
                        cbStatus.SelectedIndex = indexToSelect;
                        indexToSelect = 0;
                        foreach (IssuePriority currentPriority in issuePriorities)
                        {
                            cbPriority.Items.Add(new TextAndValueItem { Text = currentPriority.Name, Value = currentPriority.ID });
                            if (currentPriority.ID == issue.Priority.ID)
                                indexToSelect = cbPriority.Items.Count - 1;
                        }
                        cbPriority.SelectedIndex = indexToSelect;
                        indexToSelect = 0;
                        foreach (Membership currentMembership in memberships)
                        {
                            cbAssignedTo.Items.Add(new TextAndValueItem { Text = currentMembership.User.Name, Value = currentMembership.User.ID });
                            if (issue.AssignedTo != null && currentMembership.User.ID == issue.AssignedTo.ID)
                                indexToSelect = cbAssignedTo.Items.Count - 1;
                        }
                        cbAssignedTo.SelectedIndex = indexToSelect;
                        tbAuthor.Text = issue.Author.Name;
                        tbSubject.Text = issue.Subject;
                        tbDescription.Text = issue.Description;
                        cbIsPrivate.Checked = issue.IsPrivate;
                        if (issue.StartDate != new DateTime())
                            dtpStartDate.Value = issue.StartDate;
                        if (issue.DueDate != new DateTime())
                            dtpDueDate.Value = issue.DueDate;
                        nudEstimatedTime.Value = issue.EstimatedHours != null && issue.EstimatedHours.Length > 0 ? (int)double.Parse(issue.EstimatedHours, System.Globalization.CultureInfo.InvariantCulture) : 0;
                        nudDoneRatio.Value = issue.DoneRatio;
                        tbCreationDate.Text = issue.CreatedOn.ToShortTimeString() + ", " + issue.CreatedOn.ToShortDateString();
                        tbLastUpdate.Text = issue.UpdatedOn.ToShortTimeString() + ", " + issue.UpdatedOn.ToShortDateString();
                        if (issue.ClosedOn != DateTime.MinValue)
                        {
                            tbClosedDate.Text = issue.ClosedOn.ToShortTimeString() + ", " + issue.ClosedOn.ToShortDateString();
                            labelClosesDate.Visible = true;
                            tbClosedDate.Visible = true;
                        }
                        tbSubject.ReadOnly = !isManager;
                        tbDescription.ReadOnly = !isManager;
                        FillIssueHistory(issue, issueTrackers, issueStatuses, issuePriorities, memberships);
                        if (projectForThisIssue.Status != 5)
                        {
                            btnSave.Visible = true;
                            ChangeUIState(true);
                            this.Text = "Issue information";
                        }
                        else
                        {
                            tabControl.Enabled = true;
                            btnClose.Enabled = true;
                            this.Text = "Issue information [closed]";
                        }
                        break;
                    case ErrorTypes.ConnectionError:
                        this.Text = "Issue information";
                        MessageBox.Show("Cannot connect to Redmine services. Please check your Internet connection and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Close();
                        break;
                    case ErrorTypes.UnathorizedAccess:
                        this.Text = "Issue information";
                        MessageBox.Show("You have the wrong authorization data. Please change it and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        controller.NeedToReAuthenticate();
                        this.Close();
                        break;
                    case ErrorTypes.UnknownError:
                        this.Text = "Issue information";
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

        private void controller_OnIssueUpdated(ErrorTypes error, long projectID)
        {
            Action action = () =>
            {
                switch (error)
                {
                    case ErrorTypes.NoErrors:
                        this.Close();
                        break;
                    case ErrorTypes.ConnectionError:
                        this.Text = "Issue information";
                        MessageBox.Show("Cannot connect to Redmine services. Please check your Internet connection and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        ChangeUIState(true);
                        break;
                    case ErrorTypes.UnathorizedAccess:
                        this.Text = "Issue information";
                        MessageBox.Show("You have the wrong authorization data. Please change it and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        controller.NeedToReAuthenticate();
                        this.Close();
                        break;
                    case ErrorTypes.UnknownError:
                        this.Text = "Issue information";
                        MessageBox.Show("An unknown error occurred. Please, try again one more time.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        ChangeUIState(true);
                        break;
                }
            };
            if (InvokeRequired)
                Invoke(action);
            else
                action();
        }

        private void FillIssueHistory(Issue issue, List<IssueTracker> issueTrackers, List<IssueStatus> issueStatuses, List<IssuePriority> issuePriorities, List<Membership> memberships)
        {
            string result = "";
            for (int i = 0; i < issue.Journals.Count; i++)
            {
                Journal currentJournal = issue.Journals[i];
                result += "# " + (i + 1) + ": updated by " + currentJournal.User.Name + " at " + currentJournal.CreatedOn.ToShortTimeString() + ", " + currentJournal.CreatedOn.ToShortDateString() + "\r\n";
                foreach (JournalDetail currentDetail in currentJournal.Details)
                {
                    switch (currentDetail.Name)
                    {
                        case "project_id":
                            try
                            {
                                result += " » Project changed from \"" + Program.controllerGlobal.GetProjects().Single(temp => temp.ID == Convert.ToInt64(currentDetail.OldValue)).Name + "\" to \"" + Program.controllerGlobal.GetProjects().Single(temp => temp.ID == Convert.ToInt64(currentDetail.NewValue)).Name + "\"\r\n";
                            }
                            catch
                            {
                                result += " » Project's ID changed from \"" + currentDetail.OldValue + "\" to \"" + currentDetail.NewValue + "\"\r\n";
                            }
                            break;
                        case "tracker_id":
                            result += " » Tracker changed from \"" + issueTrackers.Single(temp => temp.ID.ToString() == currentDetail.OldValue).Name + "\" to \"" + issueTrackers.Single(temp => temp.ID.ToString() == currentDetail.NewValue).Name + "\"\r\n";
                            break;
                        case "status_id":
                            result += " » Status changed from \"" + issueStatuses.Single(temp => temp.ID.ToString() == currentDetail.OldValue).Name + "\" to \"" + issueStatuses.Single(temp => temp.ID.ToString() == currentDetail.NewValue).Name + "\"\r\n";
                            break;
                        case "priority_id":
                            result += " » Priority changed from \"" + issuePriorities.Single(temp => temp.ID.ToString() == currentDetail.OldValue).Name + "\" to \"" + issuePriorities.Single(temp => temp.ID.ToString() == currentDetail.NewValue).Name + "\"\r\n";
                            break;
                        case "assigned_to_id":
                            if (currentDetail.NewValue != null)
                                try
                                {
                                    result += " » Assignee set to " + memberships.Single(temp => temp.User.ID.ToString() == currentDetail.NewValue).User.Name + "\r\n";
                                }
                                catch
                                {
                                    result += " » Assignee set to user with ID = \"" + currentDetail.NewValue + "\"\r\n";
                                }
                            else
                                try
                                {
                                    result += " » Assignee deleted (last: " + memberships.Single(temp => temp.User.ID.ToString() == currentDetail.OldValue).User.Name + ")\r\n";
                                }
                                catch
                                {
                                    result += " » Assignee deleted (last: user with ID = \"" + currentDetail.OldValue + "\")\r\n";
                                }
                            break;
                        case "subject":
                            result += " » Subject changed from \"" + currentDetail.OldValue + "\" to \"" + currentDetail.NewValue + "\"\r\n";
                            break;
                        case "description":
                            result += " » Description updated\r\n";
                            break;
                        case "start_date":
                            if (currentDetail.OldValue != null)
                                result += " » Start date changed from \"" + currentDetail.OldValue + "\" to \"" + currentDetail.NewValue + "\"\r\n";
                            else
                                result += " » Start date set to \"" + currentDetail.NewValue + "\"\r\n";
                            break;
                        case "due_date":
                            if (currentDetail.OldValue != null)
                                result += " » Due date changed from \"" + currentDetail.OldValue + "\" to \"" + currentDetail.NewValue + "\"\r\n";
                            else
                                result += " » Due date set to \"" + currentDetail.NewValue + "\"\r\n";
                            break;
                        case "estimated_hours":
                            if (currentDetail.OldValue != null)
                                result += " » Estimated time changed from \"" + currentDetail.OldValue + "\" to \"" + currentDetail.NewValue + "\"\r\n";
                            else
                                result += " » Estimated time set to \"" + currentDetail.NewValue + "\"\r\n";
                            break;
                        case "done_ratio":
                            if (currentDetail.OldValue != null)
                                result += " » % Done changed from \"" + currentDetail.OldValue + "\" to \"" + currentDetail.NewValue + "\"\r\n";
                            else
                                result += " » % Done set to \"" + currentDetail.NewValue + "\"\r\n";
                            break;
                        case "is_private":
                            if (currentDetail.OldValue != null)
                                result += " » Private changed from \"" + (currentDetail.OldValue == "1" ? "Yes" : "No") + "\" to \"" + (currentDetail.NewValue == "1" ? "Yes" : "No") + "\"\r\n";
                            else
                                result += " » Private set to \"" + (currentDetail.NewValue == "1" ? "Yes" : "No") + "\"\r\n";
                            break;
                    }
                }
                if (currentJournal.Note != null && currentJournal.Note.Length > 0)
                    result += " » Note: " + currentJournal.Note + "\r\n";
                result += "------------------------------------------------------------------------------------------\r\n";
            }
            tbHistory.Text = result;
        }

        private void ChangeUIState(bool isEnabled)
        {
            tabControl.Enabled = isEnabled;
            tbID.Enabled = isEnabled;
            cbProject.Enabled = isEnabled && isManager;
            cbTracker.Enabled = isEnabled && isManager;
            cbStatus.Enabled = isEnabled;
            cbPriority.Enabled = isEnabled && isManager;
            cbAssignedTo.Enabled = isEnabled && isManager;
            tbAuthor.Enabled = isEnabled;
            cbAddNote.Enabled = isEnabled;
            tbSubject.Enabled = isEnabled;
            tbDescription.Enabled = isEnabled;
            cbIsPrivate.Enabled = isEnabled && isManager;
            dtpStartDate.Enabled = isEnabled && isManager;
            dtpDueDate.Enabled = isEnabled && isManager;
            nudEstimatedTime.Enabled = isEnabled && isManager;
            nudDoneRatio.Enabled = isEnabled && isManager;
            tbCreationDate.Enabled = isEnabled;
            tbLastUpdate.Enabled = isEnabled;
            tbClosedDate.Enabled = isEnabled;
            btnSave.Enabled = isEnabled;
            btnClose.Enabled = isEnabled;
        }
    }
}
