using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SageOneApi.Client.Models
{
    public class DefaultLedgerAccounts
    {
        public PropertyValueWithPath bank_charges_ledger_account { get; set; }
        public PropertyValueWithPath bank_interest_charges_paid_ledger_account { get; set; }
        public PropertyValueWithPath bank_interest_received_ledger_account { get; set; }
        public PropertyValueWithPath carriage_ledger_account { get; set; }
        public PropertyValueWithPath customer_receipt_discount_ledger_account { get; set; }
        public PropertyValueWithPath exchange_rate_gains_ledger_account { get; set; }
        public PropertyValueWithPath exchange_rate_losses_ledger_account { get; set; }
        public PropertyValueWithPath other_payment_ledger_account { get; set; }
        public PropertyValueWithPath other_receipt_ledger_account { get; set; }
        public PropertyValueWithPath product_purchase_ledger_account { get; set; }
        public PropertyValueWithPath product_sales_ledger_account { get; set; }
        public PropertyValueWithPath purchase_discount_ledger_account { get; set; }
        public PropertyValueWithPath purchase_ledger_account { get; set; }
        public PropertyValueWithPath sales_discount_ledger_account { get; set; }
        public PropertyValueWithPath sales_ledger_account { get; set; }
        public PropertyValueWithPath service_sales_ledger_account { get; set; }
        public PropertyValueWithPath vendor_payment_discount_ledger_account { get; set; }
    }
}
