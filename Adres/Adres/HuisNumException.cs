using System;
using System.Collections.Generic;
using System.Text;

namespace AdresOef {
    public class HuisNumException : AdresException{
        public HuisNumException(string message) : base(message) {

        }
        public HuisNumException(string message, Exception innerException) : base(message, innerException) {

        }
    }
}

