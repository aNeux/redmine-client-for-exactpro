using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace RedmineClient.Models
{
    /// <summary>
    /// Класс для парсера, представляющий информацию о всех возможных трекерах.
    /// </summary>
    public class TrackersJSONObject
    {
        [JsonProperty("trackers")]
        public List<Tracker> Trackers { set; get; }
    }

    /// <summary>
    /// Класс, представляющий информацию о типе задачи.
    /// </summary>
    public class Tracker
    {
        [JsonProperty("id")]
        public int ID { set; get; }
        [JsonProperty("name")]
        public string Name { set; get; }
        [JsonProperty("default_status")]
        public DefaultStatus DefaultStatus { set; get; }
    }

    /// <summary>
    /// Класс, представляющий информацию о статусе по умолчанию для определенного трекера.
    /// </summary>
    public class DefaultStatus
    {
        [JsonProperty("id")]
        public long ID { set; get; }
        [JsonProperty("name")]
        public string Name { set; get; }
    }
}
