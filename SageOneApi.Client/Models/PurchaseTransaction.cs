namespace SageOneApi.Client.Models
{
    public abstract class PurchaseTransaction : ControlTransaction
    {
        public string vendor_reference { get; set; }
    }

    public class PurchaseTransactionLine : ControlTransactionLine
    {
        public bool is_purchase_for_resale { get; set; }
    }
}
