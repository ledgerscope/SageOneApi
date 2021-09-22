using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;

namespace SageOneApi.Client.Models
{
	public class TaxPercentage
	{
		[JsonPropertyName("percentage")]
		public string Percentage { get; set; }
		[JsonPropertyName("from_date")]
		public DateTime FromDate { get; set; }
		[JsonPropertyName("to_date")]
		public DateTime? ToDate { get; set; }
	}
}
