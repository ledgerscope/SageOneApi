using System;

namespace SageOneApi.Client.Models
{
    public class LedgerEntry : SageOneAccountingEntity
    {
        public Transaction transaction { get; set; }
        public PropertyValueWithPath transaction_type { get; set; }
        public DateTime date { get; set; }
        public string description { get; set; }
        public decimal debit { get; set; }
        public decimal credit { get; set; }
        public TaxRate tax_rate { get; set; }
        public LedgerAccount ledger_account { get; set; }
        public Contact contact { get; set; }
        public bool deleted { get; set; }
    }
}
