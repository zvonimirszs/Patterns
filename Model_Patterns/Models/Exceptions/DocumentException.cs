using System;
using System.Collections.Generic;
using System.Text;

namespace Model_Patterns.Models.Exceptions
{
    public class DocumentException : Exception
    {
        public DocumentException()
        {
        }
        public DocumentException(string message) : base(message)
        {
        }
        public DocumentException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
