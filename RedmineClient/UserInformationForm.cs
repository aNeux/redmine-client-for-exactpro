using System;
using System.Windows.Forms;

namespace RedmineClient
{
    public partial class UserInformationForm : Form
    {
        public UserInformationForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
        }

        private void UserInformationForm_Shown(object sender, EventArgs e)
        {
            tbID.Text = Properties.User.Default.id.ToString();
            tbLogin.Text = Properties.User.Default.login;
            tbFirstName.Text = Properties.User.Default.first_name;
            tbLastName.Text = Properties.User.Default.last_name;
            tbEmail.Text = Properties.User.Default.email;
            tbCreationDate.Text = Properties.User.Default.created_on.ToShortTimeString() + ", " + Properties.User.Default.created_on.ToShortDateString();
            tbAPIKey.Text = Utils.DecodeXOR(Properties.User.Default.api_key);
            labelInfo.Select();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            var dialogResult = MessageBox.Show("Do you really want to log out and exit the program?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                Properties.User.Default.Reset();
                Application.Exit();
            }
        }
    }
}
