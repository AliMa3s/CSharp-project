using System;
using System.Collections.Generic;
using System.Text;

namespace LinqVirusDataAnalyzerLib {
   public class DataMunicipalityCumulative {

        public int NIScode { get; private set; }
        public int Number { get; private set; }
        public string Municipality { get; private set; }
        public string Provincie{ get; private set; }
        public string Region { get; private set; }

        public DataMunicipalityCumulative(int nIScode, string municipality, string provincie, string region, int number) {
            NIScode = nIScode;
            Municipality = municipality;
            Provincie = provincie;
            Region = region;
            Number = number;
        }
    }
}
