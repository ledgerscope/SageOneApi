using System.Text.Json.Serialization;

namespace SageOneApi.Client.Models
{
    public class CatalogItem : SageOneAccountingEntity
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
        [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        public decimal CostPrice { get; set; }
        [JsonPropertyName("source_guid")]
        public string SourceGuid { get; set; }
        [JsonPropertyName("purchase_description")]
        public string PurchaseDescription { get; set; }
        [JsonPropertyName("active")]
        public bool Active { get; set; }
    }
}
