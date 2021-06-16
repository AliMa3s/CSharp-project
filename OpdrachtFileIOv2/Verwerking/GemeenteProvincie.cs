using System;
using System.Collections.Generic;
using System.Text;

namespace Verwerking {
    public class GemeenteProvincie {
        //Properties 
        public string Provincie { get; set; }
        public string Gemeente { get; set; }
        public string Taal { get; set; }
        public SortedSet<string> StraatNaam { get; set; }
        //Constructor
        public GemeenteProvincie(string naamProvincie) {
            Provincie = naamProvincie;
            StraatNaam = new SortedSet<string>();
        }

        public override string ToString() {
            string a = "";
            foreach (var straat in StraatNaam) {
                a += $"{Provincie},{Gemeente},{straat}\n";
            }
            return a;
        }
    }
}
