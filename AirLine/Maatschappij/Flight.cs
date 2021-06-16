using System;
using System.Collections.Generic;
using System.Text;

namespace Maatschappij {

    public class Flight {
        public Flight(int flightNumber, Route route, Airplane airplane, int seatsSold, DateTime departureDate) {
            FlightNumber = flightNumber;
            Route = route;
            Airplane = airplane;
            SeatsSold = seatsSold;
            DepartureDate = departureDate;
        }

        public int FlightNumber { get; private set; }
        public DateTime DepartureDate { get; private set; }
        public Route Route { get; private set; }
        public Airplane Airplane { get; private set; }
        public int SeatsSold { get; private set; }
        public double Cost() {
            return Airplane.FuelCostPerPersonPer100km * SeatsSold * Route.Distance / 100;
        }

        public override bool Equals(object obj) {
            return obj is Flight flight &&
                   FlightNumber == flight.FlightNumber;
        }

        public override int GetHashCode() {
            return HashCode.Combine(FlightNumber);
        }

        public double OccupancyRate() {
            return (double)SeatsSold / (double)Airplane.AvailableSeats;
        }
        public override string ToString() {
            return $"[Flight] {FlightNumber},{Route},{Airplane},{SeatsSold}";
        }

    }
}