using System;
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
            // Настройка дефолтных значений надписей на кнопках в MessageBox
            MessageBoxManager.OK = "Ok";
            MessageBoxManager.Yes = "Yes";
            MessageBoxManager.No = "No";
            MessageBoxManager.Cancel = "Cancel";
            MessageBoxManager.Register();
            // Инициализация глобального контроллера
            controllerGlobal = new Controller();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
