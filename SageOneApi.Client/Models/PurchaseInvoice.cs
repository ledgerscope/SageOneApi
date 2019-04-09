using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace SageOneApi.Client.Models
{
    public class PurchaseInvoice : PurchaseTransaction
    {
	    [JsonProperty("due_date")]
		public DateTime DueDate { get; set; }
		[JsonProperty("invoice_lines")]
		public List<PurchaseTransactionLine> InvoiceLines { get; set; }
		[JsonProperty("withholding_tax_rate")]
		public TaxRate WithholdingTaxRate { get; set; }
		[JsonProperty("withholding_tax_amount")]
		public decimal? WithholdingTaxAmount { get; set; }
		[JsonProperty("base_currency_withholding_tax_amount")]
		public decimal? BaseCurrencyWithholdingTaxAmount { get; set; }
    }
}
