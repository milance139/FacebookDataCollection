using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FacebookDataCollection.Models.FacebookModels.PostModels
{
    public class PostsCollection
    {
        [JsonProperty("data")]
        public List<Post> Posts { get; set; }

        public Paging Paging { get; set; }
    }
}