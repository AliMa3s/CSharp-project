using System;
using System.Collections.Generic;

namespace ConsoleApp1 {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("Hello World!");
            Heks h = new Heks("Gwendolien",200,300,2.4);
            Kobol k = new Kobol("Noob", 300, 50, 8.2);
            Barbaar b = new Barbaar("Heyyo!", 500, 500, 1.2);

            Console.WriteLine(h);
            Console.WriteLine(k);
            Console.WriteLine(b);
            List<Troep> troepen = new List<Troep>();
            troepen.Add(h);
            troepen.Add(k);
            troepen.Add(b);
            h.Verschijn();
            b.WordWild();
            foreach(Troep t in troepen) {
                t.Beweeg();
            }
            h.Verberg();
            k.SteelGoud();
        }
    }
}
