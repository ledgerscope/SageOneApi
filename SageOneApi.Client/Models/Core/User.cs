using Newtonsoft.Json;

namespace SageOneApi.Client.Models.Core
{
    public class User : SageOneCoreEntity
    {
	    [JsonProperty("first_name")]
		public string FirstName { get; set; }
		[JsonProperty("lasst_name")]
		public string LasstName { get; set; }
		[JsonProperty("initials")]
		public string Initials { get; set; }
		[JsonProperty("email")]
		public string Email { get; set; }
		[JsonProperty("locale")]
		public string Locale { get; set; }
    }
}
