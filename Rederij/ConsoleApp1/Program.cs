using scheepvaart;
using System;

namespace ConsoleApp1 {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("Hello World!");
            
            Ship s1 = new CargoShip(120, 50, "Ali's Cargo", 600000);
            Ship s2 = new RoroShip(54, 350, "RoroRarara", 7500004, 35, 8, Lading.Diesel);
            Ship s3 = new CruiseShip(87, 68, "NangaParbat", 5000, Lading.nafta);
            Ship s4 = new Containership(85, 45, "Going Merry", 487321548, 98630, Lading.Amoniak);
            Console.WriteLine(s1 + Lading.LNG.ToString());
            Console.WriteLine(s2 + Lading.Diesel.ToString());
            Console.WriteLine(s3 + Lading.nafta.ToString());
            Console.WriteLine(s4 + Lading.Amoniak.ToString());

            
        }
        
       
    }
    }
