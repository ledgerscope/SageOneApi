using Newtonsoft.Json;
using System;

namespace SageOneApi.Client.Models
{
    public class PaymentOnAccount : PropertyValueWithPath
    {
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public string contact_name { get; set; }
        public string contact_reference { get; set; }
        public Contact contact { get; set; }
        public DateTime date { get; set; }
        public string reference { get; set; }
        public decimal net_amount { get; set; }
        public decimal tax_amount { get; set; }
        public decimal total_amount { get; set; }
        public decimal outstanding_amount { get; set; }
        public PropertyValueWithPath currency { get; set; }
        public decimal exchange_rate { get; set; }
        public decimal base_currency_net_amount { get; set; }
        public decimal base_currency_tax_amount { get; set; }
        public decimal base_currency_total_amount { get; set; }
        public decimal base_currency_outstanding_amount { get; set; }
        public PropertyValueWithPath status { get; set; }
    }
}
