using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace SageOneApi.Client.Models
{
    public class TaxRate : PropertyValueWithPath
    {
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public string name { get; set; }
        public string agency { get; set; }
        public decimal? percentage { get; set; }
        public List<Percentage> percentages { get; set; }
        public bool is_visible { get; set; }
        public bool is_combined_rate { get; set; }
        public bool editable { get; set; }
        public bool deletable { get; set; }
    }

    public class Percentage
    {
        public string percentage { get; set; }
        public DateTime from_date { get; set; }
        public DateTime? to_date { get; set; }
    }
}
