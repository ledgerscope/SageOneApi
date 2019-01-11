namespace SageOneApi.Client.Models
{
    public class BankReconciliation : SageOneAccountingEntity
    {
        public BankAccount bank_account { get; set; }
        public string statement_date { get; set; }
        public string statement_end_balance { get; set; }
        public string reference { get; set; }
        public string total_received { get; set; }
        public string total_paid { get; set; }
        public string starting_balance { get; set; }
        public string closing_balance { get; set; }
        public string reconciled_balance { get; set; }
        public string balance_difference { get; set; }
        public PropertyValue status { get; set; }
    }
}
