namespace SageOneApi.Client.Models
{
    public class BankAccount : SageOneAccountingEntity
    {
        public BankAccountDetails bank_account_details { get; set; }
        public LedgerAccount ledger_account { get; set; }
        public PropertyValueWithPath bank_account_type { get; set; }
        public decimal balance { get; set; }
        public MainAddress main_address { get; set; }
        public PropertyValueWithPath main_contact_person { get; set; }
        public string nominal_code { get; set; }
        public bool editable { get; set; }
        public bool deletable { get; set; }
        public string journal_code { get; set; }
        public PropertyValueWithPath default_payment_method { get; set; }
    }
}
