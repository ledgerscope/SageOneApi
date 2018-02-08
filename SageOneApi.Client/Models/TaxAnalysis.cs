namespace SageOneApi.Client.Models
{
    public class TaxAnalysis
    {
        public PropertyValueWithPath tax_rate { get; set; }
        public string net_amount { get; set; }
        public string tax_amount { get; set; }
        public string total_amount { get; set; }
        public string goods_amount { get; set; }
        public string service_amount { get; set; }
    }
}
