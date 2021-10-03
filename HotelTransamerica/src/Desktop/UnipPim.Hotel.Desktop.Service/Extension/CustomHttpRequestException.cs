using System;
using System.Net;
using System.Runtime.Serialization;

namespace UnipPim.Hotel.Desktop.Extension.Servicos
{
    [Serializable]
    internal class CustomHttpRequestException : Exception
    {
        private HttpStatusCode statusCode;

        public CustomHttpRequestException()
        {
        }

        public CustomHttpRequestException(HttpStatusCode statusCode)
        {
            this.statusCode = statusCode;
        }

        public CustomHttpRequestException(string message) : base(message)
        {
        }

        public CustomHttpRequestException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected CustomHttpRequestException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}