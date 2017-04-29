using System;
using System.Collections.Generic;
using RedmineClient.Models;
using System.Windows.Forms;

namespace RedmineClient
{
    public partial class NewIssueForm : Form
    {
        private Controller controller;
        private long projectID;
        private string projectName;
        private bool isCouldCloseForm = false;

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
            controller.OnMembershipsLoaded += controller_OnMembershipsLoaded;
            controller.OnIssueCreated += controller_OnIssueCreated;
            controller.PrepareDataForCreatingNewIssue(projectID);
        }

        private void CreateNewIssueForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!isCouldCloseForm && e.CloseReason == CloseReason.UserClosing)
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

        private void cbProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((long)(cbProjects.SelectedItem as TextAndValueItem).Value != projectID)
            {
                this.Text = "New issue [please, wait..]";
                ChangeUIState(false);
                controller.LoadMemberships((long)(cbProjects.SelectedItem as TextAndValueItem).Value);
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
                newIssue.ProjectID = (long)(cbProjects.SelectedItem as TextAndValueItem).Value;
                newIssue.TrackerID = (int)(cbTrackers.SelectedItem as TextAndValueItem).Value;
                newIssue.Subject = tbSubject.Text;
                newIssue.PriorityID = (int)(cbPriorities.SelectedItem as TextAndValueItem).Value;
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
                ChangeUIState(false);
                this.Text = "New issue [please, wait..]";
                controller.CreateIssue(newIssue);
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
                        int indexToSelect = 0;
                        List<Project> projects = controller.GetProjects();
                        projects.RemoveAll(temp1 => temp1.Roles.FindIndex(temp2 => temp2.ID == 3) < 0 || temp1.Status == 5);
                        foreach (Project currentProject in projects)
                        {
                            if (currentProject.Parent == null)
                                cbProjects.Items.Add(new TextAndValueItem { Text = currentProject.Name, Value = currentProject.ID });
                            else
                                cbProjects.Items.Add(new TextAndValueItem { Text = "    └ " + currentProject.Name, Value = currentProject.ID });
                            if (currentProject.ID == projectID)
                                indexToSelect = cbProjects.Items.Count - 1;
                        }
                        cbProjects.SelectedIndex = indexToSelect;
                        foreach (IssueTracker currentTracker in issueTrackers)
                            cbTrackers.Items.Add(new TextAndValueItem { Text = currentTracker.Name, Value = currentTracker.ID });
                        foreach (IssuePriority currentPriority in issuePriorities)
                            cbPriorities.Items.Add(new TextAndValueItem { Text = currentPriority.Name, Value = currentPriority.ID });
                        foreach (Membership currentMembership in memberships)
                        {
                            cbAssignee.Items.Add(new TextAndValueItem { Text = currentMembership.User.Name, Value = currentMembership.User.ID });
                            cblWatchers.Items.Add(new TextAndValueItem { Text = currentMembership.User.Name, Value = currentMembership.User.ID });
                        }
                        cbTrackers.SelectedIndex = 0;
                        cbPriorities.SelectedIndex = 0;
                        cbAssignee.SelectedIndex = 0;
                        dtpStartDate.Value = DateTime.Now;
                        ChangeUIState(true);
                        this.Text = "New issue";
                        break;
                    case ErrorTypes.ConnectionError:
                        this.Text = "New issue";
                        MessageBox.Show("Cannot connect to Redmine services. Please check your Internet connection and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        isCouldCloseForm = true;
                        this.Close();
                        break;
                    case ErrorTypes.UnathorizedAccess:
                        this.Text = "New issue";
                        MessageBox.Show("You have the wrong authorization data. Please change it and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        isCouldCloseForm = true;
                        controller.NeedToReAuthenticate(false);
                        this.Close();
                        break;
                    case ErrorTypes.UnknownError:
                        this.Text = "New issue";
                        MessageBox.Show("An unknown error occurred. Please, try again one more time.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        isCouldCloseForm = true;
                        this.Close();
                        break;
                }
            };
            if (InvokeRequired)
                Invoke(action);
            else
                action();
        }

        private void controller_OnMembershipsLoaded(ErrorTypes error, List<Membership> memberships)
        {
            Action action = () =>
            {
                switch (error)
                {
                    case ErrorTypes.NoErrors:
                        for (int i = cbAssignee.Items.Count - 1; i >= 1; i--)
                            cbAssignee.Items.RemoveAt(i);
                        cblWatchers.Items.Clear();
                        foreach (Membership currentMembership in memberships)
                        {
                            cbAssignee.Items.Add(new TextAndValueItem { Text = currentMembership.User.Name, Value = currentMembership.User.ID });
                            cblWatchers.Items.Add(new TextAndValueItem { Text = currentMembership.User.Name, Value = currentMembership.User.ID });
                        }
                        cbAssignee.SelectedIndex = 0;
                        projectID = (long)(cbProjects.SelectedItem as TextAndValueItem).Value;
                        ChangeUIState(true);
                        this.Text = "New issue";
                        break;
                    case ErrorTypes.ConnectionError:
                        this.Text = "New issue";
                        MessageBox.Show("Cannot connect to Redmine services. Please check your Internet connection and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        for (int i = 0; i < cbProjects.Items.Count; i++)
                            if ((long)(cbProjects.Items[i] as TextAndValueItem).Value == projectID)
                            {
                                cbProjects.SelectedIndex = i;
                                break;
                            }
                        ChangeUIState(true);
                        break;
                    case ErrorTypes.UnathorizedAccess:
                        this.Text = "New issue";
                        MessageBox.Show("You have the wrong authorization data. Please change it and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        controller.NeedToReAuthenticate(false);
                        this.Close();
                        break;
                    case ErrorTypes.UnknownError:
                        this.Text = "New issue";
                        MessageBox.Show("An unknown error occurred. Please, try again one more time.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        for (int i = 0; i < cbProjects.Items.Count; i++)
                            if ((long)(cbProjects.Items[i] as TextAndValueItem).Value == projectID)
                            {
                                cbProjects.SelectedIndex = i;
                                break;
                            }
                        ChangeUIState(true);
                        break;
                }
            };
            if (InvokeRequired)
                Invoke(action);
            else
                action();
        }

        private void controller_OnIssueCreated(ErrorTypes error, long projectID)
        {
            Action action = () =>
            {
                switch (error)
                {
                    case ErrorTypes.NoErrors:
                        isCouldCloseForm = true;
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
                        controller.NeedToReAuthenticate(false);
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
            cbProjects.Enabled = isEnabled;
            cbTrackers.Enabled = isEnabled;
            tbSubject.Enabled = isEnabled;
            cbPriorities.Enabled = isEnabled;
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
