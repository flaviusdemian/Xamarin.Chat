using System;
using Newtonsoft.Json;

namespace XamChat.Core.Models
{
    public class Friend
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("firstname")]
        public string FirstName { get; set; }

        [JsonProperty("lastname")]
        public string LastName { get; set; }

        [JsonProperty("phoneNumber")]
        public string PhoneNumber { get; set; }

        [JsonProperty("picture")]
        public string Picture { get; set; }

        public string FullName
        {
            get { return String.Format("{0} {1}", FirstName, LastName); }
        }
    }
}