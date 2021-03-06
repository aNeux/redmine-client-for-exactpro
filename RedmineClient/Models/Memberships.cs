﻿using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace RedmineClient.Models
{
    /// <summary>
    /// Класс для парсера, представляющий информацию о значении пользователей в определенном проекте и некоторые другие данные.
    /// </summary>
    public class MembershipsJSONObject
    {
        [JsonProperty("memberships")]
        public List<Membership> Memberships { set; get; }
        [JsonProperty("total_count")]
        public int TotalCount { set; get; }
        [JsonProperty("offset")]
        public int Offset { set; get; }
        [JsonProperty("limit")]
        public int Limit { set; get; }
    }

    /// <summary>
    /// Класс, представляющий информацию о значении пользователя в определенном проекте.
    /// </summary>
    public class Membership
    {
        [JsonProperty("id")]
        public long ID { set; get; }
        [JsonProperty("project")]
        public Project Project { set; get; }
        [JsonProperty("user")]
        public User User { set; get; }
        [JsonProperty("roles")]
        public List<Role> Roles { set; get; }
    }

    /// <summary>
    /// Класс, представляющий информацию о роли пользователя в определенном проекте.
    /// </summary>
    public class Role
    {
        [JsonProperty("id")]
        public long ID { set; get; }
        [JsonProperty("name")]
        public string Name { set; get; }
    }
}
