namespace SageOneApi.Client.Models
{
    public class AllocatedArtefact
    {
        public string id { get; set; }
        public Artefact artefact { get; set; }
        public string amount { get; set; }
        public string discount { get; set; }
    }
}
