using System;
using System.Collections.Generic;
using System.Text;

namespace DataReader {
   public class IdGenerator {
        //Straat id
        private static int Straadid = 1;
        public static int GetStraatId() {
            return Straadid++;
        }
        //punt id
        private static int PuntId = 1;
        public static int GetPuntId() {
            return PuntId++;
        }
    }
}
