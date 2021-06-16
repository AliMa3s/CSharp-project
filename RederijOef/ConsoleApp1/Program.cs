using System;


namespace ConsoleApp1 {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("Hello World!");
            Containerschip msc_Ambra = new Containerschip();
            msc_Ambra.lengte = 400m;
            msc_Ambra.breedte = 62m;
            msc_Ambra.tonnage = 232618;
            msc_Ambra.naam = "MSC Ambra";
            msc_Ambra.cargowaarde = "23756 TEU";
            msc_Ambra.aantalContainers = 23756;
            msc_Ambra.PrintContainerschip();

            Console.ReadKey();

            Containerschip msc_Gülsün = new Containerschip();
            msc_Gülsün.lengte = 420m;
            msc_Gülsün.breedte = 62m;
            msc_Gülsün.tonnage = 244249;
            msc_Gülsün.naam = "MSC Gülsün";
            msc_Gülsün.cargowaarde = "24944 TEU";
            msc_Gülsün.aantalContainers = 24944;
            msc_Gülsün.PrintContainerschip();

            Console.ReadKey();

            Cruiseschip carla_C = new Cruiseschip();
            carla_C.lengte = 187.8m;
            carla_C.breedte = 25.75m;
            carla_C.tonnage = 16289;
            carla_C.naam = "Carla C.";
            carla_C.aantalPassagiers = 1072;
            carla_C.traject = "Bombay - Mombassa - Adelaide";
            carla_C.traject2 = "Adelaide - Mombassa - Colombo";
            carla_C.traject3 = "Mombassa - Bombay - Colombo - Adelaide";
            carla_C.PrintCruiseschip();

            Console.ReadKey();

            Cruiseschip costa_Favolosa = new Cruiseschip();
            costa_Favolosa.lengte = 290m;
            costa_Favolosa.breedte = 40m;
            costa_Favolosa.tonnage = 114500;
            costa_Favolosa.naam = "Costa Favolosa";
            costa_Favolosa.aantalPassagiers = 3780;
            costa_Favolosa.traject = "Santa Cruz - Amuay - Eastern Cape";
            costa_Favolosa.traject2 = "Eastern Cape - Amuay - Salvador";
            costa_Favolosa.traject3 = "Amuay - Santa Cruz - Salvador - Eastern Cape";
            costa_Favolosa.PrintCruiseschip();

            Console.ReadKey();

            Gastanker ms_AlDafna = new Gastanker();
            ms_AlDafna.lengte = 345m;
            ms_AlDafna.breedte = 53.83m;
            ms_AlDafna.tonnage = 163922;
            ms_AlDafna.naam = "MS Al Dafna";
            ms_AlDafna.volume = "2.619880e+8L";
            ms_AlDafna.lading = "LNG";
            ms_AlDafna.cargowaarde = "261 988 cubic meters liquid gas";
            ms_AlDafna.PrintGastanker();

            Console.ReadKey();

            Gastanker lpgc_Ayame = new Gastanker();
            lpgc_Ayame.lengte = 230m;
            lpgc_Ayame.breedte = 36.6m;
            lpgc_Ayame.tonnage = 51041;
            lpgc_Ayame.naam = "LPGC Ayame";
            lpgc_Ayame.volume = "8.300000e+7L";
            lpgc_Ayame.lading = "LPG";
            lpgc_Ayame.cargowaarde = "83 000 cubic meters liquid gas";
            lpgc_Ayame.PrintGastanker();

            Console.ReadKey();

            Olietanker hellespont_Fairfax = new Olietanker();
            hellespont_Fairfax.lengte = 380m;
            hellespont_Fairfax.breedte = 68m;
            hellespont_Fairfax.tonnage = 234006;
            hellespont_Fairfax.naam = "Hellespont Fairfax";
            hellespont_Fairfax.volume = "503,409,900 L";
            hellespont_Fairfax.lading = "Olie";
            hellespont_Fairfax.cargowaarde = "3,166,353 barrels";
            hellespont_Fairfax.PrintOlietanker();

            Console.ReadKey();

            Olietanker ti_Asia = new Olietanker();
            ti_Asia.lengte = 301m;
            ti_Asia.breedte = 51m;
            ti_Asia.tonnage = 214861;
            ti_Asia.naam = "TI Asia";
            ti_Asia.volume = "2.350000e+8L";
            ti_Asia.lading = "Benzeen";
            ti_Asia.cargowaarde = "1.48 million barrels";
            ti_Asia.PrintOlietanker();

            Console.ReadKey();

            RoRoschip ms_Epsilon = new RoRoschip();
            ms_Epsilon.lengte = 186.50m;
            ms_Epsilon.breedte = 25.60m;
            ms_Epsilon.tonnage = 26375;
            ms_Epsilon.naam = "MS EPSILON";
            ms_Epsilon.aantalAutos = 70;
            ms_Epsilon.aantalTrucks = 14;
            ms_Epsilon.cargowaarde = " 7 140 000 dollars";
            ms_Epsilon.PrintRoRoschip();

            Console.ReadKey();

            RoRoschip mv_Faust = new RoRoschip();
            mv_Faust.lengte = 227.80m;
            mv_Faust.breedte = 32.26m;
            mv_Faust.tonnage = 71583;
            mv_Faust.naam = "MV Faust";
            mv_Faust.aantalAutos = 3484;
            mv_Faust.aantalTrucks = 468;
            mv_Faust.cargowaarde = "600 million dollars";
            mv_Faust.PrintRoRoschip();

            Console.ReadKey();

            Sleepboot abbeille_Bourbon = new Sleepboot();
            abbeille_Bourbon.lengte = 380m;
            abbeille_Bourbon.breedte = 68m;
            abbeille_Bourbon.tonnage = 234006;
            abbeille_Bourbon.naam = "Abbeille Bourbon";
            abbeille_Bourbon.PrintSleepboot();

            Console.ReadKey();

            Sleepboot abbeille_Flandre = new Sleepboot();
            abbeille_Flandre.lengte = 380m;
            abbeille_Flandre.breedte = 68m;
            abbeille_Flandre.tonnage = 234006;
            abbeille_Flandre.naam = "Abbeille Bourbon";
            abbeille_Flandre.PrintSleepboot();

            Console.ReadKey();

            Veerboot moby_Corse = new Veerboot();
            moby_Corse.lengte = 152.91m;
            moby_Corse.breedte = 26.26m;
            moby_Corse.tonnage = 18321;
            moby_Corse.naam = "Moby Corse";
            moby_Corse.aantalPassagiers = 1120;
            moby_Corse.traject = "Toulon - Bastia";
            moby_Corse.traject2 = "Bastia - Toulon";
            moby_Corse.PrintVeerboot();

            Console.ReadKey();

            Veerboot pascal_Lota = new Veerboot();
            pascal_Lota.lengte = 175.10m;
            pascal_Lota.breedte = 27.60m;
            pascal_Lota.tonnage = 36400;
            pascal_Lota.naam = "Pascal Lota";
            pascal_Lota.aantalPassagiers = 2080;
            pascal_Lota.traject = "Sydney - Scotia Bay";
            pascal_Lota.traject2 = "Scotia Bay - Sydney";
            pascal_Lota.PrintVeerboot();

            Console.ReadKey();
        }
    }
}
