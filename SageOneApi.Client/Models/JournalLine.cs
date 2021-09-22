using System.Text.Json.Serialization;

namespace SageOneApi.Client.Models
{
	public class JournalLine
	{
		[JsonPropertyName("ledger_account")]
		public LedgerAccount LedgerAccount { get; set; }
		[JsonPropertyName("details")]
		public string Details { get; set; }
		[JsonPropertyName("debit")]
		public decimal Debit { get; set; }
		[JsonPropertyName("credit")]
		public decimal Credit { get; set; }
		[JsonPropertyName("include_on_tax_return")]
		public bool IncludeOnTaxReturn { get; set; }
	}
}
