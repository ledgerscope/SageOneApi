using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SageOneApi.Client.Models
{
	public class ContactPayment : DatedTransaction
	{
		[JsonPropertyName("links")]
		public List<Link> Links { get; set; }
		[JsonPropertyName("payment_method")]
		public PropertyValueWithPath PaymentMethod { get; set; }
		[JsonPropertyName("contact")]
		public Contact Contact { get; set; }
		[JsonPropertyName("bank_account")]
		public BankAccount BankAccount { get; set; }
		[JsonPropertyName("net_amount")]
		public decimal NetAmount { get; set; }
		[JsonPropertyName("tax_amount")]
		public decimal? TaxAmount { get; set; }
		[JsonPropertyName("total_amount")]
		public decimal TotalAmount { get; set; }
		[JsonPropertyName("currency")]
		public PropertyValueWithPath Currency { get; set; }
		[JsonPropertyName("exchange_rate")]
		public decimal ExchangeRate { get; set; }
		[JsonPropertyName("base_currency_net_amount")]
		public decimal BaseCurrencyNetAmount { get; set; }
		[JsonPropertyName("base_currency_tax_amount")]
		public decimal BaseCurrencyTaxAmount { get; set; }
		[JsonPropertyName("base_currency_total_amount")]
		public decimal BaseCurrencyTotalAmount { get; set; }
		[JsonPropertyName("base_currency_currency_charge")]
		public decimal BaseCurrencyCurrencyCharge { get; set; }
		[JsonPropertyName("reference")]
		public string Reference { get; set; }
		[JsonPropertyName("allocated_artefacts")]
		public List<AllocatedArtefact> AllocatedArtefacts { get; set; }
		[JsonPropertyName("tax_rate")]
		public TaxRate TaxRate { get; set; }
		[JsonPropertyName("payment_on_account")]
		public PaymentOnAccount PaymentOnAccount { get; set; }
	}
}
