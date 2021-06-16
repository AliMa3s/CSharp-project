using System;
using System.Collections.Generic;
using System.Text;

namespace WinkelEvents {
   public enum ProductType {
        Tripel, Dubbel, Kriek, Pils
    }
    public class Bestelling {
        public ProductType Product{ get; set; }
        public double Prijs { get; set; }
        public int Aantal { get; set; }
        public string Adres { get; set; }
      
        public Bestelling(ProductType productType, double prijs, int aantal, string adres) {
            Product = productType;
            Prijs = prijs;
            Aantal = aantal;
            Adres = adres;
        }

        public override string ToString() {
            return $"{Product}, {Prijs}, {Aantal}, {Adres}";
        }
    }
}
