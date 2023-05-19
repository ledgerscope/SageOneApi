using System.Text.Json.Serialization;

namespace SageOneApi.Client.Models
{
    /// <summary>Analysis Type Level denotes if the type is a Transactional or Group analysis Type. The Id is 1 for Transactions and 2 for Group.</summary>
    public class AnalysisTypeLevel
	{
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("identifier")]
        public string Identifier { get; set; }
    }
}
