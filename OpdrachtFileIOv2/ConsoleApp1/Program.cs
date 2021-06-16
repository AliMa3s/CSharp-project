using System;
using Verwerking;

namespace ConsoleApp1 {
    class Program {
        static void Main(string[] args) {
            AdresData r = new AdresData();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            r.UitZip();
            r.Verwerk();
            
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Verwijder?");
            Console.ReadLine();
            r.Verwijder();
            Console.ResetColor();
        }
    }
}
