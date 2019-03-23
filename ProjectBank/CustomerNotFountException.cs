using System;
using System.Runtime.Serialization;

namespace ProjectBank
{
    [Serializable]
    internal class CustomerNotFountException : ApplicationException
    {
        public CustomerNotFountException()
        {
        }

        public CustomerNotFountException(string message) : base(message)
        {
        }

        public CustomerNotFountException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected CustomerNotFountException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}