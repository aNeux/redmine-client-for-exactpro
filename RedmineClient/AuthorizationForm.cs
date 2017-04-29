using System;
using System.Text;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace RedmineClient
{
    public partial class AuthorizationForm : Form
    {
        private Controller controller;

        public AuthorizationForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
        }

        private void APITokenForm_Shown(object sender, EventArgs e)
        {
            if (Properties.User.Default.api_key.Length != 0)
            {
                cbUseAPIKeyInstead.Checked = true;
                tbAPIKey.Text = Utils.DecodeXOR(Properties.User.Default.api_key);
                tbAPIKey.Select();
                tbAPIKey.SelectAll();
            }
            else
                tbLogin.Select();
            controller = Program.controllerGlobal;
            controller.OnUserAuthenticated += controller_OnUserAuthenticated;
        }

        private void EnterAPITokenForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            controller.OnUserAuthenticated -= controller_OnUserAuthenticated;
            if (Properties.User.Default.api_key.Length == 0)
                Application.Exit();
        }

        private void linkLabelForgotPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(Properties.Application.Default.redmine_host + "account/lost_password");
        }

        private void cbUseAPIKeyInstead_CheckedChanged(object sender, EventArgs e)
        {
            labelLogin.Enabled = !cbUseAPIKeyInstead.Checked;
            tbLogin.Enabled = !cbUseAPIKeyInstead.Checked;
            labelPassword.Enabled = !cbUseAPIKeyInstead.Checked;
            tbPassword.Enabled = !cbUseAPIKeyInstead.Checked;
            linkLabelForgotPassword.Enabled = !cbUseAPIKeyInstead.Checked;
            labelAPIKey.Enabled = cbUseAPIKeyInstead.Checked;
            tbAPIKey.Enabled = cbUseAPIKeyInstead.Checked;
            if (!cbUseAPIKeyInstead.Checked)
                if (tbLogin.Text.Length == 0)
                    tbLogin.Select();
                else
                {
                    tbPassword.Select();
                    tbPassword.SelectionStart = tbPassword.Text.Length;
                }
            else
            {
                tbAPIKey.Select();
                tbAPIKey.SelectionStart = tbAPIKey.Text.Length;
            }
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            if (!cbUseAPIKeyInstead.Checked)
                if (tbLogin.Text.Length == 0)
                    MessageBox.Show("Please, enter your login (user name)!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (tbPassword.Text.Length == 0)
                    MessageBox.Show("Please, enter your password!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    ChangeUIState(false);
                    this.Text = "Authorization [please, wait..]";
                    controller.Authorize(true, Convert.ToBase64String(System.Text.Encoding.GetEncoding("ISO-8859-1").GetBytes(tbLogin.Text + ":" + tbPassword.Text)));
                }
            else
                if (tbAPIKey.Text.Length == 0)
                    MessageBox.Show("Please, enter your API key!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    ChangeUIState(false);
                    this.Text = "Authorization [please, wait..]";
                    controller.Authorize(false, tbAPIKey.Text);
                }
        }

        private void btnCacnel_Click(object sender, EventArgs e)
        {
            if (Properties.User.Default.api_key.Length != 0)
                this.Close();
            else
            {
                DialogResult dialogResult = MessageBox.Show("Cause you are not authorized, the application will be closed. Are you really sure you want to exit?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                    Application.Exit();
            }
        }

        private void controller_OnUserAuthenticated(ErrorTypes error, bool isUserChanged)
        {
            Action action = () =>
                {
                    switch (error)
                    {
                        case ErrorTypes.NoErrors:
                            this.Close();
                            break;
                        case ErrorTypes.ConnectionError:
                            this.Text = "Authorization";
                            MessageBox.Show("Cannot connect to Redmine services. Please check your Internet connection and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            ChangeUIState(true);
                            break;
                        case ErrorTypes.UnathorizedAccess:
                            this.Text = "Authorization";
                            MessageBox.Show("You have entered the wrong authorization data. Please change it and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            ChangeUIState(true);
                            break;
                        case ErrorTypes.UnknownError:
                            this.Text = "Authorization";
                            ChangeUIState(true);
                            break;
                    }
                };
            if (InvokeRequired)
                Invoke(action);
            else
                action();
        }

        private void ChangeUIState(bool isEnabled)
        {
            labelLogin.Enabled = isEnabled && !cbUseAPIKeyInstead.Checked;
            tbLogin.Enabled = isEnabled && !cbUseAPIKeyInstead.Checked;
            labelPassword.Enabled = isEnabled && !cbUseAPIKeyInstead.Checked;
            tbPassword.Enabled = isEnabled && !cbUseAPIKeyInstead.Checked;
            linkLabelForgotPassword.Enabled = isEnabled && !cbUseAPIKeyInstead.Checked;
            labelAPIKey.Enabled = isEnabled && cbUseAPIKeyInstead.Checked;
            tbAPIKey.Enabled = isEnabled && cbUseAPIKeyInstead.Checked;
            cbUseAPIKeyInstead.Enabled = isEnabled;
            btnLogIn.Enabled = isEnabled;
            btnCancel.Enabled = isEnabled;
        }
    }
}
