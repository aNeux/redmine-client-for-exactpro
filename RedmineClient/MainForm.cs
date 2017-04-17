using System;
using System.Collections.Generic;
using System.Linq;
using RedmineClient.Models;
using System.Windows.Forms;

namespace RedmineClient
{
    public partial class MainForm : Form
    {
        private Controller controller;
        private long lastSelectedProjectID = -1;
        private string selectedProjectRoles = null;

        public MainForm()
        {
            InitializeComponent();
            this.CenterToScreen();
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            cbProjects.SelectedIndex = 0;
            controller = Program.controllerGlobal;
            controller.OnUserAuthenticated += controller_OnAPIKeyChanged;
            controller.OnProjectsUpdated += controller_OnProjectsUpdated;
            controller.OnIssuesUpdated += controller_OnIssuesUpdated;
            controller.OnIssueCreated += controller_OnIssueCreated;
            controller.UpdateProjects();
            toolStripStatusLabel.Text = "Updating projects..";
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Properties.Settings.Default.api_key.Length != 0 && (e.CloseReason == CloseReason.UserClosing || e.CloseReason == CloseReason.ApplicationExitCall))
            {
                var dialogResult = MessageBox.Show("Are you sure you want to exit?", "Exiting", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    controller.OnUserAuthenticated -= controller_OnAPIKeyChanged;
                    controller.OnProjectsUpdated -= controller_OnProjectsUpdated;
                    controller.OnIssuesUpdated -= controller_OnIssuesUpdated;
                    controller.OnIssueCreated -= controller_OnIssueCreated;
                }
                else
                    e.Cancel = true;
            }
            else
            {
                controller.OnUserAuthenticated -= controller_OnAPIKeyChanged;
                controller.OnProjectsUpdated -= controller_OnProjectsUpdated;
                controller.OnIssuesUpdated -= controller_OnIssuesUpdated;
                controller.OnIssueCreated -= controller_OnIssueCreated;
            }
        }

        private void newIssueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new CreateNewIssueForm(controller.GetProject(lastSelectedProjectID)).ShowDialog();
        }

        private void refreshStripMenuItem_Click(object sender, EventArgs e)
        {
            controller.UpdateProjects();
            toolStripStatusLabel.Text = "Updating projects..";
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void changeAPITokenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AuthorizationForm().ShowDialog();
        }

        private void userInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new UserInformationForm().ShowDialog();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AboutForm().ShowDialog();
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dialogResult = MessageBox.Show("Do you really want to log out and exit the program?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                Properties.Settings.Default.Reset();
                Application.Exit();
            }
        }

        private void exitFromNotifyIconToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void cbSelectProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnProjectInfo.Enabled = false;
            if (cbProjects.SelectedIndex != 0)
            {
                btnProjectInfo.Visible = true;
                string projectName = cbProjects.SelectedItem.ToString();
                long projectID = long.Parse(projectName.Substring(1, projectName.IndexOf(":") - 1));
                lastSelectedProjectID = projectID;
                controller.UpdateIssues(projectID);
                toolStripStatusLabel.Text = "Updating issues..";
            }
            else
            {
                lastSelectedProjectID = -1;
                selectedProjectRoles = null;
                newIssueToolStripMenuItem.Enabled = false;
                btnProjectInfo.Visible = false;
                labelProjectRoles.Text = "";
                lvIssues.Items.Clear();
            }
        }

        private void btnProjectInfo_Click(object sender, EventArgs e)
        {
            new ProjectInformation(controller.GetProject(lastSelectedProjectID)).ShowDialog();
        }

        private void lvIssues_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && lvIssues.FocusedItem.Bounds.Contains(e.Location))
                contextMenuIssue.Show(Cursor.Position);
        }

        private void issueInfotoolStripMenuItem_Click(object sender, EventArgs e)
        {
            Issue issue = controller.GetIssue(long.Parse(lvIssues.FocusedItem.SubItems[0].Text));
            string issueInfo = "Project: " + issue.Project.Name + "\n"
                + "ID: " + issue.ID + "\n"
                + "Subject: " + issue.Subject + "\n"
                + "Tracker: " + issue.Tracker.Name + "\n"
                + "Author: " + issue.Author.Name + "\n"
                + "Status: " + issue.Status.Name + "\n"
                + "Priority: " + issue.Priority.Name + "\n"
                + "Description: " + issue.Description + "\n"
                + "Created on: " + issue.CreatedOn.Hour + ":" + issue.CreatedOn.Minute + ", " + issue.CreatedOn.Day + " " + issue.CreatedOn.Month + " " + issue.CreatedOn.Year;
            MessageBox.Show(issueInfo, "Info about issue \"" + issue.Subject + "\"");
        }

        private void controller_OnAPIKeyChanged(ErrorTypes error, bool isChanged)
        {
            Action action = () =>
                {
                    if (error == ErrorTypes.NoErrors && isChanged)
                    {
                        cbProjects.SelectedIndex = 0;
                        controller.UpdateProjects();
                        toolStripStatusLabel.Text = "Updating projects..";
                    }
                };
            if (InvokeRequired)
                Invoke(action);
            else
                action();
        }

        private void controller_OnProjectsUpdated(ErrorTypes error, List<Project> projects)
        {
            Action action = () =>
                {
                    switch (error)
                    {
                        case ErrorTypes.NoErrors:
                            this.Text = "Redmine Client ["+ Properties.Settings.Default.login +"]";
                            userInformationToolStripMenuItem.Enabled = true;
                            for (int i = cbProjects.Items.Count - 1; i >= 1; i--)
                                cbProjects.Items.RemoveAt(i);
                            int indexToSelect = 0;
                            for (int i = 0; i < projects.Count; i++)
                            {
                                cbProjects.Items.Add("#" + projects[i].ID + ": " + projects[i].Name);
                                if (lastSelectedProjectID == projects[i].ID)
                                    indexToSelect = i + 1;
                            }
                            if (indexToSelect == 0)
                                toolStripStatusLabel.Text = "Projects was updated at " + DateTime.Now.ToShortTimeString();
                            cbProjects.SelectedIndex = indexToSelect;
                            break;
                        case ErrorTypes.NetworkError:
                            toolStripStatusLabel.Text = "Projects update failed at " + DateTime.Now.ToShortTimeString() + " (network error)";
                            MessageBox.Show("Cannot connect to Redmine services and load projects. Please check your Internet connection and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        case ErrorTypes.UnathorizedAccess:
                            toolStripStatusLabel.Text = "Projects update failed at " + DateTime.Now.ToShortTimeString() + " (wrong authorization data)";
                            if (Properties.Settings.Default.api_key.Length == 0)
                                new AuthorizationForm().ShowDialog();
                            else
                                MessageBox.Show("You have wrong authorization data. Please check it, change if necessary and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                    }
                };
            if (InvokeRequired)
                Invoke(action);
            else
                action();
        }

        private void controller_OnIssuesUpdated(ErrorTypes error, List<Issue> issues, string projectRoles)
        {
            Action action = () =>
                {
                    switch (error)
                    {
                        case ErrorTypes.NoErrors:
                            lvIssues.Items.Clear();
                            foreach (Issue issue in issues)
                            {
                                ListViewItem lvi = new ListViewItem(issue.ID + "");
                                lvi.SubItems.Add(issue.Subject);
                                lvi.SubItems.Add(issue.Tracker.Name);
                                lvi.SubItems.Add(issue.Status.Name);
                                lvi.SubItems.Add(issue.Priority.Name);
                                lvi.SubItems.Add(issue.UpdatedOn.ToShortTimeString() + ", " + issue.UpdatedOn.ToShortDateString());
                                lvIssues.Items.Add(lvi);
                            }
                            selectedProjectRoles = projectRoles;
                            newIssueToolStripMenuItem.Enabled = selectedProjectRoles.Contains("Manager") && controller.GetProject(lastSelectedProjectID).Status == 1;
                            btnProjectInfo.Enabled = true;
                            labelProjectRoles.Text = "Roles: " + selectedProjectRoles;
                            toolStripStatusLabel.Text = "Issues was updated at " + DateTime.Now.ToShortTimeString();
                            break;
                        case ErrorTypes.NetworkError:
                            toolStripStatusLabel.Text = "Issues update failed at " + DateTime.Now.ToShortTimeString() + " (network error)";
                            MessageBox.Show("Cannot connect to Redmine services and load issues. Please check your Internet connection and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        case ErrorTypes.UnathorizedAccess:
                            toolStripStatusLabel.Text = "Issues update failed at " + DateTime.Now.ToShortTimeString() + " (wrong authorization data)";
                            if (Properties.Settings.Default.api_key.Length == 0)
                                new AuthorizationForm().ShowDialog();
                            else
                                MessageBox.Show("You have wrong authorization data. Please check it, change if necessary and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            controller.UpdateIssues(lastSelectedProjectID);
        }
    }
}
