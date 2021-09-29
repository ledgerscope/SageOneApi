using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SageOneApi.Client.Models
{
	public class OtherPayment : DatedTransaction
	{
		[JsonPropertyName("payment_method")]
		public PropertyValueWithPath PaymentMethod { get; set; }
		[JsonPropertyName("contact")]
		public Contact Contact { get; set; }
		[JsonPropertyName("bank_account")]
		public BankAccount bank_account { get; set; }
		[JsonPropertyName("tax_address_region")]
		public string TaxAddressRegion { get; set; }
		[JsonPropertyName("net_amount")]
		public decimal NetAmount { get; set; }
		[JsonPropertyName("tax_amount")]
		public decimal? TaxAmount { get; set; }
		[JsonPropertyName("total_amount")]
		public decimal TotalAmount { get; set; }
		[JsonPropertyName("reference")]
		public string Reference { get; set; }
		[JsonPropertyName("payment_lines")]
		public List<PaymentLine> PaymentLines { get; set; }
		[JsonPropertyName("editable")]
		public bool Editable { get; set; }
		[JsonPropertyName("deletable")]
		public bool Deletable { get; set; }
		[JsonPropertyName("withholding_tax_rate")]
		public decimal? WithholdingTaxRate { get; set; }
		[JsonPropertyName("withholding_tax_amount")]
		public decimal? WithholdingTaxAmount { get; set; }
	}
}
