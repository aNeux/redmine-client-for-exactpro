using System;
using System.Collections;
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
        private int lastSortedColumn = -1;

        public MainForm()
        {
            InitializeComponent();
            this.CenterToScreen();
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            cbProjects.SelectedIndex = 0;
            controller = Program.controllerGlobal;
            controller.OnUserAuthenticated += controller_OnUserAuthenticated;
            controller.OnProjectsUpdated += controller_OnProjectsUpdated;
            controller.OnIssuesUpdated += controller_OnIssuesUpdated;
            controller.OnIssueCreated += controller_OnIssueCreated;
            controller.OnIssueRemoved += controller_OnIssueRemoved;
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
                    controller.OnUserAuthenticated -= controller_OnUserAuthenticated;
                    controller.OnProjectsUpdated -= controller_OnProjectsUpdated;
                    controller.OnIssuesUpdated -= controller_OnIssuesUpdated;
                    controller.OnIssueCreated -= controller_OnIssueCreated;
                    controller.OnIssueRemoved += controller_OnIssueRemoved;
                }
                else
                    e.Cancel = true;
            }
            else
            {
                controller.OnUserAuthenticated -= controller_OnUserAuthenticated;
                controller.OnProjectsUpdated -= controller_OnProjectsUpdated;
                controller.OnIssuesUpdated -= controller_OnIssuesUpdated;
                controller.OnIssueCreated -= controller_OnIssueCreated;
                controller.OnIssueRemoved += controller_OnIssueRemoved;
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
            if (cbProjects.SelectedIndex != 0)
            {
                btnProjectInfo.Visible = true;
                if (lastSelectedProjectID != (long)(cbProjects.SelectedItem as TextAndValueItem).Value)
                {
                    lastSelectedProjectID = (long)(cbProjects.SelectedItem as TextAndValueItem).Value;
                    lvIssues.Items.Clear();
                }
                Project currentProject = controller.GetProject(lastSelectedProjectID);
                createNewIssueToolStripMenuItem.Enabled = currentProject.Roles.Contains("Manager") && currentProject.Status == 1;
                labelProjectRoles.Text = "Roles: " + currentProject.Roles;
                controller.UpdateIssues(lastSelectedProjectID);
                toolStripStatusLabel.Text = "Updating issues..";
            }
            else
            {
                lastSelectedProjectID = -1;
                createNewIssueToolStripMenuItem.Enabled = false;
                btnProjectInfo.Visible = false;
                labelProjectRoles.Text = "";
                lvIssues.Items.Clear();
            }
        }

        private void btnProjectInfo_Click(object sender, EventArgs e)
        {
            new ProjectInformation(lastSelectedProjectID).ShowDialog();
        }

        private void lvIssues_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            
        }

        private void lvIssues_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && lvIssues.FocusedItem.Bounds.Contains(e.Location))
                contextMenuIssue.Show(Cursor.Position);
        }

        private void issueInfotoolStripMenuItem_Click(object sender, EventArgs e)
        {
            new IssueInformationForm(long.Parse(lvIssues.FocusedItem.SubItems[0].Text), controller.GetProject(lastSelectedProjectID).Roles).ShowDialog();
        }

        private void controller_OnUserAuthenticated(ErrorTypes error, bool isUserChanged)
        {
            Action action = () =>
                {
                    if (error == ErrorTypes.NoErrors && isUserChanged)
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
                                if (projects[i].Parent == null)
                                    cbProjects.Items.Add(new TextAndValueItem { Text = projects[i].Name, Value = projects[i].ID });
                                else
                                    cbProjects.Items.Add(new TextAndValueItem { Text = "    └ " + projects[i].Name, Value = projects[i].ID });
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
                        case ErrorTypes.UnknownError:
                            toolStripStatusLabel.Text = "Projects update failed at " + DateTime.Now.ToShortTimeString() + " (unknown error)";
                            MessageBox.Show("An unknown error occurred. Please, try again one more time.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                    }
                };
            if (InvokeRequired)
                Invoke(action);
            else
                action();
        }

        private void controller_OnIssuesUpdated(ErrorTypes error, List<Issue> issues)
        {
            Action action = () =>
                {
                    lvIssues.Items.Clear();
                    switch (error)
                    {
                        case ErrorTypes.NoErrors:
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
                        case ErrorTypes.UnknownError:
                            toolStripStatusLabel.Text = "Issues update failed at " + DateTime.Now.ToShortTimeString() + " (unknown error)";
                            MessageBox.Show("An unknown error occurred. Please, try again one more time.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (error == ErrorTypes.NoErrors)
                controller.UpdateIssues(lastSelectedProjectID);
        }

        private void controller_OnIssueRemoved(ErrorTypes error)
        {
            if (error == ErrorTypes.NoErrors)
                controller.UpdateIssues(lastSelectedProjectID);
        }
    }

    class ListViewItemComparer : IComparer
    {
        private int column;
        private SortOrder sortOrder;

        public ListViewItemComparer(int column, SortOrder sortOrder)
        {
            this.column = column;
            this.sortOrder = sortOrder;
        }

        public int Compare(object x, object y)
        {
            return 0;
        }
    }
}
