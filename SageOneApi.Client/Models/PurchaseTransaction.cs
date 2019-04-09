using Newtonsoft.Json;

namespace SageOneApi.Client.Models
{
    public abstract class PurchaseTransaction : ControlTransaction
    {
	    [JsonProperty("vendor_reference")]
		public string VendorReference { get; set; }
    }
}
