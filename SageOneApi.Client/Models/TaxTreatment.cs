using Newtonsoft.Json;

namespace SageOneApi.Client.Models
{
	public class TaxTreatment
	{
		[JsonProperty("home_tax")]
		public bool HomeTax { get; set; }
		[JsonProperty("eu_tax_registered")]
		public bool? EuTaxRegistered { get; set; }
		[JsonProperty("eu_not_tax_registered")]
		public bool? EuNotTaxRegistered { get; set; }
		[JsonProperty("rest_of_world_tax")]
		public bool RestOfWorldTax { get; set; }
	}
}
