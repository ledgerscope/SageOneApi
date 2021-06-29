using Newtonsoft.Json;

namespace SageOneApi.Client.Models.Core
{
    public class Business : SageOneAccountingEntity
	{
		[JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("address_line_1")]
		public string AddressLine1 { get; set; }
		[JsonProperty("address_line_2")]
		public string AddressLine2 { get; set; }
		[JsonProperty("city")]
		public string City { get; set; }
		[JsonProperty("postal_code")]
		public string PostalCode { get; set; }
		[JsonProperty("country")]
		public PropertyValueWithPath Country { get; set; }
		[JsonProperty("region")]
		public string Region { get; set; }
		[JsonProperty("telephone")]
		public string Telephone { get; set; }
		[JsonProperty("mobile")]
		public string Mobile { get; set; }
		[JsonProperty("website")]
		public string Website { get; set; }
		[JsonProperty("is_demo")]
		public bool IsDemo { get; set; }
		[JsonProperty("subscriptions")]
		public Subscription[] Subscriptions { get; set; }
    }
}
