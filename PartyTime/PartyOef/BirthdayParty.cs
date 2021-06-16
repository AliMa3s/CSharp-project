using System;
using System.Collections.Generic;
using System.Text;

namespace PartyOef {
    public class BirthdayParty : Party {
        public string TaartTekst { get; set; }

        public BirthdayParty(int aantalMensen, bool luxeOptie, string taarttekst) {
            AantalMensen = aantalMensen;
            LuxeOptie = luxeOptie;
            TaartTekst = taarttekst;
        }

        private int Lengte {
            get {
                return TaartTekst.Length > MaxTekstLengte() ? MaxTekstLengte() : TaartTekst.Length;
            }
        }
        public int TaartGrotte() {
            return AantalMensen <= 4 ? 8 : 16;
        }
        public int MaxTekstLengte() {
            return TaartGrotte() == 8 ? 16 : 40;
        }

        public bool IsTaartTeksttTeLang {
            get { return TaartTekst.Length > MaxTekstLengte(); }
        }

        public override decimal Kost {
            get {
                decimal totalKost = base.Kost;
                decimal TaartKost = TaartGrotte() == 8 ? 40m + Lengte * .25m : 75m + Lengte * .25m;
                return totalKost + TaartKost;
            }
        }
        public override string ToString() {
            return $"De kosten zijn " + Kost.ToString();
        }
    }
}
