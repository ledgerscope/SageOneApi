using System.Text.Json.Serialization;
using System;

namespace SageOneApi.Client.Models
{
	public abstract class DatedTransaction : SageOneAccountingEntity
	{
		[JsonPropertyName("transaction")]
		public PropertyValueWithPath Transaction { get; set; }

		[JsonPropertyName("transaction_type")]
		public PropertyValueWithPath TransactionType { get; set; }

		[JsonPropertyName("date")]
		public DateTime Date { get; set; }
	}
}
