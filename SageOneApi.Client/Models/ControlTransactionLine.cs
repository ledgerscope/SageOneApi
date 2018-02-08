using System.Collections.Generic;

namespace SageOneApi.Client.Models
{
    public class ControlTransactionLine
    {
        public string id { get; set; }
        public string displayed_as { get; set; }
        public string description { get; set; }
        public object product { get; set; }
        public object service { get; set; }
        public LedgerAccount ledger_account { get; set; }
        public string quantity { get; set; }
        public string unit_price { get; set; }
        public string net_amount { get; set; }
        public PropertyValueWithPath tax_rate { get; set; }
        public string tax_amount { get; set; }
        public List<Tax> tax_breakdown { get; set; }
        public string total_amount { get; set; }
        public string base_currency_unit_price { get; set; }
        public string base_currency_net_amount { get; set; }
        public string base_currency_tax_amount { get; set; }
        public List<Tax> base_currency_tax_breakdown { get; set; }
        public string base_currency_total_amount { get; set; }
        public object eu_goods_services_type { get; set; }
    }
}
