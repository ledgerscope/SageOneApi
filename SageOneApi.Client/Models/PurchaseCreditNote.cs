using System.Collections.Generic;

namespace SageOneApi.Client.Models
{
    public class PurchaseCreditNote
    {
        public List<PurchaseTransactionLine> credit_note_lines { get; set; }
    }
}
