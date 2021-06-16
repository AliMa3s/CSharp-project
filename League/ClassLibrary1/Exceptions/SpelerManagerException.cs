using System;
using System.Runtime.Serialization;

namespace TeamsManager.Managers {
    [Serializable]
    internal class SpelerManagerException : Exception {
        public SpelerManagerException() {
        }

        public SpelerManagerException(string message) : base(message) {
        }

        public SpelerManagerException(string message, Exception innerException) : base(message, innerException) {
        }

        protected SpelerManagerException(SerializationInfo info, StreamingContext context) : base(info, context) {
        }
    }
}