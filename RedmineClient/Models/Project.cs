using System;
using Newtonsoft.Json;

namespace RedmineClient.Models
{
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
        public long Status { set; get; }
        [JsonProperty("created_on")]
        public DateTime CreatedOn { set; get; }
    }
}
