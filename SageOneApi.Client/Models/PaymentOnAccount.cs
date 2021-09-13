using Newtonsoft.Json;
using System;

namespace SageOneApi.Client.Models
{
	public class PaymentOnAccount
	{
		[JsonProperty("id")]
		public string Id { get; set; }
		[JsonProperty("displayed_as")]
		public string DisplayedAs { get; set; }
		[JsonProperty("path")]
		public string Path { get; set; }
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
		[JsonProperty("net_amount")]
		public decimal NetAmount { get; set; }
		[JsonProperty("tax_amount")]
		public decimal? TaxAmount { get; set; }
		[JsonProperty("total_amount")]
		public decimal TotalAmount { get; set; }
		[JsonProperty("outstanding_amount")]
		public decimal OutstandingAmount { get; set; }
		[JsonProperty("currency")]
		public PropertyValueWithPath Currency { get; set; }
		[JsonProperty("exchange_rate")]
		public decimal ExchangeRate { get; set; }
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
	}
}
