using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace SageOneApi.Client.Models
{
    public class TaxPercentage
    {
        public string percentage { get; set; }
        public DateTime from_date { get; set; }
        public DateTime? to_date { get; set; }
    }
}
