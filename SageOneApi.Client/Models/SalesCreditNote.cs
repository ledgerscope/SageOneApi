using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace SageOneApi.Client.Models
{
    public class SalesCreditNote : SalesTransaction
    {
        public string credit_note_number { get; set; }
        public List<SalesTransactionLine> credit_note_lines { get; set; }
    }
}
