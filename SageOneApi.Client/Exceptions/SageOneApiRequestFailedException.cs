using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SageOneApi.Client.Exceptions
{
	internal class SageOneApiRequestFailedException : Exception
	{
		public SageOneApiRequestFailedException(HttpResponseMessage response, string responseContent)
		{
			Response = response;
			ResponseContent = responseContent;
		}
		public  HttpResponseMessage Response { get; set; }

		public string ResponseContent { get; set; }
	}
}
