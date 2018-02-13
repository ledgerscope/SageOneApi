using Newtonsoft.Json;
using System;

namespace SageOneApi.Client.Models
{
    public class BankAccount
    {
        public string id { get; set; }
        public string displayed_as { get; set; }
        [JsonProperty("$path")]
        public string path { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public BankAccountDetails bank_account_details { get; set; }
        public LedgerAccount ledger_account { get; set; }
        public BankAccountType bank_account_type { get; set; }
        public string balance { get; set; }
        public MainAddress main_address { get; set; }
        public MainContactPerson main_contact_person { get; set; }
        public object nominal_code { get; set; }
        public bool editable { get; set; }
        public bool deletable { get; set; }
        public object journal_code { get; set; }
        public DefaultPaymentMethod default_payment_method { get; set; }
    }
}
