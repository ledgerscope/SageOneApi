namespace SageOneApi.Client.Models
{
    public abstract class PurchaseTransaction : ControlTransaction
    {
        public string vendor_reference { get; set; }
    }
}
