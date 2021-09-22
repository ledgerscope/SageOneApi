using System.Text.Json.Serialization;

namespace SageOneApi.Client.Models
{
	public class PurchaseTransactionLine : ControlTransactionLine
	{
		[JsonPropertyName("is_purchase_for_resale")]
		public bool IsPurchaseForResale { get; set; }
	}
}
