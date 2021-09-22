using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SageOneApi.Client.Models
{
	public class PurchaseCreditNote : PurchaseTransaction
	{
		[JsonPropertyName("credit_note_lines")]
		public List<PurchaseTransactionLine> CreditNoteLines { get; set; }
	}
}
