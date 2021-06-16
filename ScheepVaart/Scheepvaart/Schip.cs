using Scheepvaart.ExceptionsHandeling;
using System;
using System.Collections.Generic;
using System.Text;


namespace Scheepvaart {
    public abstract class Schip {
        
        public Schip(string naam, double lengte, double breedte, double tonnage) {
            Naam = naam;
            Lengte = lengte;
            Breedte = breedte;
            Tonnage = tonnage;
            //Exception handeling
            if (naam == "") throw new SchipException("Naam van schip moet 1 letter bevatten.");
            if (Lengte == 0.0 || breedte == 0.0) throw new SchipException("Lengte en breedte moet groter zijn dan 0.");
            if (Tonnage <= 0.0) throw new SchipException("Tonnage moet groter zijn dan 0.");
        }

        public string Naam { get; set; }
        public double Lengte { get; set; }
        public double Breedte { get; set; }
        public double Tonnage{ get; set; } //Volume van het schip

        //String override methode
        public override string ToString() {
            return $"Schip: {this.GetType()} || Naam: {Naam} | Lengte: {Lengte} | Breedte: {Breedte} | Tonnage: {Tonnage}";
        }

    }
}
