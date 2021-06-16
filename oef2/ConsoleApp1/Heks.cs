using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1 {
   public class Heks : Troep {
        public Heks(string naam, int levenspunten, int aanvalSterkte, double snelheid)
            : base(naam,levenspunten,aanvalSterkte,snelheid){
            }
        
        public void Verschijn() {
            Console.WriteLine("hier ben ik");
        }

        public void Verberg() {
            Console.WriteLine("je kan me niet zien");
        }
        public override string ToString() {
            return base.ToString() + $"[heks]"; 
        }
    }
}
