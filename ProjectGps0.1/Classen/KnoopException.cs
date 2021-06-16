using System;
using System.Runtime.Serialization;

namespace Classen {
    [Serializable]
    internal class KnoopException : Exception {
        public KnoopException() {
        }

        public KnoopException(string message) : base(message) {
        }

        public KnoopException(string message, Exception innerException) : base(message, innerException) {
        }

        protected KnoopException(SerializationInfo info, StreamingContext context) : base(info, context) {
        }
    }
}