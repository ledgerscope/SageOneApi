using Newtonsoft.Json;

namespace SageOneApi.Client.Models
{
    public class PropertyValueWithPath : PropertyValue
    {
        [JsonProperty("$path")]
        public string path { get; set; }
    }
}
