using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace SageOneApi.Client.Models
{
	public class OtherPayment : SageOneAccountingEntity
	{
		[JsonProperty("transaction")]
		public PropertyValueWithPath Transaction { get; set; }
		[JsonProperty("transaction_type")]
		public PropertyValueWithPath TransactionType { get; set; }
		[JsonProperty("payment_method")]
		public PropertyValueWithPath PaymentMethod { get; set; }
		[JsonProperty("contact")]
		public Contact Contact { get; set; }
		[JsonProperty("bank_account")]
		public BankAccount bank_account { get; set; }
		[JsonProperty("tax_address_region")]
		public string TaxAddressRegion { get; set; }
		[JsonProperty("date")]
		public DateTime Date { get; set; }
		[JsonProperty("net_amount")]
		public decimal NetAmount { get; set; }
		[JsonProperty("tax_amount")]
		public decimal? TaxAmount { get; set; }
		[JsonProperty("total_amount")]
		public decimal TotalAmount { get; set; }
		[JsonProperty("reference")]
		public string Reference { get; set; }
		[JsonProperty("payment_lines")]
		public List<PaymentLine> PaymentLines { get; set; }
		[JsonProperty("editable")]
		public bool Editable { get; set; }
		[JsonProperty("deletable")]
		public bool Deletable { get; set; }
		[JsonProperty("withholding_tax_rate")]
		public double? WithholdingTaxRate { get; set; }
		[JsonProperty("withholding_tax_amount")]
		public decimal? WithholdingTaxAmount { get; set; }
	}
}
