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
		public SageOneApiRequestFailedException(HttpResponseMessage response)
		{
			Response = response;
		}
		public  HttpResponseMessage Response { get; set; }
	}
}
