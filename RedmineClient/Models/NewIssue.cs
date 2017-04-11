using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace RedmineClient.Models
{
    /// <summary>
    /// Класс для парсера, представляющий готовую к созданию задачу.
    /// </summary>
    public class NewIssueJSONObject
    {
        [JsonProperty("issue")]
        public NewIssue NewIssue { set; get; }
    }

    /// <summary>
    /// Класс, представляющий информацию о подготовленной к созданию задачи.
    /// </summary>
    public class NewIssue
    {
        [JsonProperty("project_id")]
        public long ProjectID { set; get; }
        [JsonProperty("tracker_id")]
        public int TrackerID { set; get; }
        [JsonProperty("status_id")]
        public int StatusID { set; get; }
        [JsonProperty("priority_id")]
        public int PriorityID { set; get; }
        [JsonProperty("subject")]
        public string Subject { set; get; }
        [JsonProperty("description")]
        public string Description { set; get; }
        [JsonProperty("assigned_to_id")]
        public long AssignedToID { set; get; }
        [JsonProperty("watcher_user_ids")]
        public List<long> WatcherUserIDs { set; get; }
        [JsonProperty("is_private")]
        public bool IsPrivate { set; get; }
        [JsonProperty("estimated_hours")]
        public int EstimatedHours { set; get; }
    }
}
