using Newtonsoft.Json;
using FacebookDataCollection.Models.FacebookModels.PostModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FacebookDataCollection.Models.FacebookModels
{
    public class FacebookData
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }

        public string FullName { get { return FirstName + " " + LastName; } set { } }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("birthday")]
        public string Birthday { get; set; }

        [JsonProperty("hometown")]
        public Hometown Hometown { get; set; }

        [JsonProperty("posts")]
        public PostsCollection Posts { get; set; }
    }
}