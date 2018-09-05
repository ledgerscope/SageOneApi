namespace SageOneApi.Client.Models
{
    public class SalesTransactionLine : ControlTransactionLine
    {
        public decimal discount_amount { get; set; }
        public decimal base_currency_discount_amount { get; set; }
        public decimal discount_percentage { get; set; }
        public PropertyValueWithPath eu_sales_description { get; set; }
    }
}
