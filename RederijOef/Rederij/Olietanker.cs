using System;
using System.Collections.Generic;
using System.Text;

namespace Rederij {
    public class Olietanker : Tanker{
        public string volume;
        public string lading;
        public string cargowaarde;

        public void PrintOlietanker() {
            Console.WriteLine("lengte" + lengte+ "breedte" + breedte + "tonnage" + tonnage+ "naam" + naam+ "volume" + volume+ "lading" + lading+ "cargowaarde" + cargowaarde);

        }
    }
}
