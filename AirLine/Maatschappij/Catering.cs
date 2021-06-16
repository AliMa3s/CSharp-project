using System;
using System.Collections.Generic;
using System.Text;

namespace Maatschappij {
   public class Catering {
        public event EventHandler<CateringEventArgs> CateringEvent;

        private Dictionary<string, List<CateringOrder>> orders = new Dictionary<string, List<CateringOrder>>();
        public void OnFlightEvent(object source, FlightEventArgs args) {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Catering - onFlightEvent");
            Console.WriteLine(args.Flight);
            PlaceOrder(args.Flight.Route.Departure, args.Flight.SeatsSold, args.Flight.DepartureDate, args.Flight);
            Console.WriteLine("----------------");
        }
        public void PlaceOrder(string airport, int numberOfMeals, DateTime cateringDate, Flight flight) {
            CateringOrder order = new CateringOrder(airport, numberOfMeals, cateringDate);
            if (orders.ContainsKey(airport)) {
                orders[airport].Add(order);
            } else {
                orders.Add(airport, new List<CateringOrder>() { order });
            }
            OnCateringEvent(order, flight);
            Console.WriteLine($"Ordering {numberOfMeals} meals in {airport}");
        }
        protected virtual void OnCateringEvent(CateringOrder order, Flight flight) {
            CateringEvent?.Invoke(this, new CateringEventArgs { Flight = flight, Order = order });
        }
        public void PrintOrderReport() {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Catering report");
            foreach (var x in orders) {
                Console.WriteLine($"Airport {x.Key}");
                foreach (var o in x.Value) {
                    Console.WriteLine($"{o}");
                }
            }
            Console.WriteLine("-----------------");
        }
    }
}
