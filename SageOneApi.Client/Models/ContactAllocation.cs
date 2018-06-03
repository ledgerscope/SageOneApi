using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace SageOneApi.Client.Models
{
    public class ContactAllocation : PropertyValueWithPath
    {
        public PropertyValueWithPath transaction { get; set; }
        public PropertyValueWithPath transaction_type { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public List<Link> links { get; set; }
        public DateTime date { get; set; }
        public Contact contact { get; set; }
        public List<AllocatedArtefact> allocated_artefacts { get; set; }
    }
}
