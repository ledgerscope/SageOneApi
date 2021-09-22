using System;
using System.Text.Json.Serialization;

namespace SageOneApi.Client.Models
{
	public class Transaction : DatedTransaction
	{
		[JsonPropertyName("reference")]
		public string Reference { get; set; }
		[JsonPropertyName("deleted")]
		public bool Deleted { get; set; }
		[JsonPropertyName("total")]
		public decimal? Total { get; set; }
		[JsonPropertyName("contact")]
		public Contact Contact { get; set; }
		[JsonPropertyName("origin")]
		public Artefact Origin { get; set; }
		[JsonPropertyName("audit_trail_id")]
		public string AuditTrailId { get; set; }
		[JsonPropertyName("number_of_attachments")]
		public int NumberOfAttachments { get; set; }
	}
}
