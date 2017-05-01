using System;
using System.Windows.Forms;

namespace RedmineClient
{
    public partial class NotificationsForm : Form
    {
        private string changes;
        private int timeout;

        private Timer timer;
        private int startPositionX;
        private int startPositionY;
        private bool isFormAvailable = false;

        public NotificationsForm(string changes, int timeout)
        {
            InitializeComponent();
            this.changes = changes;
            this.timeout = timeout;
        }

        protected override void OnLoad(EventArgs e)
        {
            startPositionX = Screen.PrimaryScreen.WorkingArea.Width - this.Width;
            startPositionY = Screen.PrimaryScreen.Bounds.Height;
            SetDesktopLocation(startPositionX, startPositionY);
            base.OnLoad(e);
            timer = new Timer();
            timer.Interval = 1;
            timer.Tick += timer_TickFormShowing;
            timer.Start();
        }

        private void NotificationsForm_Shown(object sender, EventArgs e)
        {
            if (Properties.Application.Default.background_updater_play_notification_sound)
                System.Media.SystemSounds.Exclamation.Play();
            this.TopMost = true;
            tbChanges.Text = changes;
            labelHack.Select();
        }

        private void NotificationsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isFormAvailable)
            {
                if (timer != null && timer.Enabled)
                {
                    timer.Stop();
                    timer.Dispose();
                }
                startPositionY = this.Location.Y;
                isFormAvailable = false;
                timer = new Timer();
                timer.Interval = 1;
                timer.Tick += timer_TickFormClosing;
                timer.Start();
                e.Cancel = true;
            }
        }

        private void NotificationsForm_MouseLeave(object sender, EventArgs e)
        {
            if (isFormAvailable && (timer == null || !timer.Enabled))
            {
                timer = new Timer();
                timer.Interval = 5000;
                timer.Tick += timer_TickNeedToCloseForm;
                timer.Start();
            }
        }

        private void tbChanges_Click(object sender, EventArgs e)
        {
            if (isFormAvailable && timer != null && timer.Enabled)
            {
                timer.Stop();
                timer.Dispose();
                timer = null;
            }
        }

        private void timer_TickFormShowing(object sender, EventArgs e)
        {
            startPositionY -= 5;
            if (startPositionY < Screen.PrimaryScreen.WorkingArea.Height - this.Height)
            {
                isFormAvailable = true;
                timer.Stop();
                timer.Dispose();
                timer = new Timer();
                timer.Interval = timeout;
                timer.Tick += timer_TickNeedToCloseForm;
                timer.Start();
            }
            else
                SetDesktopLocation(startPositionX, startPositionY);
        }

        private void timer_TickNeedToCloseForm(object sender, EventArgs e)
        {
            timer.Stop();
            timer.Dispose();
            startPositionY = this.Location.Y;
            isFormAvailable = false;
            timer = new Timer();
            timer.Interval = 1;
            timer.Tick += timer_TickFormClosing;
            timer.Start();
        }

        private void timer_TickFormClosing(object sender, EventArgs e)
        {
            startPositionY += 5;
            if (startPositionY >= Screen.PrimaryScreen.Bounds.Height)
                this.Close();
            else
                SetDesktopLocation(startPositionX, startPositionY);
        }
    }
}
