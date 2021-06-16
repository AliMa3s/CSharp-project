using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1 {
    public class Barbaar : Troep {
        public Barbaar(string naam, int levenspunten, int aanvalSterkte, double snelheid)
            : base(naam,levenspunten,aanvalSterkte,snelheid){
          
        }

        public void WordWild() {
            Console.WriteLine("GRRRRRRRRRRR");
        }

        public override string ToString() {
            return base.ToString() + $"[heks]";
        }
    }
}





