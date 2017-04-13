using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace RedmineClient.Models
{
    /// <summary>
    /// Класс для парсера, представляющий информацию о проектах и некоторые другие данные.
    /// </summary>
    public class ProjectsJSONObject
    {
        [JsonProperty("projects")]
        public List<Project> Projects { set; get; }
        [JsonProperty("total_count")]
        public int TotalCount { set; get; }
        [JsonProperty("offset")]
        public int Offset { set; get; }
        [JsonProperty("limit")]
        public int Limit { set; get; }
    }

    /// <summary>
    /// Класс, представляющий информацию об определенном проекте.
    /// </summary>
    public class Project
    {
        [JsonProperty("id")]
        public long ID { set; get; }
        [JsonProperty("name")]
        public string Name { set; get; }
        [JsonProperty("identifier")]
        public string Identifier { set; get; }
        [JsonProperty("description")]
        public string Description { set; get; }
        [JsonProperty("status")]
        public int Status { set; get; }
        [JsonProperty("is_public")]
        public bool IsPublic { set; get; }
        [JsonProperty("created_on")]
        public DateTime CreatedOn { set; get; }
        [JsonProperty("updated_on")]
        public DateTime UpdatedOn { set; get; }
        public List<Membership> Memberships { set; get; }
    }
}
