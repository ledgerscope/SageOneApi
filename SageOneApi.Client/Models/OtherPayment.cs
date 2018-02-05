using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace SageOneApi.Client.Models
{
    public class OtherPayment
    {
        public string id { get; set; }
        public string displayed_as { get; set; }
        [JsonProperty("$path")]
        public string path { get; set; }
        public Transaction transaction { get; set; }
        public TransactionType transaction_type { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public PaymentMethod payment_method { get; set; }
        public Contact contact { get; set; }
        public BankAccount bank_account { get; set; }
        public object tax_address_region { get; set; }
        public string date { get; set; }
        public string net_amount { get; set; }
        public string tax_amount { get; set; }
        public string total_amount { get; set; }
        public string reference { get; set; }
        public List<PaymentLine> payment_lines { get; set; }
        public bool editable { get; set; }
        public bool deletable { get; set; }
        public object withholding_tax_rate { get; set; }
        public object withholding_tax_amount { get; set; }
    }

    public class PaymentLine
    {
        public string id { get; set; }
        public string displayed_as { get; set; }
        public LedgerAccount ledger_account { get; set; }
        public string details { get; set; }
        public TaxRate tax_rate { get; set; }
        public string net_amount { get; set; }
        public string tax_amount { get; set; }
        public string total_amount { get; set; }
        public List<TaxBreakdown> tax_breakdown { get; set; }
        public bool is_purchase_for_resale { get; set; }
    }
}
