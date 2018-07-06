using System.Collections.Generic;

namespace SageOneApi.Client.Models
{
    public abstract class QuickEntry : ControlTransaction
    {
        public PropertyValueWithPath quick_entry_type { get; set; }
        public LedgerAccount ledger_account { get; set; }
        public string details { get; set; }
        public TaxRate tax_rate { get; set; }
        public List<Tax> tax_breakdown { get; set; }
        public List<Tax> base_currency_tax_breakdown { get; set; }
        public bool trade_of_asset { get; set; }
    }
}
