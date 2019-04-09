using Newtonsoft.Json;

namespace SageOneApi.Client.Models
{
    public class FinancialSettings : SageOneSingleAccountingEntity
    {
        [JsonProperty("$path")]
        public string Path { get; set; }
        [JsonProperty("year_end_date")]
		public string YearEndDate { get; set; }
		[JsonProperty("year_end_lockdown_date")]
		public string YearEndLockdownDate { get; set; }
		[JsonProperty("accounts_start_date")]
		public string AccountsStartDate { get; set; }
		[JsonProperty("base_currency")]
		public PropertyValueWithPath BaseCurrency { get; set; }
		[JsonProperty("multi_currency_enabled")]
		public bool MultiCurrencyEnabled { get; set; }
		[JsonProperty("use_live_exchange_rates")]
		public bool UseLiveExchangeRates { get; set; }
		[JsonProperty("tax_scheme")]
		public PropertyValueWithPath TaxScheme { get; set; }
		[JsonProperty("tax_return_frequency")]
		public PropertyValueWithPath TaxReturnFrequency { get; set; }
		[JsonProperty("tax_number")]
		public string TaxNumber { get; set; }
		[JsonProperty("general_tax_number")]
		public string GeneralTaxNumber { get; set; }
		[JsonProperty("tax_office")]
		public object TaxOffice { get; set; }
		[JsonProperty("default_irpf_rate")]
		public string DefaultIrpfRate { get; set; }
		[JsonProperty("flat_rate_tax_percentage")]
		public object FlatRateTaxPercentage { get; set; }
		[JsonProperty("sales_tax_calculation")]
		public object SalesTaxCalculation { get; set; }
		[JsonProperty("purchase_tax_calculation")]
		public object PurchaseTaxCalculation { get; set; }
    }
}
