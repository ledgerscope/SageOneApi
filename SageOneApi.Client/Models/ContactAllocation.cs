using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;

namespace SageOneApi.Client.Models
{
	public class ContactAllocation : DatedTransaction
	{
		[JsonPropertyName("links")]
		public List<Link> Links { get; set; }
		[JsonPropertyName("contact")]
		public Contact Contact { get; set; }
		[JsonPropertyName("allocated_artefacts")]
		public List<AllocatedArtefact> AllocatedArtefacts { get; set; }
	}
}
