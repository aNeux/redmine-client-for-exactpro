using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace RedmineClient.Models
{
    /// <summary>
    /// Класс для парсера, представляющий информацию о всех возможных статусах задачи.
    /// </summary>
    public class IssueStatusesJSONObject
    {
        [JsonProperty("issue_statuses")]
        public List<IssueStatus> IssueStatuses { set; get; }
    }

    /// <summary>
    /// Класс, представляющий информацию о статусе задачи.
    /// </summary>
    public class IssueStatus
    {
        [JsonProperty("id")]
        public int ID { set; get; }
        [JsonProperty("name")]
        public string Name { set; get; }
        [JsonProperty("is_closed")]
        public bool IsClosed { set; get; }
    }
}
