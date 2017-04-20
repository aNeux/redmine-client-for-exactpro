using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace RedmineClient.Models
{
    /// <summary>
    /// Класс для парсера, представляющий информацию о всех возможных трекерах задачи.
    /// </summary>
    public class IssueTrackersJSONObject
    {
        [JsonProperty("trackers")]
        public List<IssueTracker> IssueTrackers { set; get; }
    }

    /// <summary>
    /// Класс, представляющий информацию о типе задачи.
    /// </summary>
    public class IssueTracker
    {
        [JsonProperty("id")]
        public int ID { set; get; }
        [JsonProperty("name")]
        public string Name { set; get; }
        [JsonProperty("default_status")]
        public IssueStatus DefaultStatus { set; get; }
    }
}
