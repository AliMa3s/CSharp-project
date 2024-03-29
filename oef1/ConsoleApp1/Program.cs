﻿using bierwinkel;
using System;
using System.Collections.Generic;

namespace ConsoleApp1 {
    class Program {
        static void Main(string[] args) {
            var b1 = new BierSpecificatie { Kleur = Bierkleur.Amber, Brouwerij = "palm", Volume = Volume.cl25, AlcoholPercentage = 5.2, HerkomstLand = "Belgie" };
            var inventaris = new Inventaris();
            inventaris.VoegDrankToe(new Bier(1.05, "palm", new BierSpecificatie { Kleur = Bierkleur.Amber, Brouwerij = "palm", Volume = Volume.cl25, AlcoholPercentage = 5.2, HerkomstLand = "Belgie" }, Setgrootte.zes));
            inventaris.VoegDrankToe(new Bier(1.25, "rodenbach classic", new BierSpecificatie { Kleur = Bierkleur.Amber, Brouwerij = "palm", Volume = Volume.cl25, AlcoholPercentage = 5.2, HerkomstLand = "Belgie" }, Setgrootte.zes));
            inventaris.VoegDrankToe(new Bier(1.6, "leffe bruin", new BierSpecificatie { Kleur = Bierkleur.Bruin, Brouwerij = "leffe", Volume = Volume.cl33, AlcoholPercentage = 6.2, HerkomstLand = "Belgie" }, Setgrootte.zes));
            inventaris.VoegDrankToe(new Bier(1.8, "duvel", new BierSpecificatie { Kleur = Bierkleur.Blond, Brouwerij = "duvel moortgat", Volume = Volume.cl33, AlcoholPercentage = 8.5, HerkomstLand = "Belgie" }, Setgrootte.vier));
            inventaris.VoegDrankToe(new Wijn(5.8, "gato nero", new WijnSpecificatie { Kleur = WijnKleur.Rood, Brouwerij = "Gato", Volume = Volume.cl75, AlcoholPercentage = 12.5, HerkomstLand = "Chili" }, Setgrootte.een));
            var x = inventaris.SelecteerDrank("palm");
            Console.WriteLine($"Bier: {x}");
            var gevondenDrankjes = inventaris.ZoekDrank(b1);
            foreach (var b in gevondenDrankjes)
                Console.WriteLine($"Drank: {b}");

            var bierSpecificatie = new BierSpecificatie { Kleur = Bierkleur.Bruin };
            var bierLijst = inventaris.ZoekDrank(bierSpecificatie);
            foreach (var b in bierLijst) {
                Console.WriteLine($"Drank: {b}");
            }
            var wijnSpecificatie = new WijnSpecificatie { Brouwerij = "Chili", Kleur = WijnKleur.Rood };
            var wijnLijst = inventaris.ZoekDrank(wijnSpecificatie);
            foreach (var w in wijnLijst) {
                Console.WriteLine($"Drank: {w}");
            }


        }
    }
}
