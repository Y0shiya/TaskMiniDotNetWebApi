using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace TaskMiniBackend.Models
{
    public class Task
    {
        [JsonProperty("id")]
        public string Id { get; set; } = "";

        [JsonProperty("note")]
        public string Note { get; set; } = "";

        [JsonProperty("order")]
        public Int64 Order { get; set; } = 0;
    }
}