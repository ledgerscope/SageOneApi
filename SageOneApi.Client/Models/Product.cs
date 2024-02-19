using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SageOneApi.Client.Models
{
    public class Product : CatalogItem
    {
        [JsonPropertyName("sales_prices")]
        public List<ProductSalesPrice> SalesPrices { get; set; }
        [JsonPropertyName("catalog_item_type")]
        public PropertyValueWithPath CatalogItemType { get; set; }
    }
}
