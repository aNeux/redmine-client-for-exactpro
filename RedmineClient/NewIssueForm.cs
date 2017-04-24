using System;
using System.Collections.Generic;
using RedmineClient.Models;
using Newtonsoft.Json;
using System.Windows.Forms;

namespace RedmineClient
{
    public partial class NewIssueForm : Form
    {
        private Controller controller;
        private long projectID;
        private string projectName;
        private bool isIssueCreated = false;

        public NewIssueForm(long projectID, string projectName)
        {
            InitializeComponent();
            this.projectID = projectID;
            this.projectName = projectName;
            this.StartPosition = FormStartPosition.CenterParent;
        }

        private void CreateNewIssueForm_Shown(object sender, EventArgs e)
        {
            cbAssignee.Items.Add(new TextAndValueItem { Text = "< none >", Value = "" });
            labelInfo.Select();
            controller = Program.controllerGlobal;
            controller.OnPreparedToCreateNewIssue += controller_OnPreparedToCreateNewIssue;
            controller.OnIssueCreated += controller_OnIssueCreated;
            controller.PrepareDataForCreatingNewIssue(projectID);
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

        private void btnCreateIssue_Click(object sender, EventArgs e)
        {
            if (tbSubject.Text.Length == 0)
                MessageBox.Show("Please, enter the subject for new issue!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                NewIssue newIssue = new NewIssue();
                newIssue.ProjectID = projectID;
                newIssue.TrackerID = (int)(cbTracker.SelectedItem as TextAndValueItem).Value;
                newIssue.Subject = tbSubject.Text;
                newIssue.PriorityID = (int)(cbPriority.SelectedItem as TextAndValueItem).Value;
                newIssue.AssignedToID = (cbAssignee.SelectedItem as TextAndValueItem).Value.ToString();
                newIssue.IsPrivate = cbIsPrivate.Checked;
                newIssue.Description = tbDescription.Text;
                newIssue.StartDate = dtpStartDate.Value.ToString("yyyy-MM-dd");
                if (dtpDueDate.Format != DateTimePickerFormat.Custom)
                    newIssue.DueDate = dtpDueDate.Value.ToString("yyyy-MM-dd");
                newIssue.EstimatedHours = (int)nudEstimatedTime.Value;
                newIssue.DoneRatio = (int)nudDoneRatio.Value;
                List<long> watcherUserIDs = new List<long>();
                foreach (var currentUser in cblWatchers.CheckedItems)
                    watcherUserIDs.Add((long)(currentUser as TextAndValueItem).Value);
                newIssue.WatcherUserIDs = watcherUserIDs;
                string jsonRequest = JsonConvert.SerializeObject(new NewIssueJSONObject() { NewIssue = newIssue }, Formatting.Indented, new JsonSerializerSettings { DefaultValueHandling = DefaultValueHandling.Ignore });
                ChangeUIState(false);
                this.Text = "New issue [please, wait..]";
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
                        tbProject.Text = projectName;
                        foreach (IssueTracker currentTracker in issueTrackers)
                            cbTracker.Items.Add(new TextAndValueItem { Text = currentTracker.Name, Value = currentTracker.ID });
                        foreach (IssuePriority currentPriority in issuePriorities)
                            cbPriority.Items.Add(new TextAndValueItem { Text = currentPriority.Name, Value = currentPriority.ID });
                        foreach (Membership currentMembership in memberships)
                        {
                            cbAssignee.Items.Add(new TextAndValueItem { Text = currentMembership.User.Name, Value = currentMembership.User.ID });
                            cblWatchers.Items.Add(new TextAndValueItem { Text = currentMembership.User.Name, Value = currentMembership.User.ID });
                        }
                        cbTracker.SelectedIndex = 0;
                        cbPriority.SelectedIndex = 0;
                        cbAssignee.SelectedIndex = 0;
                        dtpStartDate.Value = DateTime.Now;
                        ChangeUIState(true);
                        this.Text = "New issue";
                        break;
                    case ErrorTypes.ConnectionError:
                        this.Text = "New issue";
                        MessageBox.Show("Cannot connect to Redmine services. Please check your Internet connection and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Close();
                        break;
                    case ErrorTypes.UnathorizedAccess:
                        this.Text = "New issue";
                        MessageBox.Show("You have the wrong authorization data. Please change it and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        controller.NeedToReAuthenticate();
                        this.Close();
                        break;
                    case ErrorTypes.UnknownError:
                        this.Text = "New issue";
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
                    case ErrorTypes.ConnectionError:
                        this.Text = "New issue";
                        MessageBox.Show("Cannot connect to Redmine services. Please check your Internet connection and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        ChangeUIState(true);
                        break;
                    case ErrorTypes.UnathorizedAccess:
                        this.Text = "New issue";
                        MessageBox.Show("You have the wrong authorization data. Please change it and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        controller.NeedToReAuthenticate();
                        this.Close();
                        break;
                    case ErrorTypes.UnknownError:
                        this.Text = "New issue";
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

        private void ChangeUIState(bool isEnabled)
        {
            tbProject.Enabled = isEnabled;
            cbTracker.Enabled = isEnabled;
            tbSubject.Enabled = isEnabled;
            cbPriority.Enabled = isEnabled;
            cbAssignee.Enabled = isEnabled;
            cbIsPrivate.Enabled = isEnabled;
            tbDescription.Enabled = isEnabled;
            dtpStartDate.Enabled = isEnabled;
            dtpDueDate.Enabled = isEnabled;
            nudEstimatedTime.Enabled = isEnabled;
            nudDoneRatio.Enabled = isEnabled;
            cblWatchers.Enabled = isEnabled;
            btnCreateIssue.Enabled = isEnabled;
            btnCancel.Enabled = isEnabled;
        }
    }
}
