using System;

namespace LinqVirusDataAnalyzerLib {
    public class DataMunicipality {
        public int NIScode { get; private set; }
        public int Number{ get; private set; }
        public DateTime Date { get; private set; }
        public string Municipality { get; private set; }
        public string Province { get; private set; }
        public string Region { get; private set; }

        public DataMunicipality(int nIScode, DateTime date, string municipality, string province, string region, int number) {
            NIScode = nIScode;
            Date = date;
            Municipality = municipality;
            Province = province;
            Region = region;
            Number = number;
        }
    }
}