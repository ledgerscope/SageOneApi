using Newtonsoft.Json;

namespace SageOneApi.Client.Models
{
	public class Tax
	{
		[JsonProperty("tax_rate")]
		public TaxRate TaxRate { get; set; }
		[JsonProperty("percentage")]
		public decimal Percentage { get; set; }
		[JsonProperty("amount")]
		public decimal Amount { get; set; }
	}
}
