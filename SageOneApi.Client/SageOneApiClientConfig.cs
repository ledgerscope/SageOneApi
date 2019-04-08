using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SageOneApi.Client
{
    public class SageOneApiClientConfig
    {
        public int PageSize { get; set; }

        public static SageOneApiClientConfig Default => new SageOneApiClientConfig()
        {
            PageSize = 100,
        };
    }
}
