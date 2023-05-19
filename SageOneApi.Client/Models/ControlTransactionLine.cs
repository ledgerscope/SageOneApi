using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SageOneApi.Client.Models
{
	public abstract class ControlTransactionLine
	{
		[JsonPropertyName("id")]
		public string Id { get; set; }
		[JsonPropertyName("displayed_as")]
		public string DisplayedAs { get; set; }
		[JsonPropertyName("description")]
		public string Description { get; set; }
		[JsonPropertyName("product")]
		public object Product { get; set; }
		[JsonPropertyName("service")]
		public object Service { get; set; }
		[JsonPropertyName("ledger_account")]
		public LedgerAccount LedgerAccount { get; set; }
		[JsonPropertyName("quantity")]
		public decimal Quantity { get; set; }
		[JsonPropertyName("unit_price")]
		public decimal UnitPrice { get; set; }
		[JsonPropertyName("net_amount")]
		public decimal NetAmount { get; set; }
		[JsonPropertyName("tax_rate")]
		public TaxRate TaxRate { get; set; }
		[JsonPropertyName("tax_amount")]
		public decimal? TaxAmount { get; set; }
		[JsonPropertyName("tax_breakdown")]
		public List<Tax> TaxBreakdown { get; set; }
		[JsonPropertyName("total_amount")]
		public decimal TotalAmount { get; set; }
		[JsonPropertyName("base_currency_unit_price")]
		public decimal BaseCurrencyUnitPrice { get; set; }
		[JsonPropertyName("base_currency_net_amount")]
		public decimal BaseCurrencyNetAmount { get; set; }
		[JsonPropertyName("base_currency_tax_amount")]
		public decimal BaseCurrencyTaxAmount { get; set; }
		[JsonPropertyName("base_currency_tax_breakdown")]
		public List<Tax> BaseCurrencyTaxBreakdown { get; set; }
		[JsonPropertyName("base_currency_total_amount")]
		public decimal BaseCurrencyTotalAmount { get; set; }
		[JsonPropertyName("eu_goods_services_type")]
		public PropertyValueWithPath EuGoodsServicesType { get; set; }
        [JsonPropertyName("analysis_type_categories")]
        public List<PropertyValueWithPath> AnalysisTypeCategories { get; set; }
    }
}
