namespace SageOneApi.Client.Models
{
    public class BusinessSettings : SageOneEntity
    {
        public PropertyValueWithPath country_of_registration { get; set; }

        public DefaultLedgerAccounts default_ledger_accounts { get; set; }
    }
}
