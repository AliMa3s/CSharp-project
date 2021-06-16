using Maatschappij;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ConsoleApp1 {
   public class FlightReader {
        private string path = "airlineData.txt";

        public List<Flight> ReadFlights() {
            List<Flight> flights = new List<Flight>();
            using (StreamReader reader = new StreamReader(path)) {
                string line;
                reader.ReadLine(); //skip first
                while ((line = reader.ReadLine()) != null) {
                    string[] x = line.Split(',');
                    int flightnumber = Int16.Parse(x[0]);
                    string[] d = x[1].Split('/');
                    DateTime date = new DateTime(Int16.Parse(d[2]), Int16.Parse(d[1]), Int16.Parse(d[0]));
                    int seatssold = Int16.Parse(x[2]);
                    string airplaneName = x[3];
                    double airplaneFuelcost = Double.Parse(x[4]);
                    int airplaneSeats = Int16.Parse(x[5]);
                    double airplaneSpeed = Double.Parse(x[6]);
                    string departure = x[7];
                    string arrival = x[8];
                    double distance = Int16.Parse(x[9]);
                    Route r = new Route(departure, arrival, distance);
                    Airplane p = new Airplane(airplaneName, airplaneFuelcost, airplaneSeats, airplaneSpeed);
                    Flight f = new Flight(flightnumber, r, p, seatssold, date);
                    flights.Add(f);
                }
            }
            return flights;
        }
    }
}
