using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace SageOneApi.Client.Models
{
	public class ContactAllocation : DatedTransaction
	{
		[JsonProperty("links")]
		public List<Link> Links { get; set; }
		[JsonProperty("contact")]
		public Contact Contact { get; set; }
		[JsonProperty("allocated_artefacts")]
		public List<AllocatedArtefact> AllocatedArtefacts { get; set; }
	}
}
