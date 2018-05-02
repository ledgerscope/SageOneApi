namespace SageOneApi.Client.Models
{
    public class TaxAnalysis
    {
        public TaxRate tax_rate { get; set; }
        public decimal net_amount { get; set; }
        public decimal tax_amount { get; set; }
        public decimal total_amount { get; set; }
        public decimal goods_amount { get; set; }
        public decimal service_amount { get; set; }
    }
}
