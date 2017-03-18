using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace RedmineClient.Models
{
    public class Issues
    {
        [JsonProperty("issues")]
        public List<Issue> IssuesList { set; get; }
        [JsonProperty("total_count")]
        public int TotalCount { set; get; }
        [JsonProperty("offset")]
        public int Offset { set; get; }
        [JsonProperty("limit")]
        public int Limit { set; get; }
    }

    public class Issue
    {
        [JsonProperty("id")]
        public long ID { set; get; }
        [JsonProperty("project")]
        public Project Project { set; get; }
        [JsonProperty("tracker")]
        public Tracker Tracker { set; get; }
        [JsonProperty("status")]
        public Status Status { set; get; }
        [JsonProperty("priority")]
        public Priority Priority { set; get; }
        [JsonProperty("author")]
        public Author Author { set; get; }
        [JsonProperty("subject")]
        public string Subject { set; get; }
        [JsonProperty("description")]
        public string Description { set; get; }
        [JsonProperty("created_on")]
        public DateTime CreatedOn { set; get; }
        [JsonProperty("updated_on")]
        public DateTime UpdatedOn { set; get; }
    }

    public class Tracker
    {
        [JsonProperty("id")]
        public long ID { set; get; }
        [JsonProperty("name")]
        public string Name { set; get; }
    }

    public class Status
    {
        [JsonProperty("id")]
        public long ID { set; get; }
        [JsonProperty("name")]
        public string Name { set; get; }
    }

    public class Priority
    {
        [JsonProperty("id")]
        public long ID { set; get; }
        [JsonProperty("name")]
        public string Name { set; get; }
    }

    public class Author
    {
        [JsonProperty("id")]
        public long ID { set; get; }
        [JsonProperty("name")]
        public string Name { set; get; }
    }
}
