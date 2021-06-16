using System;
using System.Collections.Generic;
using System.Text;

namespace AdresSysteem
{
    public class AdresException : Exception
    {
        public AdresException(string message) : base(message)
        {
        }
        public AdresException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
