using System.Text.Json.Serialization;

namespace SageOneApi.Client.Models
{
    public class AnalysisTypeCategory : SageOneAccountingEntity
	{
		[JsonPropertyName("code")]
		public string Code { get; set; }
		[JsonPropertyName("name")]
		public string Name { get; set; }
        [JsonPropertyName("combined_id")]
        public string CombinedId { get; set; }
        [JsonPropertyName("analysis_type")]
        public PropertyValueWithPath AnalysisType { get; set; }
    }
}
