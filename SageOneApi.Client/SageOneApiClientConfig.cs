namespace SageOneApi.Client
{
	public class SageOneApiClientConfig
	{
		public int PageSize { get; }

		public SageOneApiClientConfig(int pageSize = 50)
		{
			PageSize = pageSize;
		}

		public static SageOneApiClientConfig Default => new SageOneApiClientConfig();
	}
}
