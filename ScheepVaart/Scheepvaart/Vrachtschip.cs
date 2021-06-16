using Scheepvaart.ExceptionsHandeling;
using System;
using System.Collections.Generic;
using System.Text;

namespace Scheepvaart {
    //erft van schip
    public abstract class Vrachtschip : Schip{
        public Vrachtschip(string naam, double lengte, double breedte, double tonnage, decimal cargowaarde) :
            base(naam, lengte, breedte, tonnage) {
            //Cargowaarde Exception waarde in euro
            if (cargowaarde < 0m) throw new SchipException("Cargowaarde moet groter of gelijk aan 0 zijn.");
            Cargowaarde = cargowaarde;
        }

        public decimal Cargowaarde { get; set; }//Waarde van de vracht in Euro
    }
}
