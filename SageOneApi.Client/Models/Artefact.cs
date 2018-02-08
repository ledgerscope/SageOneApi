using Newtonsoft.Json;
using System.Collections.Generic;

namespace SageOneApi.Client.Models
{
    public class Artefact
    {
        public string id { get; set; }
        public string displayed_as { get; set; }
        [JsonProperty("$path")]
        public string path { get; set; }
        public List<Link> links { get; set; }
    }
}
