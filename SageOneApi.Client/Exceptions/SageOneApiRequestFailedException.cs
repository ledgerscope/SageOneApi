using System;
using System.Net.Http;

namespace SageOneApi.Client.Exceptions
{
	public class SageOneApiRequestFailedException : Exception
	{
		public SageOneApiRequestFailedException(HttpResponseMessage response, string responseContent)
		{
			Response = response;
			ResponseContent = responseContent;
		}

		public HttpResponseMessage Response { get; set; }

		public string ResponseContent { get; set; }
	}
}
