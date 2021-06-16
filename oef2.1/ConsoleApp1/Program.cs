
using oef2._1;
using System;
using System.Collections.Generic;

namespace ConsoleApp1 {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("Hello World!");
            Vervoer v = new Vervoer("lotter");
            Console.WriteLine(v);
            v.Lawai();
            v.drinkt();
            Console.WriteLine("--------------------");
            Auto a = new Auto("auto");
            Console.WriteLine(a);
            a.Lawai();
            a.drinkt();
            Console.WriteLine("--------------------");
            Fiets f = new Fiets("fiets");
            Console.WriteLine(f);
            f.Lawai();
            f.drinkt();
            List<Vervoer> vervoers = new List<Vervoer>();
            vervoers.Add(v);
            vervoers.Add(a);
            vervoers.Add(f);
            foreach(Vervoer ver in vervoers) {
                Console.WriteLine(ver);
                ver.Lawai();
                ver.drinkt();
                Console.WriteLine("-------------------");
            }
        }
    }
}
