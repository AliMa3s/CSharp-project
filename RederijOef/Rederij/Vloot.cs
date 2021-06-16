using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rederij {
    public class Vloot {
        public BaseScheppen zoekSchip(string naam) {
            if (Schepen.ContainsKey(naam))
                return Schepen[naam];
            else
                return null;
        }
        public string Naam { get; set; }
        private Dictionary<string, BaseScheppen> Schepen = new Dictionary<string, BaseScheppen>();

        public Vloot(string naam, decimal lengte, decimal breedte, int tonnage) {
            Naam = naam;
        }

        public void voegSchipToe(BaseScheppen schip) {
            if (!Schepen.ContainsKey(schip.naam)) {
                Schepen.Add(schip.naam,schip);
                schip.Vloot = this;
            }
        }

        public void verwijderSchip(BaseScheppen schip) {
            if (Schepen.ContainsKey(schip.naam)) {
                Schepen.Remove(schip.naam);
                schip.Vloot = null;
            }
        }
        public SortedDictionary<int, List<Vloot>> tonnagePerVloot() {
            SortedDictionary<int, List<Vloot>> tpv = new SortedDictionary<int, List<Vloot>>();
            foreach (Vloot v in Vloot.Values) {
                int t = v.tonnage();
                if (tpv.ContainsKey(t)) tpv[t].Add(v);
                else { tpv.Add(t, new List<Vloot>() { v }); }
            }
            return tpv;
        }
        public int passagiers() {
            int p = 0;
            foreach (BaseScheppen s in Schepen.Values) {
                if (s is Passagierschip) p += ((Passagierschip)s).AantalPassagiers;
            }
            return p;
        }
    }

}
        
