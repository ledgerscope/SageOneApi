using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace SageOneApi.Client.Models
{
	public class Journal : DatedTransaction
	{
		[JsonProperty("reference")]
		public string Reference { get; set; }
		[JsonProperty("description")]
		public string Description { get; set; }
		[JsonProperty("total")]
		public decimal Total { get; set; }
		[JsonProperty("journal_code")]
		public string JournalCode { get; set; }
		[JsonProperty("journal_lines")]
		public List<JournalLine> JournalLines { get; set; }
	}
}
