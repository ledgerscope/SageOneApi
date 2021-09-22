using System.Text.Json.Serialization;

namespace SageOneApi.Client.Models
{
	public class DefaultLedgerAccounts
	{
		[JsonPropertyName("bank_charges_ledger_account")]
		public PropertyValueWithPath BankChargesLedgerAccount { get; set; }
		[JsonPropertyName("bank_interest_charges_paid_ledger_account")]
		public PropertyValueWithPath BankInterestChargesPaidLedgerAccount { get; set; }
		[JsonPropertyName("bank_interest_received_ledger_account")]
		public PropertyValueWithPath BankInterestReceivedLedgerAccount { get; set; }
		[JsonPropertyName("carriage_ledger_account")]
		public PropertyValueWithPath CarriageLedgerAccount { get; set; }
		[JsonPropertyName("customer_receipt_discount_ledger_account")]
		public PropertyValueWithPath CustomerReceiptDiscountLedgerAccount { get; set; }
		[JsonPropertyName("exchange_rate_gains_ledger_account")]
		public PropertyValueWithPath ExchangeRateGainsLedgerAccount { get; set; }
		[JsonPropertyName("exchange_rate_losses_ledger_account")]
		public PropertyValueWithPath ExchangeRateLossesLedgerAccount { get; set; }
		[JsonPropertyName("other_payment_ledger_account")]
		public PropertyValueWithPath OtherPaymentLedgerAccount { get; set; }
		[JsonPropertyName("other_receipt_ledger_account")]
		public PropertyValueWithPath OtherReceiptLedgerAccount { get; set; }
		[JsonPropertyName("product_purchase_ledger_account")]
		public PropertyValueWithPath ProductPurchaseLedgerAccount { get; set; }
		[JsonPropertyName("product_sales_ledger_account")]
		public PropertyValueWithPath ProductSalesLedgerAccount { get; set; }
		[JsonPropertyName("purchase_discount_ledger_account")]
		public PropertyValueWithPath PurchaseDiscountLedgerAccount { get; set; }
		[JsonPropertyName("purchase_ledger_account")]
		public PropertyValueWithPath PurchaseLedgerAccount { get; set; }
		[JsonPropertyName("sales_discount_ledger_account")]
		public PropertyValueWithPath SalesDiscountLedgerAccount { get; set; }
		[JsonPropertyName("sales_ledger_account")]
		public PropertyValueWithPath SalesLedgerAccount { get; set; }
		[JsonPropertyName("service_sales_ledger_account")]
		public PropertyValueWithPath ServiceSalesLedgerAccount { get; set; }
		[JsonPropertyName("vendor_payment_discount_ledger_account")]
		public PropertyValueWithPath VendorPaymentDiscountLedgerAccount { get; set; }
	}
}
