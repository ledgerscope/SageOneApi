using System.Text.Json.Serialization;

namespace SageOneApi.Client.Models.Core
{
    public class Me
    {
		[JsonPropertyName("business")]
        public Business Business { get; set; }
        [JsonPropertyName("user")]
		public User User { get; set; }
    }
}
