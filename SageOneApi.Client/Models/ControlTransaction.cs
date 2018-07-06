using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace SageOneApi.Client.Models
{
    public abstract class ControlTransaction : SageOneEntity
    {
        public PropertyValueWithPath transaction { get; set; }
        public PropertyValueWithPath transaction_type { get; set; }
        public List<Link> links { get; set; }
        public string contact_name { get; set; }
        public string contact_reference { get; set; }
        public Contact contact { get; set; }
        public DateTime date { get; set; }
        public string reference { get; set; }
        public string notes { get; set; }
        public double? total_quantity { get; set; }
        public decimal net_amount { get; set; }
        public decimal tax_amount { get; set; }
        public decimal total_amount { get; set; }
        public decimal? payments_allocations_total_amount { get; set; }
        public decimal? payments_allocations_total_discount { get; set; }
        public decimal? total_paid { get; set; }
        public decimal outstanding_amount { get; set; }
        public PropertyValueWithPath currency { get; set; }
        public decimal exchange_rate { get; set; }
        public decimal inverse_exchange_rate { get; set; }
        public decimal base_currency_net_amount { get; set; }
        public decimal base_currency_tax_amount { get; set; }
        public decimal base_currency_total_amount { get; set; }
        public decimal base_currency_outstanding_amount { get; set; }
        public PropertyValueWithPath status { get; set; }
        public string void_reason { get; set; }
        public List<TaxAnalysis> tax_analysis { get; set; }
        public string last_paid { get; set; }
        public object tax_address_region { get; set; }
        public bool tax_reconciled { get; set; }
        public bool migrated { get; set; }
        public string tax_calculation_method { get; set; }
    }
}
