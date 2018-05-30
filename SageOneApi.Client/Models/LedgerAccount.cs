using Newtonsoft.Json;
using System;

namespace SageOneApi.Client.Models
{
    public class LedgerAccount
    {
        public string id { get; set; }
        public string displayed_as { get; set; }
        [JsonProperty("$path")]
        public string path { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public PropertyValue ledger_account_group { get; set; }
        public string name { get; set; }
        public string display_name { get; set; }
        public bool included_in_chart { get; set; }
        public string nominal_code { get; set; }
        public PropertyValueWithPath ledger_account_type { get; set; }
        public string ledger_account_classification { get; set; }
        public TaxRate tax_rate { get; set; }
        public bool fixed_tax_rate { get; set; }
        public bool visible_in_banking { get; set; }
        public bool visible_in_expenses { get; set; }
        public bool visible_in_journals { get; set; }
        public bool visible_in_other_payments { get; set; }
        public bool visible_in_other_receipts { get; set; }
        public bool visible_in_reporting { get; set; }
        public bool visible_in_sales { get; set; }
        public bool is_control_account { get; set; }
        public string control_name { get; set; }
        public object balance_details { get; set; }
    }
}
