using System.Text.Json.Serialization;

namespace SageOneApi.Client.Models
{
	public class Tax
	{
		[JsonPropertyName("tax_rate")]
		public TaxRate TaxRate { get; set; }
		[JsonPropertyName("percentage")]
		public decimal Percentage { get; set; }
		[JsonPropertyName("amount")]
		public decimal Amount { get; set; }
	}
}
