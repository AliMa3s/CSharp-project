using System;
using System.Collections.Generic;
using System.Text;

namespace Rederij {
    public class Cruiseschip : Passagierschip{
        public int aantalPassagiers;
        public string traject;
        public string traject2;
        public string traject3;

        public void PrintCruiseschip() {
            Console.WriteLine("lengte" + lengte + "breedte" + breedte+ "tonnage" + tonnage+ "naam" + naam+ "traject 1" + traject+ "traject 2" + traject2+ "traject 3" + traject3);
          
        }
    }
}
