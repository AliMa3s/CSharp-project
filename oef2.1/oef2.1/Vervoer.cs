using System;
using System.Collections.Generic;
using System.Text;

namespace oef2._1 {
   public class Vervoer {
        public Vervoer(string naam) {
            Naam = naam;
        }
        public string Naam { get; set; }
        public  void Lawai() {
            Console.WriteLine("Beep Beep");
        }
        public virtual void drinkt() {
            Console.WriteLine("drinkt ");
        }
        public override string ToString() {
            return $"[Vervoer]{Naam}";
        }
    }
}
