using System;
using System.Collections.Generic;
using System.Text;

namespace Scheepvaart {
    //erft van tanker
    public class GasTanker : Tanker{
        //Gastanker: lengte, breedte, tonnage, naam, cargowaarde, volume (liters), lading (LPG, LNG of amoniak)
        public GasTanker(string naam, double lengte, double breedte, double tonnage, decimal cargowaarde, double volume, GasTankerLading lading ):
        base(naam, lengte, breedte, tonnage, cargowaarde, volume) {
            Lading = lading;
        }
        //Enum for soort lading
        public enum GasTankerLading {
            LPG, LNG, amoniak
        }

        public GasTankerLading Lading { get; set; }
        public override string ToString() {
            return $"GasTanker: Lengte {Lengte}, Breedte {Breedte}, Tonnage {Tonnage}, naam {Naam}, Aantal volume {Volume}, Cargowaarde {Cargowaarde} Lading {Lading}";
        }
    }
}
