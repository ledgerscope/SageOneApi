using Newtonsoft.Json;

namespace SageOneApi.Client.Models
{
    public class PropertyValue
    {
		[JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("displayed_as")]
		public string DisplayedAs { get; set; }
    }
}
