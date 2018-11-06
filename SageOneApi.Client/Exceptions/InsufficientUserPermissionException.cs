using System;
using System.Net;

namespace SageOneApi.Client.Exceptions
{
    public class InsufficientUserPermissionException : WebException
    {
        public InsufficientUserPermissionException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
