using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace RedmineClient.Models
{
    /// <summary>
    /// Класс для парсера, представляющий информацию о всех возможных приоритетах задачи.
    /// </summary>
    public class IssuePrioritiesJSONObject
    {
        [JsonProperty("issue_priorities")]
        public List<IssuePriority> IssuePriorities { set; get; }
    }

    /// <summary>
    /// Класс, представляющий информацию о приоритете задачи.
    /// </summary>
    public class IssuePriority
    {
        [JsonProperty("id")]
        public int ID { set; get; }
        [JsonProperty("name")]
        public string Name { set; get; }
        [JsonProperty("is_default")]
        public bool IsDefault { set; get; }
    }
}
