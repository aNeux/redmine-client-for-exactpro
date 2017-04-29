using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace RedmineClient
{
    public partial class OptionsForm : Form
    {
        private Controller controller;

        public OptionsForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
        }

        private void OptionsForm_Shown(object sender, EventArgs e)
        {
            cbAskBeforeExiting.Checked = Properties.Application.Default.ask_before_exiting;
            cbMinimazeToTray.Checked = Properties.Application.Default.minimaze_to_tray;
            cbShowAccountLogin.Checked = Properties.Application.Default.show_account_login;
            cbShowStatusBar.Checked = Properties.Application.Default.show_status_bar;
            cbEnableEncryption.Checked = Properties.Application.Default.encryption_enabled;
            cbEnableBackgroundUpdater.Checked = Properties.Application.Default.background_updater_enabled;
            nudBackgroundUpdaterInterval.Value = Properties.Application.Default.background_updater_interval / 60 / 1000;
            tbRedmineHost.Text = Properties.Application.Default.redmine_host;
            cbShowClosedProjects.Checked = Properties.Application.Default.show_closed_projects;
            cbShowProjectsWithoutCurrentUser.Checked = Properties.Application.Default.show_projects_without_current_user;
            controller = Program.controllerGlobal;
            controller.OnOptionsApplied += controller_OnOptionsApplied;
        }

        private void OptionsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            controller.OnOptionsApplied -= controller_OnOptionsApplied;
        }

        private void cbEnableBackgroundUpdater_CheckedChanged(object sender, EventArgs e)
        {
            labelBackgroundUpdaterInterval.Enabled = cbEnableBackgroundUpdater.Checked;
            nudBackgroundUpdaterInterval.Enabled = cbEnableBackgroundUpdater.Checked;
            labelMinutes.Enabled = cbEnableBackgroundUpdater.Checked;
        }

        private void cbEnableEditHostURL_CheckedChanged(object sender, EventArgs e)
        {
            tbRedmineHost.ReadOnly = !cbEnableEditingRedmineHost.Checked;
            tbRedmineHost.Text = Properties.Application.Default.redmine_host;
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            if (cbEnableEditingRedmineHost.Checked && !Regex.IsMatch(tbRedmineHost.Text, @"^(https?:\/\/)?([\da-z\.-]+)\.([a-z\.]{2,6})([\/\w \.-]*)*\/$"))
                MessageBox.Show("Format of URL address you entered is invalid. Please, correct it and try again. Note that required formats is http://<domain & subdomains>/ or https://<domain & subdomains>/.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                Models.ApplicationOptions newOptions = new Models.ApplicationOptions(false);
                newOptions.AskBeforeExiting = cbAskBeforeExiting.Checked;
                newOptions.MinimazeToTray = cbMinimazeToTray.Checked;
                newOptions.ShowAccountLogin = cbShowAccountLogin.Checked;
                newOptions.ShowStatusBar = cbShowStatusBar.Checked;
                newOptions.EnableEncryption = cbEnableEncryption.Checked;
                newOptions.EnableBackgroundUpdater = cbEnableBackgroundUpdater.Checked;
                newOptions.BackgroundUpdaterInterval = (long)nudBackgroundUpdaterInterval.Value * 1000 * 60;
                newOptions.RedmineHost = tbRedmineHost.Text;
                newOptions.ShowClodedProjects = cbShowClosedProjects.Checked;
                newOptions.ShowProjectsWithoutCurrentUser = cbShowProjectsWithoutCurrentUser.Checked;
                if (cbEnableEditingRedmineHost.Checked && Properties.Application.Default.redmine_host != tbRedmineHost.Text)
                {
                    tabControl.Enabled = false;
                    btnApply.Enabled = false;
                    btnCancel.Enabled = false;
                    this.Text = "Options [please, wait..]";
                }
                controller.ApplyNewOptions(newOptions);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnReseToDefaults_Click(object sender, EventArgs e)
        {
            var dialogResult = MessageBox.Show("Are you sure that you want to restore options to their default values? Redmine host will be set to http://student-rm.exactpro.com/.", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                if (Properties.Application.Default.redmine_host != "http://student-rm.exactpro.com/")
                {
                    tabControl.Enabled = false;
                    btnApply.Enabled = false;
                    btnCancel.Enabled = false;
                    this.Text = "Options [please, wait..]";
                }
                controller.ApplyNewOptions(new Models.ApplicationOptions(true));
            }
        }

        private void controller_OnOptionsApplied(ErrorTypes error, bool[] whatsChanged)
        {
            Action action = () =>
                {
                    switch (error)
                    {
                        case ErrorTypes.NoErrors:
                            this.Close();
                            break;
                        case ErrorTypes.ConnectionError:
                            this.Text = "Options";
                            MessageBox.Show("Cannot connect to Redmine services. Probably you entered invalid host address, so please, check it out and try again. Also it could be a network error too.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            tabControl.Enabled = true;
                            btnApply.Enabled = true;
                            btnCancel.Enabled = true;
                            break;
                        case ErrorTypes.UnknownError:
                            this.Text = "Options";
                            MessageBox.Show("An unknown error occurred. Please, try again one more time.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            tabControl.Enabled = true;
                            btnApply.Enabled = true;
                            btnCancel.Enabled = true;
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
