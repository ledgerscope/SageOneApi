using System.Text.Json.Serialization;
using System;

namespace SageOneApi.Client.Models
{
	public class BankTransfer : DatedTransaction
	{
		[JsonPropertyName("from_bank_account")]
		public BankAccount FromBankAccount { get; set; }
		[JsonPropertyName("to_bank_account")]
		public BankAccount ToBankAccount { get; set; }
		[JsonPropertyName("reference")]
		public string Reference { get; set; }
		[JsonPropertyName("amount")]
		[JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        public decimal Amount { get; set; }
		[JsonPropertyName("description")]
		public string Description { get; set; }
	}
}
