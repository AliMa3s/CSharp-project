using System;
using System.Collections.Generic;
using System.Text;

namespace Scheepvaart.ExceptionsHandeling {
   public class VlootException : Exception{
        public VlootException() { }

        public VlootException(string message) : base(message) { }
        public VlootException(string message, Exception innerException) : base(message, innerException) { }
    }
}
