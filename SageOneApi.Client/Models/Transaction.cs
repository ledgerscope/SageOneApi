using System;
using Newtonsoft.Json;

namespace SageOneApi.Client.Models
{
	public class Transaction : DatedTransaction
	{
		[JsonProperty("reference")]
		public string Reference { get; set; }
		[JsonProperty("deleted")]
		public bool Deleted { get; set; }
		[JsonProperty("total")]
		public decimal? Total { get; set; }
		[JsonProperty("contact")]
		public Contact Contact { get; set; }
		[JsonProperty("origin")]
		public Artefact Origin { get; set; }
		[JsonProperty("audit_trail_id")]
		public string AuditTrailId { get; set; }
		[JsonProperty("number_of_attachments")]
		public int NumberOfAttachments { get; set; }
	}
}
