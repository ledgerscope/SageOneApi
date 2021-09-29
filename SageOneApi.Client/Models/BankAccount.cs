using System.Text.Json.Serialization;

namespace SageOneApi.Client.Models
{
	public class BankAccount : SageOneAccountingEntity
	{
		[JsonPropertyName("bank_account_details")]
		public BankAccountDetails BankAccountDetails { get; set; }
		[JsonPropertyName("ledger_account")]
		public LedgerAccount LedgerAccount { get; set; }
		[JsonPropertyName("bank_account_type")]
		public PropertyValueWithPath BankAccountType { get; set; }
		[JsonPropertyName("balance")]
		public decimal? Balance { get; set; }
		[JsonPropertyName("main_address")]
		public Address MainAddress { get; set; }
		[JsonPropertyName("main_contact_person")]
		public ContactPerson MainContactPerson { get; set; }
		[JsonPropertyName("nominal_code")]
		public int? NominalCode { get; set; }
		[JsonPropertyName("editable")]
		public bool Editable { get; set; }
		[JsonPropertyName("deletable")]
		public bool Deletable { get; set; }
		[JsonPropertyName("journal_code")]
		public string JournalCode { get; set; }
		[JsonPropertyName("default_payment_method")]
		public PropertyValueWithPath DefaultPaymentMethod { get; set; }
	}
}
