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
