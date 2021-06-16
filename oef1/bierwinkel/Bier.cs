using System;
/*Opgave bierwinkel.
Onze klant “Johnny” heeft een bierwinkel en om zijn eigen klanten zo goed mogelijk te helpen roept
hij onze hulp in. We gaan dus software voor Johnny’s bierwinkel. In deze winkel bieden we een aantal
soorten bier aan die de klant kan selecteren aan de hand van een aantal kenmerken, zo kan de klant
een bier selecteren op basis van zijn kleur (blond, amber en bruin), de brouwerij vanwaar het bier
afkomstig is, de inhoudsmaat (25 cl, 33cl, …) en het alcoholpercentage.
Elk bier heeft natuurlijk ook een unieke naam en – het zou anders geen winkel zijn – een prijs per stuk
natuurlijk. Sommige bieren verkopen we apart, andere in setjes van 4, 6 of 8. En voor een aantal is
de levering per 12 of 24.
Wanneer een klant naar de winkel komt moeten we in staat zijn om het juiste bier te vinden voor deze
klant. We hebben dus een inventaris nodig van welke bieren er te koop zijn in onze winkel.
*/
namespace bierwinkel {

        //Eerst maak je constructor
        public class Bier : Drank {
            #region Ctor
            public Bier(double prijsPerStuk, string naam, BierSpecificatie bierSpecificatie, Setgrootte minimumHoeveelheid)
                : base(prijsPerStuk, naam, minimumHoeveelheid) {
                // Precondities
                if (prijsPerStuk <= 0) throw new Exception("Prijs moet groter zijn dan 0");
                if (string.IsNullOrEmpty(naam)) throw new Exception("Naam bier moet gekend zijn");

                DrankSpecificatie = bierSpecificatie;
            }
            #endregion
        }
    }