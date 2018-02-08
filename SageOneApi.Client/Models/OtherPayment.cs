using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace SageOneApi.Client.Models
{
    public class OtherPayment
    {
        public string id { get; set; }
        public string displayed_as { get; set; }
        [JsonProperty("$path")]
        public string path { get; set; }
        public PropertyValueWithPath transaction { get; set; }
        public PropertyValueWithPath transaction_type { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public PropertyValueWithPath payment_method { get; set; }
        public Contact contact { get; set; }
        public PropertyValueWithPath bank_account { get; set; }
        public object tax_address_region { get; set; }
        public string date { get; set; }
        public string net_amount { get; set; }
        public string tax_amount { get; set; }
        public string total_amount { get; set; }
        public string reference { get; set; }
        public List<PaymentLine> payment_lines { get; set; }
        public bool editable { get; set; }
        public bool deletable { get; set; }
        public object withholding_tax_rate { get; set; }
        public object withholding_tax_amount { get; set; }
    }
}
