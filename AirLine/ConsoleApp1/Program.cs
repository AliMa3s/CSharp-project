using Maatschappij;
using System;
using System.Collections.Generic;

namespace ConsoleApp1 {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("Hello World!");
            Airline airline = new Airline();
            Finance finance = new Finance();
            Sales sales = new Sales();
            Catering catering = new Catering();

            //link modules with events
            airline.FlightEvent += finance.OnFlightEvent;
            airline.FlightEvent += sales.OnFlightEvent;
            airline.FlightEvent += catering.OnFlightEvent;
            catering.CateringEvent += finance.OnCateringEvent;

            //simulate app
            FlightReader fr = new FlightReader();
            List<Flight> flights = fr.ReadFlights();
            foreach (var f in flights) {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(f);
                airline.AddFlight(f);
            }

            //check observers
            catering.PrintOrderReport();
            sales.PrintAnalysisReport();
            finance.PrintCateringReport(2021);
            finance.PrintFuelReport(2021);
        }
    }
}
