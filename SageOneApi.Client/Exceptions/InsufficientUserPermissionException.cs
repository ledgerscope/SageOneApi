using System;
using System.Net;

namespace SageOneApi.Client.Exceptions
{
    public class InsufficientUserPermissionException : Exception
    {
        public WebException Exception { get; }

        public InsufficientUserPermissionException()
        {
        }

        public InsufficientUserPermissionException(WebException ex)
        {
            Exception = ex; 
        }

        public InsufficientUserPermissionException(string message) : base(message)
        {
        }

        public InsufficientUserPermissionException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InsufficientUserPermissionException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context)
        {
        }
    }
}
