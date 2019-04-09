using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace SageOneApi.Client.Models
{
    public class SalesCreditNote : SalesTransaction
    {
		[JsonProperty("credit_note_number")]
        public string CreditNoteNumber { get; set; }
        [JsonProperty("credit_note_lines")]
		public List<SalesTransactionLine> CreditNoteLines { get; set; }
    }
}
