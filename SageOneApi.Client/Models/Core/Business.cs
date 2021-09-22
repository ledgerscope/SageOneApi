using System.Text.Json.Serialization;

namespace SageOneApi.Client.Models.Core
{
	public class Business : SageOneAccountingEntity
	{
		[JsonPropertyName("name")]
		public string Name { get; set; }
		[JsonPropertyName("address_line_1")]
		public string AddressLine1 { get; set; }
		[JsonPropertyName("address_line_2")]
		public string AddressLine2 { get; set; }
		[JsonPropertyName("city")]
		public string City { get; set; }
		[JsonPropertyName("postal_code")]
		public string PostalCode { get; set; }
		[JsonPropertyName("country")]
		public PropertyValueWithPath Country { get; set; }
		[JsonPropertyName("region")]
		public string Region { get; set; }
		[JsonPropertyName("telephone")]
		public string Telephone { get; set; }
		[JsonPropertyName("mobile")]
		public string Mobile { get; set; }
		[JsonPropertyName("website")]
		public string Website { get; set; }
		[JsonPropertyName("is_demo")]
		public bool IsDemo { get; set; }
		[JsonPropertyName("subscriptions")]
		public Subscription[] Subscriptions { get; set; }
	}
}
