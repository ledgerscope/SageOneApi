using Newtonsoft.Json;

namespace SageOneApi.Client.Models
{
    public class DefaultPaymentMethod
    {
        public string id { get; set; }
        public string displayed_as { get; set; }
        [JsonProperty("$path")]
        public string path { get; set; }
    }
}
