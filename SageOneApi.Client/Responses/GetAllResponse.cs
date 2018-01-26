using Newtonsoft.Json;

namespace SageOneApi.Client.Responses
{
    public class GetAllResponse
    {
        [JsonProperty("$total")]
        public int total { get; set; }

        [JsonProperty("$page")]
        public int page { get; set; }

        [JsonProperty("$next")]
        public object next { get; set; }

        [JsonProperty("$back")]
        public object back { get; set; }

        [JsonProperty("$itemsPerPage")]
        public int itemsPerPage { get; set; }

        [JsonProperty("$items")]
        public Item[] items { get; set; }
    }

    public class Item
    {
        public string id { get; set; }
        public string displayed_as { get; set; }

        [JsonProperty("$path")]
        public string path { get; set; }
    }
}
