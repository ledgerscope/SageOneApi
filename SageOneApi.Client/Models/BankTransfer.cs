using Newtonsoft.Json;
using System;

namespace SageOneApi.Client.Models
{
    public class BankTransfer : SageOneEntity
    {
        public PropertyValueWithPath transaction { get; set; }
        public PropertyValueWithPath transaction_type { get; set; }
        public BankAccount from_bank_account { get; set; }
        public BankAccount to_bank_account { get; set; }
        public DateTime date { get; set; }
        public string reference { get; set; }
        public decimal amount { get; set; }
        public string description { get; set; }
    }
}
