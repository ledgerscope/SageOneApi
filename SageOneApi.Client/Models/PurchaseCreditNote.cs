using System.Collections.Generic;

namespace SageOneApi.Client.Models
{
    public class PurchaseCreditNote : PurchaseTransaction
    {
        public List<PurchaseTransactionLine> credit_note_lines { get; set; }
    }
}
