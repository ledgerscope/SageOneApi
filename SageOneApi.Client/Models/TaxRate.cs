using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace SageOneApi.Client.Models
{
    public class TaxRate : SageOneEntity
    {
        public string name { get; set; }
        public string agency { get; set; }
        public decimal? percentage { get; set; }
        public List<TaxPercentage> percentages { get; set; }
        public bool is_visible { get; set; }
        public bool is_combined_rate { get; set; }
        public bool editable { get; set; }
        public bool deletable { get; set; }
    }
}
