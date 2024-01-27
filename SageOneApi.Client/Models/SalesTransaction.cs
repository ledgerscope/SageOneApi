using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SageOneApi.Client.Models
{
	public abstract class SalesTransaction : ControlTransaction
	{
		[JsonPropertyName("main_address_free_form")]
		public string MainAddressFreeForm { get; set; }
		[JsonPropertyName("main_address")]
		public Address MainAddress { get; set; }
		[JsonPropertyName("delivery_address_free_form")]
		public string DeliveryAddressFreeForm { get; set; }
		[JsonPropertyName("delivery_address")]
		public Address DeliveryAddress { get; set; }
		[JsonPropertyName("terms_and_conditions")]
		public string TermsAndConditions { get; set; }
		[JsonPropertyName("shipping_net_amount")]
		[JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        public decimal? ShippingNetAmount { get; set; }
		[JsonPropertyName("shipping_tax_rate")]
		public TaxRate ShippingTaxRate { get; set; }
		[JsonPropertyName("shipping_tax_amount")]
		[JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        public decimal? ShippingTaxAmount { get; set; }
		[JsonPropertyName("shipping_tax_breakdown")]
		public List<Tax> ShippingTaxBreakdown { get; set; }
		[JsonPropertyName("shipping_total_amount")]
		[JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        public decimal? ShippingTotalAmount { get; set; }
		[JsonPropertyName("base_currency_shipping_net_amount")]
		[JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        public decimal? BaseCurrencyShippingNetAmount { get; set; }
		[JsonPropertyName("base_currency_shipping_tax_amount")]
		[JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        public decimal? BaseCurrencyShippingTaxAmount { get; set; }
		[JsonPropertyName("base_currency_shipping_tax_breakdown")]
		public List<Tax> BaseCurrencyShippingTaxBreakdown { get; set; }
		[JsonPropertyName("base_currency_shipping_total_amount")]
		[JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        public decimal BaseCurrencyShippingTotalAmount { get; set; }
		[JsonPropertyName("total_discount_amount")]
		[JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        public decimal TotalDiscountAmount { get; set; }
		[JsonPropertyName("base_currency_total_discount_amount")]
		[JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        public decimal BaseCurrencyTotalDiscountAmount { get; set; }
		[JsonPropertyName("sent")]
		public bool Sent { get; set; }
	}
}
