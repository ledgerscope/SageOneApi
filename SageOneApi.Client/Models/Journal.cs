using System;
using System.Collections.Generic;

namespace SageOneApi.Client.Models
{
    public class Journal : SageOneAccountingEntity
    {
        public PropertyValueWithPath transaction { get; set; }
        public PropertyValueWithPath transaction_type { get; set; }
        public DateTime date { get; set; }
        public string reference { get; set; }
        public string description { get; set; }
        public decimal total { get; set; }
        public string journal_code { get; set; }
        public List<JournalLine> journal_lines { get; set; }
    }
}
