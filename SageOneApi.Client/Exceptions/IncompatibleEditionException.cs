using System;
using System.Net;

namespace SageOneApi.Client.Exceptions
{
	public class IncompatibleEditionException : WebException
	{
		public IncompatibleEditionException(string message, Exception innerException) : base(message, innerException)
		{
		}
	}
}
