using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace SageOneApi.Client.Models
{
    public abstract class ControlTransaction : SageOneAccountingEntity
    {
		[JsonProperty("transaction")]
        public PropertyValueWithPath Transaction { get; set; }
        [JsonProperty("transaction_type")]
		public PropertyValueWithPath TransactionType { get; set; }
		[JsonProperty("links")]
		public List<Link> Links { get; set; }
		[JsonProperty("contact_name")]
		public string ContactName { get; set; }
		[JsonProperty("contact_reference")]
		public string ContactReference { get; set; }
		[JsonProperty("contact")]
		public Contact Contact { get; set; }
		[JsonProperty("date")]
		public DateTime Date { get; set; }
		[JsonProperty("reference")]
		public string Reference { get; set; }
		[JsonProperty("notes")]
		public string Notes { get; set; }
		[JsonProperty("total_quantity")]
		public double? TotalQuantity { get; set; }
		[JsonProperty("net_amount")]
		public decimal? NetAmount { get; set; }
		[JsonProperty("tax_amount")]
		public decimal? TaxAmount { get; set; }
		[JsonProperty("total_amount")]
		public decimal TotalAmount { get; set; }
		[JsonProperty("payments_allocations_total_amount")]
		public decimal? PaymentsAllocationsTotalAmount { get; set; }
		[JsonProperty("payments_allocations_total_discount")]
		public decimal? PaymentsAllocationsTotalDiscount { get; set; }
		[JsonProperty("total_paid")]
		public decimal? TotalPaid { get; set; }
		[JsonProperty("outstanding_amount")]
		public decimal OutstandingAmount { get; set; }
		[JsonProperty("currency")]
		public PropertyValueWithPath Currency { get; set; }
		[JsonProperty("exchange_rate")]
		public decimal ExchangeRate { get; set; }
		[JsonProperty("inverse_exchange_rate")]
		public decimal InverseExchangeRate { get; set; }
		[JsonProperty("base_currency_net_amount")]
		public decimal BaseCurrencyNetAmount { get; set; }
		[JsonProperty("base_currency_tax_amount")]
		public decimal BaseCurrencyTaxAmount { get; set; }
		[JsonProperty("base_currency_total_amount")]
		public decimal BaseCurrencyTotalAmount { get; set; }
		[JsonProperty("base_currency_outstanding_amount")]
		public decimal BaseCurrencyOutstandingAmount { get; set; }
		[JsonProperty("status")]
		public PropertyValueWithPath Status { get; set; }
		[JsonProperty("void_reason")]
		public string VoidReason { get; set; }
		[JsonProperty("tax_analysis")]
		public List<TaxAnalysis> TaxAnalysis { get; set; }
		[JsonProperty("last_paid")]
		public string LastPaid { get; set; }
		[JsonProperty("tax_address_region")]
		public object TaxAddressRegion { get; set; }
		[JsonProperty("tax_reconciled")]
		public bool TaxReconciled { get; set; }
		[JsonProperty("migrated")]
		public bool Migrated { get; set; }
		[JsonProperty("tax_calculation_method")]
		public string TaxCalculationMethod { get; set; }
    }
}
