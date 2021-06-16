using DataReader;
using System;

namespace ConsoleApp1 {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("Hello World!");
            //string path = @"C:\Users\alima\source\repos\ProjectGPS1\WRdata";
            //Processor p = new Processor();
            //p.LeesBestanden(path, "WRstraatnamen.csv","WRdata.csv");
            //var straten = p.GeefStraten();
            //Console.WriteLine(straten.Count);
            string path = @"C:\Users\alima\source\repos\ProjectGPS1\WRdata";
            Processor pr = new Processor();
            pr.LeesBestanden(path, "WRstraatnamen.csv", "WRdata.csv");
            DatabaseInit di = new DatabaseInit(@"Data Source=desktop-ps4v4ia\sqlexpress;Initial Catalog=wegen;Integrated Security=True");
            di.WriteStraat(pr.Straten);
        }
    }
}
