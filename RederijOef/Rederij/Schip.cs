using System;
using System.Collections.Generic;
using System.Text;

namespace Rederij {
    public abstract class Schip {
        public Schip(int lengte, int breedte, string naam, int tonnage) {
            Lengte = lengte;
            Breedte = breedte;
            Naam = naam;
            Tonnage = tonnage;
            
        }
        public int Lengte { get; set; }
        public int Breedte { get; set; }
        public string Naam { get; set; }
        public int Tonnage { get; set; }
        public Vloot Vloot{ get; set; }

        public override string ToString() {
            return $"(Schip {Naam}, {Lengte}, {Breedte}, {Tonnage}, {Vloot.Naam},{this.GetType()})";
        }
    }
}
