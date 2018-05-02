namespace SageOneApi.Client.Models
{
    public class AllocatedArtefact
    {
        public string id { get; set; }
        public Artefact artefact { get; set; }
        public decimal amount { get; set; }
        public decimal? discount { get; set; }
    }
}
