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
            tbID.Text = Properties.Settings.Default.id.ToString();
            tbLogin.Text = Properties.Settings.Default.login;
            tbFirstName.Text = Properties.Settings.Default.first_name;
            tbLastName.Text = Properties.Settings.Default.last_name;
            tbEmail.Text = Properties.Settings.Default.email;
            tbCreationDate.Text = Properties.Settings.Default.created_on.ToShortTimeString() + ", " + Properties.Settings.Default.created_on.ToShortDateString();
            tbAPIKey.Text = Utils.DecodeXOR(Properties.Settings.Default.api_key);
            labelInfo.Select();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
