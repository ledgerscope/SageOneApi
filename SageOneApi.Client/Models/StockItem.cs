using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SageOneApi.Client.Models
{
    public class StockItem : SageOneAccountingEntity
	{
        [JsonPropertyName("deletable")]
        public bool Deletable { get; set; }
        [JsonPropertyName("deactivatable")]
        public bool Deactivatable { get; set; }
        [JsonPropertyName("used_on_recurring_invoice")]
        public bool UsedOnRecurringInvoice { get; set; }
        [JsonPropertyName("description")]
		public string Description { get; set; }
        [JsonPropertyName("item_code")]
        public string ItemCode { get; set; }
        [JsonPropertyName("notes")]
        public string Notes { get; set; }
        [JsonPropertyName("sales_ledger_account")]
        public PropertyValueWithPath SalesLedgerAccount { get; set; }
        [JsonPropertyName("sales_tax_rate")]
        public PropertyValueWithPath SalesTaxRate { get; set; }
        [JsonPropertyName("purchase_ledger_account")]
        public PropertyValueWithPath PurchaseLedgerAccount { get; set; }
        [JsonPropertyName("usual_supplier")]
        public Contact UsualSupplier { get; set; }
        [JsonPropertyName("purchase_tax_rate")]
        public PropertyValueWithPath PurchaseTaxRate { get; set; }
        [JsonPropertyName("cost_price")]
        public decimal CostPrice { get; set; }
        [JsonPropertyName("sales_prices")]
		public List<ProductSalesPrice> SalesPrices { get; set; }
        [JsonPropertyName("source_guid")]
        public string SourceGuid { get; set; }
        [JsonPropertyName("purchase_description")]
        public string PurchaseDescription { get; set; }
        [JsonPropertyName("reorder_level")]
        public decimal? ReorderLevel { get; set; }
        [JsonPropertyName("reorder_quantity")]
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
        public decimal? WeightConverted { get; set; }
        [JsonPropertyName("active")]
        public bool Active { get; set; }
        [JsonPropertyName("quantity_in_stock")]
        public decimal QuantityInStock { get; set; }
        [JsonPropertyName("last_cost_price")]
        public decimal LastCostPrice { get; set; }
        [JsonPropertyName("last_cost_price_stock_value")]
        public decimal LastCostPriceStockValue { get; set; }
        [JsonPropertyName("average_cost_price")]
        public decimal AverageCostPrice { get; set; }
        [JsonPropertyName("average_cost_price_stock_value")]
        public decimal AverageCostPriceStockValue { get; set; }
        [JsonPropertyName("cost_price_last_updated")]
        public DateTime? CostPriceLastUpdated { get; set; }
    }
}
