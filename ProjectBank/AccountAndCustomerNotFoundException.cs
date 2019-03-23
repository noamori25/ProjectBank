using System;
using System.Runtime.Serialization;

namespace ProjectBank
{
    [Serializable]
    internal class AccountAndCustomerNotFoundException : ApplicationException
    {
        public AccountAndCustomerNotFoundException()
        {
        }

        public AccountAndCustomerNotFoundException(string message) : base(message)
        {
        }

        public AccountAndCustomerNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected AccountAndCustomerNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}