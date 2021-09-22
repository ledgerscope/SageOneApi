using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SageOneApi.Client.Models
{
	public class Journal : DatedTransaction
	{
		[JsonPropertyName("reference")]
		public string Reference { get; set; }
		[JsonPropertyName("description")]
		public string Description { get; set; }
		[JsonPropertyName("total")]
		public decimal Total { get; set; }
		[JsonPropertyName("journal_code")]
		public string JournalCode { get; set; }
		[JsonPropertyName("journal_lines")]
		public List<JournalLine> JournalLines { get; set; }
	}
}
