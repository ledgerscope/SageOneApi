namespace SageOneApi.Client.Constants
{
    public static class TransactionType
    {
        public const string SalesInvoice = "SALES_INVOICE";
        public const string SalesCreditNote = "SALES_CREDIT_NOTE";
        public const string PurchaseInvoice = "PURCHASE_INVOICE";
        public const string PurchaseCreditNote = "PURCHASE_CREDIT_NOTE";
        public const string CustomerReceipt = "CUSTOMER_RECEIPT";
        public const string CustomerRefund = "CUSTOMER_REFUND";
        public const string VendorPayment = "VENDOR_PAYMENT";
        public const string VendorRefund = "VENDOR_REFUND";
        public const string OtherReceipt = "OTHER_RECEIPT";
        public const string OtherPayment = "OTHER_PAYMENT";
        public const string OtherPaymentRefund = "OTHER_PAYMENT_REFUND";
        public const string TaxReturn = "TAX_RETURN";
        public const string TaxPayment = "TAX_PAYMENT";
        public const string BankReceipt = "BANK_RECEIPT";
    }
}
