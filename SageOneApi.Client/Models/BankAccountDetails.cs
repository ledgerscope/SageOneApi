using Newtonsoft.Json;

namespace SageOneApi.Client.Models
{
    public class BankAccountDetails
    {
		[JsonProperty("account_name")]
        public string AccountName { get; set; }
        [JsonProperty("account_number")]
		public string AccountNumber { get; set; }
		[JsonProperty("sort_code")]
		public string SortCode { get; set; }
		[JsonProperty("bic")]
		public string Bic { get; set; }
		[JsonProperty("iban")]
		public string Iban { get; set; }
    }
}
