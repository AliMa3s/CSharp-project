using System;
using System.Collections.Generic;
using System.Text;

namespace Rederij {
   public class Gastanker : Tanker {
        public string volume;
        public string lading;
        public string cargowaarde;
        public void PrintGastanker() {
            Console.WriteLine("lengte" + lengte);
            Console.WriteLine("breedte" + breedte);
            Console.WriteLine("tonnage" + tonnage);
            Console.WriteLine("naam" + naam);
            Console.WriteLine("volume" + volume);
            Console.WriteLine("lading" + lading);
            Console.WriteLine("cargowaarde" + cargowaarde);
        }
        public decimal lengte { get; set; }
        public decimal breedte { get; set; }
        public int tonnage { get; set; }
        public string naam { get; set; }
        
        public override string ToString() {
            return $"(Schip {naam}, {lengte}, {breedte}, [tonnage}, {Vloot.naam},{this.GetType()})";
        }
    }
}


        

    