using System;
using System.Collections.Generic;
using System.Text;
using Scheepvaart.ExceptionsHandeling;

namespace Scheepvaart {
    //Erft van schip
   public class Passagierschip : Schip{
        public Passagierschip(string naam, double lengte, double breedte, double tonnage, int aantalPassagiers) :
            base(naam, lengte, breedte, tonnage) {
            AantalPassagiers = aantalPassagiers;

            if (aantalPassagiers < 0) throw new SchipException("Aantal passagiers moet groter of gelijk aan 0 zijn.");
        }

        public int AantalPassagiers { get; set; }
        public Traject Traject { get; set; }

        public override string ToString() {
            return $"Passagierschip: Lengte {Lengte}, Breedte {Breedte}, Tonnage {Tonnage}, naam {Naam}, Aantal Passagiers {AantalPassagiers} Traject {Traject}";
        }
    }
}
