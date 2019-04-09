using Newtonsoft.Json;

namespace SageOneApi.Client.Models
{
    public class TaxAnalysis
    {
	    [JsonProperty("tax_rate")]
		public TaxRate TaxRate { get; set; }
		[JsonProperty("net_amount")]
		public decimal NetAmount { get; set; }
		[JsonProperty("tax_amount")]
		public decimal TaxAmount { get; set; }
		[JsonProperty("total_amount")]
		public decimal TotalAmount { get; set; }
		[JsonProperty("goods_amount")]
		public decimal GoodsAmount { get; set; }
		[JsonProperty("service_amount")]
		public decimal ServiceAmount { get; set; }
    }
}
