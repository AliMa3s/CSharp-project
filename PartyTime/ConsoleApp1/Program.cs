using System;
using System.Collections.Generic;
using PartyOef;

namespace ConsoleApp1 {
    class Program {
        static void Main(string[] args) {
            List<Party> parties = new List<Party>();
            Console.WriteLine("Hello World!");
            DinnerParty d1 = new DinnerParty(5, false,false);
            DinnerParty d2 = new DinnerParty(15, true, true);
            DinnerParty d3 = new DinnerParty(10, true, false);
            Console.WriteLine(d1);
            Console.WriteLine(d2);
            Console.WriteLine(d3);
            d1.AantalMensen = 10;
            Console.WriteLine(d1);
            BirthdayParty b1 = new BirthdayParty(6, true, "52");
            BirthdayParty b2 = new BirthdayParty(5, false, "Hello");
            Console.WriteLine(b1);
            parties.Add(d1);parties.Add(d2);parties.Add(d3);parties.Add(b1);parties.Add(b2);
            foreach (Party p in parties) {
                Console.WriteLine($"{p}, {p.Kost}");
            }
        }
    }
}
