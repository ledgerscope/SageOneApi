using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;

namespace SageOneApi.Client.Models
{
	public class Contact : SageOneAccountingEntity
	{
		[JsonPropertyName("links")]
		public List<Link> Links { get; set; }
		[JsonPropertyName("contact_types")]
		public List<PropertyValueWithPath> ContactTypes { get; set; }
		[JsonPropertyName("name")]
		public string Name { get; set; }
		[JsonPropertyName("reference")]
		public string Reference { get; set; }
		[JsonPropertyName("default_sales_ledger_account")]
		public LedgerAccount DefaultSalesLedgerAccount { get; set; }
		[JsonPropertyName("default_sales_tax_rate")]
		public TaxRate DefaultSalesTaxRate { get; set; }
		[JsonPropertyName("tax_number")]
		public string TaxNumber { get; set; }
		[JsonPropertyName("notes")]
		public string Notes { get; set; }
		[JsonPropertyName("email")]
		public string Email { get; set; }
		[JsonPropertyName("locale")]
		public string Locale { get; set; }
		[JsonPropertyName("main_address")]
		public Address MainAddress { get; set; }
		[JsonPropertyName("delivery_address")]
		public Address DeliveryAddress { get; set; }
		[JsonPropertyName("main_contact_person")]
		public ContactPerson MainContactPerson { get; set; }
		[JsonPropertyName("bank_account_details")]
		public BankAccountDetails BankAccountDetails { get; set; }
		[JsonPropertyName("credit_limit")]
		[JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
		public decimal? CreditLimit { get; set; }
		[JsonPropertyName("credit_days")]
		public int? CreditDays { get; set; }
		[JsonPropertyName("credit_terms_and_conditions")]
		public string CreditTermsAndConditions { get; set; }
		[JsonPropertyName("product_sales_price_type")]
		public PropertyValueWithPath ProductSalesPriceType { get; set; }
		[JsonPropertyName("source_guid")]
		public string SourceGuid { get; set; }
		[JsonPropertyName("currency")]
		public PropertyValueWithPath Currency { get; set; }
		[JsonPropertyName("aux_reference")]
		public string AuxReference { get; set; }
		[JsonPropertyName("registered_number")]
		public string RegisteredNumber { get; set; }
		[JsonPropertyName("deletable")]
		public bool Deletable { get; set; }
		[JsonPropertyName("tax_treatment")]
		public TaxTreatment TaxTreatment { get; set; }
		[JsonPropertyName("gdpr_obfuscated")]
		public bool GdprObfuscated { get; set; }
		[JsonPropertyName("balance")]
		[JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
		public decimal? Balance { get; set; }
        [JsonPropertyName("balance_details")]
		public BalanceDetails BalanceDetails { get; set; }
	}
}
