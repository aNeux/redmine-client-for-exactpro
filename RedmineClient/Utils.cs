using System;
using System.Management;

namespace RedmineClient
{
    /// <summary>
    /// Класс, содержащий различные полезные методы.
    /// </summary>
    public static class Utils
    {
        /// <summary>
        /// XOR-шифрование заданной строки.
        /// </summary>
        /// <param name="strToEncode">Строка для шифрования.</param>
        /// <returns>Зашифрованная методом XOR строка.</returns>
        public static string EncodeXOR(string strToEncode)
        {
            char[] text = strToEncode.ToCharArray();
            char[] keyCharArray = GetUniqueKey().ToCharArray();
            string result = null;
            for (int i = 0; i < text.Length; i++)
                result += (char)(text[i] ^ keyCharArray[i % keyCharArray.Length]);
            return result;
        }

        /// <summary>
        /// Дешифрование строки, закодированной методом XOR.
        /// </summary>
        /// <param name="strToDecode">Строка для дешифрования.</param>
        /// <returns>Дешифрованная строка.</returns>
        public static string DecodeXOR(string strToDecode)
        {
            char[] result = new char[strToDecode.Length];
            char[] keyCharArray = GetUniqueKey().ToCharArray();
            for (int i = 0; i < strToDecode.Length; i++)
                result[i] = (char)(strToDecode[i] ^ keyCharArray[i % keyCharArray.Length]);
            return new string(result);
        }

        /// <summary>
        /// Получение уникального для данного устройства ключа, который может быть использован в XOR-шифровании.
        /// </summary>
        /// <returns>Уникальный ключ для данного устройства.</returns>
        private static string GetUniqueKey()
        {
            string result = "";
            ManagementObjectSearcher moSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_ComputerSystem");
            foreach (ManagementObject process in moSearcher.Get())
            {
                process.Get();
                result += process["Manufacturer"].ToString() + process["Model"].ToString();
            }
            moSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_BIOS");
            foreach (ManagementObject mObject in moSearcher.Get())
                result += ((string[])mObject["BIOSVersion"])[0];
            return result.Replace(" ", "");
        }
    }
}
