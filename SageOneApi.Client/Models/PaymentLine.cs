using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SageOneApi.Client.Models
{
	public class PaymentLine
	{
		[JsonPropertyName("id")]
		public string Id { get; set; }
		[JsonPropertyName("displayed_as")]
		public string DisplayedAs { get; set; }
		[JsonPropertyName("ledger_account")]
		public LedgerAccount LedgerAccount { get; set; }
		[JsonPropertyName("details")]
		public string Details { get; set; }
		[JsonPropertyName("tax_rate")]
		public TaxRate TaxRate { get; set; }
		[JsonPropertyName("net_amount")]
		[JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        public decimal NetAmount { get; set; }
		[JsonPropertyName("tax_amount")]
		[JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        public decimal? TaxAmount { get; set; }
		[JsonPropertyName("total_amount")]
		[JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        public decimal TotalAmount { get; set; }
		[JsonPropertyName("tax_breakdown")]
		public List<Tax> TaxBreakdown { get; set; }
		[JsonPropertyName("is_purchase_for_resale")]
		public bool IsPurchaseForResale { get; set; }
        [JsonPropertyName("analysis_type_categories")]
        public List<PropertyValueWithPath> AnalysisTypeCategories { get; set; }
    }
}
