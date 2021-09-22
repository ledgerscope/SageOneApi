using System.Text.Json.Serialization;

namespace SageOneApi.Client.Models
{
	public class PropertyValueWithPath : PropertyValue
	{
		[JsonPropertyName("$path")]
		public string Path { get; set; }
	}
}
