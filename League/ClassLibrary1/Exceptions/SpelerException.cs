using System;
using System.Runtime.Serialization;

namespace ClassLibrary1 {
    [Serializable]
    internal class SpelerException : Exception {
        public SpelerException() {
        }

        public SpelerException(string message) : base(message) {
        }

        public SpelerException(string message, Exception innerException) : base(message, innerException) {
        }

        protected SpelerException(SerializationInfo info, StreamingContext context) : base(info, context) {
        }
    }
}