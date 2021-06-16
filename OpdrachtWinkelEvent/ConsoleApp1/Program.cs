using System;
using WinkelEvents;

namespace ConsoleApp1 {
    class Program {
        static void Main(string[] args) {
            Winkel w = new Winkel();
            Sales s = new Sales();
            Stockbeheer sb = new Stockbeheer();
            Groothandelaar gh = new Groothandelaar();

            sb.ToonStock();
            w.WinkelVerkoop += s.OnWinkelVerkoop;
            
            
            sb.StockWijziging += gh.OnStockWijziging;
            w.WinkelVerkoop += sb.OnWinkelVerkoop;
            
            
            //sb.StockWijziging += gh.OnStockWijziging;
           

            // Verkoop van winkelproducten
            Console.WriteLine("Verkoop van producten...");
            w.VerkoopProduct(new Bestelling(ProductType.Dubbel, 3.99, 35, "Dorpstraat 5, Lievegem"));
            w.VerkoopProduct(new Bestelling(ProductType.Kriek, 2.99, 25, "Dorpstraat 5, Lievegem"));
            w.VerkoopProduct(new Bestelling(ProductType.Dubbel, 3.99, 35, "Kerkstraat 155, Zele"));
            w.VerkoopProduct(new Bestelling(ProductType.Kriek, 2.99, 55, "Dorpstraat 5, Lievegem"));
            
            
      
        }
    }
}
