using Newtonsoft.Json;

namespace SageOneApi.Client.Models
{
    public class LedgerAccount : SageOneAccountingEntity
    {
	    [JsonProperty("ledger_account_group")]
		public PropertyValue LedgerAccountGroup { get; set; }
		[JsonProperty("name")]
		public string Name { get; set; }
		[JsonProperty("display_name")]
		public string DisplayName { get; set; }
		[JsonProperty("display_formatted")]
		public string DisplayFormatted { get; set; }
		[JsonProperty("included_in_chart")]
		public bool? IncludedInChart { get; set; }
		[JsonProperty("nominal_code")]
		public string NominalCode { get; set; }
		[JsonProperty("ledger_account_type")]
		public PropertyValueWithPath LedgerAccountType { get; set; }
		[JsonProperty("ledger_account_classification")]
		public string LedgerAccountClassification { get; set; }
		[JsonProperty("tax_rate")]
		public TaxRate TaxRate { get; set; }
        [JsonProperty("fixed_tax_rate")]
		public bool FixedTaxRate { get; set; }
		[JsonProperty("visible_in_banking")]
		public bool VisibleInBanking { get; set; }
		[JsonProperty("visible_in_expenses")]
		public bool VisibleInExpenses { get; set; }
		[JsonProperty("visib" + "le_in_journals")]
		public bool VisibleInJournals { get; set; }
		[JsonProperty("visible_in_other_payments")]
		public bool VisibleInOtherPayments { get; set; }
		[JsonProperty("visible_in_other_receipts")]
		public bool VisibleInOtherReceipts { get; set; }
		[JsonProperty("visible_in_reporting")]
		public bool VisibleInReporting { get; set; }
		[JsonProperty("visible_in_sales")]
		public bool VisibleInSales { get; set; }
		[JsonProperty("is_control_account")]
		public bool IsControlAccount { get; set; }
        [JsonProperty("control_name")]
		public string ControlName { get; set; }
		[JsonProperty("balance_details")]
		public BalanceDetails BalanceDetails { get; set; }
    }
}
