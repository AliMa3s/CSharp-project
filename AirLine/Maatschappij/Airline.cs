using System;
using System.Collections.Generic;
using System.Text;

namespace Maatschappij {
  public class Airline {
        public event EventHandler<FlightEventArgs> FlightEvent;

        public string Name { get; private set; }
        private Dictionary<int, Flight> flights = new Dictionary<int, Flight>();

        public void AddFlight(Flight flight) {
            if (!flights.ContainsKey(flight.FlightNumber)) {
                flights.Add(flight.FlightNumber, flight);
                OnFlightEvent(flight);
            }
        }

        protected virtual void OnFlightEvent(Flight flight) {
            FlightEvent?.Invoke(this, new FlightEventArgs { Flight = flight });
        }
    }
}
