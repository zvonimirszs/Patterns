using System;
using System.Collections.Generic;
using System.Text;

namespace Model_Patterns.Models.Exceptions
{
    public class CacheProviderException : Exception
    {
        public CacheProviderException()
        {
        }
        public CacheProviderException(string message) : base(message)
        {
        }
        public CacheProviderException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
