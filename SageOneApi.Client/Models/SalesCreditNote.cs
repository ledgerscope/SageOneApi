using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;

namespace SageOneApi.Client.Models
{
	public class SalesCreditNote : SalesTransaction
	{
		[JsonPropertyName("credit_note_number")]
		public string CreditNoteNumber { get; set; }
		[JsonPropertyName("credit_note_lines")]
		public List<SalesTransactionLine> CreditNoteLines { get; set; }
	}
}
