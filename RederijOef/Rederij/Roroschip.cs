using System;
using System.Collections.Generic;
using System.Text;

namespace Rederij {
    public class Roroschip : Vrachtschip {
        public int aantalAutos;
        public int aantalTrucks;
        public string cargowaarde;

        public void PrintRoRoschip() {
            Console.WriteLine("lengte" + lengte+ "breedte" + breedte+ "tonnage" + tonnage+ "naam" + naam+ "aantal auto's" + aantalAutos+ "aantal trucks" + aantalTrucks+ "cargowaarde" + cargowaarde);

        }
    }
}
