using System;
using ClassLibrary1;
using ClassLibrary1.Interfaces;
using ClassLibrary1.Managers;

namespace ConsoleApp1 {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("Hello World!");
            //SpelerManagerInSQL spelermanager1 = new SpelerManagerInSQL();
            //spelermanager1.RegisterSpeler("Jos", 190, null);
            string connectionString = @"Data Source=DESKTOP-PS4V4IA\SQLEXPRESS;Initial Catalog=League;Integrated Security=True";
            //ILeague league = new LeagueInMemory();
            ILeague league = new LeagueInSQL(connectionString);
            ISpelerManager sm = new SpelerManagerInSQL(connectionString, league);
            Team t1 = league.RegistreerTeam(1, "Antwerp");
            Team t2 = league.RegistreerTeam(2, "Westerlo");
            Team t3 = league.RegistreerTeam(3, "Deinze");
            Team t4 = league.RegistreerTeam(4, "Beveren");
            foreach (var t in league.SelecteerTeams()) {
                t.Show();
            }
            Speler s1 = sm.SelecteerSpeler("Mark");
            //Team t1 = league.SelecteerTeam("Westerlo");
            sm.TransfereerSpeler(s1, t1, 1300000);
            //Team t1 = league.SelecteerTeam("Antwerp");
            //t1.ZetBijnaam("Great Old");
            //league.UpdateTeam(t1);
            //try
            //{
            //    league.VerwijderTeam(league.SelecteerTeam(4));
            //}
            //catch(LeagueException ex)
            //{
            //    Console.WriteLine(ex);
            //}
            foreach (var t in league.SelecteerTeams()) {
                t.Show();
            }
            //ISpelerManager sm = new SpelerManagerInMemory();

            //Speler s1 = sm.RegistreerSpeler("Lowie",null,null);
            //Speler s2 = sm.RegistreerSpeler("jos", 179, 71);
            //Console.WriteLine(s1);
            //Console.WriteLine(s2);
            //sm.VerwijderSpeler(1);
            //Speler s1 = sm.SelecteerSpeler("jos");
            //var t = sm.SelecteerTransfers(2);
            //var x = sm.SelecteerTransfers();
            //var s = sm.SelecteerSpelers();
            //s1.ZetRugnummer(8);
            //sm.UpdateSpeler(s1);
            //s1.ZetGewicht(69);
            //Speler s2 = sm.RegistreerSpeler("Mark",null,null);
            //Speler s3 = sm.RegistreerSpeler("Jordy", 189, 94);
            //s1.ZetRugnummer(6);

            //foreach(var x in sm.SelecteerSpelers())
            //{
            //    Console.WriteLine(x);
            //}
            //sm.TransfereerSpeler(s2, t2, 0);
            //sm.TransfereerSpeler(s1, t1, 1000);

            //t1.Show();
            //t2.Show();

            //sm.TransfereerSpeler(s2, t1, 9000);
            //sm.TransfereerSpeler(s1, t1, 100000);


            //t1.Show();
            //t2.Show();

            //foreach (var x in sm.SelecteerTransfers())
            //{
            //    Console.WriteLine(x);
            //}
        }
    }
}
