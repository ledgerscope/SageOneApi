using Newtonsoft.Json;

namespace SageOneApi.Client.Models
{
    public class PurchaseTransactionLine : ControlTransactionLine
    {
		[JsonProperty("is_purchase_for_resale")]
        public bool IsPurchaseForResale { get; set; }
    }
}
