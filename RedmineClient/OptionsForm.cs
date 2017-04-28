using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace RedmineClient
{
    public partial class OptionsForm : Form
    {
        public OptionsForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
        }

        private void OptionsForm_Shown(object sender, EventArgs e)
        {
            cbAskBeforeExit.Checked = Properties.Application.Default.ask_before_exit;
            cbMinimazeToTray.Checked = Properties.Application.Default.minimaze_to_tray;
            cbShowLogin.Checked = Properties.Application.Default.show_account_login;
            cbShowStatusBar.Checked = Properties.Application.Default.show_status_bar;
            cbEnableEncryption.Checked = Properties.Application.Default.enable_encryption;
            cbEnableBackgroundUpdater.Checked = Properties.Application.Default.background_updater_enable;
            nudUpdateInterval.Value = Properties.Application.Default.background_updater_interval / 60 / 1000;
            tbHostURL.Text = Properties.Application.Default.redmine_host;
            cbShowClosedProjects.Checked = Properties.Application.Default.show_closed_projects;
        }

        private void cbEnableBackgroundUpdater_CheckedChanged(object sender, EventArgs e)
        {
            labelUpdateInterval.Enabled = cbEnableBackgroundUpdater.Checked;
            nudUpdateInterval.Enabled = cbEnableBackgroundUpdater.Checked;
            labelMinutes.Enabled = cbEnableBackgroundUpdater.Checked;
        }

        private void cbEnableEditHostURL_CheckedChanged(object sender, EventArgs e)
        {
            tbHostURL.ReadOnly = !cbEnableEditingHostURL.Checked;
            tbHostURL.Text = Properties.Application.Default.redmine_host;
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            if (Regex.IsMatch(tbHostURL.Text, @"^(https?:\/\/)?([\da-z\.-]+)\.([a-z\.]{2,6})([\/\w \.-]*)*\/$"))
            {
                bool[] whatsChanged = new bool[7];
                Properties.Application.Default.ask_before_exit = cbAskBeforeExit.Checked;
                Properties.Application.Default.minimaze_to_tray = cbMinimazeToTray.Checked;
                if (cbShowLogin.Checked != Properties.Application.Default.show_account_login)
                {
                    whatsChanged[0] = true;
                    Properties.Application.Default.show_account_login = cbShowLogin.Checked;
                }
                if (cbShowStatusBar.Checked != Properties.Application.Default.show_status_bar)
                {
                    whatsChanged[1] = true;
                    Properties.Application.Default.show_status_bar = cbShowStatusBar.Checked;
                }
                if (cbEnableEncryption.Checked != Properties.Application.Default.enable_encryption)
                {
                    whatsChanged[2] = true;
                    Properties.Application.Default.enable_encryption = cbEnableEncryption.Checked;
                }
                if (cbEnableBackgroundUpdater.Checked != Properties.Application.Default.background_updater_enable)
                {
                    whatsChanged[3] = true;
                    Properties.Application.Default.background_updater_enable = cbEnableBackgroundUpdater.Checked;
                }
                if ((long)nudUpdateInterval.Value * 1000 * 60 != Properties.Application.Default.background_updater_interval)
                {
                    whatsChanged[4] = true;
                    Properties.Application.Default.background_updater_interval = (long)nudUpdateInterval.Value * 1000 * 60;
                }
                if (tbHostURL.Text != Properties.Application.Default.redmine_host)
                {
                    whatsChanged[5] = true;
                    Properties.Application.Default.redmine_host = tbHostURL.Text;
                }
                if (cbShowClosedProjects.Checked != Properties.Application.Default.show_closed_projects)
                {
                    whatsChanged[6] = true;
                    Properties.Application.Default.show_closed_projects = cbShowClosedProjects.Checked;
                }
                Properties.Application.Default.Save();
                Program.controllerGlobal.NotifyAboutChangedSettings(whatsChanged);
                this.Close();
            }
            else
            {
                MessageBox.Show("URL format for Redmine host is invalid. Please, check it and correct.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tabControl.SelectedIndex = 2;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
