using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SageOneApi.Client.Utils
{
	internal class HttpClientFactory
	{
		private static HttpClient _httpClient;

		public static HttpClient Create()
		{
			return _httpClient ?? (_httpClient = new HttpClient());
		}
	}
}
