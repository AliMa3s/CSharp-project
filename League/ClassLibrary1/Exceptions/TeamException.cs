using System;
using System.Runtime.Serialization;

namespace ClassLibrary1 {
    [Serializable]
    internal class TeamException : Exception {
        public TeamException() {
        }

        public TeamException(string message) : base(message) {
        }

        public TeamException(string message, Exception innerException) : base(message, innerException) {
        }

        protected TeamException(SerializationInfo info, StreamingContext context) : base(info, context) {
        }
    }
}