using System.Text.Json.Serialization;

namespace SageOneApi.Client.Models
{
	public class TaxAnalysis
	{
		[JsonPropertyName("tax_rate")]
		public TaxRate TaxRate { get; set; }
		[JsonPropertyName("net_amount")]
		public decimal NetAmount { get; set; }
		[JsonPropertyName("tax_amount")]
		public decimal TaxAmount { get; set; }
		[JsonPropertyName("total_amount")]
		public decimal TotalAmount { get; set; }
		[JsonPropertyName("goods_amount")]
		public decimal GoodsAmount { get; set; }
		[JsonPropertyName("service_amount")]
		public decimal ServiceAmount { get; set; }
	}
}
