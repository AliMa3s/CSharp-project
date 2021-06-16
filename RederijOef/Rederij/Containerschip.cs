using System;
using System.Collections.Generic;
using System.Text;

namespace Rederij {
    public class Containerschip : Vrachtschip {
        public string cargowaarde;
        public int aantalContainers;

        public void PrintContainerschip() {
            Console.WriteLine("lengte" + lengte + "breedte" + breedte + "tonnage" + tonnage+ "naam" + naam + "cargowaarde" + cargowaarde + "aantalContainers" + aantalContainers);
      
        }
    }
}
