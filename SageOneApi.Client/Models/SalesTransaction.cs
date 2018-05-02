using System.Collections.Generic;

namespace SageOneApi.Client.Models
{
    public abstract class SalesTransaction : ControlTransaction
    {
        public string main_address_free_form { get; set; }
        public MainAddress main_address { get; set; }
        public string delivery_address_free_form { get; set; }
        public DeliveryAddress delivery_address { get; set; }
        public string terms_and_conditions { get; set; }
        public decimal shipping_net_amount { get; set; }
        public TaxRate shipping_tax_rate { get; set; }
        public decimal shipping_tax_amount { get; set; }
        public List<string> shipping_tax_breakdown { get; set; }
        public decimal shipping_total_amount { get; set; }
        public decimal base_currency_shipping_net_amount { get; set; }
        public decimal base_currency_shipping_tax_amount { get; set; }
        public List<string> base_currency_shipping_tax_breakdown { get; set; }
        public decimal base_currency_shipping_total_amount { get; set; }
        public decimal total_discount_amount { get; set; }
        public decimal base_currency_total_discount_amount { get; set; }
        public bool sent { get; set; }
    }
}
