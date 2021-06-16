using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinqVirusDataAnalyzerLib {
   public class DataAnalyzer {

        private List<DataMunicipality> dataM = new List<DataMunicipality>();
        private List<DataMunicipalityCumulative> dataMC = new List<DataMunicipalityCumulative>();

        public void SetDataMunicipality(List<DataMunicipality> data) {
            dataM = data;
        }

        public void SetDataMunicipalityCumulative(List<DataMunicipalityCumulative> data) {
            dataMC = data;
        }

        public List<string> GetMunicipalities(string province) {
            return dataMC.Where(p => p.Provincie == province).Select(x => x.Municipality).Distinct().OrderBy(x => x).ToList();
        }
        public List<(string, int)> GetMaxMunicipalities(string provincie, int n = 5) {

        }
    }
}
