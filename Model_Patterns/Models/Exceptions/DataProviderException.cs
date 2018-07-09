using System;
using System.Collections.Generic;
using System.Text;

namespace Model_Patterns.Models.Exceptions
{
    public class DataProviderException : Exception
    {
        public DataProviderException()
        {
        }
        public DataProviderException(string message) : base(message)
        {
        }
        public DataProviderException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
