using Newtonsoft.Json;

namespace SageOneApi.Client.Models
{
    public class Address
    {
        [JsonProperty("$path")]
        public string path { get; set; }
        public PropertyValueWithPath address_type { get; set; }
        public string address_line_1 { get; set; }
        public string address_line_2 { get; set; }
        public string city { get; set; }
        public string region { get; set; }
        public string postal_code { get; set; }
        public PropertyValueWithPath country { get; set; }
        public PropertyValueWithPath country_group { get; set; }
    }
}
