using System.Text.Json.Serialization;

namespace SageOneApi.Client.Models
{
	public class Tax
	{
		[JsonPropertyName("tax_rate")]
		public TaxRate TaxRate { get; set; }
		[JsonPropertyName("percentage")]
		[JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        public decimal Percentage { get; set; }
		[JsonPropertyName("amount")]
		[JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        public decimal Amount { get; set; }
	}
}
