using System.Text.Json.Serialization;

namespace SageOneApi.Client.Models
{
    public class CisSettings : SageOneSingleAccountingEntity
    {
        [JsonPropertyName("$path")]
        public string Path { get; set; }

        [JsonPropertyName("unique_tax_reference")]
        public string UniqueTaxReference { get; set; }

        [JsonPropertyName("contractor")]
        public bool Contractor { get; set; }

        [JsonPropertyName("subcontractor")]
        public bool Subcontractor { get; set; }

        [JsonPropertyName("accounts_office_reference")]
        public string AccountsOfficeReference { get; set; }

        [JsonPropertyName("paye_reference")]
        public string PayeReference { get; set; }

        [JsonPropertyName("tax_rate_id")]
        public string TaxRateId { get; set; }
    }
}
