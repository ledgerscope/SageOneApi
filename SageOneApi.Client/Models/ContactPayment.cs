using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace SageOneApi.Client.Models
{
	public class ContactPayment : SageOneAccountingEntity
	{
		[JsonProperty("transaction")]
		public PropertyValueWithPath Transaction { get; set; }
		[JsonProperty("transaction_type")]
		public PropertyValueWithPath TransactionType { get; set; }
		[JsonProperty("links")]
		public List<Link> Links { get; set; }
		[JsonProperty("payment_method")]
		public PropertyValueWithPath PaymentMethod { get; set; }
		[JsonProperty("contact")]
		public Contact Contact { get; set; }
		[JsonProperty("bank_account")]
		public BankAccount BankAccount { get; set; }
		[JsonProperty("date")]
		public DateTime Date { get; set; }
		[JsonProperty("net_amount")]
		public decimal NetAmount { get; set; }
		[JsonProperty("tax_amount")]
		public decimal? TaxAmount { get; set; }
		[JsonProperty("total_amount")]
		public decimal TotalAmount { get; set; }
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
		[JsonProperty("base_currency_currency_charge")]
		public decimal BaseCurrencyCurrencyCharge { get; set; }
		[JsonProperty("reference")]
		public string Reference { get; set; }
		[JsonProperty("allocated_artefacts")]
		public List<AllocatedArtefact> AllocatedArtefacts { get; set; }
		[JsonProperty("tax_rate")]
		public TaxRate TaxRate { get; set; }
		[JsonProperty("payment_on_account")]
		public PaymentOnAccount PaymentOnAccount { get; set; }
	}
}
