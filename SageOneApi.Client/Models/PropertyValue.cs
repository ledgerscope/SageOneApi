using System.Text.Json.Serialization;

namespace SageOneApi.Client.Models
{
	public class PropertyValue
	{
		[JsonPropertyName("id")]
		public string Id { get; set; }
		[JsonPropertyName("displayed_as")]
		public string DisplayedAs { get; set; }
	}
}
