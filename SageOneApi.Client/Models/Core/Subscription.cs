using Newtonsoft.Json;

namespace SageOneApi.Client.Models.Core
{
    public class Subscription : SageOneCoreEntity
    {
		[JsonProperty("active")]
        public bool Active { get; set; }
    }
}
