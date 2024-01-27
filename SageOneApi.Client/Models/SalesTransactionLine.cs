using System.Text.Json.Serialization;

namespace SageOneApi.Client.Models
{
	public class SalesTransactionLine : ControlTransactionLine
	{
		[JsonPropertyName("discount_amount")]
		[JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        public decimal DiscountAmount { get; set; }
		[JsonPropertyName("base_currency_discount_amount")]
		[JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        public decimal BaseCurrencyDiscountAmount { get; set; }
		[JsonPropertyName("discount_percentage")]
		[JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        public decimal DiscountPercentage { get; set; }
		[JsonPropertyName("eu_sales_description")]
		public PropertyValueWithPath EuSalesDescription { get; set; }
	}
}
