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
        private Issue issue;
        private List<IssueTracker> issueTrackers;
        private List<IssueStatus> issueStatuses;
        private List<IssuePriority> issuePriorities;
        private List<Membership> memberships;

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

        private void btnSave_Click(object sender, EventArgs e)
        {
            NewIssue updatedIssue = new NewIssue();
            updatedIssue.Subject = tbSubject.Text;
            updatedIssue.TrackerID = (int)(cbTracker.SelectedItem as TextAndValueItem).Value;
            updatedIssue.StatusID = (int)(cbStatus.SelectedItem as TextAndValueItem).Value;
            updatedIssue.PriorityID = (int)(cbPriority.SelectedItem as TextAndValueItem).Value;
            updatedIssue.AssignedToID = (cbAssignedTo.SelectedItem as TextAndValueItem).Value.ToString();
            updatedIssue.Description = tbDescription.Text;
            updatedIssue.DoneRatio = (int)nudDoneRatio.Value;
            if (cbAddNote.Checked)
                updatedIssue.Notes = tbAddNote.Text;
            string jsonRequest = JsonConvert.SerializeObject(new NewIssueJSONObject { NewIssue = updatedIssue }, Newtonsoft.Json.Formatting.Indented, new JsonSerializerSettings { DefaultValueHandling = DefaultValueHandling.Ignore });
            tbID.Enabled = false;
            tbSubject.Enabled = false;
            cbTracker.Enabled = false;
            cbStatus.Enabled = false;
            cbPriority.Enabled = false;
            cbAssignedTo.Enabled = false;
            tbAuthor.Enabled = false;
            tbDescription.Enabled = false;
            tbStartDate.Enabled = false;
            tbCreationDate.Enabled = false;
            tbLastUpdate.Enabled = false;
            nudDoneRatio.Enabled = false;
            tbClosedDate.Enabled = false;
            cbAddNote.Enabled = false;
            tbAddNote.Enabled = false;
            btnSave.Enabled = false;
            btnRemoveIssue.Enabled = false;
            btnShowHistory.Enabled = false;
            btnClose.Enabled = false;
            this.Text = "Issue information [please, wait..]";
            controller.UpdateIssue(issueID, jsonRequest);
        }

        private void cbAddNote_CheckedChanged(object sender, EventArgs e)
        {
            tbAddNote.Enabled = cbAddNote.Checked;
        }

        private void btnRemoveIssue_Click(object sender, EventArgs e)
        {
            var dialogResult = MessageBox.Show("Are you really sure you want to remove issue #" + issueID + "?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                tbID.Enabled = false;
                tbSubject.Enabled = false;
                cbTracker.Enabled = false;
                cbStatus.Enabled = false;
                cbPriority.Enabled = false;
                cbAssignedTo.Enabled = false;
                tbAuthor.Enabled = false;
                tbDescription.Enabled = false;
                tbStartDate.Enabled = false;
                tbCreationDate.Enabled = false;
                tbLastUpdate.Enabled = false;
                nudDoneRatio.Enabled = false;
                tbClosedDate.Enabled = false;
                cbAddNote.Enabled = false;
                tbAddNote.Enabled = false;
                btnSave.Enabled = false;
                btnRemoveIssue.Enabled = false;
                btnShowHistory.Enabled = false;
                btnClose.Enabled = true;
                this.Text = "Issue information [please, wait..]";
                controller.RemoveIssue(issueID);
            }
        }

        private void btnShowHistory_Click(object sender, EventArgs e)
        {
            new IssueHistoryForm(issue, issueTrackers, issueStatuses, issuePriorities, memberships).ShowDialog();
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
                        this.issue = issue;
                        this.issueTrackers = issueTrackers;
                        this.issueStatuses = issueStatuses;
                        this.issuePriorities = issuePriorities;
                        this.memberships = memberships;
                        tbID.Text = issue.ID.ToString();
                        tbSubject.Text = issue.Subject;
                        int indexToSelect = 0;
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
                        tbDescription.Text = issue.Description;
                        tbStartDate.Text = issue.StartDate.ToShortDateString();
                        tbCreationDate.Text = issue.CreatedOn.ToShortTimeString() + ", " + issue.CreatedOn.ToShortDateString();
                        tbLastUpdate.Text = issue.UpdatedOn.ToShortTimeString() + ", " + issue.UpdatedOn.ToShortDateString();
                        nudDoneRatio.Value = issue.DoneRatio;
                        if (issue.ClosedOn != DateTime.MinValue)
                        {
                            tbClosedDate.Text = issue.ClosedOn.ToShortTimeString() + ", " + issue.ClosedOn.ToShortDateString();
                            labelClosesDate.Visible = true;
                            tbClosedDate.Enabled = true;
                            tbClosedDate.Visible = true;
                        }
                        tbID.Enabled = true;
                        tbSubject.Enabled = true;
                        tbSubject.ReadOnly = !projectRoles.Contains("Manager");
                        cbTracker.Enabled = projectRoles.Contains("Manager");
                        cbStatus.Enabled = true;
                        cbPriority.Enabled = projectRoles.Contains("Manager");
                        cbAssignedTo.Enabled = projectRoles.Contains("Manager");
                        tbAuthor.Enabled = true;
                        tbDescription.Enabled = true;
                        tbDescription.ReadOnly = !projectRoles.Contains("Manager");
                        tbStartDate.Enabled = true;
                        tbCreationDate.Enabled = true;
                        tbLastUpdate.Enabled = true;
                        nudDoneRatio.Enabled = projectRoles.Contains("Manager");
                        cbAddNote.Enabled = true;
                        btnSave.Enabled = true;
                        btnRemoveIssue.Enabled = projectRoles.Contains("Manager");
                        btnShowHistory.Enabled = issue.Journals != null && issue.Journals.Count > 0;
                        btnClose.Enabled = true;
                        this.Text = "Issue information [" + projectRoles + "]";
                        break;
                    case ErrorTypes.NetworkError:
                        MessageBox.Show("Cannot connect to Redmine services. Please check your Internet connection and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Close();
                        break;
                    case ErrorTypes.UnathorizedAccess:
                        MessageBox.Show("You have wrong authorization data. Please check it, change if necessary and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Close();
                        break;
                    case ErrorTypes.UnknownError:
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
                    case ErrorTypes.NetworkError:
                        MessageBox.Show("Cannot connect to Redmine services. Please check your Internet connection and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        tbID.Enabled = true;
                        tbSubject.Enabled = true;
                        cbTracker.Enabled = projectRoles.Contains("Manager");
                        cbStatus.Enabled = true;
                        cbPriority.Enabled = projectRoles.Contains("Manager");
                        cbAssignedTo.Enabled = projectRoles.Contains("Manager");
                        tbAuthor.Enabled = true;
                        tbDescription.Enabled = true;
                        tbStartDate.Enabled = true;
                        tbCreationDate.Enabled = true;
                        tbLastUpdate.Enabled = true;
                        nudDoneRatio.Enabled = projectRoles.Contains("Manager");
                        tbClosedDate.Enabled = true;
                        cbAddNote.Enabled = true;
                        tbAddNote.Enabled = cbAddNote.Checked;
                        btnSave.Enabled = true;
                        btnRemoveIssue.Enabled = projectRoles.Contains("Manager");
                        btnShowHistory.Enabled = issue.Journals != null && issue.Journals.Count > 0;
                        btnClose.Enabled = true;
                        this.Text = "Issue information [" + projectRoles + "]";
                        break;
                    case ErrorTypes.UnathorizedAccess:
                        MessageBox.Show("You have wrong authorization data. Please check it, change if necessary and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        tbID.Enabled = true;
                        tbSubject.Enabled = true;
                        cbTracker.Enabled = projectRoles.Contains("Manager");
                        cbStatus.Enabled = true;
                        cbPriority.Enabled = projectRoles.Contains("Manager");
                        cbAssignedTo.Enabled = projectRoles.Contains("Manager");
                        tbAuthor.Enabled = true;
                        tbDescription.Enabled = true;
                        tbStartDate.Enabled = true;
                        tbCreationDate.Enabled = true;
                        tbLastUpdate.Enabled = true;
                        nudDoneRatio.Enabled = projectRoles.Contains("Manager");
                        tbClosedDate.Enabled = true;
                        cbAddNote.Enabled = true;
                        tbAddNote.Enabled = cbAddNote.Checked;
                        btnSave.Enabled = true;
                        btnRemoveIssue.Enabled = projectRoles.Contains("Manager");
                        btnShowHistory.Enabled = issue.Journals != null && issue.Journals.Count > 0;
                        btnClose.Enabled = true;
                        this.Text = "Issue information [" + projectRoles + "]";
                        break;
                    case ErrorTypes.UnknownError:
                        MessageBox.Show("An unknown error occurred. Please, try again one more time.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        tbID.Enabled = true;
                        tbSubject.Enabled = true;
                        cbTracker.Enabled = projectRoles.Contains("Manager");
                        cbStatus.Enabled = true;
                        cbPriority.Enabled = projectRoles.Contains("Manager");
                        cbAssignedTo.Enabled = projectRoles.Contains("Manager");
                        tbAuthor.Enabled = true;
                        tbDescription.Enabled = true;
                        tbStartDate.Enabled = true;
                        tbCreationDate.Enabled = true;
                        tbLastUpdate.Enabled = true;
                        nudDoneRatio.Enabled = projectRoles.Contains("Manager");
                        tbClosedDate.Enabled = true;
                        cbAddNote.Enabled = true;
                        tbAddNote.Enabled = cbAddNote.Checked;
                        btnSave.Enabled = true;
                        btnRemoveIssue.Enabled = projectRoles.Contains("Manager");
                        btnShowHistory.Enabled = issue.Journals != null && issue.Journals.Count > 0;
                        btnClose.Enabled = true;
                        this.Text = "Issue information [" + projectRoles + "]";
                        break;
                }
            };
            if (InvokeRequired)
                Invoke(action);
            else
                action();
        }
    }
}
