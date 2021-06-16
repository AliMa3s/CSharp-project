using System;
using System.Collections.Generic;
using System.Text;

namespace Scheepvaart.ExceptionsHandeling {
   public class TrajectException : Exception{
        public TrajectException() { }

        public TrajectException(string message) : base(message) { }
        public TrajectException(string message, Exception innerException) : base(message, innerException) { }
    }
}
