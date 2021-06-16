using System;
using System.Collections.Generic;
using System.Text;

namespace Scheepvaart.ExceptionsHandeling {
    public class HavenException : Exception{
        public HavenException() { }

        public HavenException(string message) : base(message) { }

        public HavenException(string message, Exception innerException) : base(message, innerException) { }
    }
}
