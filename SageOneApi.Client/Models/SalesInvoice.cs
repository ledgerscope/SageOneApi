using System;
using System.Collections.Generic;

namespace SageOneApi.Client.Models
{
    public class SalesInvoice : SalesTransaction
    {
        public string invoice_number { get; set; }
        public DateTime due_date { get; set; }
        public decimal? original_quote_estimate { get; set; }
        public DateTime? delivery_performance_date { get; set; }
        public TaxRate withholding_tax_rate { get; set; }
        public decimal? withholding_tax_amount { get; set; }
        public decimal? base_currency_withholding_tax_amount { get; set; }
        public List<SalesTransactionLine> invoice_lines { get; set; }
    }
}
