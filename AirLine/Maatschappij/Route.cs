using System;
using System.Collections.Generic;
using System.Text;

namespace Maatschappij {
    public class Route {
        public Route(string departure, string arrival, double distance) {
            Departure = departure;
            Arrival = arrival;
            Distance = distance;
        }

        public Route(string departure, string arrival, double distance, List<string> stopOvers) : this(departure, arrival, distance) {
            StopOvers = stopOvers;
        }

        public string Departure { get; private set; }
        public string Arrival { get; private set; }
        public double Distance { get; private set; } //km
        public List<string> StopOvers { get; private set; } = new List<string>();
        public void AddStopOver(string airport) {
            if (!StopOvers.Contains(airport)) StopOvers.Add(airport);
        }

        public override bool Equals(object obj) {
            return obj is Route route &&
                   Departure == route.Departure &&
                   Arrival == route.Arrival;
        }

        public override int GetHashCode() {
            return HashCode.Combine(Departure, Arrival);
        }
        public override string ToString() {
            return $"[Route] {Departure},{Arrival}";
        }
    }
}
