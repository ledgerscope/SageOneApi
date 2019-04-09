using Newtonsoft.Json;

namespace SageOneApi.Client.Responses
{
    public class GetAllResponse<T>
    {
        [JsonProperty("$total")]
        public int Total { get; set; }

        [JsonProperty("$page")]
        public int Page { get; set; }

        [JsonProperty("$next")]
        public object Next { get; set; }

        [JsonProperty("$back")]
        public object Back { get; set; }

        [JsonProperty("$itemsPerPage")]
        public int ItemsPerPage { get; set; }

        [JsonProperty("$items")]
        public T[] Items { get; set; }
    }
}
