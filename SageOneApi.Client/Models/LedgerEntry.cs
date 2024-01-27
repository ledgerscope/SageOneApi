using System;
using System.Text.Json.Serialization;

namespace SageOneApi.Client.Models
{
	public class LedgerEntry : DatedTransaction
	{
		[JsonPropertyName("description")]
		public string Description { get; set; }
		[JsonPropertyName("debit")]
		[JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        public decimal Debit { get; set; }
		[JsonPropertyName("credit")]
		[JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        public decimal Credit { get; set; }
		[JsonPropertyName("tax_rate")]
		public TaxRate TaxRate { get; set; }
		[JsonPropertyName("ledger_account")]
		public LedgerAccount LedgerAccount { get; set; }
		[JsonPropertyName("contact")]
		public Contact Contact { get; set; }
		[JsonPropertyName("deleted")]
		public bool Deleted { get; set; }
	}
}
