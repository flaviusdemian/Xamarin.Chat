using System;
using Newtonsoft.Json;

namespace XamChat.Core.Models
{
    public class Friend
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("firstname")]
        public String FirstName { get; set; }

        [JsonProperty("lastname")]
        public String LastName { get; set; }

        [JsonProperty("phoneNumber")]
        public String PhoneNumber { get; set; }

        [JsonProperty("picture")]
        public String Picture { get; set; }

        public String FullName
        {
            get { return String.Format("{0} {1}", FirstName, LastName); }
        }
    }
}