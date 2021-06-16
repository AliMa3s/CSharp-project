using System;
using System.Collections.Generic;
using System.Text;

namespace Scheepvaart {
    //Erft van schip
    public class Sleepboot : Schip{
        //Sleepboot: lengte, breedte, tonnage, naam
        public Sleepboot(string naam, double lengte, double breedte, double tonnage) : 
            base (naam,lengte,breedte,tonnage) { }
        public override string ToString() {
            return $"Sleepboot: Lengte {Lengte}, Breedte {Breedte}, Tonnage {Tonnage}, naam {Naam}";
        }
    }
}
