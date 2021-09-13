using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace SageOneApi.Client.Models
{
	public class TaxPercentage
	{
		[JsonProperty("percentage")]
		public string Percentage { get; set; }
		[JsonProperty("from_date")]
		public DateTime FromDate { get; set; }
		[JsonProperty("to_date")]
		public DateTime? ToDate { get; set; }
	}
}
