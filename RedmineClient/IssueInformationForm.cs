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
        private bool isHasJournals = false;

        public IssueInformationForm(long issueID, string projectRoles)
        {
            InitializeComponent();
            this.issueID = issueID;
            this.projectRoles = projectRoles;
            this.StartPosition = FormStartPosition.CenterParent;
        }
        private void IssueInformationForm_Shown(object sender, EventArgs e)
        {
            labelID.Select();
            controller = Program.controllerGlobal;
            controller.OnIssueInformationLoaded += controller_OnIssueInformationLoaded;
            controller.OnIssueRemoved += controller_OnIssueRemoved;
            controller.LoadIssueInformation(issueID);
        }

        private void IssueInformationForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            controller.OnIssueInformationLoaded -= controller_OnIssueInformationLoaded;
            controller.OnIssueRemoved -= controller_OnIssueRemoved;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
        }

        private void btnRemoveIssue_Click(object sender, EventArgs e)
        {
            var dialogResult = MessageBox.Show("Are you really sure that you want to remove issue #" + issueID + "?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                tbSubject.ReadOnly = false;
                cbTracker.Enabled = false;
                cbStatus.Enabled = false;
                cbPriority.Enabled = false;
                cbAssignedTo.Enabled = false;
                tbDescription.ReadOnly = false;
                nudDoneRatio.Enabled = false;
                btnSave.Enabled = false;
                btnRemoveIssue.Enabled = false;
                btnShowHistory.Enabled = false;
                btnClose.Enabled = false;
                this.Text = "Issue information [please, wait..]";
                controller.RemoveIssue(issueID);
            }
        }

        private void btnShowHistory_Click(object sender, EventArgs e)
        {

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
                        tbSubject.Text = issue.Subject;
                        int indexToSelect = 0;
                        foreach (IssueTracker tracker in issueTrackers)
                        {
                            cbTracker.Items.Add(new TextAndValueItem { Text = tracker.Name, Value = tracker.ID });
                            if (tracker.ID == issue.Tracker.ID)
                                indexToSelect = cbTracker.Items.Count - 1;
                        }
                        cbTracker.SelectedIndex = indexToSelect;
                        indexToSelect = 0;
                        if (!projectRoles.Contains("Manager"))
                            issueStatuses.RemoveAll(temp => temp.ID < issue.Status.ID || temp.Name == "Closed" || temp.Name == "Rejected");
                        foreach (IssueStatus status in issueStatuses)
                        {
                            cbStatus.Items.Add(new TextAndValueItem { Text = status.Name, Value = status.ID });
                            if (status.ID == issue.Status.ID)
                                indexToSelect = cbStatus.Items.Count - 1;
                        }
                        cbStatus.SelectedIndex = indexToSelect;
                        indexToSelect = 0;
                        foreach (IssuePriority priority in issuePriorities)
                        {
                            cbPriority.Items.Add(new TextAndValueItem { Text = priority.Name, Value = priority.ID });
                            if (priority.ID == issue.Priority.ID)
                                indexToSelect = cbPriority.Items.Count - 1;
                        }
                        cbPriority.SelectedIndex = indexToSelect;
                        indexToSelect = 0;
                        foreach (Membership membership in memberships)
                        {
                            cbAssignedTo.Items.Add(new TextAndValueItem { Text = membership.User.Name, Value = membership.User.ID });
                            if (issue.AssignedTo != null && membership.User.ID == issue.AssignedTo.ID)
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
                            tbClosedDate.Visible = true;
                        }
                        tbSubject.ReadOnly = !projectRoles.Contains("Manager");
                        cbTracker.Enabled = projectRoles.Contains("Manager");
                        cbStatus.Enabled = true;
                        cbPriority.Enabled = projectRoles.Contains("Manager");
                        cbAssignedTo.Enabled = projectRoles.Contains("Manager");
                        tbDescription.ReadOnly = !projectRoles.Contains("Manager");
                        nudDoneRatio.Enabled = projectRoles.Contains("Manager");
                        btnSave.Enabled = true;
                        btnRemoveIssue.Enabled = projectRoles.Contains("Manager");
                        isHasJournals = issue.Journals != null;
                        btnShowHistory.Enabled = isHasJournals;
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

        private void controller_OnIssueRemoved(ErrorTypes error)
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
                        tbSubject.ReadOnly = !projectRoles.Contains("Manager");
                        cbTracker.Enabled = projectRoles.Contains("Manager");
                        cbStatus.Enabled = true;
                        cbPriority.Enabled = projectRoles.Contains("Manager");
                        cbAssignedTo.Enabled = projectRoles.Contains("Manager");
                        tbDescription.ReadOnly = !projectRoles.Contains("Manager");
                        nudDoneRatio.Enabled = !projectRoles.Contains("Manager");
                        btnSave.Enabled = true;
                        btnRemoveIssue.Enabled = projectRoles.Contains("Manager");
                        btnShowHistory.Enabled = isHasJournals;
                        btnClose.Enabled = true;
                        this.Text = "Issue information [" + projectRoles + "]";
                        break;
                    case ErrorTypes.UnathorizedAccess:
                        MessageBox.Show("You have wrong authorization data. Please check it, change if necessary and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        tbSubject.ReadOnly = !projectRoles.Contains("Manager");
                        cbTracker.Enabled = projectRoles.Contains("Manager");
                        cbStatus.Enabled = true;
                        cbPriority.Enabled = projectRoles.Contains("Manager");
                        cbAssignedTo.Enabled = projectRoles.Contains("Manager");
                        tbDescription.ReadOnly = !projectRoles.Contains("Manager");
                        nudDoneRatio.Enabled = !projectRoles.Contains("Manager");
                        btnSave.Enabled = true;
                        btnRemoveIssue.Enabled = projectRoles.Contains("Manager");
                        btnShowHistory.Enabled = isHasJournals;
                        btnClose.Enabled = true;
                        this.Text = "Issue information [" + projectRoles + "]";
                        break;
                    case ErrorTypes.UnknownError:
                        MessageBox.Show("An unknown error occurred. Please, try again one more time.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        tbSubject.ReadOnly = !projectRoles.Contains("Manager");
                        cbTracker.Enabled = projectRoles.Contains("Manager");
                        cbStatus.Enabled = true;
                        cbPriority.Enabled = projectRoles.Contains("Manager");
                        cbAssignedTo.Enabled = projectRoles.Contains("Manager");
                        tbDescription.ReadOnly = !projectRoles.Contains("Manager");
                        nudDoneRatio.Enabled = !projectRoles.Contains("Manager");
                        btnSave.Enabled = true;
                        btnRemoveIssue.Enabled = projectRoles.Contains("Manager");
                        btnShowHistory.Enabled = isHasJournals;
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
