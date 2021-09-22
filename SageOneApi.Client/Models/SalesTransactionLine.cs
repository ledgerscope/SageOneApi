using System.Text.Json.Serialization;

namespace SageOneApi.Client.Models
{
	public class SalesTransactionLine : ControlTransactionLine
	{
		[JsonPropertyName("discount_amount")]
		public decimal DiscountAmount { get; set; }
		[JsonPropertyName("base_currency_discount_amount")]
		public decimal BaseCurrencyDiscountAmount { get; set; }
		[JsonPropertyName("discount_percentage")]
		public decimal DiscountPercentage { get; set; }
		[JsonPropertyName("eu_sales_description")]
		public PropertyValueWithPath EuSalesDescription { get; set; }
	}
}
