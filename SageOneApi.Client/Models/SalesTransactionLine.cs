namespace SageOneApi.Client.Models
{
    public class SalesTransactionLine : ControlTransactionLine
    {
        public string discount_amount { get; set; }
        public string base_currency_discount_amount { get; set; }
        public string discount_percentage { get; set; }
        public object eu_sales_description { get; set; }
    }
}
