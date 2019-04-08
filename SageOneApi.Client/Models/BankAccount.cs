using Newtonsoft.Json;

namespace SageOneApi.Client.Models
{
    public class BankAccount : SageOneAccountingEntity
    {
		[JsonProperty("bank_account_details")]
        public BankAccountDetails BankAccountDetails { get; set; }
        [JsonProperty("ledger_account")]
		public LedgerAccount LedgerAccount { get; set; }
		[JsonProperty("bank_account_type")]
		public PropertyValueWithPath BankAccountType { get; set; }
		[JsonProperty("balance")]
		public decimal Balance { get; set; }
		[JsonProperty("main_address")]
		public Address MainAddress { get; set; }
		[JsonProperty("main_contact_person")]
		public ContactPerson MainContactPerson { get; set; }
		[JsonProperty("nominal_code")]
		public string NominalCode { get; set; }
		[JsonProperty("editable")]
		public bool Editable { get; set; }
		[JsonProperty("deletable")]
		public bool Deletable { get; set; }
		[JsonProperty("journal_code")]
		public string JournalCode { get; set; }
		[JsonProperty("default_payment_method")]
		public PropertyValueWithPath DefaultPaymentMethod { get; set; }
    }
}
