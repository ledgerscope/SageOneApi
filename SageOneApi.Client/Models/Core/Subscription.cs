using System.Text.Json.Serialization;

namespace SageOneApi.Client.Models.Core
{
    public class Subscription : SageOneCoreEntity
    {
		[JsonPropertyName("active")]
        public bool Active { get; set; }
    }
}
