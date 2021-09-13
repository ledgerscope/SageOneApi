using System.Collections.Generic;
using Newtonsoft.Json;

namespace SageOneApi.Client.Models
{
	public class PurchaseCreditNote : PurchaseTransaction
	{
		[JsonProperty("credit_note_lines")]
		public List<PurchaseTransactionLine> CreditNoteLines { get; set; }
	}
}
