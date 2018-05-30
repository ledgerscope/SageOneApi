using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SageOneApi.Client.Models
{
    public class BalanceDetails
    {
        public decimal balance { get; set; }

        public string credit_or_debit { get; set; }

        public decimal credits { get; set; }
        public decimal debits { get; set; }

        public string from_date { get; set; }
        public string to_date { get; set; }
    }
}
