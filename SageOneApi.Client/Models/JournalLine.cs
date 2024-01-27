using System.Collections.Generic;
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
		[JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        public decimal Debit { get; set; }
		[JsonPropertyName("credit")]
		[JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        public decimal Credit { get; set; }
		[JsonPropertyName("include_on_tax_return")]
		public bool IncludeOnTaxReturn { get; set; }
        [JsonPropertyName("analysis_type_categories")]
        public List<PropertyValueWithPath> AnalysisTypeCategories { get; set; }
    }
}
