using System;

namespace SageOneApi.Client.Exceptions
{
	public class IncompatibleEditionException : Exception
	{
		public IncompatibleEditionException(string message, Exception innerException) : base(message, innerException)
		{
		}
	}
}
