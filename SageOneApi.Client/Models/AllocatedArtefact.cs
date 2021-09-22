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
		public decimal Amount { get; set; }
		[JsonPropertyName("discount")]
		public decimal? Discount { get; set; }
	}
}
