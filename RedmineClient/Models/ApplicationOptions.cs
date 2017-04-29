using System;

namespace RedmineClient.Models
{
    public class ApplicationOptions
    {
        public bool AskBeforeExiting { set; get; }
        public bool MinimazeToTray { set; get; }
        public bool ShowAccountLogin { set; get; }
        public bool ShowStatusBar { set; get; }
        public bool EnableEncryption { set; get; }
        public bool EnableBackgroundUpdater { set; get; }
        public long BackgroundUpdaterInterval { set; get; }
        public string RedmineHost { set; get; }
        public bool ShowClodedProjects { set; get; }
        public bool ShowProjectsWithoutCurrentUser { set; get; }

        public ApplicationOptions(bool setDefaults)
        {
            if (setDefaults)
            {
                this.AskBeforeExiting = true;
                this.MinimazeToTray = false;
                this.ShowAccountLogin = true;
                this.ShowStatusBar = true;
                this.EnableEncryption = true;
                this.EnableBackgroundUpdater = true;
                this.BackgroundUpdaterInterval = 60000;
                this.RedmineHost = "http://student-rm.exactpro.com/";
                this.ShowClodedProjects = true;
                this.ShowProjectsWithoutCurrentUser = false;
            }
        }
    }
}
