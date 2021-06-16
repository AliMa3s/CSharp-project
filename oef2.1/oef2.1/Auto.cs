using System;
using System.Collections.Generic;
using System.Text;

namespace oef2._1 {
    public class Auto : Vervoer{
        public Auto(string naam) : base (naam) {
            Naam = naam;
        }
        public string Naam { get; set; }

        public void Lawai() {
            Console.WriteLine("Beep Beep");
        }
        public void drinkt() {
            Console.WriteLine("Benzine");
        }
    }
}
