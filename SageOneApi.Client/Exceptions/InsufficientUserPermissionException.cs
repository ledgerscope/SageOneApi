using System;

namespace SageOneApi.Client.Exceptions
{
	public class InsufficientUserPermissionException : Exception
	{
		public InsufficientUserPermissionException(string message, Exception innerException) : base(message, innerException)
		{
		}
	}
}
