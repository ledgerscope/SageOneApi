using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SageOneApi.Client.Models
{
    public class Transaction : PropertyValueWithPath
    {
        public PropertyValueWithPath transaction { get; set; }
        public PropertyValueWithPath transaction_type { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }

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
