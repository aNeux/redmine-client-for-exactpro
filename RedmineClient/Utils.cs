using System;
using System.IO;
using System.Net;

namespace RedmineClient
{
    /// <summary>
    /// Класс, содержащий различные полезные методы.
    /// </summary>
    public static class Utils
    {
        /// <summary>
        /// Проверка наличия соединения с сетью Интернет.
        /// </summary>
        public static bool IsNetworkAvailable()
        {
            try
            {
                Stream stream = new WebClient().OpenRead("http://www.google.com");
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
