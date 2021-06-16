using System;
using System.Collections.Generic;
using System.Text;

namespace PartyOef {
    public class Party {
        public const int EetenKostPerPerson = 25;

        public int AantalMensen { get; set; }
        public bool LuxeOptie { get; set; }

        private decimal BerekenKostDecurtaie() {
            return LuxeOptie ? (AantalMensen * 15.00m) + 50.00m : (AantalMensen * 7.50m) + 30.00m;
        }

        public virtual decimal Kost {
            get {
                //if mensen > 12 kost 100bij else 0
                return BerekenKostDecurtaie() + EetenKostPerPerson * AantalMensen + (AantalMensen > 12 ? 100m : 0m);
            }
        }
    }
}
