using System;
using Newtonsoft.Json;

namespace SageOneApi.Client.Models
{
	public class LedgerEntry : DatedTransaction
	{
		[JsonProperty("description")]
		public string Description { get; set; }
		[JsonProperty("debit")]
		public decimal Debit { get; set; }
		[JsonProperty("credit")]
		public decimal Credit { get; set; }
		[JsonProperty("tax_rate")]
		public TaxRate TaxRate { get; set; }
		[JsonProperty("ledger_account")]
		public LedgerAccount LedgerAccount { get; set; }
		[JsonProperty("contact")]
		public Contact Contact { get; set; }
		[JsonProperty("deleted")]
		public bool Deleted { get; set; }
	}
}
