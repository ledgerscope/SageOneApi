namespace SageOneApi.Client.Models
{
    public class JournalLine
    {
        public LedgerAccount ledger_account { get; set; }
        public string details { get; set; }
        public string debit { get; set; }
        public string credit { get; set; }
        public bool include_on_tax_return { get; set; }
    }
}
