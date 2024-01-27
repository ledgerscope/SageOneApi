using System.Text.Json.Serialization;

namespace SageOneApi.Client.Models
{
	public class TaxAnalysis
	{
		[JsonPropertyName("tax_rate")]
		public TaxRate TaxRate { get; set; }
		[JsonPropertyName("net_amount")]
		[JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        public decimal NetAmount { get; set; }
		[JsonPropertyName("tax_amount")]
		[JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        public decimal TaxAmount { get; set; }
		[JsonPropertyName("total_amount")]
		[JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        public decimal TotalAmount { get; set; }
		[JsonPropertyName("goods_amount")]
		[JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        public decimal GoodsAmount { get; set; }
		[JsonPropertyName("service_amount")]
		[JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        public decimal ServiceAmount { get; set; }
	}
}
