using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SageOneApi.Client.Responses
{
    public class OAuth2TokenResponse
    {
        public string access_token { get; set; }
        public string token_type { get; set; }
        public int expires_in { get; set; }
        public string refresh_token { get; set; }

        public string error { get; set; }
        public string error_description { get; set; }

        // not used by all OAuth 2.0 implementations
        public string resource_owner_id { get; set; }
    }
}
