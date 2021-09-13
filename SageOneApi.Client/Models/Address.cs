using Newtonsoft.Json;

namespace SageOneApi.Client.Models
{
	public class Address
	{
		[JsonProperty("$path")]
		public string Path { get; set; }
		[JsonProperty("address_type")]
		public PropertyValueWithPath AddressType { get; set; }
		[JsonProperty("address_line_1")]
		public string AddressLine1 { get; set; }
		[JsonProperty("address_line_2")]
		public string AddressLine2 { get; set; }
		[JsonProperty("city")]
		public string City { get; set; }
		[JsonProperty("region")]
		public string Region { get; set; }
		[JsonProperty("postal_code")]
		public string PostalCode { get; set; }
		[JsonProperty("country")]
		public PropertyValueWithPath Country { get; set; }
		[JsonProperty("country_group")]
		public PropertyValueWithPath CountryGroup { get; set; }
	}
}
