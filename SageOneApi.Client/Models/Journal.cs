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
        public PropertyValueWithPath transaction { get; set; }
        public PropertyValueWithPath transaction_type { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public DateTime date { get; set; }
        public string reference { get; set; }
        public string description { get; set; }
        public decimal total { get; set; }
        public string journal_code { get; set; }
        public List<JournalLine> journal_lines { get; set; }
    }
}
