namespace SageOneApi.Client.Models
{
    public class JournalLine
    {
        public LedgerAccount ledger_account { get; set; }
        public string details { get; set; }
        public decimal debit { get; set; }
        public decimal credit { get; set; }
        public bool include_on_tax_return { get; set; }
    }
}
