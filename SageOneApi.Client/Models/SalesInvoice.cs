using System.Collections.Generic;

namespace SageOneApi.Client.Models
{
    public class SalesInvoice : SalesTransaction
    {
        public string invoice_number { get; set; }
        public string due_date { get; set; }
        public object original_quote_estimate { get; set; }
        public object delivery_performance_date { get; set; }
        public object withholding_tax_rate { get; set; }
        public object withholding_tax_amount { get; set; }
        public object base_currency_withholding_tax_amount { get; set; }
        public List<SalesTransactionLine> invoice_lines { get; set; }
    }
}
