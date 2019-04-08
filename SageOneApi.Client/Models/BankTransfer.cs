using Newtonsoft.Json;
using System;

namespace SageOneApi.Client.Models
{
    public class BankTransfer : SageOneAccountingEntity
    {
		[JsonProperty("transaction")]
        public PropertyValueWithPath Transaction { get; set; }
        [JsonProperty("transaction_type")]
		public PropertyValueWithPath TransactionType { get; set; }
		[JsonProperty("from_bank_account")]
		public BankAccount FromBankAccount { get; set; }
		[JsonProperty("to_bank_account")]
		public BankAccount ToBankAccount { get; set; }
		[JsonProperty("date")]
		public DateTime Date { get; set; }
		[JsonProperty("reference")]
		public string Reference { get; set; }
		[JsonProperty("amount")]
		public decimal Amount { get; set; }
		[JsonProperty("description")]
		public string Description { get; set; }
    }
}
