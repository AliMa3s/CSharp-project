using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WinkelEvents {
   public class Groothandelaar {
        //lijst van bestellingen
        private List<Bestelling> bestellingen;

        public Groothandelaar() {
            bestellingen = new List<Bestelling>();
        }

        public void OnStockWijziging(object source, StockbeheerEventArgs args) {
            bestellingen.Add(args.Bestelling);
            ToonAlleBestellingen();
        }

        public Bestelling ToonLaatsteBestelling() {
            return bestellingen.LastOrDefault(); //return the last element of sequence or default value if sequence contains no elements
        }

        public void ToonAlleBestellingen() {
            int dubbelAantal = 0;
            int kriekAantal = 0;
            int pilsAantal = 0;
            int trippelAantal = 0;
            Console.WriteLine("----------");
            foreach (Bestelling b in bestellingen) {
                switch (b.Product) {
                    case ProductType.Pils:
                        pilsAantal += b.Aantal;
                        break;
                    case ProductType.Tripel:
                         trippelAantal += b.Aantal;
                        break;
                    case ProductType.Kriek:
                         kriekAantal += b.Aantal;
                        break;
                    case ProductType.Dubbel:
                         dubbelAantal += b.Aantal;
                        break;

                }
            }
            if(dubbelAantal != 0) {
                Console.Write("Voorraadbestelling : ");
                Console.Write(ProductType.Dubbel);
                Console.Write(", ");
                Console.WriteLine(dubbelAantal.ToString());
            }
            if (kriekAantal != 0) {
                Console.Write("Voorraadbestelling : ");
                Console.Write(ProductType.Kriek);
                Console.Write(", ");
                Console.WriteLine(kriekAantal.ToString());
            }
            if (pilsAantal != 0) {
                Console.Write("Voorraadbestelling : ");
                Console.Write(ProductType.Pils);
                Console.Write(", ");
                Console.WriteLine(pilsAantal.ToString());
            }
            if (trippelAantal != 0) {
                Console.Write("Voorraadbestelling : ");
                Console.Write(ProductType.Tripel);
                Console.Write(", ");
                Console.WriteLine(trippelAantal.ToString());
            }
            Console.WriteLine("----------");
        }

    }
}
