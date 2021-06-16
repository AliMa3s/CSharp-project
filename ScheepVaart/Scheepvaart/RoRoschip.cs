using System;
using System.Collections.Generic;
using System.Text;
using Scheepvaart.ExceptionsHandeling;

namespace Scheepvaart {
    //Erft van Vrachtschip
   public class RoRoschip : Vrachtschip {
        //RoRoschip: lengte, breedte, tonnage, naam,aantal autos, aantal trucks, cargowaarde
        public RoRoschip(string naam, double lengte, double breedte, double tonnage, int aantalAutos, int aantalTrucks, decimal cargowaarde) :
        base(naam, lengte, breedte, tonnage, cargowaarde) {
            AantalAutos = aantalAutos;
            AantalTrucks = aantalTrucks;
            //Als auto, trucks is kleiner dan 0 throw exception
            if (aantalAutos < 0) throw new SchipException("Aantal auto's moet groter of gelijk aan 0 zijn.");
            if (aantalTrucks< 0) throw new SchipException("Aantal trucks moet groter of gelijk aan 0 zijn.");
        }

        public int AantalAutos { get; set; }
        public int AantalTrucks { get; set; }
        public override string ToString() {
            return $"RoRoschip: Lengte {Lengte}, Breedte {Breedte}, Tonnage {Tonnage}, naam {Naam}, Aantal Autos {AantalAutos}, " +
                $"Aantal Trucks {AantalTrucks} Cargowaarde {Cargowaarde}";
        }
    }
}
