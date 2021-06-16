using System;
using System.Collections.Generic;
using System.Text;

namespace oef2._1 {
    public class Fiets : Vervoer {
        public Fiets(string naam) : base(naam) {
           
        }
        
        public override void drinkt() {
            base.drinkt();
            Console.WriteLine("Niks man gratis");
        }
        public new void Lawai() {
            base.Lawai();
            Console.WriteLine("ding ding");
        }
        public override string ToString() {
            return $"[Fiets]{Naam}";
        }
    }
}
