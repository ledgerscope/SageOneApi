using SageOneApi.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SageOneApi.Client
{
    public class ContactPerson : SageOneAccountingEntity
    {
        public string name { get; set; }
        public string job_title { get; set; }
        public string telephone { get; set; }
        public string mobile { get; set; }
        public string email { get; set; }
        public string fax { get; set; }
        public bool is_mail_contact { get; set; }
        public bool is_preferred_contact { get; set; }
        public Address address { get; set; }
        public DateTime? deleted_at { get; set; }
    }
}
