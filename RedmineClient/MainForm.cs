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
            logOutToolStripMenuItem.Enabled = Properties.User.Default.api_key.Length > 0;
            cbProjects.SelectedIndex = 0;
            if (!Properties.Application.Default.show_account_login && statusStrip.Visible)
            {
                lvIssues.Size = new System.Drawing.Size(lvIssues.Size.Width, lvIssues.Size.Height + statusStrip.Size.Height);
                statusStrip.Visible = false;
            }
            controller = Program.controllerGlobal;
            controller.OnUserAuthenticated += controller_OnUserAuthenticated;
            controller.OnNeededToReAuthenticate += controller_OnNeededToReAuthenticate;
            controller.OnUpdated += controller_OnUpdated;
            controller.OnIssueCreated += controller_OnIssueCreatedOrUpdated;
            controller.OnIssueUpdated += controller_OnIssueCreatedOrUpdated;
            controller.OnIssueRemoved += controller_OnIssueRemoved;
            controller.OnOptionsApplied += controller_OnOptionsApplied;
            toolStripStatusLabel.Text = "Updating..";
            controller.Update();
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                if (Properties.Application.Default.minimaze_to_tray)
                    this.Hide();
                if (controller.GetProjects() != null && Properties.Application.Default.background_updater_enabled)
                {
                    controller.OnBackgroundUpdated += controller_OnBackgroundUpdated;
                    controller.StartBackgroundUpdater(false);
                }
            }
            else if (this.WindowState == FormWindowState.Normal && controller.IsBackgroundUpdaterWorking())
            {
                controller.OnBackgroundUpdated -= controller_OnBackgroundUpdated;
                controller.StopBackgroundUpdater();
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Properties.User.Default.api_key.Length != 0 && (e.CloseReason == CloseReason.UserClosing || e.CloseReason == CloseReason.ApplicationExitCall) && Properties.Application.Default.ask_before_exiting)
            {
                var dialogResult = MessageBox.Show("Are you sure you want to exit?", "Exiting", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    controller.OnUserAuthenticated -= controller_OnUserAuthenticated;
                    controller.OnNeededToReAuthenticate -= controller_OnNeededToReAuthenticate;
                    controller.OnUpdated -= controller_OnUpdated;
                    controller.OnIssueCreated -= controller_OnIssueCreatedOrUpdated;
                    controller.OnIssueUpdated -= controller_OnIssueCreatedOrUpdated;
                    controller.OnIssueRemoved -= controller_OnIssueRemoved;
                    controller.OnOptionsApplied -= controller_OnOptionsApplied;
                    controller.OnBackgroundUpdated -= controller_OnBackgroundUpdated;
                }
                else
                    e.Cancel = true;
            }
            else
            {
                controller.OnUserAuthenticated -= controller_OnUserAuthenticated;
                controller.OnNeededToReAuthenticate -= controller_OnNeededToReAuthenticate;
                controller.OnUpdated -= controller_OnUpdated;
                controller.OnIssueCreated -= controller_OnIssueCreatedOrUpdated;
                controller.OnIssueUpdated -= controller_OnIssueCreatedOrUpdated;
                controller.OnIssueRemoved -= controller_OnIssueRemoved;
                controller.OnOptionsApplied -= controller_OnOptionsApplied;
                controller.OnBackgroundUpdated -= controller_OnBackgroundUpdated;
            }
        }

        private void newIssueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            long projectID = (long)(cbProjects.SelectedItem as TextAndValueItem).Value;
            string projectName = (cbProjects.SelectedItem as TextAndValueItem).Text;
            new NewIssueForm(projectID, projectName).ShowDialog();
        }

        private void refreshStripMenuItem_Click(object sender, EventArgs e)
        {
            refreshToolStripMenuItem.Enabled = false;
            refreshFromNIToolStripMenuItem.Enabled = false;
            if (this.WindowState == FormWindowState.Normal)
            {
                toolStripStatusLabel.Text = "Updating..";
                controller.Update();
            }
            else
            {
                controller.StopBackgroundUpdater();
                controller.StartBackgroundUpdater(true);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dialogResult = MessageBox.Show("Do you really want to log out and exit the program?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                Properties.User.Default.Reset();
                Application.Exit();
            }
        }

        private void changeAPITokenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AuthorizationForm().ShowDialog();
        }

        private void userInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new UserInformationForm().ShowDialog();
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new OptionsForm().ShowDialog();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AboutForm().ShowDialog();
        }

        private void cbSelectProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbProjects.SelectedIndex != 0)
            {
                btnProjectInfo.Visible = true;
                lastSelectedProjectID = (long)(cbProjects.SelectedItem as TextAndValueItem).Value;
                Project currentProject = controller.GetProjects().Single(temp => temp.ID == lastSelectedProjectID);
                newIssueToolStripMenuItem.Enabled = currentProject.Roles.FindIndex(temp => temp.ID == 3) >= 0 && currentProject.Status == 1;
                if (currentProject.Status == 1)
                {
                    string projectRoles = "";
                    foreach (Role role in currentProject.Roles)
                        projectRoles += role.Name + ", ";
                    labelProjectRoles.Text = "Roles: " + projectRoles.Remove(projectRoles.Length - 2);
                }
                lvIssues.Items.Clear();
                foreach (Issue issue in controller.GetIssues(lastSelectedProjectID))
                {
                    ListViewItem lvi = new ListViewItem(issue.ID + "");
                    lvi.SubItems.Add(issue.Subject);
                    lvi.SubItems.Add(issue.Tracker.Name);
                    lvi.SubItems.Add(issue.Status.Name);
                    lvi.SubItems.Add(issue.Priority.Name);
                    lvi.SubItems.Add(issue.AssignedTo != null && issue.AssignedTo.Name.Length > 0 ? issue.AssignedTo.Name : "< none >");
                    lvi.SubItems.Add(issue.UpdatedOn.ToShortTimeString() + ", " + issue.UpdatedOn.ToShortDateString());
                    lvIssues.Items.Add(lvi);
                }
                removeIssueToolStripMenuItem.Visible = newIssueToolStripMenuItem.Enabled;
            }
            else
            {
                lastSelectedProjectID = -1;
                newIssueToolStripMenuItem.Enabled = false;
                btnProjectInfo.Visible = false;
                labelProjectRoles.Text = "";
                removeIssueToolStripMenuItem.Visible = false;
                lvIssues.Items.Clear();
            }
        }

        private void btnProjectInfo_Click(object sender, EventArgs e)
        {
            new ProjectInformation(lastSelectedProjectID).ShowDialog();
        }

        private void lvIssues_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column != lastSortedColumn)
            {
                lastSortedColumn = e.Column;
                lvIssues.Sorting = SortOrder.Ascending;
            }
            else
            {
                if (lvIssues.Sorting == SortOrder.Ascending)
                    lvIssues.Sorting = SortOrder.Descending;
                else
                    lvIssues.Sorting = SortOrder.Ascending;
            }
            this.lvIssues.ListViewItemSorter = new ListViewItemComparer(e.Column, lvIssues.Sorting);
            lvIssues.Sort();
        }

        private void lvIssues_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && lvIssues.FocusedItem.Bounds.Contains(e.Location))
                contextMenuIssue.Show(Cursor.Position);
        }

        private void issueInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new IssueInformationForm(long.Parse(lvIssues.FocusedItem.SubItems[0].Text), controller.GetProjects().Single(temp => temp.ID == lastSelectedProjectID).Roles).ShowDialog();
        }

        private void notifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                this.Show();
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void removeIssueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            long issueID = long.Parse(lvIssues.FocusedItem.SubItems[0].Text);
            var dialogResult = MessageBox.Show("Are you really sure you want to remove issue #" + issueID + "?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                toolStripStatusLabel.Text = "Removing issue #" + issueID + "..";
                controller.RemoveIssue(issueID);
            }
        }

        private void controller_OnUserAuthenticated(ErrorTypes error, bool isUserChanged)
        {
            Action action = () =>
                {
                    if (error == ErrorTypes.NoErrors && isUserChanged)
                    {
                        this.Text = "Redmine Client";
                        refreshToolStripMenuItem.Enabled = false;
                        logOutToolStripMenuItem.Enabled = true;
                        refreshFromNIToolStripMenuItem.Enabled = false;
                        cbProjects.SelectedIndex = 0;
                        toolStripStatusLabel.Text = "Updating..";
                        controller.Update();
                    }
                };
            if (InvokeRequired)
                Invoke(action);
            else
                action();
        }

        private void controller_OnNeededToReAuthenticate(bool isFromOptions)
        {
            Action action = () =>
            {
                this.Text = "Redmine Client";
                refreshToolStripMenuItem.Enabled = false;
                userInformationToolStripMenuItem.Enabled = false;
                logOutToolStripMenuItem.Enabled = false;
                toolStripStatusLabel.Text = isFromOptions ? "Waiting for authorization.." : "Last request failed at " + DateTime.Now.ToShortTimeString() + " (wrong authorization data)";
                accountNIToolStripMenuItem.Visible = false;
                logOutNIToolStripMenuItem.Visible = false;
                NIToolStripSeparator.Visible = false;
                refreshFromNIToolStripMenuItem.Enabled = false;
                new AuthorizationForm().ShowDialog();
            };
            if (InvokeRequired)
                Invoke(action);
            else
                action();
        }

        private void controller_OnUpdated(ErrorTypes error, List<Project> projects)
        {
            Action action = () =>
                {
                    switch (error)
                    {
                        case ErrorTypes.NoErrors:
                            this.Text = "Redmine Client" + (Properties.Application.Default.show_status_bar ? " [account: " + Properties.User.Default.login + "]" : "");
                            userInformationToolStripMenuItem.Enabled = true;
                            accountNIToolStripMenuItem.Text = "Account: " + Properties.User.Default.login;
                            accountNIToolStripMenuItem.Visible = true;
                            logOutNIToolStripMenuItem.Visible = true;
                            NIToolStripSeparator.Visible = true;
                            for (int i = cbProjects.Items.Count - 1; i >= 1; i--)
                                cbProjects.Items.RemoveAt(i);
                            for (int i = 0; i < projects.Count; i++)
                                if (Properties.Application.Default.show_closed_projects || (!Properties.Application.Default.show_closed_projects && projects[i].Status != 5))
                                    if (Properties.Application.Default.show_projects_without_current_user || (!Properties.Application.Default.show_projects_without_current_user && projects[i].Roles[0].ID != -1))
                                        if (projects[i].Parent == null)
                                            cbProjects.Items.Add(new TextAndValueItem { Text = projects[i].Name + (projects[i].Status == 5 ? " (closed)" : ""), Value = projects[i].ID });
                                        else
                                            cbProjects.Items.Add(new TextAndValueItem { Text = "    └ " + projects[i].Name + (projects[i].Status == 5 ? " (closed)" : ""), Value = projects[i].ID });
                            int indexToSelect = 0;
                            for (int i = 1; i < cbProjects.Items.Count; i++)
                                if ((long)(cbProjects.Items[i] as TextAndValueItem).Value == lastSelectedProjectID)
                                {
                                    indexToSelect = i;
                                    break;
                                }
                            cbProjects.SelectedIndex = indexToSelect;
                            toolStripStatusLabel.Text = "Last update was at " + DateTime.Now.ToShortTimeString() + " (success)";
                            refreshToolStripMenuItem.Enabled = true;
                            refreshFromNIToolStripMenuItem.Enabled = true;
                            if (this.WindowState == FormWindowState.Minimized && Properties.Application.Default.background_updater_enabled && !controller.IsBackgroundUpdaterWorking())
                                controller.StartBackgroundUpdater(false);
                            break;
                        case ErrorTypes.ConnectionError:
                            toolStripStatusLabel.Text = "Last update failed at " + DateTime.Now.ToShortTimeString() + " (network error)";
                            refreshToolStripMenuItem.Enabled = true;
                            refreshFromNIToolStripMenuItem.Enabled = true;
                            MessageBox.Show("Cannot connect to Redmine services and load projects. Please check your Internet connection and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        case ErrorTypes.UnathorizedAccess:
                            this.Text = "Redmine Client";
                            refreshToolStripMenuItem.Enabled = false;
                            logOutToolStripMenuItem.Enabled = false;
                            toolStripStatusLabel.Text = "Last update failed at " + DateTime.Now.ToShortTimeString() + " (wrong authorization data)";
                            accountNIToolStripMenuItem.Visible = false;
                            logOutNIToolStripMenuItem.Visible = false;
                            NIToolStripSeparator.Visible = false;
                            refreshFromNIToolStripMenuItem.Enabled = false;
                            if (Properties.User.Default.api_key.Length != 0)
                            {
                                Properties.User.Default.api_key = "";
                                Properties.User.Default.Save();
                                MessageBox.Show("You have the wrong authorization data. Please change it and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            new AuthorizationForm().ShowDialog();
                            break;
                        case ErrorTypes.UnknownError:
                            toolStripStatusLabel.Text = "Last update failed at " + DateTime.Now.ToShortTimeString() + " (unknown error)";
                            refreshToolStripMenuItem.Enabled = true;
                            refreshFromNIToolStripMenuItem.Enabled = true;
                            MessageBox.Show("An unknown error occurred. Please, try again one more time.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                    }
                };
            if (InvokeRequired)
                Invoke(action);
            else
                action();
        }

        private void controller_OnIssueCreatedOrUpdated(ErrorTypes error, long projectID)
        {
            Action action = () =>
                {
                    if (error == ErrorTypes.NoErrors)
                    {
                        for (int i = 1; i < cbProjects.Items.Count; i++)
                            if ((long)(cbProjects.Items[i] as TextAndValueItem).Value == projectID)
                            {
                                if (cbProjects.SelectedIndex == i)
                                    cbSelectProject_SelectedIndexChanged(null, null);
                                else
                                    cbProjects.SelectedIndex = i;
                                break;
                            }
                    }
                };
            if (InvokeRequired)
                Invoke(action);
            else
                action();
        }

        private void controller_OnIssueRemoved(ErrorTypes error, long issueID)
        {
            Action action = () =>
            {
                switch (error)
                {
                    case ErrorTypes.NoErrors:
                        cbSelectProject_SelectedIndexChanged(null, null);
                        toolStripStatusLabel.Text = "Issue #" + issueID + " removed at " + DateTime.Now.ToShortTimeString() + " (success)";
                        break;
                    case ErrorTypes.ConnectionError:
                        toolStripStatusLabel.Text = "Issue #" + issueID + "removing failed at " + DateTime.Now.ToShortTimeString() + " (network error)";
                        MessageBox.Show("Cannot connect to Redmine services. Please check your Internet connection and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case ErrorTypes.UnathorizedAccess:
                        this.Text = "Redmine Client";
                        refreshToolStripMenuItem.Enabled = false;
                        logOutToolStripMenuItem.Enabled = false;
                        toolStripStatusLabel.Text = "Issue #" + issueID + "removing failed at " + DateTime.Now.ToShortTimeString() + " (wrong authorization data)";
                        accountNIToolStripMenuItem.Visible = false;
                        logOutNIToolStripMenuItem.Visible = false;
                        NIToolStripSeparator.Visible = false;
                        refreshFromNIToolStripMenuItem.Enabled = false;
                        if (Properties.User.Default.api_key.Length != 0)
                        {
                            Properties.User.Default.api_key = "";
                            Properties.User.Default.Save();
                            MessageBox.Show("You have the wrong authorization data. Please change it and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        new AuthorizationForm().ShowDialog();
                        break;
                    case ErrorTypes.UnknownError:
                        toolStripStatusLabel.Text = "Issue #" + issueID + "removing failed at " + DateTime.Now.ToShortTimeString() + " (unknown error)";
                        MessageBox.Show("An unknown error occurred. Please, try again one more time.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
            };
            if (InvokeRequired)
                Invoke(action);
            else
                action();
        }

        private void controller_OnOptionsApplied(ErrorTypes error, bool[] whatsChanged)
        {
            Action action = () =>
                {
                    if (error == ErrorTypes.NoErrors)
            {
                // Изменился ли хост для Redmine
                if (whatsChanged[2])
                {
                    this.Text = "Redmine Client";
                    cbProjects.SelectedIndex = 0;
                    lvIssues.Items.Clear();
                }
                else
                {
                    // Изменилась ли настройка отображения логина текущего пользователя
                    if (whatsChanged[0])
                        this.Text = "Redmine Client" + (Properties.Application.Default.show_status_bar ? " [account: " + Properties.User.Default.login + "]" : "");
                    // Изменилась ли настройка отображения закрытых проектов или проектов, в которых пользователь не участвует
                    if (whatsChanged[3] || whatsChanged[4])
                    {
                        for (int i = cbProjects.Items.Count - 1; i >= 1; i--)
                            cbProjects.Items.RemoveAt(i);
                        List<Project> projects = controller.GetProjects();
                        for (int i = 0; i < projects.Count; i++)
                            if (Properties.Application.Default.show_closed_projects || (!Properties.Application.Default.show_closed_projects && projects[i].Status != 5))
                                if (Properties.Application.Default.show_projects_without_current_user || (!Properties.Application.Default.show_projects_without_current_user && projects[i].Roles[0].ID != -1))
                                    if (projects[i].Parent == null)
                                        cbProjects.Items.Add(new TextAndValueItem { Text = projects[i].Name + (projects[i].Status == 5 ? " (closed)" : ""), Value = projects[i].ID });
                                    else
                                        cbProjects.Items.Add(new TextAndValueItem { Text = "    └ " + projects[i].Name + (projects[i].Status == 5 ? " (closed)" : ""), Value = projects[i].ID });
                        int indexToSelect = 0;
                        for (int i = 1; i < cbProjects.Items.Count; i++)
                            if ((long)(cbProjects.Items[i] as TextAndValueItem).Value == lastSelectedProjectID)
                            {
                                indexToSelect = i;
                                break;
                            }
                        cbProjects.SelectedIndex = indexToSelect;
                    }
                }
                // Изменилась ли настройка отображения статус бара на главной форме
                if (whatsChanged[1])
                    if (Properties.Application.Default.show_account_login)
                    {
                        if (!statusStrip.Visible)
                        {
                            lvIssues.Size = new System.Drawing.Size(lvIssues.Size.Width, lvIssues.Size.Height - statusStrip.Size.Height);
                            statusStrip.Visible = true;
                        }
                    }
                    else if (statusStrip.Visible)
                    {
                        lvIssues.Size = new System.Drawing.Size(lvIssues.Size.Width, lvIssues.Size.Height + statusStrip.Size.Height);
                        statusStrip.Visible = false;
                    }
            }
                };
            if (InvokeRequired)
                Invoke(action);
            else
                action();
        }

        private void controller_OnBackgroundUpdated(ErrorTypes error, List<Project> newProjects, string resultInfo)
        {
            Action action = () =>
                {
                    switch (error)
                    {
                        case ErrorTypes.NoErrors:
                            for (int i = cbProjects.Items.Count - 1; i >= 1; i--)
                                cbProjects.Items.RemoveAt(i);
                            for (int i = 0; i < newProjects.Count; i++)
                                if (Properties.Application.Default.show_closed_projects || (!Properties.Application.Default.show_closed_projects && newProjects[i].Status != 5))
                                    if (Properties.Application.Default.show_projects_without_current_user || (!Properties.Application.Default.show_projects_without_current_user && newProjects[i].Roles[0].ID != -1))
                                        if (newProjects[i].Parent == null)
                                            cbProjects.Items.Add(new TextAndValueItem { Text = newProjects[i].Name + (newProjects[i].Status == 5 ? " (closed)" : ""), Value = newProjects[i].ID });
                                        else
                                            cbProjects.Items.Add(new TextAndValueItem { Text = "    └ " + newProjects[i].Name + (newProjects[i].Status == 5 ? " (closed)" : ""), Value = newProjects[i].ID });
                            int indexToSelect = 0;
                            for (int i = 1; i < cbProjects.Items.Count; i++)
                                if ((long)(cbProjects.Items[i] as TextAndValueItem).Value == lastSelectedProjectID)
                                {
                                    indexToSelect = i;
                                    break;
                                }
                            cbProjects.SelectedIndex = indexToSelect;
                            toolStripStatusLabel.Text = "Last update was at " + DateTime.Now.ToShortTimeString() + " (success)";
                            refreshToolStripMenuItem.Enabled = true;
                            refreshFromNIToolStripMenuItem.Enabled = true;
                            if (this.WindowState == FormWindowState.Minimized && resultInfo.Length > 0)
                                new NotificationsForm(resultInfo, 15000).Show();
                            break;
                        case ErrorTypes.UnathorizedAccess:
                            if (this.WindowState == FormWindowState.Minimized)
                            {
                                notifyIcon.BalloonTipTitle = "Redmine Client [notification]";
                                notifyIcon.BalloonTipIcon = ToolTipIcon.Error;
                                notifyIcon.BalloonTipText = "Another background update failed: wrong authorization data. Click here to open the program and re-authenticate.";
                                notifyIcon.ShowBalloonTip(5000);
                                if (Properties.Application.Default.background_updater_play_notification_sound)
                                    System.Media.SystemSounds.Exclamation.Play();
                            }
                            else
                                controller.NeedToReAuthenticate(false);
                            break;
                    }
                };
            if (InvokeRequired)
                Invoke(action);
            else
                action();
        }

        private void notifyIcon_BalloonTipClicked(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            controller.NeedToReAuthenticate(false);
        }
    }

    class ListViewItemComparer : IComparer
    {
        private int column;
        private SortOrder sortOrder;

        public ListViewItemComparer()
        {
            column = 0;
            sortOrder = SortOrder.Ascending;
        }

        public ListViewItemComparer(int column, SortOrder sortOrder)
        {
            this.column = column;
            this.sortOrder = sortOrder;
        }

        public int Compare(object x, object y)
        {
            int returnValue = -1;
            if (column == 6)
            {
                string[] splittedFullDate = ((ListViewItem)x).SubItems[column].Text.Replace(" ", "").Split(',');
                DateTime firstDate = new DateTime(int.Parse(splittedFullDate[1].Split('.')[2]), int.Parse(splittedFullDate[1].Split('.')[1]), int.Parse(splittedFullDate[1].Split('.')[0]), int.Parse(splittedFullDate[0].Split(':')[0]), int.Parse(splittedFullDate[0].Split(':')[1]), 0);
                splittedFullDate = ((ListViewItem)y).SubItems[column].Text.Replace(" ", "").Split(',');
                DateTime secondDate = new DateTime(int.Parse(splittedFullDate[1].Split('.')[2]), int.Parse(splittedFullDate[1].Split('.')[1]), int.Parse(splittedFullDate[1].Split('.')[0]), int.Parse(splittedFullDate[0].Split(':')[0]), int.Parse(splittedFullDate[0].Split(':')[1]), 0);
                returnValue = DateTime.Compare(firstDate, secondDate);
            }
            else
                returnValue = String.Compare(((ListViewItem)x).SubItems[column].Text, ((ListViewItem)y).SubItems[column].Text);
            if (sortOrder == SortOrder.Descending)
                returnValue *= -1;
            return returnValue;
        }
    }
}
