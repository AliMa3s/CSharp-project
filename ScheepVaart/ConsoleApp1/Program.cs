using Scheepvaart;
using System;
using System.Collections.Generic;

namespace ConsoleApp1 {
    class Program {
        static void Main(string[] args) {
            //Sleepboot test = new Sleepboot("Sleepboot", 1.0, 1.0, 1.0);
            //Console.WriteLine(test.Naam);

            //Olietanker test2 = new Olietanker("Olietanker", 1.0, 1.0, 1.0, 1m, 1.0, Olietanker.OlietankerLading.olie);
            //Console.WriteLine(test2.Naam);
            Rederij rederij = new Rederij();
            Vloot vloot = new Vloot("Vloot");
            Vloot vloot1 = new Vloot("Vloot1");
            Vloot vloot2 = new Vloot("Vloot2");
            Vloot vloot3 = new Vloot("Vloot3");
            Schip schip = new Containerschip("Containerschip", 1.0, 1.0, 19.0, 1, 100m);
            Schip schip2 = new RoRoschip("RoRoschip", 1.0, 1.0, 15.0, 1, 1, 100m);
            Schip schip3 = new Olietanker("Olietanker", 1.0, 1.0, 10.0, 100m, 111.0, Olietanker.OlietankerLading.diesel);
            Schip schip4 = new GasTanker("Gastanker", 1.0, 1.0, 1.0, 300m, 1.0, GasTanker.GasTankerLading.amoniak);
            vloot.VoegSchipToe(schip);
            vloot.VoegSchipToe(schip4);
            vloot1.VoegSchipToe(schip2);
            vloot2.VoegSchipToe(schip3);
            rederij.VoegVlootToe(vloot);
            rederij.VoegVlootToe(vloot1);
            rederij.VoegVlootToe(vloot2);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(schip);
            Console.WriteLine(schip2);
            Console.WriteLine(schip3);
            Console.WriteLine(schip4);
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Yellow;
            //SortedDictionary<double, List<Vloot>> tonnages = rederij.GeefTonnagePerVloot();
            double test = rederij.GeefTotaalVolumeTankers();
            Console.WriteLine($"Totaal Volume Tankers : {test}");
            //Console.WriteLine(rederij.GeefTotaleCargowaarde());
            Schip sleepboot1 = new Sleepboot("Sleepboot1", 1.0, 1.0, 19.0);
            Schip sleepboot2 = new Sleepboot("Sleepboot2", 1.0, 1.0, 19.0);
            Schip sleepboot3 = new Sleepboot("Sleepboot3", 1.0, 1.0, 19.0);
            vloot.VoegSchipToe(sleepboot1);
            vloot2.VoegSchipToe(sleepboot3);
            vloot1.VoegSchipToe(sleepboot2);
            List<Sleepboot> foo = rederij.GeefBeschikbareSleepboten();
            foreach (Sleepboot s in foo) {
                Console.WriteLine($"Beschiekbare Sleepboten {s}");
            }
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Traject traject1 = new Traject();
            traject1.VoegToe(new Haven("Haven: Antwerpen "));
            traject1.VoegToe(new Haven("Haven: Gent "));
            Schip schip5 = new Cruiseschip("Cruisetest", 1.0, 1.0, 1.0, 20, traject1);
            Schip schip6 = new Containerschip("Containerschip", 5, 4, 12, 52, 300);
            Traject traject2 = new Traject();
            traject2.VoegToe(new Haven("Haven: Oostende"));
            traject2.VoegToe(new Haven("Haven: Calais"));
            Schip schip7 = new Veerboot("Veerboot", 2, 3, 4, 54, traject2);
            vloot.VoegSchipToe(schip7);
            vloot.VoegSchipToe(schip5);
            Console.WriteLine(schip5);
            Console.WriteLine(schip6);
            Console.WriteLine(schip7);
            Console.WriteLine($"Passagiers: {rederij.GeefTotaalAantalPassagiers()}");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Red;
            Schip a = new Containerschip("Container C1",120,200,50, 25, 8600);
            Traject traject3 = new Traject();
            traject3.VoegToe(new Haven("Antwerpen"));
            traject3.VoegToe(new Haven("Gent"));
            Schip b = new Cruiseschip("Container C1", 130, 400, 500, 25,traject3);

            RoRoschip c = new RoRoschip("RORO R001", 290, 35, 700,  45, 20, 98000);
            Vrachtschip d = new Containerschip("Vracht V09", 100, 21, 800,  55, 9800);

            Console.WriteLine(a);
            Console.WriteLine(b);
            Console.WriteLine(c);
            Console.WriteLine(d);
            Console.ResetColor();

        }
    }
}
