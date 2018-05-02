namespace SageOneApi.Client.Models
{
    public class BankAccountDetails
    {
        public string account_name { get; set; }
        public string account_number { get; set; }
        public string sort_code { get; set; }
        public string bic { get; set; }
        public string iban { get; set; }
    }
}
