using System;
using System.Text;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace RedmineClient
{
    public partial class ChangeAPIKeyForm : Form
    {
        Controller controller;

        public ChangeAPIKeyForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
        }

        private void APITokenForm_Shown(object sender, EventArgs e)
        {
            tbAPIKey.Text = Properties.Settings.Default.api_key;
            tbAPIKey.Select();
            tbAPIKey.SelectAll();
            controller = Program.controllerGlobal;
            controller.OnAPIKeyChanged += controller_OnAPITokenChanged;
        }

        private void EnterAPITokenForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            controller.OnAPIKeyChanged -= controller_OnAPITokenChanged;
            if (Properties.Settings.Default.api_key.Length == 0)
                Application.Exit();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (tbAPIKey.Text.Length == 0)
                MessageBox.Show("Please, enter API key!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                btnSave.Enabled = false;
                btnCancel.Enabled = false;
                controller.ChangeAPIKey(tbAPIKey.Text);
            }
        }

        private void btnCacnel_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.api_key.Length != 0)
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
                    switch (error)
                    {
                        case ErrorTypes.NoErrors:
                            this.Close();
                            break;
                        case ErrorTypes.NoInternetConnection:
                            btnSave.Enabled = true;
                            btnCancel.Enabled = true;
                            MessageBox.Show("Cannot connect to Redmine services. Please check your Internet connection and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        case ErrorTypes.UnathorizedAccess:
                            btnSave.Enabled = true;
                            btnCancel.Enabled = true;
                            MessageBox.Show("Wrong API key. Please check entered data and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
