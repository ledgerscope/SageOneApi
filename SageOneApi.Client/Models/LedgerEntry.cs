using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SageOneApi.Client.Models
{
    public class LedgerEntry : PropertyValueWithPath
    {
        public Transaction transaction { get; set; }
        public PropertyValueWithPath transaction_type { get; set; }
        public DateTime? created_at { get; set; }
        public DateTime updated_at { get; set; }
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
