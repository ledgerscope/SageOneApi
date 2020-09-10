using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace SageOneApi.Client.Models
{
    public class SalesInvoice : SalesTransaction
    {
		[JsonProperty("invoice_number")]
        public string InvoiceNumber { get; set; }
        [JsonProperty("due_date")]
		public DateTime DueDate { get; set; }
		[JsonProperty("original_quote_estimate")]
		public PropertyValueWithPath OriginalQuoteEstimate { get; set; }
		[JsonProperty("delivery_performance_date")]
		public DateTime? DeliveryPerformanceDate { get; set; }
		[JsonProperty("withholding_tax_rate")]
		public double? WithholdingTaxRate { get; set; }
		[JsonProperty("withholding_tax_amount")]
		public decimal? WithholdingTaxAmount { get; set; }
		[JsonProperty("base_currency_withholding_tax_amount")]
		public decimal? BaseCurrencyWithholdingTaxAmount { get; set; }
		[JsonProperty("invoice_lines")]
		public List<SalesTransactionLine> InvoiceLines { get; set; }
    }
}
