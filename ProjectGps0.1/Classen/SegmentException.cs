using System;
using System.Runtime.Serialization;

namespace Classen {
    [Serializable]
    internal class SegmentException : Exception {
        public SegmentException() {
        }

        public SegmentException(string message) : base(message) {
        }

        public SegmentException(string message, Exception innerException) : base(message, innerException) {
        }

        protected SegmentException(SerializationInfo info, StreamingContext context) : base(info, context) {
        }
    }
}