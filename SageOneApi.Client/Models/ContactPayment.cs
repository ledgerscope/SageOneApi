using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace SageOneApi.Client.Models
{
    public class ContactPayment : PropertyValueWithPath
    {
        public PropertyValueWithPath transaction { get; set; }
        public PropertyValueWithPath transaction_type { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public List<Link> links { get; set; }
        public PropertyValueWithPath payment_method { get; set; }
        public Contact contact { get; set; }
        public BankAccount bank_account { get; set; }
        public DateTime date { get; set; }
        public decimal net_amount { get; set; }
        public decimal tax_amount { get; set; }
        public decimal total_amount { get; set; }
        public PropertyValueWithPath currency { get; set; }
        public decimal exchange_rate { get; set; }
        public decimal base_currency_net_amount { get; set; }
        public decimal base_currency_tax_amount { get; set; }
        public decimal base_currency_total_amount { get; set; }
        public decimal base_currency_currency_charge { get; set; }
        public string reference { get; set; }
        public List<AllocatedArtefact> allocated_artefacts { get; set; }
        public TaxRate tax_rate { get; set; }
        public PaymentOnAccount payment_on_account { get; set; }
    }
}
