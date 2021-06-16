using System;

namespace AdresSysteem
{
    public class StraatnaamException : AdresException
    {
        public StraatnaamException(string message) : base(message)
        {
        }
        public StraatnaamException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}