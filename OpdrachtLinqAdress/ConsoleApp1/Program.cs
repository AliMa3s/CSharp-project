using OpdrachtLinq;
using System;

namespace ConsoleApp1 {
    class Program {
        static void Main(string[] args) {
            AdresInfo a = new AdresInfo();
            a.Start();
            //Geef lijst met de provincienamen, alfabetisch gesorteerd.
            a.GetProvincieAlfabetisch();
            //•Geef lijst van straatnamen voor opgegeven gemeente.
            Console.ReadLine();
            a.GetStraatVanStad("Gent");
            Console.ReadLine();
            //•Selecteer de straatnaam die het meest keren voorkomt en druk voor elk voorkomen de provincienaam, gemeentenaam en straatnaam af.
            //Sortering op basis van provincie en gemeente.
            a.GetMeestVoorkomtStraat();
            Console.ReadLine();
            //•Voorzie een analoge functie die de meest voorkomende straatnamen weergeeft met een parameter die aangeefthoeveel straatnamen.
            //Output analoog aanvoorgaande functie.
            a.GetAantalMeestVoorkomtStraat(40);
            Console.ReadLine();
            //•Voorzie een functie die voor 2 opgegeven gemeenten de gemeenschappelijke lijst van straatnamen weergeeft.
            a.GetStraatenGemeenshcappelijkVan2Gemeentes("Gent", "Antwerpen");
            Console.ReadLine();
            //•Voorzie een functie die de straatnamen weergeeft die enkel voorkomen in de opgegeven gemeente,
            //maar die niet voorkomen in een lijst vananderegemeenten.
            a.GetUniekeStraatenVanGemeente("Hasselt");
            Console.ReadLine();
            //•Maak een functie die de gemeente weergeeft met het hoogste aantal straatnamen.
            a.GetHoogstAantalStraaten();
            Console.ReadLine();
            //•Geef de langste straatnaam weer.
            a.GetLangsteStraat();
            Console.ReadLine();
            //•Geeft de naast de langste straatnaam ook de gemeente en provincie weer.
            a.GetLangsteStraatMetGemEnProv();
            Console.ReadLine();
            //•Geef een lijst met straatnamen die uniek zijn (en toon ook gemeente en provincie).
            //Effe Gestopt omdat teveel straaten zijn
           // a.GetUniekeStraaten();
            Console.ReadLine();
            //•Geef een lijst met straatnamen die uniek zijn voor een opgegeven gemeente.
            a.GetUniekeStraatenVanGemeente("Gent");
            Console.ReadLine();
        }
    }
}
