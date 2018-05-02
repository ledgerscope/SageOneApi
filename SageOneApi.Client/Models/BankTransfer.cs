using Newtonsoft.Json;
using System;

namespace SageOneApi.Client.Models
{
    public class BankTransfer
    {
        public string id { get; set; }
        public string displayed_as { get; set; }
        [JsonProperty("$path")]
        public string path { get; set; }
        public PropertyValueWithPath transaction { get; set; }
        public PropertyValueWithPath transaction_type { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public BankAccount from_bank_account { get; set; }
        public BankAccount to_bank_account { get; set; }
        public DateTime date { get; set; }
        public string reference { get; set; }
        public decimal amount { get; set; }
        public string description { get; set; }
    }
}
