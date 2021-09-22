using System.Text.Json.Serialization;

namespace SageOneApi.Client.Models
{
	public abstract class PurchaseTransaction : ControlTransaction
	{
		[JsonPropertyName("vendor_reference")]
		public string VendorReference { get; set; }
	}
}
