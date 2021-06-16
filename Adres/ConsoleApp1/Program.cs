using System;

using AdresOef;

namespace ConsoleApp1 {
    class Program {
        public static void ShowExceptionDetails(Exception e) {
            Console.WriteLine("-----------");
            Console.WriteLine($"Type: {e.GetType()}");
            Console.WriteLine($"Source: {e.Source}");
            Console.WriteLine($"TargetSite: {e.TargetSite.GetType()}");
            Console.WriteLine($"Message: {e.Message}");
            foreach (var x in e.Data) {
                Console.WriteLine($"data: ",x);
            }
            Console.WriteLine("-----------");
        }
        public static string GetGemeentanaam() {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Geef gemeentenaam : ");
            return Console.ReadLine();
            Console.ResetColor();
        }
        public static string GetStraatnaam() {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Geef Straatnaam : ");
            return Console.ReadLine();
            Console.ResetColor();
        }
        public static string GetHuisnummer() {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Geef Huisnummer : ");
            return Console.ReadLine();
            Console.ResetColor();
        }
        public static (string,string,string) GetAdres() {
            string gemeentenaam = GetGemeentanaam();
            string straatnaam = GetStraatnaam();
            string huisnummer = GetHuisnummer();
            return (gemeentenaam, straatnaam, huisnummer);
        }
        public static void VerwerkAdresInfo(string gemeentenaam, string straatnaam, string huisnummer, AdresBeheer adresbeheer) {
            Adres a1 = new Adres(gemeentenaam, straatnaam, huisnummer);
            adresbeheer.VoegToe(a1);
            Console.WriteLine($"[Adres] {a1.PrintPostAdresOpLijn()}");
        }
        
        static void Main(string[] args) {
            bool detailMode = true;
            string gemeentenaam = "";
            string straatnaam = "";
            string huisnummer = "";
            AdresBeheer adresbeheerder = new AdresBeheer();
            int keuze;
            while (true) {
                try {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Maak keuze : [1] Adres Toevoegen, [2] Adres tonen, [3] Stoppen");
                    keuze = int.Parse(Console.ReadLine());
                    Console.ResetColor();
                    switch (keuze) {
                        case 1:
                            (gemeentenaam, straatnaam, huisnummer) = GetAdres();
                            VerwerkAdresInfo(gemeentenaam, straatnaam, huisnummer, adresbeheerder); 
                            break;
                        case 2: adresbeheerder.PrintAdres(); break;
                        case 3: Environment.Exit(0); break;
                    }
                } catch (AdresException ex) {
                    if (detailMode) ShowExceptionDetails(ex);
                    //input is fout probeer invoer opnieuw
                    if (ex is GemException) gemeentenaam = GetGemeentanaam();
                    if (ex is StraatException) straatnaam = GetStraatnaam();
                    if (ex is HuisNumException) huisnummer = GetHuisnummer();
                    try {
                        VerwerkAdresInfo(gemeentenaam, straatnaam, huisnummer, adresbeheerder);
                    } catch (Exception e) {
                        if (detailMode) ShowExceptionDetails(e);
                        Console.WriteLine("Sorry - Opnieuw helemaal proberen"); ;
                        
                    }
                }
                catch (AdresBeheerException ex) {
                    if (detailMode) ShowExceptionDetails(ex);
                    //beheer probleem - start de lus opnieuw
                }
                catch(Exception ex) {
                    if (detailMode) ShowExceptionDetails(ex);
                    Console.WriteLine("No Adres Exception- I quit");
                    Environment.Exit(1000);
                }
            }


















































            // MINE 
            //AdresBeheer lijst = new AdresBeheer();
            //Console.WriteLine("Hello World!");
            //int inputKeuze = 0;
            //do {
            //    Console.WriteLine($"Maak keuze [1] Adres Toevoegen [2] Adres tonnen [3] Stoopen");
            //    inputKeuze = Convert.ToInt32(Console.ReadLine());
            //    string geementeInput = "";
            //    string straat = "";
            //    string Huisnummer= "";
            //    Gemeentes gemeente;
            //    if(inputKeuze == 1) {
            //        try {
                        
            //            Console.WriteLine("Geef gemeentenaam: ");

            //            geementeInput = Console.ReadLine().ToLower();
            //            gemeente = (Gemeentes)Enum.Parse(typeof(Gemeentes), geementeInput, true);
            //        } catch (Exception e) {

            //            throw new GemException("Ongeldig Gemeente naam",e) ;
            //        }
                
                
            //        try {
            //            Console.Write("Geef straatnaam: ");
            //            straat = Console.ReadLine().ToLower();
            //            if (straat == null) throw new StraatException("Straat naam ingeven");
            //        } catch (Exception sn) {

            //            throw new StraatException("Straat naam ingeven", sn);
            //        }
                
                
            //        try {
            //            Console.Write("Geef Huisnummer: ");
            //            Huisnummer= Console.ReadLine().ToLower();
            //            if (!char.IsDigit(Huisnummer[0])) throw new HuisNumException("Eerste character van huisnummer moet een nummer zijn.");
            //        } catch (Exception hn) {

            //            throw new HuisNumException("Eerste character van huisnummer moet een nummer zijn.", hn);
            //        }
            //    }
            //    Adres newAdres = new Adres(geementeInput, straat, Huisnummer);
            //    lijst.AdrestoeVoegen(newAdres);

            //    if (inputKeuze == 2) {
            //        Console.Write(lijst.PrintLijst());
            //    }
            //} while (inputKeuze != 3);

        }
    }
}
