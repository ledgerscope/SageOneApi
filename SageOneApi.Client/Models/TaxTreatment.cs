namespace SageOneApi.Client.Models
{
    public class TaxTreatment
    {
        public bool home_tax { get; set; }
        public bool eu_tax_registered { get; set; }
        public bool eu_not_tax_registered { get; set; }
        public bool rest_of_world_tax { get; set; }
    }
}
