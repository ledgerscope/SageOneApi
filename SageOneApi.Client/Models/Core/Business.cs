using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SageOneApi.Client.Models.Core
{
    public class Business
    {
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public string displayed_as { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public string address_line_1 { get; set; }
        public string address_line_2 { get; set; }
        public string city { get; set; }
        public string postal_code { get; set; }
        public string country { get; set; }
        public string region { get; set; }
        public string telephone { get; set; }
        public string mobile { get; set; }
        public string website { get; set; }
        public bool is_demo { get; set; }
        public object subscriptions { get; set; }
    }
}
