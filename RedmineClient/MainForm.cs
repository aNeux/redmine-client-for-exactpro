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
                + "Description: " + project.Description + "\n"
                + "Status: " + project.Status + "\n"
                + "Created on: " + project.CreatedOn.Hour + ":" + project.CreatedOn.Minute + ", " + project.CreatedOn.Day + " " + Utils.GetMonthName(project.CreatedOn.Month) + " " + project.CreatedOn.Year;
            MessageBox.Show(projectInfo, "Info about project \"" + project.Name + "\"");
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
                            MessageBox.Show("Cannot connect to Redmine services. Please check your Internet connection and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                                lvi.SubItems.Add(issue.Status.Name);
                                lvi.SubItems.Add(issue.CreatedOn.Hour + ":" + issue.CreatedOn.Minute + ", " + issue.CreatedOn.Day + " " + Utils.GetMonthName(issue.CreatedOn.Month) + " " + issue.CreatedOn.Year);
                                lvIssues.Items.Add(lvi);
                            }
                            break;
                        case ErrorTypes.NoInternetConnection:
                            MessageBox.Show("Cannot connect to Redmine services. Please check your Internet connection and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
