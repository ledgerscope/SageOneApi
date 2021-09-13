using System.Collections.Generic;
using Newtonsoft.Json;

namespace SageOneApi.Client.Models
{
	public abstract class SalesTransaction : ControlTransaction
	{
		[JsonProperty("main_address_free_form")]
		public string MainAddressFreeForm { get; set; }
		[JsonProperty("main_address")]
		public Address MainAddress { get; set; }
		[JsonProperty("delivery_address_free_form")]
		public string DeliveryAddressFreeForm { get; set; }
		[JsonProperty("delivery_address")]
		public Address DeliveryAddress { get; set; }
		[JsonProperty("terms_and_conditions")]
		public string TermsAndConditions { get; set; }
		[JsonProperty("shipping_net_amount")]
		public decimal? ShippingNetAmount { get; set; }
		[JsonProperty("shipping_tax_rate")]
		public TaxRate ShippingTaxRate { get; set; }
		[JsonProperty("shipping_tax_amount")]
		public decimal? ShippingTaxAmount { get; set; }
		[JsonProperty("shipping_tax_breakdown")]
		public List<Tax> ShippingTaxBreakdown { get; set; }
		[JsonProperty("shipping_total_amount")]
		public decimal? ShippingTotalAmount { get; set; }
		[JsonProperty("base_currency_shipping_net_amount")]
		public decimal? BaseCurrencyShippingNetAmount { get; set; }
		[JsonProperty("base_currency_shipping_tax_amount")]
		public decimal? BaseCurrencyShippingTaxAmount { get; set; }
		[JsonProperty("base_currency_shipping_tax_breakdown")]
		public List<Tax> BaseCurrencyShippingTaxBreakdown { get; set; }
		[JsonProperty("base_currency_shipping_total_amount")]
		public decimal BaseCurrencyShippingTotalAmount { get; set; }
		[JsonProperty("total_discount_amount")]
		public decimal TotalDiscountAmount { get; set; }
		[JsonProperty("base_currency_total_discount_amount")]
		public decimal BaseCurrencyTotalDiscountAmount { get; set; }
		[JsonProperty("sent")]
		public bool Sent { get; set; }
	}
}
