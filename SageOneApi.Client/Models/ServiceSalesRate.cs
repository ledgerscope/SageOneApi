using System;
using System.Text.Json.Serialization;

namespace SageOneApi.Client.Models
{
    public class ServiceSalesRate : PropertyValue
    {
        [JsonPropertyName("created_at")]
        public DateTime? CreatedAt { get; set; }
        [JsonPropertyName("updated_at")]
        public DateTime? UpdatedAt { get; set; }
        [JsonPropertyName("rate_name")]
        public string RateName { get; set; }
        [JsonPropertyName("rate")]
        public decimal Rate { get; set; }
        [JsonPropertyName("rate_includes_tax")]
        public bool RateIncludesTax { get; set; }
        [JsonPropertyName("service_rate_type")]
        public PropertyValueWithPath ServiceRateType { get; set; }
    }
}
