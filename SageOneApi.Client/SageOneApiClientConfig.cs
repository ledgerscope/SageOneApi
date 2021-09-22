namespace SageOneApi.Client
{
	public class SageOneApiClientConfig
	{
		/// <summary>
		/// Default items per page for each request.
		/// </summary>
		/// <remarks>Can be overridden if you supply items_per_page item in the query parameters.</remarks>
		public int PageSize { get; }

		public SageOneApiClientConfig(int pageSize = 50)
		{
			PageSize = pageSize;
		}

		public static SageOneApiClientConfig Default => new SageOneApiClientConfig();
	}
}
