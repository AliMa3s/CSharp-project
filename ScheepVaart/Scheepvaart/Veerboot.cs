using System;
using System.Collections.Generic;
using System.Text;
using Scheepvaart.ExceptionsHandeling;

namespace Scheepvaart {
    //Erft van Passagierschip
    public class Veerboot : Passagierschip{
        //Veerboot: lengte, breedte, tonnage, naam, aantal passagiers, traject
        public Veerboot(string naam, double lengte, double breedte, double tonnage, int aantalPassagiers, Traject traject) :
            base(naam, lengte, breedte, tonnage, aantalPassagiers) {
            //Exception Een traject moet tussen twee havens zijn
            if (traject.Count != 2) throw new SchipException("Traject moet een vast traject tussen 2 havens zijn.");
            Traject = traject;
        }

        public override string ToString() {
            return $"Veerboot: Lengte {Lengte}, Breedte {Breedte}, Tonnage {Tonnage}, naam {Naam}, Aantal Passagiers {AantalPassagiers} Traject {Traject}";
        }
    }
}
