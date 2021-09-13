using System.Collections.Generic;
using Newtonsoft.Json;

namespace SageOneApi.Client.Models
{
	public abstract class QuickEntry : ControlTransaction
	{
		[JsonProperty("quick_entry_type")]
		public PropertyValueWithPath QuickEntryType { get; set; }
		[JsonProperty("ledger_account")]
		public LedgerAccount LedgerAccount { get; set; }
		[JsonProperty("details")]
		public string Details { get; set; }
		[JsonProperty("tax_rate")]
		public TaxRate TaxRate { get; set; }
		[JsonProperty("tax_breakdown")]
		public List<Tax> TaxBreakdown { get; set; }
		[JsonProperty("base_currency_tax_breakdown")]
		public List<Tax> BaseCurrencyTaxBreakdown { get; set; }
		[JsonProperty("trade_of_asset")]
		public bool TradeOfAsset { get; set; }
	}
}
