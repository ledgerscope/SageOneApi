using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;

namespace SageOneApi.Client.Models
{
    ///<Summary>
    /// Complete documentation can be found <see href="https://developer.sage.com/accounting/guides/concepts/analysis_types/">here</see>
    ///</Summary>
    public class AnalysisType : SageOneAccountingEntity
	{
		[JsonPropertyName("active_areas")]
		public List<string> ActiveAreas { get; set; }
		[JsonPropertyName("analysis_type_level")]
		public AnalysisTypeLevel AnalysisTypeLevel { get; set; }
        [JsonPropertyName("analysis_type_categories")]
        public List<AnalysisTypeCategory> AnalysisTypeCategories { get; set; }
        [JsonPropertyName("name")]
		public string Name { get; set; }
	}
}
