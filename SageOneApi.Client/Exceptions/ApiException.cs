using System;
using System.Net;

namespace SageOneApi.Client.Exceptions
{
    public class ApiException : WebException
    {
        public ApiException()
        {
        }

        public ApiException(string message) : base(message)
        {
        }

        public ApiException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public ApiException(string message, WebExceptionStatus status) : base(message, status)
        {
        }

        public ApiException(string message, Exception innerException, WebExceptionStatus status, WebResponse response) : base(message, innerException, status, response)
        {
        }

        protected ApiException(System.Runtime.Serialization.SerializationInfo serializationInfo, System.Runtime.Serialization.StreamingContext streamingContext) : base(serializationInfo, streamingContext)
        {
        }
    }
}
