using System;
using System.Runtime.Serialization;

namespace TeamsManager.Managers {
    [Serializable]
    internal class LeagueException : Exception {
        public LeagueException() {
        }

        public LeagueException(string message) : base(message) {
        }

        public LeagueException(string message, Exception innerException) : base(message, innerException) {
        }

        protected LeagueException(SerializationInfo info, StreamingContext context) : base(info, context) {
        }
    }
}