using Newtonsoft.Json;

namespace SageOneApi.Client.Models
{
    public class FinancialSettings : SageOneSingleAccountingEntity
    {
        [JsonProperty("$path")]
        public string path { get; set; }
        public string year_end_date { get; set; }
        public string year_end_lockdown_date { get; set; }
        public string accounts_start_date { get; set; }
        public PropertyValueWithPath base_currency { get; set; }
        public bool multi_currency_enabled { get; set; }
        public bool use_live_exchange_rates { get; set; }
        public PropertyValueWithPath tax_scheme { get; set; }
        public PropertyValueWithPath tax_return_frequency { get; set; }
        public string tax_number { get; set; }
        public string general_tax_number { get; set; }
        public object tax_office { get; set; }
        public string default_irpf_rate { get; set; }
        public object flat_rate_tax_percentage { get; set; }
        public object sales_tax_calculation { get; set; }
        public object purchase_tax_calculation { get; set; }
    }
}
