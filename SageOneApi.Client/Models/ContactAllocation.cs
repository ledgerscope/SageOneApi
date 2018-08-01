using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace SageOneApi.Client.Models
{
    public class ContactAllocation : SageOneAccountingEntity
    {
        public PropertyValueWithPath transaction { get; set; }
        public PropertyValueWithPath transaction_type { get; set; }
        public List<Link> links { get; set; }
        public DateTime date { get; set; }
        public Contact contact { get; set; }
        public List<AllocatedArtefact> allocated_artefacts { get; set; }
    }
}
