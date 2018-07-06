using Newtonsoft.Json;
using System;

namespace SageOneApi.Client.Models
{
    public abstract class SageOneEntity
    {
        [JsonProperty("$path")]
        public string path { get; set; }
        public string id { get; set; }
        public string displayed_as { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }
}
