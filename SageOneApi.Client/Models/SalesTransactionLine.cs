using Newtonsoft.Json;

namespace SageOneApi.Client.Models
{
    public class SalesTransactionLine : ControlTransactionLine
    {
		[JsonProperty("discount_amount")]
        public decimal DiscountAmount { get; set; }
        [JsonProperty("base_currency_discount_amount")]
		public decimal BaseCurrencyDiscountAmount { get; set; }
		[JsonProperty("discount_percentage")]
		public decimal DiscountPercentage { get; set; }
		[JsonProperty("eu_sales_description")]
		public PropertyValueWithPath EuSalesDescription { get; set; }
    }
}
