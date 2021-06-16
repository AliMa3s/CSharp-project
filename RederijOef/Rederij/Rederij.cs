using System;
using System.Collections.Generic;
using System.Text;

namespace Rederij {
    public class Rederij {
        public BaseScheppen zoekSchip(string schipnaam) {
            BaseScheppen s;
            if ((s = v.zoekSchip)schipnaam)) != null);
            return s;
        }
        return null;

        public int passagiers() {
            int p = 0;
            foreach (Vloot v in Vloot.Values) {
                p += v.passagiers();
            }
            return p;
        }
        public void plaatsSchipInAndereVloot(string schipnaam, string vlootnaam) {
            Schip s = zoekSchip(schipnaam);
            if (s !=  null)
        {
                Vloot [s.Vloot.Naam].verwijderSchip(s);
                Vloot [vlootnaam].voegSchipToe(s);
                s.Vloot = Vloot[vlootnaam];
            }
        }
    }
    
}

