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
        private string projectRoles;

        public IssueInformationForm(long issueID, string projectRoles)
        {
            InitializeComponent();
            this.issueID = issueID;
            this.projectRoles = projectRoles;
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
            }
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
            string jsonRequest = JsonConvert.SerializeObject(new NewIssueJSONObject { NewIssue = updatedIssue }, Newtonsoft.Json.Formatting.Indented, new JsonSerializerSettings { DefaultValueHandling = DefaultValueHandling.Ignore });
            ChangeUIState(false);
            this.Text = "Issue information [please, wait..]";
            controller.UpdateIssue(issueID, jsonRequest);
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
                        foreach (Project currentProject in controller.GetProjects().Where(temp => temp.Roles.Contains("Manager")))
                        {
                            if (currentProject.Parent == null)
                                cbProject.Items.Add(new TextAndValueItem { Text = currentProject.Name, Value = currentProject.ID });
                            else
                                cbProject.Items.Add(new TextAndValueItem { Text = "    └ " + currentProject.Name, Value = currentProject.ID });
                            if (currentProject.ID == issue.Project.ID)
                                indexToSelect = cbProject.Items.Count - 1;
                        }
                        cbProject.SelectedIndex = indexToSelect;
                        indexToSelect = 0;
                        foreach (IssueTracker currentTracker in issueTrackers)
                        {
                            cbTracker.Items.Add(new TextAndValueItem { Text = currentTracker.Name, Value = currentTracker.ID });
                            if (currentTracker.ID == issue.Tracker.ID)
                                indexToSelect = cbTracker.Items.Count - 1;
                        }
                        cbTracker.SelectedIndex = indexToSelect;
                        indexToSelect = 0;
                        if (!projectRoles.Contains("Manager"))
                            issueStatuses.RemoveAll(temp => temp.ID < issue.Status.ID || temp.Name == "Closed" || temp.Name == "Rejected");
                        foreach (IssueStatus currentStatus in issueStatuses)
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
                        tbSubject.ReadOnly = !projectRoles.Contains("Manager");
                        tbDescription.ReadOnly = !projectRoles.Contains("Manager");
                        FillIssueHistory(issue, issueTrackers, issueStatuses, issuePriorities, memberships);
                        ChangeUIState(true);
                        this.Text = "Issue information [" + projectRoles + "]";
                        break;
                    case ErrorTypes.ConnectionError:
                        this.Text = "Issue information [" + projectRoles + "]";
                        MessageBox.Show("Cannot connect to Redmine services. Please check your Internet connection and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Close();
                        break;
                    case ErrorTypes.UnathorizedAccess:
                        this.Text = "Issue information [" + projectRoles + "]";
                        MessageBox.Show("You have the wrong authorization data. Please change it and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        controller.NeedToReAuthenticate();
                        this.Close();
                        break;
                    case ErrorTypes.UnknownError:
                        this.Text = "Issue information [" + projectRoles + "]";
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

        private void controller_OnIssueUpdated(ErrorTypes error)
        {
            Action action = () =>
            {
                switch (error)
                {
                    case ErrorTypes.NoErrors:
                        this.Close();
                        break;
                    case ErrorTypes.ConnectionError:
                        this.Text = "Issue information [" + projectRoles + "]";
                        MessageBox.Show("Cannot connect to Redmine services. Please check your Internet connection and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        ChangeUIState(true);
                        break;
                    case ErrorTypes.UnathorizedAccess:
                        this.Text = "Issue information [" + projectRoles + "]";
                        MessageBox.Show("You have the wrong authorization data. Please change it and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        controller.NeedToReAuthenticate();
                        this.Close();
                        break;
                    case ErrorTypes.UnknownError:
                        this.Text = "Issue information [" + projectRoles + "]";
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
                            result += " » Project changed from \"" + Program.controllerGlobal.GetProject(Convert.ToInt64(currentDetail.OldValue)).Name + "\" to \"" + Program.controllerGlobal.GetProject(Convert.ToInt64(currentDetail.NewValue)).Name + "\"\r\n";
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
                                result += " » Assignee set to " + memberships.Single(temp => temp.User.ID.ToString() == currentDetail.NewValue).User.Name + "\r\n";
                            else
                                result += " » Assignee deleted (last: " + memberships.Single(temp => temp.User.ID.ToString() == currentDetail.OldValue).User.Name + ")\r\n";
                            break;
                        case "subject":
                            result += " » Subject changed from \"" + currentDetail.OldValue + "\" to \"" + currentDetail.NewValue + "\"\r\n";
                            break;
                        case "description":
                            result += " » Description updated\r\n";
                            break;
                        case "start_date":
                            result += " » Start date changed from \"" + currentDetail.OldValue + "\" to \"" + currentDetail.NewValue + "\"\r\n";
                            break;
                        case "due_date":
                            result += " » Due date changed from \"" + currentDetail.OldValue + "\" to \"" + currentDetail.NewValue + "\"\r\n";
                            break;
                        case "estimated_hours":
                            result += " » Estimated time changed from \"" + currentDetail.OldValue + "\" to \"" + currentDetail.NewValue + "\"\r\n";
                            break;
                        case "done_ratio":
                            result += " » % Done changed from \"" + currentDetail.OldValue + "\" to \"" + currentDetail.NewValue + "\"\r\n";
                            break;
                        case "is_private":
                            result += " » Private changed from \"" + (currentDetail.OldValue == "1" ? "Yes" : "No") + "\" to \"" + (currentDetail.NewValue == "1" ? "Yes" : "No") + "\"\r\n";
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
            cbProject.Enabled = isEnabled && projectRoles.Contains("Manager");
            cbTracker.Enabled = isEnabled && projectRoles.Contains("Manager");
            cbStatus.Enabled = isEnabled;
            cbPriority.Enabled = isEnabled && projectRoles.Contains("Manager");
            cbAssignedTo.Enabled = isEnabled && projectRoles.Contains("Manager");
            tbAuthor.Enabled = isEnabled;
            cbAddNote.Enabled = isEnabled;
            tbSubject.Enabled = isEnabled;
            tbDescription.Enabled = isEnabled;
            cbIsPrivate.Enabled = isEnabled && projectRoles.Contains("Manager");
            dtpStartDate.Enabled = isEnabled && projectRoles.Contains("Manager");
            dtpDueDate.Enabled = isEnabled && projectRoles.Contains("Manager");
            nudEstimatedTime.Enabled = isEnabled && projectRoles.Contains("Manager");
            nudDoneRatio.Enabled = isEnabled && projectRoles.Contains("Manager");
            tbCreationDate.Enabled = isEnabled;
            tbLastUpdate.Enabled = isEnabled;
            tbClosedDate.Enabled = isEnabled;
            btnSave.Enabled = isEnabled;
            btnClose.Enabled = isEnabled;
        }
    }
}
