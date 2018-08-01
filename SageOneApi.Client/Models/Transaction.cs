using System;

namespace SageOneApi.Client.Models
{
    public class Transaction : SageOneAccountingEntity
    {
        public PropertyValueWithPath transaction { get; set; }
        public PropertyValueWithPath transaction_type { get; set; }
        public DateTime date { get; set; }
        public string reference { get; set; }
        public bool deleted { get; set; }
        public decimal? total { get; set; }
        public Contact contact { get; set; }
        public Artefact origin { get; set; }
        public string audit_trail_id { get; set; }
        public int number_of_attachments { get; set; }
    }
}
