using System.Text.Json.Serialization;

namespace SageOneApi.Client.Models
{
	public class AllocatedArtefact
	{
		[JsonPropertyName("id")]
		public string Id { get; set; }
		[JsonPropertyName("artefact")]
		public Artefact Artefact { get; set; }
		[JsonPropertyName("amount")]
		[JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        public decimal Amount { get; set; }
		[JsonPropertyName("discount")]
		[JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        public decimal? Discount { get; set; }
	}
}
