using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace SageOneApi.Client.Models
{
	public class Contact : SageOneAccountingEntity
	{
		[JsonProperty("links")]
		public List<Link> Links { get; set; }
		[JsonProperty("contact_types")]
		public List<PropertyValueWithPath> ContactTypes { get; set; }
		[JsonProperty("name")]
		public string Name { get; set; }
		[JsonProperty("reference")]
		public string Reference { get; set; }
		[JsonProperty("default_sales_ledger_account")]
		public LedgerAccount DefaultSalesLedgerAccount { get; set; }
		[JsonProperty("default_sales_tax_rate")]
		public TaxRate DefaultSalesTaxRate { get; set; }
		[JsonProperty("tax_number")]
		public string TaxNumber { get; set; }
		[JsonProperty("notes")]
		public string Notes { get; set; }
		[JsonProperty("email")]
		public string Email { get; set; }
		[JsonProperty("locale")]
		public string Locale { get; set; }
		[JsonProperty("main_address")]
		public Address MainAddress { get; set; }
		[JsonProperty("delivery_address")]
		public Address DeliveryAddress { get; set; }
		[JsonProperty("main_contact_person")]
		public ContactPerson MainContactPerson { get; set; }
		[JsonProperty("bank_account_details")]
		public BankAccountDetails BankAccountDetails { get; set; }
		[JsonProperty("credit_limit")]
		public string CreditLimit { get; set; }
		[JsonProperty("credit_days")]
		public string CreditDays { get; set; }
		[JsonProperty("credit_terms_and_conditions")]
		public string CreditTermsAndConditions { get; set; }
		[JsonProperty("product_sales_price_type")]
		public PropertyValueWithPath ProductSalesPriceType { get; set; }
		[JsonProperty("source_guid")]
		public string SourceGuid { get; set; }
		[JsonProperty("currency")]
		public PropertyValueWithPath Currency { get; set; }
		[JsonProperty("aux_reference")]
		public string AuxReference { get; set; }
		[JsonProperty("registered_number")]
		public string RegisteredNumber { get; set; }
		[JsonProperty("deletable")]
		public bool Deletable { get; set; }
		[JsonProperty("tax_treatment")]
		public TaxTreatment TaxTreatment { get; set; }
		[JsonProperty("gdpr_obfuscated")]
		public bool GdprObfuscated { get; set; }
		[JsonProperty("balance")]
		public decimal? Balance { get; set; }
		[JsonProperty("balance_details")]
		public BalanceDetails BalanceDetails { get; set; }
	}
}
