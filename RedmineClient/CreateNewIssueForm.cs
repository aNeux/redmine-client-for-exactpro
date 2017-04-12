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
        public List<Tracker> trackers;
        public List<Membership> memberships;

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
                newIssue.TrackerID = trackers.Single(temp => temp.Name == cbTracker.SelectedItem.ToString()).ID;
                newIssue.Subject = tbSubject.Text;
                newIssue.StatusID = 1;
                newIssue.PriorityID = cbPriority.SelectedIndex + 1;
                try
                {
                    newIssue.AssignedToID = memberships.Single(temp => temp.Member.Name == cbAssignee.SelectedItem.ToString()).Member.ID;
                }
                catch
                {
                    newIssue.AssignedToID = -1;
                }
                newIssue.Description = tbDescription.Text;
                newIssue.IsPrivate = cbIsPrivate.Checked;
                newIssue.EstimatedHours = (int)nudEstimatedTime.Value;
                List<long> watcherUserIDs = new List<long>();
                foreach (var currentUser in cblWatchers.CheckedItems)
                    try
                    {
                        watcherUserIDs.Add(memberships.Single(temp => temp.Member.Name == currentUser.ToString()).Member.ID);
                    }
                    catch { }
                newIssue.WatcherUserIDs = watcherUserIDs;
                string jsonRequest = JsonConvert.SerializeObject(new NewIssueJSONObject() { NewIssue = newIssue }, Formatting.Indented);
                btnCreateIssue.Enabled = false;
                btnCancel.Enabled = false;
                controller.CreateIssue(jsonRequest);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void controller_OnPreparedToCreateNewIssue(ErrorTypes error, List<Tracker> trackers, List<Membership> memberships)
        {
            Action action = () =>
            {
                switch (error)
                {
                    case ErrorTypes.NoErrors:
                        this.trackers = trackers;
                        this.memberships = memberships;
                        tbProject.Text = project.Name;
                        foreach (Tracker tracker in trackers)
                            cbTracker.Items.Add(tracker.Name);
                        foreach (Membership membership in memberships)
                            if (membership.Member != null)
                            {
                                cbAssignee.Items.Add(membership.Member.Name);
                                cblWatchers.Items.Add(membership.Member.Name);
                            }
                        cbTracker.SelectedIndex = 0;
                        cbStatus.SelectedIndex = 0;
                        cbPriority.SelectedIndex = 0;
                        cbAssignee.SelectedIndex = 0;
                        tbProject.Enabled = true;
                        cbTracker.Enabled = true;
                        tbSubject.Enabled = true;
                        cbStatus.Enabled = true;
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
                    case ErrorTypes.NoInternetConnection:
                        MessageBox.Show("Cannot connect to Redmine services. Please check your Internet connection and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Close();
                        break;
                    case ErrorTypes.UnathorizedAccess:
                        MessageBox.Show("Wrong API key. Please check entered data and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    case ErrorTypes.NoInternetConnection:
                        MessageBox.Show("Cannot connect to Redmine services. Please check your Internet connection and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Close();
                        break;
                    case ErrorTypes.UnathorizedAccess:
                        MessageBox.Show("Wrong API key. Please check entered data and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Close();
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
