using Newtonsoft.Json;

namespace SageOneApi.Client.Models
{
	public class BusinessSettings : SageOneSingleAccountingEntity
	{
		[JsonProperty("country_of_registration")]
		public PropertyValueWithPath CountryOfRegistration { get; set; }
		[JsonProperty("default_ledger_accounts")]
		public DefaultLedgerAccounts DefaultLedgerAccounts { get; set; }
	}
}
