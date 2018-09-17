using System;
using System.Net;

namespace SageOneApi.Client.Exceptions
{
    public class InsufficientUserPermissionException : WebException
    {
        public InsufficientUserPermissionException()
        {
        }

        public InsufficientUserPermissionException(string message) : base(message)
        {
        }

        public InsufficientUserPermissionException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public InsufficientUserPermissionException(string message, WebExceptionStatus status) : base(message, status)
        {
        }

        public InsufficientUserPermissionException(string message, Exception innerException, WebExceptionStatus status, WebResponse response) : base(message, innerException, status, response)
        {
        }

        protected InsufficientUserPermissionException(System.Runtime.Serialization.SerializationInfo serializationInfo, System.Runtime.Serialization.StreamingContext streamingContext) : base(serializationInfo, streamingContext)
        {
        }
    }
}
