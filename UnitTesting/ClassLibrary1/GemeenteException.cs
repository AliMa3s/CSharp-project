using System;
using System.Collections.Generic;
using System.Text;

namespace AdresSysteem
{
    public class GemeenteException : AdresException
    {
        public GemeenteException(string message) : base(message)
        {
        }
        public GemeenteException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
