using System;
using System.Windows.Forms;
using RedmineClient.Models;

namespace RedmineClient
{
    public partial class ProjectInformation : Form
    {
        private Project project;

        public ProjectInformation(Project project)
        {
            InitializeComponent();
            this.project = project;
            this.StartPosition = FormStartPosition.CenterParent;
        }

        private void ProjectInformation_Shown(object sender, EventArgs e)
        {
            tbID.Text = project.ID.ToString();
            tbName.Text = project.Name;
            tbIdentifier.Text = project.Identifier;
            tbStatus.Text = project.Status == 1? "Opened" : "Closed";
            tbCreationDate.Text = project.CreatedOn.ToShortTimeString() + ", " + project.CreatedOn.ToShortDateString();
            tbLastUpdate.Text = project.UpdatedOn.ToShortTimeString() + ", " + project.UpdatedOn.ToShortDateString();
            tbDescription.Text = project.Description;
            foreach (Membership membership in project.Memberships)
            {
                string memberRoles = "";
                foreach (Role role in membership.Roles)
                    memberRoles += role.Name + ", ";
                memberRoles = memberRoles.Remove(memberRoles.Length - 2);
                if (membership.Member != null)
                    lbMembers.Items.Add(membership.Member.Name + " (" + memberRoles + ")");
            }
            labelID.Select();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
