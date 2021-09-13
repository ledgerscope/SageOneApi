using System.Collections.Generic;
using Newtonsoft.Json;

namespace SageOneApi.Client.Models
{
	public class PaymentLine
	{
		[JsonProperty("id")]
		public string Id { get; set; }
		[JsonProperty("displayed_as")]
		public string DisplayedAs { get; set; }
		[JsonProperty("ledger_account")]
		public LedgerAccount LedgerAccount { get; set; }
		[JsonProperty("details")]
		public string Details { get; set; }
		[JsonProperty("tax_rate")]
		public TaxRate TaxRate { get; set; }
		[JsonProperty("net_amount")]
		public decimal NetAmount { get; set; }
		[JsonProperty("tax_amount")]
		public decimal? TaxAmount { get; set; }
		[JsonProperty("total_amount")]
		public decimal TotalAmount { get; set; }
		[JsonProperty("tax_breakdown")]
		public List<Tax> TaxBreakdown { get; set; }
		[JsonProperty("is_purchase_for_resale")]
		public bool IsPurchaseForResale { get; set; }
	}
}
