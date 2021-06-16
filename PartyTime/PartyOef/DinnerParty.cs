using System;
using System.Collections.Generic;
using System.Text;

namespace PartyOef {
    public class DinnerParty : Party {
        public bool GezondOptie { get; set; }
        
        public DinnerParty(int aantalMensen,bool gezondOptie, bool luxeOptie) {
            AantalMensen = aantalMensen;
            GezondOptie = gezondOptie;
            LuxeOptie = luxeOptie;
        }

        private decimal KostVanDranken() {
            return GezondOptie ? 5.00m : 20.00m;
        }
        public override decimal Kost {
            get {
                decimal totalKost = base.Kost + AantalMensen * KostVanDranken();
                return totalKost * (GezondOptie ? 0.95m : 1m);
            }
        }


        public override string ToString() {
            return $"De kosten zijn " + Kost.ToString();
        }























        //public const int EetenKostPerPerson = 25;

        //private double kost;
        //private bool gezondOptie;

        //public DinnerParty(int aantalMensen, bool gezondOptie, bool luxeOptie) {
        //    AantalMensen = aantalMensen;
        //    GezondOptie = gezondOptie;
        //    LuxeOptie = luxeOptie;
        //}

        //public int AantalMensen { get; set; }
        //public bool LuxeOptie { get; set; }
        //public bool GezondOptie{ get; set; }

        //private double BerekenDecuratieKosten() {
        //    double kostenDecuratie;
        //    if (LuxeOptie) {
        //        kostenDecuratie = (AantalMensen * 15) + 50;
        //    } else {
        //        kostenDecuratie = (AantalMensen * 7.5) + 30;
        //    }
        //    return kostenDecuratie;
        //}
        //private double BerekenDrankenPerPerson() {
        //    double kostDrankPerPersoon;
        //    if (gezondOptie) {
        //        kostDrankPerPersoon = 5;
        //    } else {
        //        kostDrankPerPersoon = 20;
        //    }
        //    return kostDrankPerPersoon;
        //}

        //public double TotalKost {

        //    get {
        //        double totalkost = BerekenDecuratieKosten();
        //        if (AantalMensen > 12) {
        //            totalkost +=100;
        //        }
        //        totalkost += ((BerekenDrankenPerPerson() + EetenKostPerPerson) * AantalMensen);
        //        if (gezondOptie) {
        //            totalkost *=.95;
        //        }
        //        return totalkost;
        //    }
        //}


    }
}
