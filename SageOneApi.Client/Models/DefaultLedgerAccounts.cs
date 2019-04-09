using Newtonsoft.Json;

namespace SageOneApi.Client.Models
{
    public class DefaultLedgerAccounts
    {
	    [JsonProperty("bank_charges_ledger_account")]
		public PropertyValueWithPath BankChargesLedgerAccount { get; set; }
		[JsonProperty("bank_interest_charges_paid_ledger_account")]
		public PropertyValueWithPath BankInterestChargesPaidLedgerAccount { get; set; }
		[JsonProperty("bank_interest_received_ledger_account")]
		public PropertyValueWithPath BankInterestReceivedLedgerAccount { get; set; }
		[JsonProperty("carriage_ledger_account")]
		public PropertyValueWithPath CarriageLedgerAccount { get; set; }
		[JsonProperty("customer_receipt_discount_ledger_account")]
		public PropertyValueWithPath CustomerReceiptDiscountLedgerAccount { get; set; }
		[JsonProperty("exchange_rate_gains_ledger_account")]
		public PropertyValueWithPath ExchangeRateGainsLedgerAccount { get; set; }
		[JsonProperty("exchange_rate_losses_ledger_account")]
		public PropertyValueWithPath ExchangeRateLossesLedgerAccount { get; set; }
		[JsonProperty("other_payment_ledger_account")]
		public PropertyValueWithPath OtherPaymentLedgerAccount { get; set; }
		[JsonProperty("other_receipt_ledger_account")]
		public PropertyValueWithPath OtherReceiptLedgerAccount { get; set; }
		[JsonProperty("product_purchase_ledger_account")]
		public PropertyValueWithPath ProductPurchaseLedgerAccount { get; set; }
		[JsonProperty("product_sales_ledger_account")]
		public PropertyValueWithPath ProductSalesLedgerAccount { get; set; }
		[JsonProperty("purchase_discount_ledger_account")]
		public PropertyValueWithPath PurchaseDiscountLedgerAccount { get; set; }
		[JsonProperty("purchase_ledger_account")]
		public PropertyValueWithPath PurchaseLedgerAccount { get; set; }
		[JsonProperty("sales_discount_ledger_account")]
		public PropertyValueWithPath SalesDiscountLedgerAccount { get; set; }
		[JsonProperty("sales_ledger_account")]
		public PropertyValueWithPath SalesLedgerAccount { get; set; }
		[JsonProperty("service_sales_ledger_account")]
		public PropertyValueWithPath ServiceSalesLedgerAccount { get; set; }
		[JsonProperty("vendor_payment_discount_ledger_account")]
		public PropertyValueWithPath VendorPaymentDiscountLedgerAccount { get; set; }
    }
}
