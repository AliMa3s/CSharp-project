using System;
using System.Runtime.Serialization;

namespace AdresSysteem
{
   public class HuisnummerException : AdresException
    {
        public HuisnummerException(string message) : base(message)
        {
        }

        public HuisnummerException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}