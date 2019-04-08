using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SageOneApi.Client.Models
{
    public class BalanceDetails
    {
		[JsonProperty("balance")]
        public decimal Balance { get; set; }
        [JsonProperty("credit_or_debit")]
		public string CreditOrDebit { get; set; }
		[JsonProperty("credits")]
		public decimal Credits { get; set; }
		[JsonProperty("debits")]
		public decimal Debits { get; set; }
		[JsonProperty("from_date")]
		public string FromDate { get; set; }
		[JsonProperty("to_date")]
		public string ToDate { get; set; }
    }
}
