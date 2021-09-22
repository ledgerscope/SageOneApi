using System.Text.Json.Serialization;

namespace SageOneApi.Client.Models
{
	public class LedgerAccount : SageOneAccountingEntity
	{
		[JsonPropertyName("ledger_account_group")]
		public PropertyValue LedgerAccountGroup { get; set; }
		[JsonPropertyName("name")]
		public string Name { get; set; }
		[JsonPropertyName("display_name")]
		public string DisplayName { get; set; }
		[JsonPropertyName("display_formatted")]
		public string DisplayFormatted { get; set; }
		[JsonPropertyName("included_in_chart")]
		public bool? IncludedInChart { get; set; }
		[JsonPropertyName("nominal_code")]
		public string NominalCode { get; set; }
		[JsonPropertyName("ledger_account_type")]
		public PropertyValueWithPath LedgerAccountType { get; set; }
		[JsonPropertyName("ledger_account_classification")]
		public string LedgerAccountClassification { get; set; }
		[JsonPropertyName("tax_rate")]
		public TaxRate TaxRate { get; set; }
		[JsonPropertyName("fixed_tax_rate")]
		public bool FixedTaxRate { get; set; }
		[JsonPropertyName("visible_in_banking")]
		public bool VisibleInBanking { get; set; }
		[JsonPropertyName("visible_in_expenses")]
		public bool VisibleInExpenses { get; set; }
		[JsonPropertyName("visib" + "le_in_journals")]
		public bool VisibleInJournals { get; set; }
		[JsonPropertyName("visible_in_other_payments")]
		public bool VisibleInOtherPayments { get; set; }
		[JsonPropertyName("visible_in_other_receipts")]
		public bool VisibleInOtherReceipts { get; set; }
		[JsonPropertyName("visible_in_reporting")]
		public bool VisibleInReporting { get; set; }
		[JsonPropertyName("visible_in_sales")]
		public bool VisibleInSales { get; set; }
		[JsonPropertyName("is_control_account")]
		public bool IsControlAccount { get; set; }
		[JsonPropertyName("control_name")]
		public string ControlName { get; set; }
		[JsonPropertyName("balance_details")]
		public BalanceDetails BalanceDetails { get; set; }
	}
}
