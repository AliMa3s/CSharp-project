using System;

namespace BridgePatternOpdracht {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine($"We are gone make a shape of square!");
            var vierk = new Vierkant(new Red());
            vierk.toonDetails();
            Console.WriteLine($"Same but with blue color");
            vierk = new Vierkant(new Blue());
            vierk.toonDetails();
            Console.WriteLine($"Same but with Geen color");
            vierk = new Vierkant(new Green());
            vierk.toonDetails();

            Console.WriteLine($"\n\nWe are gona make a shape of Circle!");
            var circle = new Circle(new Red());
            circle.toonDetails();
            Console.WriteLine($"Same but with blue color");
            circle = new Circle(new Blue());
            circle.toonDetails();
            Console.WriteLine($"Same but with Green color");
            circle = new Circle(new Green());
            circle.toonDetails();


        }
    }
}
