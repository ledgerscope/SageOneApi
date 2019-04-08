using Newtonsoft.Json;

namespace SageOneApi.Client.Models
{
    public class AllocatedArtefact
    {
		[JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("artefact")]
		public Artefact Artefact { get; set; }
		[JsonProperty("amount")]
		public decimal Amount { get; set; }
		[JsonProperty("discount")]
		public decimal? Discount { get; set; }
    }
}
