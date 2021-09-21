using Newtonsoft.Json;
using System;

namespace SageOneApi.Client.Models
{
	public abstract class DatedTransaction : SageOneAccountingEntity
	{
		[JsonProperty("transaction")]
		public PropertyValueWithPath Transaction { get; set; }

		[JsonProperty("transaction_type")]
		public PropertyValueWithPath TransactionType { get; set; }

		[JsonProperty("date")]
		public DateTime Date { get; set; }
	}
}
