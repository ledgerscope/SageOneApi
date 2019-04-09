using Newtonsoft.Json;

namespace SageOneApi.Client.Models
{
    public class JournalLine
    {
		[JsonProperty("ledger_account")]
        public LedgerAccount LedgerAccount { get; set; }
        [JsonProperty("details")]
		public string Details { get; set; }
		[JsonProperty("debit")]
		public decimal Debit { get; set; }
		[JsonProperty("credit")]
		public decimal Credit { get; set; }
		[JsonProperty("include_on_tax_return")]
		public bool IncludeOnTaxReturn { get; set; }
    }
}
