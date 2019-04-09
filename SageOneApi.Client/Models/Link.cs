using Newtonsoft.Json;

namespace SageOneApi.Client.Models
{
    public class Link
    {
		[JsonProperty("href")]
        public string Href { get; set; }
        [JsonProperty("rel")]
		public string Rel { get; set; }
		[JsonProperty("type")]
		public string Type { get; set; }
    }
}
