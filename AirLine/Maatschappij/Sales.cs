using System;
using System.Collections.Generic;
using System.Text;

namespace Maatschappij {

    public class Sales {
        private Dictionary<Route, List<Flight>> flights = new Dictionary<Route, List<Flight>>();

        private void AddFlight(Flight flight) {
            if (flights.ContainsKey(flight.Route)) {
                if (!flights[flight.Route].Contains(flight)) {
                    flights[flight.Route].Add(flight);
                }
            } else {
                flights.Add(flight.Route, new List<Flight>() { flight });
            }
        }
        private double CalcAverageOccupancyRate(List<Flight> flights) {
            double result = 0.0;
            foreach (Flight f in flights) {
                result += f.OccupancyRate();
            }
            return result / flights.Count;
        }
        public Dictionary<Route, (double, int)> AnalyseFlights(double minOccupancy) {
            Dictionary<Route, (double, int)> result = new Dictionary<Route, (double, int)>();
            double tmp;
            foreach (var r in flights.Keys) {
                tmp = CalcAverageOccupancyRate(flights[r]);
                if (tmp <= minOccupancy)
                    result.Add(r, (tmp, flights[r].Count));
            }
            return result;
        }
        public void PrintAnalysisReport(double minOccupancy = 1.0) {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Analysis report");
            foreach (var x in AnalyseFlights(minOccupancy)) {
                Console.WriteLine($"{x.Key},{x.Value.Item1},{x.Value.Item2}");
            }
            Console.WriteLine("-----------------");
        }
        public void OnFlightEvent(object source, FlightEventArgs args) {
            Console.WriteLine("Sales - onFlightEvent");
            Console.WriteLine(args.Flight);
            AddFlight(args.Flight);
            Console.WriteLine("----------------");
        }

    }
}
