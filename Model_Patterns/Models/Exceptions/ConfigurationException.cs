using System;
using System.Collections.Generic;
using System.Text;

namespace Model_Patterns.Models.Exceptions
{
    public class ConfigurationException : Exception
    {
        public ConfigurationException()
        {
        }
        public ConfigurationException(string message) : base(message)
        {
        }
        public ConfigurationException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
