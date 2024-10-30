using System.Net.Http;

namespace SageOneApi.Client.Utils
{
	internal class HttpClientFactory
	{
		private static HttpClient _httpClient;

		public static HttpClient Create()
		{
			return _httpClient ??= new HttpClient();
		}
	}
}
