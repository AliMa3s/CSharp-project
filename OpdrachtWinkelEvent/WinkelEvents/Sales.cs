using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WinkelEvents {
   public class Sales {
        //maak dictionary van string en lijst van bestellingen rappot
        private Dictionary<string, List<Bestelling>> _rapport;

        public Sales() {
            _rapport = new Dictionary<string, List<Bestelling>>();
        }

        public void OnWinkelVerkoop(object source, WinkelEventArgs args) {
            //klant identificeren op basis van het adres
            if (_rapport.ContainsKey(args.Bestelling.Adres)) {
                //he KeyValuePair class stores a pair of values in a single list with C#. Set KeyValuePair and add elements 
                //Use the FirstorDefault() method to return the first element of a sequence or a default value if element isn't there.
                KeyValuePair<string, List<Bestelling>> keyValuePair = _rapport.Where(x => x.Key == args.Bestelling.Adres).FirstOrDefault();
                keyValuePair.Value.Add(args.Bestelling);
            } else {
                //maak nieuwe lijs van bestellingen
                List<Bestelling> nieuweBestellingen = new List<Bestelling>();
                nieuweBestellingen.Add(args.Bestelling);
                //voeg in rapport bestelling adres en de lijst van nieuwe bestellingen
                _rapport.Add(args.Bestelling.Adres, nieuweBestellingen);
            }
            ToonRapport();
        }

        public void ToonRapport() {
            Console.WriteLine("----------");
            Console.WriteLine("Sales - rapport");
            //dictionary rapport overlopen kijken voor hoveelheid key/value pairs
            for (int indexRapport = 0; indexRapport < _rapport.Count; indexRapport++) {
                int dubbelAantal = 0;
                int kriekAantal = 0;
                int pilsAantal = 0;
                int trippelAantal = 0;
                //voeg info in het rapportitem
                var rapportItem = _rapport.ElementAt(indexRapport);
                //raportitem afprinten
                Console.WriteLine($"Adres: "+rapportItem.Key.ToString());
                //loopen door rapportitem
                for (int indexBestellingen = 0; indexBestellingen < rapportItem.Value.Count; indexBestellingen++) {
                    var bestellingItem = rapportItem.Value.ElementAt(indexBestellingen);
                    //welke item besteld zijn
                    switch (bestellingItem.Product) {
                        case ProductType.Dubbel:
                            //aantal besteld product optellen
                            dubbelAantal += bestellingItem.Aantal;
                            break;
                        case ProductType.Kriek:
                            //aantal besteld product optellen
                            kriekAantal += bestellingItem.Aantal;
                            break;
                        case ProductType.Pils:
                            //aantal besteld product optellen
                            pilsAantal += bestellingItem.Aantal;
                            break;
                        case ProductType.Tripel:
                            //aantal besteld product optellen
                            trippelAantal += bestellingItem.Aantal;
                            break;
                    }
                }
                if (dubbelAantal != 0) {
                    Console.Write(ProductType.Dubbel);
                    Console.Write(", ");
                    Console.WriteLine(dubbelAantal.ToString());
                }
                if (kriekAantal != 0) {
                    Console.Write(ProductType.Kriek);
                    Console.Write(", ");
                    Console.WriteLine(kriekAantal.ToString());
                }
                if (pilsAantal != 0) {
                    Console.Write(ProductType.Pils);
                    Console.Write(", ");
                    Console.WriteLine(pilsAantal.ToString());
                }
                if (trippelAantal != 0) {
                    Console.Write(ProductType.Tripel);
                    Console.Write(", ");
                    Console.WriteLine(trippelAantal.ToString());
                }
            }
            Console.WriteLine("----------");
        }

    }
}
