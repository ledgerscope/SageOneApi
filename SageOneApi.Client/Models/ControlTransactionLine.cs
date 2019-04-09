using System.Collections.Generic;
using Newtonsoft.Json;

namespace SageOneApi.Client.Models
{
    public abstract class ControlTransactionLine
    {
		[JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("displayed_as")]
		public string DisplayedAs { get; set; }
		[JsonProperty("description")]
		public string Description { get; set; }
		[JsonProperty("product")]
		public object Product { get; set; }
		[JsonProperty("service")]
		public object Service { get; set; }
		[JsonProperty("ledger_account")]
		public LedgerAccount LedgerAccount { get; set; }
		[JsonProperty("quantity")]
		public double Quantity { get; set; }
		[JsonProperty("unit_price")]
		public decimal UnitPrice { get; set; }
		[JsonProperty("net_amount")]
		public decimal NetAmount { get; set; }
		[JsonProperty("tax_rate")]
		public TaxRate TaxRate { get; set; }
		[JsonProperty("tax_amount")]
		public decimal TaxAmount { get; set; }
		[JsonProperty("tax_breakdown")]
		public List<Tax> TaxBreakdown { get; set; }
		[JsonProperty("total_amount")]
		public decimal TotalAmount { get; set; }
		[JsonProperty("base_currency_unit_price")]
		public decimal BaseCurrencyUnitPrice { get; set; }
		[JsonProperty("base_currency_net_amount")]
		public decimal BaseCurrencyNetAmount { get; set; }
		[JsonProperty("base_currency_tax_amount")]
		public decimal BaseCurrencyTaxAmount { get; set; }
		[JsonProperty("base_currency_tax_breakdown")]
		public List<Tax> BaseCurrencyTaxBreakdown { get; set; }
		[JsonProperty("base_currency_total_amount")]
		public decimal BaseCurrencyTotalAmount { get; set; }
		[JsonProperty("eu_goods_services_type")]
		public PropertyValueWithPath EuGoodsServicesType { get; set; }
    }
}
