using Newtonsoft.Json;

namespace SageOneApi.Client.Models
{
	public class BankReconciliation : SageOneAccountingEntity
	{
		[JsonProperty("bank_account")]
		public BankAccount BankAccount { get; set; }
		[JsonProperty("statement_date")]
		public string StatementDate { get; set; }
		[JsonProperty("statement_end_balance")]
		public string StatementEndBalance { get; set; }
		[JsonProperty("reference")]
		public string Reference { get; set; }
		[JsonProperty("total_received")]
		public string TotalReceived { get; set; }
		[JsonProperty("total_paid")]
		public string TotalPaid { get; set; }
		[JsonProperty("starting_balance")]
		public string StartingBalance { get; set; }
		[JsonProperty("closing_balance")]
		public string ClosingBalance { get; set; }
		[JsonProperty("reconciled_balance")]
		public string ReconciledBalance { get; set; }
		[JsonProperty("balance_difference")]
		public string BalanceDifference { get; set; }
		[JsonProperty("status")]
		public PropertyValue Status { get; set; }
	}
}
