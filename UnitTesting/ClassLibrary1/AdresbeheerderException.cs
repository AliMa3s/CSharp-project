using System;
using System.Collections.Generic;
using System.Text;

namespace AdresSysteem
{
    public class AdresbeheerderException : Exception
    {
        public AdresbeheerderException(string message) : base(message)
        {
        }
        public AdresbeheerderException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
