using System;
using System.Collections.Generic;
using System.Text;
using Scheepvaart.ExceptionsHandeling;

namespace Scheepvaart {
    //Erft van Vrachtschip
    public class Containerschip : Vrachtschip{
        //Containerschip: lengte, breedte, tonnage, naam, aantalcontainers, cargowaarde
        public Containerschip(string naam, double lengte, double breedte, double tonnage, int aantalContainers, decimal cargowaarde) :
            base(naam, lengte, breedte, tonnage, cargowaarde) {
            //Exception als container kleiner dan 0 is
            if (aantalContainers < 0) throw new SchipException("Aantal Containers moet groter of gelijk aan 0 zijn.");
            AantalContainers = aantalContainers;
        }

        public int AantalContainers { get; set; }
        public override string ToString() {
            return $"Containerschip: Lengte {Lengte}, Breedte {Breedte}, Tonnage {Tonnage}, naam {Naam}, Aantal Containers {AantalContainers} Cargowaarde {Cargowaarde}";
        }
    }
}
