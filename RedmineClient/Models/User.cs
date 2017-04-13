using System;
using Newtonsoft.Json;

namespace RedmineClient.Models
{
    /// <summary>
    /// Класс для парсера, представляющий информацию об определенном пользователе.
    /// </summary>
    public class UserJSONObject
    {
        [JsonProperty("user")]
        public User User { set; get; }
    }

    /// <summary>
    /// Класс, представляющий информацию об определенном пользователе.
    /// </summary>
    public class User
    {
        [JsonProperty("id")]
        public long ID { set; get; }
        [JsonProperty("login")]
        public string Login { set; get; }
        [JsonProperty("firstname")]
        public string FirstName { set; get; }
        [JsonProperty("lastname")]
        public string LastName { set; get; }
        [JsonProperty("mail")]
        public string Email { set; get; }
        [JsonProperty("created_on")]
        public DateTime CreatedOn { set; get; }
        [JsonProperty("last_login_on")]
        public DateTime LastLoginOn { set; get; }
        [JsonProperty("api_key")]
        public string APIKey { set; get; }
    }
}
