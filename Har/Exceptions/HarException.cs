using System;
using System.Runtime.Serialization;

namespace Har.Exceptions
{
    [Serializable]
    public class HarException : Exception
    {
        public HarException()
        {
        }

        public HarException(string message) : base(message)
        {
        }

        public HarException(string messageFormat, params object[] args)
            : base(string.Format(messageFormat, args))
        {
        }

        protected HarException(SerializationInfo
            info, StreamingContext context)
            : base(info, context)
        {
        }

        public HarException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
