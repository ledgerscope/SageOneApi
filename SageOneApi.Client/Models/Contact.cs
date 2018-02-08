using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace SageOneApi.Client.Models
{
    public class Contact
    {
        public string id { get; set; }
        public string displayed_as { get; set; }
        [JsonProperty("$path")]
        public string path { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public List<Link> links { get; set; }
        public List<PropertyValueWithPath> contact_types { get; set; }
        public string name { get; set; }
        public string reference { get; set; }
        public PropertyValueWithPath default_sales_ledger_account { get; set; }
        public object default_sales_tax_rate { get; set; }
        public object tax_number { get; set; }
        public object notes { get; set; }
        public string locale { get; set; }
        public MainAddress main_address { get; set; }
        public object delivery_address { get; set; }
        public PropertyValueWithPath main_contact_person { get; set; }
        public BankAccountDetails bank_account_details { get; set; }
        public object credit_limit { get; set; }
        public object credit_days { get; set; }
        public object credit_terms_and_conditions { get; set; }
        public PropertyValueWithPath product_sales_price_type { get; set; }
        public object source_guid { get; set; }
        public PropertyValueWithPath currency { get; set; }
        public string aux_reference { get; set; }
        public object registered_number { get; set; }
        public bool deletable { get; set; }
        public TaxTreatment tax_treatment { get; set; }
    }
}
