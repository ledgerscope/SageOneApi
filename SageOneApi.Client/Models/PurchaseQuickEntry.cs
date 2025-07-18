using System.Text.Json.Serialization;

namespace SageOneApi.Client.Models
{
	public class PurchaseQuickEntry : QuickEntry
	{
        [JsonPropertyName("pst_amount")]
        public decimal? PstAmount { get; set; }

        [JsonPropertyName("gst_amount")]
        public decimal? GstAmount { get; set; }

        [JsonPropertyName("tax_recoverable")]
        public bool? TaxRecoverable { get; set; }
    }
}
