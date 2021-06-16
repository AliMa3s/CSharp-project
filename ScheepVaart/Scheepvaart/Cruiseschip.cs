using System;
using System.Collections.Generic;
using System.Text;
using Scheepvaart.ExceptionsHandeling;

namespace Scheepvaart {
    //Erft van Vrachtschip
    public class Cruiseschip : Passagierschip{
        public Cruiseschip(string naam, double lengte, double breedte, double tonnage, int aantalPassagiers, Traject traject) :
            base(naam, lengte, breedte, tonnage, aantalPassagiers) {
            //EXception als traject is kleiner dan 1
            if (traject.Count <= 1) throw new SchipException("Traject moet meer dan 1 haven bevatten");
            Traject = traject;
        }

        public override string ToString() {
            return $"Cruiseschip: Lengte {Lengte}, Breedte {Breedte}, " +
                $"Tonnage {Tonnage}, naam {Naam}, Aantal Passagiers {AantalPassagiers} Traject {Traject}";
        }
    }
}
