using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SageOneApi.Client.Constants
{
    public static class AuthRequestParams
    {
        public static readonly string ClientId = "client_id";
        public static readonly string ClientSecret = "client_secret";
        public static readonly string RedirectUri = "redirect_uri";
        public static readonly string ResponseType = "response_type";
        public static readonly string Scope = "scope";
        public static readonly string ForceLogin = "force_login";
        public static readonly string GrantType = "grant_type";
        public static readonly string Code = "code";
        public static readonly string AuthorisationCode = "authorization_code";
        public static readonly string RefreshToken = "refresh_token";
        public static readonly string State = "state";
        public static readonly string Token = "token";
    }
}
