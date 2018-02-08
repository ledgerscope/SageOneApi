using System.Collections.Generic;

namespace SageOneApi.Client.Models
{
    public class PurchaseInvoice : PurchaseTransaction
    {
        public string due_date { get; set; }
        public List<PurchaseTransactionLine> invoice_lines { get; set; }
        public object withholding_tax_rate { get; set; }
        public object withholding_tax_amount { get; set; }
        public object base_currency_withholding_tax_amount { get; set; }
    }
}
