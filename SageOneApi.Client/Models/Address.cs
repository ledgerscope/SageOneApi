using System.Text.Json.Serialization;

namespace SageOneApi.Client.Models
{
	public class Address
	{
		[JsonPropertyName("$path")]
		public string Path { get; set; }
		[JsonPropertyName("address_type")]
		public PropertyValueWithPath AddressType { get; set; }
		[JsonPropertyName("address_line_1")]
		public string AddressLine1 { get; set; }
		[JsonPropertyName("address_line_2")]
		public string AddressLine2 { get; set; }
		[JsonPropertyName("city")]
		public string City { get; set; }
		[JsonPropertyName("region")]
		public string Region { get; set; }
		[JsonPropertyName("postal_code")]
		public string PostalCode { get; set; }
		[JsonPropertyName("country")]
		public PropertyValueWithPath Country { get; set; }
		[JsonPropertyName("country_group")]
		public PropertyValueWithPath CountryGroup { get; set; }
	}
}
