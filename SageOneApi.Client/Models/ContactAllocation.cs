using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace SageOneApi.Client.Models
{
    public class ContactAllocation : SageOneAccountingEntity
    {
		[JsonProperty("transaction")]
        public PropertyValueWithPath Transaction { get; set; }
        [JsonProperty("transaction_type")]
		public PropertyValueWithPath TransactionType { get; set; }
		[JsonProperty("links")]
		public List<Link> Links { get; set; }
		[JsonProperty("date")]
		public DateTime Date { get; set; }
		[JsonProperty("contact")]
		public Contact Contact { get; set; }
		[JsonProperty("allocated_artefacts")]
		public List<AllocatedArtefact> AllocatedArtefacts { get; set; }
    }
}
