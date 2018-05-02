using System;
using System.Collections.Generic;

namespace SageOneApi.Client.Models
{
    public class PurchaseInvoice : PurchaseTransaction
    {
        public DateTime due_date { get; set; }
        public List<PurchaseTransactionLine> invoice_lines { get; set; }
        public TaxRate withholding_tax_rate { get; set; }
        public decimal? withholding_tax_amount { get; set; }
        public decimal? base_currency_withholding_tax_amount { get; set; }
    }
}
