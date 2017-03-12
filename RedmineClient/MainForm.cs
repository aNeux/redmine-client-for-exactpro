using System;
using System.Collections.Generic;
using RedmineClient.Models;
using System.Windows.Forms;

namespace RedmineClient
{
    public partial class MainForm : Form
    {
        Controller controller;

        public MainForm()
        {
            InitializeComponent();
            this.CenterToScreen();
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            controller = Program.controllerGlobal;
            controller.OnAPITokenChanged += controller_OnAPITokenChanged;
            controller.OnProjectsUpdated += controller_OnProjectsUpdated;
            controller.OnIssuesUpdated += controller_OnIssuesUpdated;
            controller.UpdateProjects();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            controller.OnAPITokenChanged -= controller_OnAPITokenChanged;
            controller.OnProjectsUpdated -= controller_OnProjectsUpdated;
            controller.OnIssuesUpdated -= controller_OnIssuesUpdated;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dialogResult = MessageBox.Show("Are you sure you want to exit?", "Exiting", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
                Application.Exit();
        }

        private void changeAPITokenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new APITokenForm().ShowDialog();
        }

        private void cbSelectProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnProjectInfo.Enabled = true;
            //btnNewIssue.Enabled = true;
            string projectName = cbSelectProject.SelectedItem.ToString();
            long projectID = long.Parse(projectName.Substring(1, projectName.IndexOf(":") - 1));
            controller.UpdateIssues(projectID);
        }

        private void btnProjectInfo_Click(object sender, EventArgs e)
        {
            string projectName = cbSelectProject.SelectedItem.ToString();
            long projectID = long.Parse(projectName.Substring(1, projectName.IndexOf(":") - 1));
            Project project = controller.GetProject(projectID);
            string projectInfo = "ID: " + project.ID + "\n"
                + "Name: " + project.Name + "\n"
                + "Identifier: " + project.Identifier + "\n"
                + "Status: " + project.Status + "\n"
                + "Description: " + project.Description + "\n"
                + "Created on: " + project.CreatedOn.Hour + ":" + project.CreatedOn.Minute + ", " + project.CreatedOn.Day + " " + Utils.GetMonthName(project.CreatedOn.Month) + " " + project.CreatedOn.Year;
            MessageBox.Show(projectInfo, "Info about project \"" + project.Name + "\"");
        }

        private void lvIssues_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && lvIssues.FocusedItem.Bounds.Contains(e.Location))
                contextMenuStripIssue.Show(Cursor.Position);
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
                + "Created on: " + issue.CreatedOn.Hour + ":" + issue.CreatedOn.Minute + ", " + issue.CreatedOn.Day + " " + Utils.GetMonthName(issue.CreatedOn.Month) + " " + issue.CreatedOn.Year;
            MessageBox.Show(issueInfo, "Info about issue \"" + issue.Subject + "\"");
        }

        private void controller_OnAPITokenChanged(ErrorTypes error, bool isChanged)
        {
            Action action = () =>
                {
                    if (error == ErrorTypes.NoErrors && isChanged)
                    {
                        btnProjectInfo.Enabled = false;
                        lvIssues.Items.Clear();
                        controller.UpdateProjects();
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
                            cbSelectProject.Items.Clear();
                            foreach (Project project in projects)
                                cbSelectProject.Items.Add("#" + project.ID + ": " + project.Name);
                            break;
                        case ErrorTypes.NoInternetConnection:
                            MessageBox.Show("Cannot connect to Redmine services and load projects. Please check your Internet connection and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        case ErrorTypes.UnathorizedAccess:
                            if (Properties.Settings.Default.api_token.Length == 0)
                                new APITokenForm().ShowDialog();
                            else
                                MessageBox.Show("You have wrong API token. Please check it, change if necessary and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                                lvi.SubItems.Add(issue.CreatedOn.Hour + ":" + issue.CreatedOn.Minute + ", " + issue.CreatedOn.Day + " " + Utils.GetMonthName(issue.CreatedOn.Month) + " " + issue.CreatedOn.Year);
                                lvIssues.Items.Add(lvi);
                            }
                            break;
                        case ErrorTypes.NoInternetConnection:
                            MessageBox.Show("Cannot connect to Redmine services and load issues. Please check your Internet connection and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        case ErrorTypes.UnathorizedAccess:
                            if (Properties.Settings.Default.api_token.Length == 0)
                                new APITokenForm().ShowDialog();
                            else
                                MessageBox.Show("You have wrong API token. Please check it, change if necessary and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
