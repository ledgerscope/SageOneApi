using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SageOneApi.Client.Models
{
    public class Service : CatalogItem
    {
        [JsonPropertyName("sales_rates")]
        public List<ServiceSalesRate> SalesRates { get; set; }
        [JsonPropertyName("oss_service")]
        public bool OssService { get; set; }
    }
}
