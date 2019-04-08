using Newtonsoft.Json;

namespace SageOneApi.Client.Models.Core
{
    public class Me
    {
		[JsonProperty("business")]
        public Business Business { get; set; }
        [JsonProperty("user")]
		public User User { get; set; }
    }
}
