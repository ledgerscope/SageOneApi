using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SageOneApi.Client.Models
{
	public class PurchaseInvoice : PurchaseTransaction
	{
		[JsonPropertyName("due_date")]
		public DateTime DueDate { get; set; }
		[JsonPropertyName("invoice_lines")]
		public List<PurchaseTransactionLine> InvoiceLines { get; set; }
		[JsonPropertyName("withholding_tax_rate")]
		public decimal? WithholdingTaxRate { get; set; }
		[JsonPropertyName("withholding_tax_amount")]
		public decimal? WithholdingTaxAmount { get; set; }
		[JsonPropertyName("base_currency_withholding_tax_amount")]
		public decimal? BaseCurrencyWithholdingTaxAmount { get; set; }
	}
}
