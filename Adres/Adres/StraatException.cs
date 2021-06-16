using System;
using System.Collections.Generic;
using System.Text;

namespace AdresOef {
    public class StraatException : AdresException{
        public StraatException(string message) : base(message) {

        }
        public StraatException(string message, Exception innerException) : base(message, innerException) {

        }
    }
}
