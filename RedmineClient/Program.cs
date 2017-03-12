using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace RedmineClient
{
    static class Program
    {
        public static Controller controllerGlobal;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            MessageBoxManager.OK = "test";
            MessageBoxManager.Yes = "Yes";
            MessageBoxManager.No = "No";
            MessageBoxManager.Cancel = "Cancel";
            MessageBoxManager.Register();
            controllerGlobal = new Controller();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
