using System;
using System.Collections.Generic;
using System.Windows.Forms;
using RedmineClient.Models;

namespace RedmineClient
{
    public partial class ProjectInformation : Form
    {
        private Controller controller;
        private long projectID;

        public ProjectInformation(long projectID)
        {
            InitializeComponent();
            this.projectID = projectID;
            this.StartPosition = FormStartPosition.CenterParent;
        }

        private void ProjectInformation_Shown(object sender, EventArgs e)
        {
            labelID.Select();
            controller = Program.controllerGlobal;
            controller.OnProjectInformationLoaded += controller_OnProjectInformationLoaded;
            controller.LoadProjectInformation(projectID);
        }

        private void ProjectInformation_FormClosing(object sender, FormClosingEventArgs e)
        {
            controller.OnProjectInformationLoaded -= controller_OnProjectInformationLoaded;
        }

        private void lbMembers_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                lbMembers.SelectedIndex = lbMembers.IndexFromPoint(e.X, e.Y);
                contextMenuMembers.Show(Cursor.Position);
            }
        }

        private void showIssuesForThatUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new IssuesForCertainUserForm((long)(lbMembers.SelectedItem as TextAndValueItem).Value).ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void controller_OnProjectInformationLoaded(ErrorTypes error, Project project, List<Membership> memberships)
        {
            Action action = () =>
            {
                switch (error)
                {
                    case ErrorTypes.NoErrors:
                        tbID.Text = project.ID.ToString();
                        tbName.Text = project.Name;
                        tbIdentifier.Text = project.Identifier;
                        tbHomepage.Text = project.Homepage.Length > 0 ? project.Homepage : "< none >";
                        tbStatus.Text = project.Status == 1 ? "Opened" : "Closed";
                        tbCreationDate.Text = project.CreatedOn.ToShortTimeString() + ", " + project.CreatedOn.ToShortDateString();
                        tbLastUpdate.Text = project.UpdatedOn.ToShortTimeString() + ", " + project.UpdatedOn.ToShortDateString();
                        tbDescription.Text = project.Description;
                        foreach (Membership membership in memberships)
                        {
                            string memberRoles = "";
                            foreach (Role role in membership.Roles)
                                memberRoles += role.Name + ", ";
                            memberRoles = memberRoles.Remove(memberRoles.Length - 2);
                            lbMembers.Items.Add(new TextAndValueItem { Text = membership.User.Name + " (" + memberRoles + ")", Value = membership.User.ID });
                        }
                        cbIsPublic.Checked = project.IsPublic;
                        lbMembers.Enabled = true;
                        btnClose.Enabled = true;
                        this.Text = "Project information";
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
