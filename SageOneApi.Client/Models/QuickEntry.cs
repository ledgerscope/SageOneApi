using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace SageOneApi.Client.Models
{
    public class QuickEntry
    {
        public string id { get; set; }
        public string displayed_as { get; set; }
        [JsonProperty("$path")]
        public string path { get; set; }
        public PropertyValueWithPath transaction { get; set; }
        public PropertyValueWithPath transaction_type { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public PropertyValueWithPath quick_entry_type { get; set; }
        public string contact_name { get; set; }
        public object contact_reference { get; set; }
        public Contact contact { get; set; }
        public string date { get; set; }
        public string reference { get; set; }
        public LedgerAccount ledger_account { get; set; }
        public string details { get; set; }
        public string net_amount { get; set; }
        public TaxRate tax_rate { get; set; }
        public string tax_amount { get; set; }
        public List<object> tax_breakdown { get; set; }
        public string total_amount { get; set; }
        public string outstanding_amount { get; set; }
        public PropertyValueWithPath currency { get; set; }
        public string exchange_rate { get; set; }
        public string inverse_exchange_rate { get; set; }
        public string base_currency_net_amount { get; set; }
        public string base_currency_tax_amount { get; set; }
        public List<object> base_currency_tax_breakdown { get; set; }
        public string base_currency_total_amount { get; set; }
        public string base_currency_outstanding_amount { get; set; }
        public PropertyValueWithPath status { get; set; }
        public object tax_address_region { get; set; }
        public bool migrated { get; set; }
        public bool trade_of_asset { get; set; }
    }
}
