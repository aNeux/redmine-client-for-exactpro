﻿using System;
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
    /// Класс, представляющий информацию о задаче.
    /// </summary>
    public class Issue
    {
        [JsonProperty("id")]
        public long ID { set; get; }
        [JsonProperty("project")]
        public Project Project { set; get; }
        [JsonProperty("tracker")]
        public Tracker Tracker { set; get; }
        [JsonProperty("status")]
        public IssueStatus Status { set; get; }
        [JsonProperty("priority")]
        public Priority Priority { set; get; }
        [JsonProperty("author")]
        public Author Author { set; get; }
        [JsonProperty("subject")]
        public string Subject { set; get; }
        [JsonProperty("description")]
        public string Description { set; get; }
        [JsonProperty("start_date")]
        public DateTime StartDate { set; get; }
        [JsonProperty("done_ratio")]
        public int DoneRatio { set; get; }
        [JsonProperty("created_on")]
        public DateTime CreatedOn { set; get; }
        [JsonProperty("updated_on")]
        public DateTime UpdatedOn { set; get; }
    }

    /// <summary>
    /// Класс, представляющий информацию о приоритете задачи.
    /// </summary>
    public class Priority
    {
        [JsonProperty("id")]
        public long ID { set; get; }
        [JsonProperty("name")]
        public string Name { set; get; }
    }

    /// <summary>
    /// Класс, представляющий информацию об авторе задачи.
    /// </summary>
    public class Author
    {
        [JsonProperty("id")]
        public long ID { set; get; }
        [JsonProperty("name")]
        public string Name { set; get; }
    }
}
