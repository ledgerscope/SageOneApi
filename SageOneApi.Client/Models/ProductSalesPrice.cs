using System;
using System.Text.Json.Serialization;

namespace SageOneApi.Client.Models
{
    public class ProductSalesPrice : PropertyValue
    {
        [JsonPropertyName("created_at")]
        public DateTime? CreatedAt { get; set; }
        [JsonPropertyName("updated_at")]
        public DateTime? UpdatedAt { get; set; }
        [JsonPropertyName("price_name")]
        public string PriceName { get; set; }
        [JsonPropertyName("price")]
        public decimal Price { get; set; }
        [JsonPropertyName("price_includes_tax")]
        public bool PriceIncludesTax { get; set; }
        [JsonPropertyName("product_sales_price_type")]
        public PropertyValueWithPath ProductSalesPriceType { get; set; }
    }
}
