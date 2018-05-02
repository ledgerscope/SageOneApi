namespace SageOneApi.Client.Models
{
    public class Tax
    {
        public TaxRate tax_rate { get; set; }
        public decimal percentage { get; set; }
        public decimal amount { get; set; }
    }
}
