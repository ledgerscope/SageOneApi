using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace SageOneApi.Client.Exceptions
{
	public class SageOneApiRequestFailedException : Exception
	{
		public SageOneApiRequestFailedException(HttpStatusCode statusCode, HttpResponseHeaders headers, string responseContent)
		{
            StatusCode = statusCode;
            Headers = headers;
            ResponseContent = responseContent;
		}

        public HttpStatusCode StatusCode { get; }
        public HttpResponseHeaders Headers { get; }
        public string ResponseContent { get; }
	}
}
