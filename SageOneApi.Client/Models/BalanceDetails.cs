using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace SageOneApi.Client.Models
{
	public class BalanceDetails
	{
		[JsonPropertyName("balance")]
		public decimal Balance { get; set; }
		[JsonPropertyName("credit_or_debit")]
		public string CreditOrDebit { get; set; }
		[JsonPropertyName("credits")]
		public decimal Credits { get; set; }
		[JsonPropertyName("debits")]
		public decimal Debits { get; set; }
		[JsonPropertyName("from_date")]
		public string FromDate { get; set; }
		[JsonPropertyName("to_date")]
		public string ToDate { get; set; }
	}
}
