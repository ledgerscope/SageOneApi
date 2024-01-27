using System.Text.Json.Serialization;
using System;

namespace SageOneApi.Client.Models
{
	public class PaymentOnAccount
	{
		[JsonPropertyName("id")]
		public string Id { get; set; }
		[JsonPropertyName("displayed_as")]
		public string DisplayedAs { get; set; }
		[JsonPropertyName("path")]
		public string Path { get; set; }
		[JsonPropertyName("contact_name")]
		public string ContactName { get; set; }
		[JsonPropertyName("contact_reference")]
		public string ContactReference { get; set; }
		[JsonPropertyName("contact")]
		public Contact Contact { get; set; }
		[JsonPropertyName("date")]
		public DateTime Date { get; set; }
		[JsonPropertyName("reference")]
		public string Reference { get; set; }
		[JsonPropertyName("net_amount")]
		[JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        public decimal NetAmount { get; set; }
		[JsonPropertyName("tax_amount")]
		[JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        public decimal? TaxAmount { get; set; }
		[JsonPropertyName("total_amount")]
		[JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        public decimal TotalAmount { get; set; }
		[JsonPropertyName("outstanding_amount")]
		[JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        public decimal OutstandingAmount { get; set; }
		[JsonPropertyName("currency")]
		public PropertyValueWithPath Currency { get; set; }
		[JsonPropertyName("exchange_rate")]
		[JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        public decimal ExchangeRate { get; set; }
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
        public decimal BaseCurrencyOutstandingAmount { get; set; }
		[JsonPropertyName("status")]
		public PropertyValueWithPath Status { get; set; }
	}
}
