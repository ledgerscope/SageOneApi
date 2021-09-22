using System.Text.Json.Serialization;

namespace SageOneApi.Client.Models.Core
{
	public class User : SageOneCoreEntity
	{
		[JsonPropertyName("first_name")]
		public string FirstName { get; set; }
		[JsonPropertyName("last_name")]
		public string LastName { get; set; }
		[JsonPropertyName("initials")]
		public string Initials { get; set; }
		[JsonPropertyName("email")]
		public string Email { get; set; }
		[JsonPropertyName("locale")]
		public string Locale { get; set; }
	}
}
