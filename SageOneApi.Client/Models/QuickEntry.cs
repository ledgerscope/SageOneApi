using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SageOneApi.Client.Models
{
	public abstract class QuickEntry : ControlTransaction
	{
		[JsonPropertyName("quick_entry_type")]
		public PropertyValueWithPath QuickEntryType { get; set; }
		[JsonPropertyName("ledger_account")]
		public LedgerAccount LedgerAccount { get; set; }
		[JsonPropertyName("details")]
		public string Details { get; set; }
		[JsonPropertyName("tax_rate")]
		public TaxRate TaxRate { get; set; }
		[JsonPropertyName("tax_breakdown")]
		public List<Tax> TaxBreakdown { get; set; }
		[JsonPropertyName("base_currency_tax_breakdown")]
		public List<Tax> BaseCurrencyTaxBreakdown { get; set; }
		[JsonPropertyName("trade_of_asset")]
		public bool TradeOfAsset { get; set; }
	}
}
