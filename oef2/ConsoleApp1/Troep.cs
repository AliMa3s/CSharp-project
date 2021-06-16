using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1 {
    public class Troep {
        public Troep(string naam, int levenspunten, int aanvalSterkte, double snelheid) {
            Naam = naam;
            Levenspunten = levenspunten;
            AanvalSterkte = aanvalSterkte;
            Snelheid = snelheid;
        }

        public string Naam { get; set; }
        public int Levenspunten { get; set; }
        public int AanvalSterkte { get; set; }
        public double Snelheid { get; set; }

        public void Beweeg() {
            Console.WriteLine($"{this.GetType()} moving");
        }

        public override string ToString() {
            return $"[heks]{Naam},{Levenspunten},{AanvalSterkte},{Snelheid}";
        }
    }
}
