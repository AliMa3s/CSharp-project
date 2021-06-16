using System;
using System.Collections.Generic;
using System.Text;

namespace Scheepvaart.ExceptionsHandeling {
   public class RederijException : Exception{
        public RederijException() { }

        public RederijException(string message) : base(message) { }

        public RederijException(string message, Exception innerException) : base(message, innerException) { }
    }
}
