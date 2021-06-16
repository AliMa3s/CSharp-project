using System;
using System.Collections.Generic;
using System.Text;

namespace Scheepvaart {
    //erft van tanker
    public class Olietanker : Tanker {
        //Olietanker:  lengte,  breedte,  tonnage,  naam,  cargowaarde,  volume  (liters),  lading  (olie, benzeen, diesel of nafta)
        public Olietanker(string naam, double lengte, double breedte, double tonnage, decimal cargowaarde, double volume, OlietankerLading lading) :
            base(naam, lengte, breedte, tonnage, cargowaarde, volume) {
            Lading = lading;
        }

        public OlietankerLading Lading { get; set; }
        public enum OlietankerLading {
            olie, benzeen, diesel, nafta
        }
        public override string ToString() {
            return $"Olietanker: Lengte {Lengte}, Breedte {Breedte}, Tonnage {Tonnage}, naam {Naam}, Aantal volume {Volume}, Cargowaarde {Cargowaarde} Lading {Lading}";
        }
    }
}
