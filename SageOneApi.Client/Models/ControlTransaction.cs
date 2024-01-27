using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;

namespace SageOneApi.Client.Models
{
	public abstract class ControlTransaction : DatedTransaction
	{
		[JsonPropertyName("links")]
		public List<Link> Links { get; set; }
		[JsonPropertyName("contact_name")]
		public string ContactName { get; set; }
		[JsonPropertyName("contact_reference")]
		public string ContactReference { get; set; }
		[JsonPropertyName("contact")]
		public Contact Contact { get; set; }
		[JsonPropertyName("reference")]
		public string Reference { get; set; }
		[JsonPropertyName("notes")]
		public string Notes { get; set; }
		[JsonPropertyName("total_quantity")]
		[JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        public decimal? TotalQuantity { get; set; }
		[JsonPropertyName("net_amount")]
		[JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        public decimal? NetAmount { get; set; }
		[JsonPropertyName("tax_amount")]
		[JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        public decimal? TaxAmount { get; set; }
		[JsonPropertyName("total_amount")]
		[JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        public decimal? TotalAmount { get; set; }
		[JsonPropertyName("payments_allocations_total_amount")]
		[JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        public decimal? PaymentsAllocationsTotalAmount { get; set; }
		[JsonPropertyName("payments_allocations_total_discount")]
		[JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        public decimal? PaymentsAllocationsTotalDiscount { get; set; }
		[JsonPropertyName("total_paid")]
		[JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        public decimal? TotalPaid { get; set; }
		[JsonPropertyName("outstanding_amount")]
		[JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        public decimal? OutstandingAmount { get; set; }
		[JsonPropertyName("currency")]
		public PropertyValueWithPath Currency { get; set; }
		[JsonPropertyName("exchange_rate")]
		[JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        public decimal ExchangeRate { get; set; }
		[JsonPropertyName("inverse_exchange_rate")]
		[JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        public decimal InverseExchangeRate { get; set; }
		[JsonPropertyName("base_currency_net_amount")]
		[JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        public decimal BaseCurrencyNetAmount { get; set; }
		[JsonPropertyName("base_currency_tax_amount")]
		[JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        public decimal BaseCurrencyTaxAmount { get; set; }
		[JsonPropertyName("base_currency_total_amount")]
		[JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        public decimal BaseCurrencyTotalAmount { get; set; }
		[JsonPropertyName("base_currency_outstanding_amount")]
		[JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        public decimal? BaseCurrencyOutstandingAmount { get; set; }
		[JsonPropertyName("status")]
		public PropertyValueWithPath Status { get; set; }
		[JsonPropertyName("void_reason")]
		public string VoidReason { get; set; }
		[JsonPropertyName("tax_analysis")]
		public List<TaxAnalysis> TaxAnalysis { get; set; }
		[JsonPropertyName("last_paid")]
		public string LastPaid { get; set; }
		[JsonPropertyName("tax_address_region")]
		public PropertyValueWithPath TaxAddressRegion { get; set; }
		[JsonPropertyName("tax_reconciled")]
		public bool TaxReconciled { get; set; }
		[JsonPropertyName("migrated")]
		public bool Migrated { get; set; }
		[JsonPropertyName("tax_calculation_method")]
		public string TaxCalculationMethod { get; set; }
	}
}
