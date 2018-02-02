using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace SageOneApi.Client.Models
{
    public class SalesCredit
    {
        public string id { get; set; }
        public string displayed_as { get; set; }
        [JsonProperty("$path")]
        public string path { get; set; }
        public Transaction transaction { get; set; }
        public TransactionType transaction_type { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public List<Link> links { get; set; }
        public string invoice_number { get; set; }
        public string contact_name { get; set; }
        public string contact_reference { get; set; }
        public Contact contact { get; set; }
        public string date { get; set; }
        public string due_date { get; set; }
        public string reference { get; set; }
        public string main_address_free_form { get; set; }
        public MainAddress main_address { get; set; }
        public string delivery_address_free_form { get; set; }
        public DeliveryAddress delivery_address { get; set; }
        public string notes { get; set; }
        public string terms_and_conditions { get; set; }
        public string shipping_net_amount { get; set; }
        public ShippingTaxRate shipping_tax_rate { get; set; }
        public string shipping_tax_amount { get; set; }
        public List<object> shipping_tax_breakdown { get; set; }
        public string shipping_total_amount { get; set; }
        public string net_amount { get; set; }
        public string tax_amount { get; set; }
        public string total_amount { get; set; }
        public string payments_allocations_total_amount { get; set; }
        public string payments_allocations_total_discount { get; set; }
        public string total_paid { get; set; }
        public string outstanding_amount { get; set; }
        public Currency currency { get; set; }
        public string exchange_rate { get; set; }
        public string inverse_exchange_rate { get; set; }
        public string base_currency_shipping_net_amount { get; set; }
        public string base_currency_shipping_tax_amount { get; set; }
        public List<object> base_currency_shipping_tax_breakdown { get; set; }
        public string base_currency_shipping_total_amount { get; set; }
        public string total_quantity { get; set; }
        public string total_discount_amount { get; set; }
        public string base_currency_total_discount_amount { get; set; }
        public string base_currency_net_amount { get; set; }
        public string base_currency_tax_amount { get; set; }
        public string base_currency_total_amount { get; set; }
        public string base_currency_outstanding_amount { get; set; }
        public Status status { get; set; }
        public bool sent { get; set; }
        public object void_reason { get; set; }
        public List<InvoiceLine> invoice_lines { get; set; }
        public List<TaxAnalysi> tax_analysis { get; set; }
        public string last_paid { get; set; }
        public object original_quote_estimate { get; set; }
        public object tax_address_region { get; set; }
        public object delivery_performance_date { get; set; }
        public object withholding_tax_rate { get; set; }
        public object withholding_tax_amount { get; set; }
        public object base_currency_withholding_tax_amount { get; set; }
        public bool tax_reconciled { get; set; }
        public bool migrated { get; set; }
        public object tax_calculation_method { get; set; }
    }
}
