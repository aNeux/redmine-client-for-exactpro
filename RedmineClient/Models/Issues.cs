using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace RedmineClient.Models
{
    /// <summary>
    /// Класс для парсера, представляющий информацию о задачах и некоторые другие данные.
    /// </summary>
    public class IssuesJSONObject
    {
        [JsonProperty("issues")]
        public List<Issue> Issues { set; get; }
        [JsonProperty("total_count")]
        public int TotalCount { set; get; }
        [JsonProperty("offset")]
        public int Offset { set; get; }
        [JsonProperty("limit")]
        public int Limit { set; get; }
    }

    /// <summary>
    /// Класс для парсера, представляющий информацию об одной определенной задаче.
    /// </summary>
    public class IssueJSONObject
    {
        [JsonProperty("issue")]
        public Issue Issue { set; get; }
    }

    /// <summary>
    /// Класс, представляющий информацию о задаче.
    /// </summary>
    public class Issue
    {
        [JsonProperty("id")]
        public long ID { set; get; }
        [JsonProperty("project")]
        public Project Project { set; get; }
        [JsonProperty("tracker")]
        public IssueTracker Tracker { set; get; }
        [JsonProperty("status")]
        public IssueStatus Status { set; get; }
        [JsonProperty("priority")]
        public IssuePriority Priority { set; get; }
        [JsonProperty("assigned_to")]
        public User AssignedTo { set; get; }
        [JsonProperty("author")]
        public User Author { set; get; }
        [JsonProperty("subject")]
        public string Subject { set; get; }
        [JsonProperty("description")]
        public string Description { set; get; }
        [JsonProperty("is_private")]
        public bool IsPrivate { set; get; }
        [JsonProperty("start_date")]
        public DateTime StartDate { set; get; }
        [JsonProperty("due_date")]
        public DateTime DueDate { set; get; }
        [JsonProperty("estimated_hours")]
        public double EstimatedHours { set; get; }
        [JsonProperty("done_ratio")]
        public int DoneRatio { set; get; }
        [JsonProperty("created_on")]
        public DateTime CreatedOn { set; get; }
        [JsonProperty("updated_on")]
        public DateTime UpdatedOn { set; get; }
        [JsonProperty("closed_on")]
        public DateTime ClosedOn { set; get; }
        [JsonProperty("journals")]
        public List<Journal> Journals { set; get; }
    }

    /// <summary>
    /// Класс, представляющий один элемент истории изменения задачи.
    /// </summary>
    public class Journal
    {
        [JsonProperty("id")]
        public long ID { set; get; }
        [JsonProperty("user")]
        public User User { set; get; }
        [JsonProperty("notes")]
        public string Note { set; get; }
        [JsonProperty("created_on")]
        public DateTime CreatedOn { set; get; }
        [JsonProperty("details")]
        public List<JournalDetail> Details { set; get; }
    }

    /// <summary>
    /// Класс, представляющий один элемент из деталей истории изменения задачи.
    /// </summary>
    public class JournalDetail
    {
        [JsonProperty("property")]
        public string Property { set; get; }
        [JsonProperty("name")]
        public string Name { set; get; }
        [JsonProperty("old_value")]
        public string OldValue { set; get; }
        [JsonProperty("new_value")]
        public string NewValue { set; get; }
    }
}
