using System.Text.Json.Serialization;

namespace SageOneApi.Client.Models
{
	public class BankReconciliation : SageOneAccountingEntity
	{
		[JsonPropertyName("bank_account")]
		public BankAccount BankAccount { get; set; }
		[JsonPropertyName("statement_date")]
		public string StatementDate { get; set; }
		[JsonPropertyName("statement_end_balance")]
		public string StatementEndBalance { get; set; }
		[JsonPropertyName("reference")]
		public string Reference { get; set; }
		[JsonPropertyName("total_received")]
		public string TotalReceived { get; set; }
		[JsonPropertyName("total_paid")]
		public string TotalPaid { get; set; }
		[JsonPropertyName("starting_balance")]
		public string StartingBalance { get; set; }
		[JsonPropertyName("closing_balance")]
		public string ClosingBalance { get; set; }
		[JsonPropertyName("reconciled_balance")]
		public string ReconciledBalance { get; set; }
		[JsonPropertyName("balance_difference")]
		public string BalanceDifference { get; set; }
		[JsonPropertyName("status")]
		public PropertyValue Status { get; set; }
	}
}
