using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;

namespace SageOneApi.Client.Models
{
	public class TaxRate : SageOneAccountingEntity
	{
		[JsonPropertyName("name")]
		public string Name { get; set; }
		[JsonPropertyName("agency")]
		public string Agency { get; set; }
		[JsonPropertyName("percentage")]
		[JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        public decimal? Percentage { get; set; }
		[JsonPropertyName("percentages")]
		public List<TaxPercentage> Percentages { get; set; }
		[JsonPropertyName("is_visible")]
		public bool IsVisible { get; set; }
		[JsonPropertyName("is_combined_rate")]
		public bool IsCombinedRate { get; set; }
		[JsonPropertyName("editable")]
		public bool Editable { get; set; }
		[JsonPropertyName("deletable")]
		public bool Deletable { get; set; }
	}
}
