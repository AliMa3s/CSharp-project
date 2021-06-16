using System;
using System.Collections.Generic;
using System.Text;

namespace AdresOef {
    public class GemException : AdresException {
        public GemException(string message) : base(message) {

        }
        public GemException(string message, Exception innerException) : base(message, innerException) {

        }
    }
}
