using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace SageOneApi.Client.Models
{
    public class Journal
    {
        public string id { get; set; }
        public string displayed_as { get; set; }
        [JsonProperty("$path")]
        public string path { get; set; }
        public Transaction transaction { get; set; }
        public TransactionType transaction_type { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public string date { get; set; }
        public string reference { get; set; }
        public string description { get; set; }
        public string total { get; set; }
        public object journal_code { get; set; }
        public List<JournalLine> journal_lines { get; set; }
    }

    public class JournalLine
    {
        public LedgerAccount ledger_account { get; set; }
        public string details { get; set; }
        public string debit { get; set; }
        public string credit { get; set; }
        public bool include_on_tax_return { get; set; }
    }
}
