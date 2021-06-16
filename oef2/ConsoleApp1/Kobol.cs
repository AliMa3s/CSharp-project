using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1 {
    public class Kobol : Troep {
        public Kobol(string naam, int levenspunten, int aanvalSterkte, double snelheid)
            : base(naam,levenspunten,aanvalSterkte,snelheid){
            
            GoudVerzameld = 0;
        }
        
        public int GoudVerzameld { get; set; }

        

        public void SteelGoud() {
            GoudVerzameld += 100;
            Console.WriteLine("Ik word rijk");
        }
        public override string ToString() {
            return base.ToString() + $"[heks]";
        }
    }
}
