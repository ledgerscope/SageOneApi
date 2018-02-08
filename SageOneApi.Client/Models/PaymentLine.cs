using System.Collections.Generic;

namespace SageOneApi.Client.Models
{
    public class PaymentLine
    {
        public string id { get; set; }
        public string displayed_as { get; set; }
        public LedgerAccount ledger_account { get; set; }
        public string details { get; set; }
        public PropertyValueWithPath tax_rate { get; set; }
        public string net_amount { get; set; }
        public string tax_amount { get; set; }
        public string total_amount { get; set; }
        public List<Tax> tax_breakdown { get; set; }
        public bool is_purchase_for_resale { get; set; }
    }
}
