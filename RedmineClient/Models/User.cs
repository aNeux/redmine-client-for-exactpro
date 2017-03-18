using System;
using System.Collections.Generic;
using Newtonsoft.Json;


namespace RedmineClient.Models
{
    
    public class UserObj
    {
        [JsonProperty("user")]
        public User User { set; get; }
    }

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
    }
}
