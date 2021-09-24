using System;
using System.Text.Json.Serialization;

namespace SageOneApi.Client.Models
{
	public class FinancialSettings : SageOneSingleAccountingEntity
	{
		[JsonPropertyName("$path")]
		public string Path { get; set; }

		[JsonPropertyName("year_end_date")]
		public DateTime? YearEndDate { get; set; }

		[JsonPropertyName("year_end_lockdown_date")]
		public DateTime? YearEndLockdownDate { get; set; }

		[JsonPropertyName("accounts_start_date")]
		public DateTime? AccountsStartDate { get; set; }

		[JsonPropertyName("base_currency")]
		public PropertyValueWithPath BaseCurrency { get; set; }

		[JsonPropertyName("multi_currency_enabled")]
		public bool MultiCurrencyEnabled { get; set; }

		[JsonPropertyName("use_live_exchange_rates")]
		public bool UseLiveExchangeRates { get; set; }

		[JsonPropertyName("base_currency_id")]
		public string BaseCurrencyId { get; set; }

		[JsonPropertyName("tax_scheme")]
		public PropertyValueWithPath TaxScheme { get; set; }

		[JsonPropertyName("tax_return_frequency")]
		public PropertyValueWithPath TaxReturnFrequency { get; set; }

		[JsonPropertyName("mtd_activation_status")]
		public string MtdActivationStatus { get; set; }

		[JsonPropertyName("mtd_connected")]
		public bool MtdConnected { get; set; }

		[JsonPropertyName("mtd_authenticated_date")]
		public DateTime? MtdAuthenticatedDate { get; set; }

		[JsonPropertyName("tax_number")]
		public string TaxNumber { get; set; }

		[JsonPropertyName("general_tax_number")]
		public string GeneralTaxNumber { get; set; }

		[JsonPropertyName("tax_office")]
		public object TaxOffice { get; set; }

		[JsonPropertyName("default_irpf_rate")]
		public string DefaultIrpfRate { get; set; }

		[JsonPropertyName("flat_rate_tax_percentage")]
		public object FlatRateTaxPercentage { get; set; }

		[JsonPropertyName("sales_tax_calculation")]
		public object SalesTaxCalculation { get; set; }

		[JsonPropertyName("purchase_tax_calculation")]
		public object PurchaseTaxCalculation { get; set; }
	}
}
