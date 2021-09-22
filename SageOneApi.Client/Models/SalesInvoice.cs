using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SageOneApi.Client.Models
{
	public class SalesInvoice : SalesTransaction
	{
		[JsonPropertyName("invoice_number")]
		public string InvoiceNumber { get; set; }
		[JsonPropertyName("due_date")]
		public DateTime DueDate { get; set; }
		[JsonPropertyName("original_quote_estimate")]
		public PropertyValueWithPath OriginalQuoteEstimate { get; set; }
		[JsonPropertyName("delivery_performance_date")]
		public DateTime? DeliveryPerformanceDate { get; set; }
		[JsonPropertyName("withholding_tax_rate")]
		public double? WithholdingTaxRate { get; set; }
		[JsonPropertyName("withholding_tax_amount")]
		public decimal? WithholdingTaxAmount { get; set; }
		[JsonPropertyName("base_currency_withholding_tax_amount")]
		public decimal? BaseCurrencyWithholdingTaxAmount { get; set; }
		[JsonPropertyName("invoice_lines")]
		public List<SalesTransactionLine> InvoiceLines { get; set; }
	}
}
