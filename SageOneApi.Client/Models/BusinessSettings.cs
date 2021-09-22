using System.Text.Json.Serialization;

namespace SageOneApi.Client.Models
{
	public class BusinessSettings : SageOneSingleAccountingEntity
	{
		[JsonPropertyName("country_of_registration")]
		public PropertyValueWithPath CountryOfRegistration { get; set; }
		[JsonPropertyName("default_ledger_accounts")]
		public DefaultLedgerAccounts DefaultLedgerAccounts { get; set; }
	}
}
