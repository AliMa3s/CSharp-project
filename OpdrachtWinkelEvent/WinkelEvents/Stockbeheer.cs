using System;
using System.Collections.Generic;
using System.Text;

namespace WinkelEvents {
    public class Stockbeheer {
        //intialisatie van stock elk product met 100
        public int TripelAantal { get; private set; } = 100;
        public int DubbelAantal { get; private set; } = 100;
        public int KriekAantal { get; private set; } = 100;
        public int PilsAantal { get; private set; } = 100;
        //Eventhandler stockwijziging publisher
        public event EventHandler<StockbeheerEventArgs> StockWijziging;

        //raise event
        protected virtual void OnStockWijziging(Bestelling b) {
            StockWijziging?.Invoke(this, new StockbeheerEventArgs { Bestelling = b });
        }
        // 
        public void OnWinkelVerkoop(object source, WinkelEventArgs args) {
            OnStockWijziging(args.Bestelling);
            VulStockAan(args.Bestelling);
            ToonStock();
        }
        //Methode toonstock
        public void ToonStock() {
            Console.WriteLine("----------");
            Console.WriteLine($"[stock:{ProductType.Dubbel}, {DubbelAantal}]");
            Console.WriteLine($"[stock:{ProductType.Kriek}, {KriekAantal}]");
            Console.WriteLine($"[stock:{ProductType.Pils}, {PilsAantal}]");
            Console.WriteLine($"[stock:{ProductType.Tripel}, {TripelAantal}]");
            Console.WriteLine("----------");
        }
        //Invullen van stock
        public void VulStockAan(Bestelling bestelling) {
            int minimumGrens = 25;
            switch (bestelling.Product) {
                //product type Dubbel
                case ProductType.Dubbel:
                    //eerste aantal - besteld aantal
                    DubbelAantal -= bestelling.Aantal;
                    //als aantal is onder 25 maak het weer 100
                    if (DubbelAantal <= minimumGrens) {
                        DubbelAantal = 100;
                    }
                    break;
                //product type Kriek
                case ProductType.Kriek:
                    //eerste aantal - besteld aantal
                    KriekAantal -= bestelling.Aantal;
                    //als aantal is onder 25 maak het weer 100
                    if (KriekAantal <= minimumGrens) {
                        KriekAantal = 100;
                    }
                    break;
                //product type pils
                case ProductType.Pils:
                    //eerste aantal - besteld aantal
                    PilsAantal -= bestelling.Aantal;
                    //als aantal is onder 25 maak het weer 100
                    if (PilsAantal <= minimumGrens) {
                        PilsAantal = 100;
                    }
                    break;
                    //product type tripel
                case ProductType.Tripel:
                    //eerste aantal - besteld aantal
                    TripelAantal -= bestelling.Aantal;
                    //als aantal is onder 25 maak het weer 100
                    if (TripelAantal <= minimumGrens) {
                        TripelAantal = 100;
                    }
                    break;
            }
        }
    }
}
