using System;
using System.Collections.Generic;
using System.Linq;
using RedmineClient.Models;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace RedmineClient
{
    public partial class CreateNewIssueForm : Form
    {
        private Controller controller;
        private Project project;
        private bool isIssueCreated = false;

        public CreateNewIssueForm(Project project)
        {
            InitializeComponent();
            this.project = project;
            this.StartPosition = FormStartPosition.CenterParent;
        }

        private void CreateNewIssueForm_Shown(object sender, EventArgs e)
        {
            labelInfo.Select();
            controller = Program.controllerGlobal;
            controller.OnPreparedToCreateNewIssue += controller_OnPreparedToCreateNewIssue;
            controller.OnIssueCreated += controller_OnIssueCreated;
            controller.PrepareDataForCreatingNewIssue(project.ID);
        }

        private void CreateNewIssueForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!isIssueCreated && e.CloseReason == CloseReason.UserClosing)
            {
                var dialogResult = MessageBox.Show("Are you sure you want to stop creating new issue?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    controller.OnPreparedToCreateNewIssue -= controller_OnPreparedToCreateNewIssue;
                    controller.OnIssueCreated -= controller_OnIssueCreated;
                }
                else
                    e.Cancel = true;
            }
            else
            {
                controller.OnPreparedToCreateNewIssue -= controller_OnPreparedToCreateNewIssue;
                controller.OnIssueCreated -= controller_OnIssueCreated;
            }
        }

        private void btnCreateIssue_Click(object sender, EventArgs e)
        {
            if (tbSubject.Text.Length == 0)
                MessageBox.Show("Please, enter the subject for new issue!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                NewIssue newIssue = new NewIssue();
                newIssue.ProjectID = project.ID;
                newIssue.TrackerID = (int)(cbTracker.SelectedItem as TextAndValueItem).Value;
                newIssue.Subject = tbSubject.Text;
                newIssue.StatusID = 1;
                newIssue.PriorityID = (int)(cbPriority.SelectedItem as TextAndValueItem).Value;
                newIssue.AssignedToID = cbAssignee.SelectedIndex > 0 ? (long)(cbAssignee.SelectedItem as TextAndValueItem).Value : -1;
                newIssue.Description = tbDescription.Text;
                newIssue.IsPrivate = cbIsPrivate.Checked;
                newIssue.EstimatedHours = (int)nudEstimatedTime.Value;
                List<long> watcherUserIDs = new List<long>();
                foreach (var currentUser in cblWatchers.CheckedItems)
                    watcherUserIDs.Add((long)(currentUser as TextAndValueItem).Value);
                newIssue.WatcherUserIDs = watcherUserIDs;
                string jsonRequest = JsonConvert.SerializeObject(new NewIssueJSONObject() { NewIssue = newIssue }, Formatting.Indented);
                tbProject.Enabled = false;
                cbTracker.Enabled = false;
                tbSubject.Enabled = false;
                cbPriority.Enabled = false;
                cbAssignee.Enabled = false;
                tbDescription.Enabled = false;
                cbIsPrivate.Enabled = false;
                nudEstimatedTime.Enabled = false;
                cblWatchers.Enabled = false;
                btnCreateIssue.Enabled = false;
                btnCancel.Enabled = false;
                this.Text = "Create new issue [please, wait..]";
                controller.CreateIssue(jsonRequest);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void controller_OnPreparedToCreateNewIssue(ErrorTypes error, List<IssueTracker> issueTrackers, List<IssuePriority> issuePriorities, List<Membership> memberships)
        {
            Action action = () =>
            {
                switch (error)
                {
                    case ErrorTypes.NoErrors:
                        tbProject.Text = project.Name;
                        foreach (IssueTracker tracker in issueTrackers)
                            cbTracker.Items.Add(new TextAndValueItem { Text = tracker.Name, Value = tracker.ID });
                        foreach (IssuePriority priority in issuePriorities)
                            cbPriority.Items.Add(new TextAndValueItem { Text = priority.Name, Value = priority.ID });
                        foreach (Membership membership in memberships)
                        {
                            cbAssignee.Items.Add(new TextAndValueItem { Text = membership.User.Name, Value = membership.User.ID });
                            cblWatchers.Items.Add(new TextAndValueItem { Text = membership.User.Name, Value = membership.User.ID });
                        }
                        cbTracker.SelectedIndex = 0;
                        cbStatus.SelectedIndex = 0;
                        cbPriority.SelectedIndex = 0;
                        cbAssignee.SelectedIndex = 0;
                        tbProject.Enabled = true;
                        cbTracker.Enabled = true;
                        tbSubject.Enabled = true;
                        cbPriority.Enabled = true;
                        cbAssignee.Enabled = true;
                        tbDescription.Enabled = true;
                        cbIsPrivate.Enabled = true;
                        nudEstimatedTime.Enabled = true;
                        cblWatchers.Enabled = true;
                        btnCreateIssue.Enabled = true;
                        btnCancel.Enabled = true;
                        this.Text = "Create new issue";
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

        private void controller_OnIssueCreated(ErrorTypes error)
        {
            Action action = () =>
            {
                switch (error)
                {
                    case ErrorTypes.NoErrors:
                        isIssueCreated = true;
                        this.Close();
                        break;
                    case ErrorTypes.NetworkError:
                        MessageBox.Show("Cannot connect to Redmine services. Please check your Internet connection and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        tbProject.Enabled = true;
                        cbTracker.Enabled = true;
                        tbSubject.Enabled = true;
                        cbPriority.Enabled = true;
                        cbAssignee.Enabled = true;
                        tbDescription.Enabled = true;
                        cbIsPrivate.Enabled = true;
                        nudEstimatedTime.Enabled = true;
                        cblWatchers.Enabled = true;
                        btnCreateIssue.Enabled = true;
                        btnCancel.Enabled = true;
                        this.Text = "Create new issue";
                        break;
                    case ErrorTypes.UnathorizedAccess:
                        MessageBox.Show("You have wrong authorization data. Please check it, change if necessary and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        tbProject.Enabled = true;
                        cbTracker.Enabled = true;
                        tbSubject.Enabled = true;
                        cbPriority.Enabled = true;
                        cbAssignee.Enabled = true;
                        tbDescription.Enabled = true;
                        cbIsPrivate.Enabled = true;
                        nudEstimatedTime.Enabled = true;
                        cblWatchers.Enabled = true;
                        btnCreateIssue.Enabled = true;
                        btnCancel.Enabled = true;
                        this.Text = "Create new issue";
                        break;
                    case ErrorTypes.UnknownError:
                        MessageBox.Show("An unknown error occurred. Please, try again one more time.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        tbProject.Enabled = true;
                        cbTracker.Enabled = true;
                        tbSubject.Enabled = true;
                        cbPriority.Enabled = true;
                        cbAssignee.Enabled = true;
                        tbDescription.Enabled = true;
                        cbIsPrivate.Enabled = true;
                        nudEstimatedTime.Enabled = true;
                        cblWatchers.Enabled = true;
                        btnCreateIssue.Enabled = true;
                        btnCancel.Enabled = true;
                        this.Text = "Create new issue";
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
