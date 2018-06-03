using System.Collections.Generic;

namespace SageOneApi.Client.Models
{
    public class PaymentLine : PropertyValue
    {
        public LedgerAccount ledger_account { get; set; }
        public string details { get; set; }
        public TaxRate tax_rate { get; set; }
        public decimal net_amount { get; set; }
        public decimal tax_amount { get; set; }
        public decimal total_amount { get; set; }
        public List<Tax> tax_breakdown { get; set; }
        public bool is_purchase_for_resale { get; set; }
    }
}
