using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SageOneApi.Client.Models
{
    public class StockItem : CatalogItem
    {
        [JsonPropertyName("sales_prices")]
        public List<ProductSalesPrice> SalesPrices { get; set; }
        [JsonPropertyName("reorder_level")]
        [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        public decimal ReorderLevel { get; set; }
        [JsonPropertyName("reorder_quantity")]
        [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        public decimal? ReorderQuantity { get; set; }
        [JsonPropertyName("location")]
        public string Location { get; set; }
        [JsonPropertyName("barcode")]
        public string Barcode { get; set; }
        [JsonPropertyName("supplier_part_number")]
        public string SupplierPartNumber { get; set; }
        [JsonPropertyName("weight")]
        public decimal? Weight { get; set; }
        [JsonPropertyName("measurement_unit")]
        public string MeasurementUnit { get; set; }
        [JsonPropertyName("weight_converted")]
        [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        public decimal WeightConverted { get; set; }
        [JsonPropertyName("quantity_in_stock")]
        [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        public decimal QuantityInStock { get; set; }
        [JsonPropertyName("last_cost_price")]
        [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        public decimal LastCostPrice { get; set; }
        [JsonPropertyName("last_cost_price_stock_value")]
        [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        public decimal LastCostPriceStockValue { get; set; }
        [JsonPropertyName("average_cost_price")]
        [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        public decimal AverageCostPrice { get; set; }
        [JsonPropertyName("average_cost_price_stock_value")]
        public decimal AverageCostPriceStockValue { get; set; }
        [JsonPropertyName("cost_price_last_updated")]
        public DateTime? CostPriceLastUpdated { get; set; }
    }
}
