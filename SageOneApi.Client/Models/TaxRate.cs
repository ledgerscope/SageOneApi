using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace SageOneApi.Client.Models
{
    public class TaxRate : SageOneAccountingEntity
    {
		[JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("agency")]
		public string Agency { get; set; }
		[JsonProperty("percentage")]
		public decimal? Percentage { get; set; }
		[JsonProperty("percentages")]
		public List<TaxPercentage> Percentages { get; set; }
		[JsonProperty("is_visible")]
		public bool IsVisible { get; set; }
		[JsonProperty("is_combined_rate")]
		public bool IsCombinedRate { get; set; }
		[JsonProperty("editable")]
		public bool Editable { get; set; }
		[JsonProperty("deletable")]
		public bool Deletable { get; set; }
    }
}
