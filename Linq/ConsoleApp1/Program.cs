using LinqVirusDataAnalyzerLib;
using System;
using System.Collections.Generic;
using System.IO;

namespace ConsoleApp1 {
    class Program {
        static void Main(string[] args) {
            string path = @"C:\Users\alima\Downloads\COVID19BE_muni\COVID19BE_muni_cum.csv";
            DataAnalyzer da = new DataAnalyzer();
            
            //List<DataMunicipalityCumulative> dataMc = DataReader.ReadCumlativeMunicipalityData(Path.Combine(path, "COVID19BE_muni_cum.csv"),false);
            List<DataMunicipalityCumulative> dataMc = DataReader.ReadCumlativeMunicipalityData(path, false);
            da.SetDataMunicipalityCumulative(dataMc);
            foreach (var m in da.GetMunicipalities("Antwerpen")) {
                Console.WriteLine(m);
            }

        }
    }
}
