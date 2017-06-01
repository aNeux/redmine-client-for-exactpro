using System;
using System.Collections.Generic;
using System.Management;
using RedmineClient.Models;

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

        /// <summary>
        /// Применение настроек фильтрации к указанному списку задач.
        /// </summary>
        /// <param name="issues">Список задач для фильтрации.</param>
        /// <param name="filterSettings">Набор настроек фильрации.</param>
        public static void ApplyFilterSettings(ref List<Issue> issues, List<Filter> filterSettings)
        {
            foreach (Filter currentFilter in filterSettings)
            {
                switch (currentFilter.Obj)
                {
                    case FilterObjects.Status:
                        if (currentFilter.Condition == FilterConditions.IS)
                            issues.RemoveAll(temp => temp.Status.ID != (int)currentFilter.Value);
                        else if (currentFilter.Condition == FilterConditions.ISNOT)
                            issues.RemoveAll(temp => temp.Status.ID == (int)currentFilter.Value);
                        break;
                    case FilterObjects.Tracker:
                        if (currentFilter.Condition == FilterConditions.IS)
                            issues.RemoveAll(temp => temp.Tracker.ID != (int)currentFilter.Value);
                        else if (currentFilter.Condition == FilterConditions.ISNOT)
                            issues.RemoveAll(temp => temp.Tracker.ID == (int)currentFilter.Value);
                        break;
                    case FilterObjects.Priority:
                        if (currentFilter.Condition == FilterConditions.IS)
                            issues.RemoveAll(temp => temp.Priority.ID != (int)currentFilter.Value);
                        else if (currentFilter.Condition == FilterConditions.ISNOT)
                            issues.RemoveAll(temp => temp.Priority.ID == (int)currentFilter.Value);
                        break;
                    case FilterObjects.Privacy:
                        if (currentFilter.Condition == FilterConditions.IS)
                            issues.RemoveAll(temp => temp.IsPrivate != (bool)currentFilter.Value);
                        else if (currentFilter.Condition == FilterConditions.ISNOT)
                            issues.RemoveAll(temp => temp.IsPrivate == (bool)currentFilter.Value);
                        break;
                    case FilterObjects.StartDate:
                        if (currentFilter.Condition == FilterConditions.IS)
                            issues.RemoveAll(temp => temp.StartDate != (DateTime)currentFilter.Value);
                        else if (currentFilter.Condition == FilterConditions.ISNOT)
                            issues.RemoveAll(temp => temp.StartDate == (DateTime)currentFilter.Value);
                        else if (currentFilter.Condition == FilterConditions.MORE_OR_EQUAL)
                            issues.RemoveAll(temp => temp.StartDate < (DateTime)currentFilter.Value);
                        else if (currentFilter.Condition == FilterConditions.LESS_OR_EQUAL)
                            issues.RemoveAll(temp => temp.StartDate > (DateTime)currentFilter.Value);
                        break;
                    case FilterObjects.Subject:
                        if (currentFilter.Condition == FilterConditions.CONTAINS)
                            issues.RemoveAll(temp => !temp.Subject.Contains((string)currentFilter.Value));
                        else if (currentFilter.Condition == FilterConditions.DOESNT_CONTAIN)
                            issues.RemoveAll(temp => temp.Subject.Contains((string)currentFilter.Value));
                        break;
                    case FilterObjects.EstimatedTime:
                        if (currentFilter.Condition == FilterConditions.IS)
                            issues.RemoveAll(temp => temp.EstimatedHours != (double)currentFilter.Value);
                        else if (currentFilter.Condition == FilterConditions.ISNOT)
                            issues.RemoveAll(temp => temp.EstimatedHours == (double)currentFilter.Value);
                        else if (currentFilter.Condition == FilterConditions.MORE_OR_EQUAL)
                            issues.RemoveAll(temp => temp.EstimatedHours < (double)currentFilter.Value);
                        else if (currentFilter.Condition == FilterConditions.LESS_OR_EQUAL)
                            issues.RemoveAll(temp => temp.EstimatedHours > (double)currentFilter.Value);
                        else if (currentFilter.Condition == FilterConditions.BEETWEN)
                            issues.RemoveAll(temp => temp.EstimatedHours < ((double[])currentFilter.Value)[0] || temp.EstimatedHours > ((double[])currentFilter.Value)[1]);
                        break;
                    case FilterObjects.DoneRatio:
                        if (currentFilter.Condition == FilterConditions.IS)
                            issues.RemoveAll(temp => temp.DoneRatio != (int)currentFilter.Value);
                        else if (currentFilter.Condition == FilterConditions.ISNOT)
                            issues.RemoveAll(temp => temp.DoneRatio == (int)currentFilter.Value);
                        else if (currentFilter.Condition == FilterConditions.MORE_OR_EQUAL)
                            issues.RemoveAll(temp => temp.DoneRatio < (int)currentFilter.Value);
                        else if (currentFilter.Condition == FilterConditions.LESS_OR_EQUAL)
                            issues.RemoveAll(temp => temp.DoneRatio > (int)currentFilter.Value);
                        else if (currentFilter.Condition == FilterConditions.BEETWEN)
                            issues.RemoveAll(temp => temp.DoneRatio < ((int[])currentFilter.Value)[0] || temp.DoneRatio > ((int[])currentFilter.Value)[1]);
                        break;
                    case FilterObjects.Author:
                        if (currentFilter.Condition == FilterConditions.IS)
                            issues.RemoveAll(temp => temp.Author.ID != (long)currentFilter.Value);
                        else if (currentFilter.Condition == FilterConditions.ISNOT)
                            issues.RemoveAll(temp => temp.Author.ID == (long)currentFilter.Value);
                        break;
                    case FilterObjects.Assignee:
                        if (currentFilter.Condition == FilterConditions.IS)
                            if ((long)currentFilter.Value == -1)
                                issues.RemoveAll(temp => temp.AssignedTo != null);
                            else
                                issues.RemoveAll(temp => temp.AssignedTo == null || (temp.AssignedTo != null && temp.AssignedTo.ID != (long)currentFilter.Value));
                        else if (currentFilter.Condition == FilterConditions.ISNOT)
                            if ((long)currentFilter.Value == -1)
                                issues.RemoveAll(temp => temp.AssignedTo == null);
                            else
                                issues.RemoveAll(temp => temp.AssignedTo != null && temp.AssignedTo.ID == (long)currentFilter.Value);
                        break;
                }
                if (issues.Count == 0)
                    break;
            }
        }
    }
}
