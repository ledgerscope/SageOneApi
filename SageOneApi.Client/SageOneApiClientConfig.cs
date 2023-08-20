using System;

namespace SageOneApi.Client
{
	public class SageOneApiClientConfig
	{
		/// <summary>
		/// Default items per page for each request.
		/// </summary>
		/// <remarks>Can be overridden if you supply items_per_page item in the query parameters.</remarks>
		public int PageSize { get; }

		public Uri BaseUri { get; }

		public Uri AccessTokenUri { get; }

		public string? ClientId { get; }

		internal string? ClientSecret { get; }

		public SageOneApiClientConfig(int pageSize = 50, Uri? baseUri = null, Uri? accessTokenUri = null, string? clientId = null, string? clientSecret = null)
		{
			PageSize = pageSize;
			BaseUri = baseUri ?? new Uri("https://api.accounting.sage.com/v3.1");
			AccessTokenUri = accessTokenUri ?? new Uri("https://oauth.accounting.sage.com/token");

			ClientId = clientId;
			ClientSecret = clientSecret;
		}

		public static SageOneApiClientConfig Default => new SageOneApiClientConfig();
	}
}
