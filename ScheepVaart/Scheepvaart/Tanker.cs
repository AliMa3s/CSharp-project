using System;
using System.Collections.Generic;
using System.Text;
using Scheepvaart.ExceptionsHandeling;

namespace Scheepvaart {
    public class Tanker : Vrachtschip{
        
        
        public Tanker(string naam, double lengte, double breedte, double tonnage, decimal cargowaarde, double volume) :
            base(naam, lengte, breedte, tonnage, cargowaarde) {
            Volume = volume;

            if (volume < 0) throw new SchipException("Volume moet groter of gelijk aan 0 zijn.");
        }

        // in liters
        public double Volume { get; set; }
    }
}
