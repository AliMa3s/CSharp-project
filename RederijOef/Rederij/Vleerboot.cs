using System;
using System.Collections.Generic;
using System.Text;

namespace Rederij {
    public class Vleerboot : Passagierschip {
        public int aantalPassagiers;
        public string traject;
        public string traject2;

        public void PrintVeerboot() {
            Console.WriteLine("lengte" + lengte+ "breedte" + breedte+ "tonnage" + tonnage+ "naam" + naam+ "aantal passagiers" + aantalPassagiers
               + "traject 1" + traject+ "traject 2" + traject2);

        }
    }
}
