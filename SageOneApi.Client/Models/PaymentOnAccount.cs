﻿using Newtonsoft.Json;
using System;

namespace SageOneApi.Client.Models
{
    public class PaymentOnAccount
    {
        public string id { get; set; }
        public string displayed_as { get; set; }
        [JsonProperty("$path")]
        public string path { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public string contact_name { get; set; }
        public string contact_reference { get; set; }
        public Contact contact { get; set; }
        public string date { get; set; }
        public string reference { get; set; }
        public string net_amount { get; set; }
        public string tax_amount { get; set; }
        public string total_amount { get; set; }
        public string outstanding_amount { get; set; }
        public PropertyValueWithPath currency { get; set; }
        public string exchange_rate { get; set; }
        public string base_currency_net_amount { get; set; }
        public string base_currency_tax_amount { get; set; }
        public string base_currency_total_amount { get; set; }
        public string base_currency_outstanding_amount { get; set; }
        public PropertyValueWithPath status { get; set; }
    }
}
