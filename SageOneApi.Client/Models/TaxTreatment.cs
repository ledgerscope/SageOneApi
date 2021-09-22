using System.Text.Json.Serialization;

namespace SageOneApi.Client.Models
{
	public class TaxTreatment
	{
		[JsonPropertyName("home_tax")]
		public bool HomeTax { get; set; }
		[JsonPropertyName("eu_tax_registered")]
		public bool? EuTaxRegistered { get; set; }
		[JsonPropertyName("eu_not_tax_registered")]
		public bool? EuNotTaxRegistered { get; set; }
		[JsonPropertyName("rest_of_world_tax")]
		public bool RestOfWorldTax { get; set; }
	}
}
