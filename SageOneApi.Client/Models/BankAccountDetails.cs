using System.Text.Json.Serialization;

namespace SageOneApi.Client.Models
{
	public class BankAccountDetails
	{
		[JsonPropertyName("account_name")]
		public string AccountName { get; set; }
		[JsonPropertyName("account_number")]
		public string AccountNumber { get; set; }
		[JsonPropertyName("sort_code")]
		public string SortCode { get; set; }
		[JsonPropertyName("bic")]
		public string Bic { get; set; }
		[JsonPropertyName("iban")]
		public string Iban { get; set; }
	}
}
