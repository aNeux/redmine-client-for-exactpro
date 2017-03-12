using System;
using System.Text;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace RedmineClient
{
    public partial class APITokenForm : Form
    {
        Controller controller;

        public APITokenForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
        }

        private void APITokenForm_Shown(object sender, EventArgs e)
        {
            tbAPIToken.Text = Properties.Settings.Default.api_token;
            tbAPIToken.Select();
            tbAPIToken.SelectAll();
            controller = Program.controllerGlobal;
            controller.OnAPITokenChanged += controller_OnAPITokenChanged;
        }

        private void EnterAPITokenForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            controller.OnAPITokenChanged -= controller_OnAPITokenChanged;
            if (Properties.Settings.Default.api_token.Length == 0)
                Application.Exit();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (tbAPIToken.Text.Length == 0)
                MessageBox.Show("Please enter API token!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                btnSave.Enabled = false;
                controller.ChangeApiToken(tbAPIToken.Text);
            }
        }

        private void btnCacnel_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.api_token.Length != 0)
                this.Close();
            else
            {
                DialogResult dialogResult = MessageBox.Show("Cause we don't know any API keys, the application will be closed. Are you really sure you want to exit?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                    Application.Exit();
            }
        }

        private void controller_OnAPITokenChanged(ErrorTypes error, bool isChanged)
        {
            Action action = () =>
                {
                    btnSave.Enabled = true;
                    switch (error)
                    {
                        case ErrorTypes.NoErrors:
                            this.Close();
                            break;
                        case ErrorTypes.NoInternetConnection:
                            MessageBox.Show("Cannot connect to Redmine services. Please check your Internet connection and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        case ErrorTypes.UnathorizedAccess:
                            MessageBox.Show("Wrong API token. Please check entered data and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
