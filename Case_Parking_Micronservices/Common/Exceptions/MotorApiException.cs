using System;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization;

namespace Case_Parking_Microservices.Common.Exceptions
{
    [Serializable]
    internal class MotorApiException : Exception
    {
        private HttpStatusCode StatusCode { get; }
        private HttpContent Content { get; }

        public MotorApiException()
        {
        }

        public MotorApiException(string? message) : base(message)
        {
        }

        public MotorApiException(HttpStatusCode statusCode, HttpContent content)
        {
            this.StatusCode = statusCode;
            this.Content = content;
        }

        public MotorApiException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected MotorApiException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
