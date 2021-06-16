using System;
using System.Collections.Generic;
using System.Text;

namespace Scheepvaart.ExceptionsHandeling {
    public class SchipException : Exception {

        public SchipException() {

        }
        public SchipException(string message) : base(message) { }

        public SchipException(string message, Exception innerException) : base(message, innerException) { }

    }
}
