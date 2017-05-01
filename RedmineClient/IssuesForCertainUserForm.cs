using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using RedmineClient.Models;

namespace RedmineClient
{
    public partial class IssuesForCertainUserForm : Form
    {
        private Controller controller;
        private long userID = -1;
        private List<Issue> issuesForEveryUser;

        public IssuesForCertainUserForm(long userID)
        {
            InitializeComponent();
            this.userID = userID;
            this.StartPosition = FormStartPosition.CenterParent;
        }

        private void IssuesForCertainUserForm_Shown(object sender, EventArgs e)
        {
            controller = Program.controllerGlobal;
            controller.OnIssuesForEveryUserLoaded += controller_OnIssuesForEveryUserLoaded;
            controller.LoadIssuesForEveryUser();
        }

        private void IssuesForCertainUserForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            controller.OnIssuesForEveryUserLoaded -= controller_OnIssuesForEveryUserLoaded;
        }

        private void cbUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            lvIssues.Items.Clear();
            List<Issue> issuesForCertainUser = new List<Issue>();
            issuesForCertainUser.AddRange(issuesForEveryUser);
            issuesForCertainUser.RemoveAll(temp => temp.AssignedTo == null || temp.AssignedTo.ID != (long)(cbUsers.SelectedItem as TextAndValueItem).Value);
            labelFoundIssuesCount.Text = "Count of issues for that user: " + issuesForCertainUser.Count + "; total count: " + issuesForEveryUser.Count;
            foreach (Issue currentIssue in issuesForCertainUser)
            {
                ListViewItem lvi = new ListViewItem(currentIssue.ID + "");
                lvi.SubItems.Add(currentIssue.Subject);
                lvi.SubItems.Add(currentIssue.Project.Name + " (ID: " + currentIssue.Project.ID + ")");
                lvi.SubItems.Add(currentIssue.Tracker.Name);
                lvi.SubItems.Add(currentIssue.Status.Name);
                lvi.SubItems.Add(currentIssue.Priority.Name);
                lvIssues.Items.Add(lvi);
            }
        }

        private void lvIssues_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                long issueID = long.Parse(lvIssues.FocusedItem.SubItems[0].Text);
                try
                {
                    long projectIDForThisIssue = issuesForEveryUser.Single(temp => temp.ID == issueID).Project.ID;
                    new IssueInformationForm(issueID, controller.GetProjects().Single(temp => temp.ID == projectIDForThisIssue).Roles).ShowDialog();
                }
                catch
                {
                    MessageBox.Show("Couldn't open information about issue #" + issueID + ". Please, refresh projects and issues from main window and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void controller_OnIssuesForEveryUserLoaded(ErrorTypes error, List<User> users, List<Issue> issuesForEveryUser)
        {
            Action action = () =>
                {
                    switch (error)
                    {
                        case ErrorTypes.NoErrors:
                            this.issuesForEveryUser = new List<Issue>();
                            this.issuesForEveryUser.AddRange(issuesForEveryUser);
                            int indexToSelect = -1;
                            for (int i = 0; i < users.Count; i++)
                            {
                                cbUsers.Items.Add(new TextAndValueItem { Text = users[i].Name, Value = users[i].ID });
                                if (userID == users[i].ID)
                                    indexToSelect = i;
                            }
                            if (indexToSelect != -1)
                                cbUsers.SelectedIndex = indexToSelect;
                            cbUsers.Enabled = true;
                            lvIssues.Enabled = true;
                            btnClose.Enabled = true;
                            this.Text = "Issues for user";
                            break;
                        case ErrorTypes.ConnectionError:
                            this.Text = "Project information";
                            MessageBox.Show("Cannot connect to Redmine services. Please check your Internet connection and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            this.Close();
                            break;
                        case ErrorTypes.UnathorizedAccess:
                            this.Text = "Project information";
                            MessageBox.Show("You have the wrong authorization data. Please change it and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            controller.NeedToReAuthenticate(false);
                            this.Close();
                            break;
                        case ErrorTypes.UnknownError:
                            this.Text = "Project information";
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
    }
}
