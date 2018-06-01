using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SageOneApi.Client.Models
{
    public class BusinessSettings
    {
        [JsonProperty("$path")]
        public string path { get; set; }

        public PropertyValueWithPath country_of_registration { get; set; }

        public DefaultLedgerAccounts default_ledger_accounts { get; set; }
    }
}
