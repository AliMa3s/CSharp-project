using System;
using System.Collections.Generic;
using System.Text;

namespace AdresOef {
    public class AdresBeheerException : Exception {

        public AdresBeheerException(string message): base(message) {

        }
        public AdresBeheerException(string message, Exception innerException) : base(message, innerException) {

        }

    }
}
