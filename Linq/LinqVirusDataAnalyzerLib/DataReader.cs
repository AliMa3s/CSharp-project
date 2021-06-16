using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace LinqVirusDataAnalyzerLib {
   public static class DataReader {
        public static List<DataMunicipality> ReadMunicipalityData(string path, bool logging = true) {
            List<DataMunicipality> dataMunicipalities = new List<DataMunicipality>();
            string line;
            using (StreamReader r = new StreamReader(path)) {
                r.ReadLine(); //skip first line
                while((line = r.ReadLine()) != null) {
                    try {
                        string[] x = line.Split(';');
                        string[] d = line.Split('-');
                        int number = Int16.Parse(x[8].StartsWith('<') ? "2" : x[8]); //<5 =>2
                        dataMunicipalities.Add(new DataMunicipality(Int32.Parse(x[0]), new DateTime(Int16.Parse(d[0]), Int16.Parse(d[1]), Int16.Parse(d[2])), x[2], x[6], x[7], number));
                    } catch (Exception ex) {
                        if (logging) Console.WriteLine(line);
                        throw;
                    }
                }
            }
            return dataMunicipalities;
        }

        public static List<DataMunicipalityCumulative> ReadCumlativeMunicipalityData(string path, bool logging = true) {
            List<DataMunicipalityCumulative> dataMunicipalities = new List<DataMunicipalityCumulative>();
            string line;
            using(StreamReader r = new StreamReader(path)) {
                r.ReadLine(); //skip first line
                while((line = r.ReadLine()) != null) {
                    try {
                        string[] x = line.Split(';');
                        dataMunicipalities.Add(new DataMunicipalityCumulative(Int32.Parse(x[0]), x[1], x[5], x[6], Int32.Parse(x[7])));
                    } catch (Exception ex) {

                        if (logging) Console.WriteLine(line);
                    }
                }
            }
            return dataMunicipalities;
        }
    }
}
