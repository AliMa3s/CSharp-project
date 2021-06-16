using System;
using System.Collections.Generic;
using System.Text;

namespace AdresOef {
   public class AdresBeheer {

        public List<Adres> Adressen = new List<Adres>();
        public void VoegToe(Adres adres) {
            if (Adressen.Contains(adres)) throw new AdresBeheerException("Adres bestaat al");
            Adressen.Add(adres);
        }

        public void PrintAdres() {
            foreach (Adres a in Adressen) {
                Console.WriteLine(a.PrintPostAdresOpLijn());
            }
        }




































        //*** MIJNE VERSIE*****//
        //public List<Adres> LijstAdres { get; set; } = new List<Adres>();
        //public void AdrestoeVoegen (Adres adres){
            
                
        //        if (LijstAdres.Contains(adres)) {
        //            throw new Exception("De Adres is al in de lijst");
        //    }
        //    else{
        //        LijstAdres.Add(adres);
        //    }
            
            
           
        //}


        //public string PrintLijst() {
        //    string Lijst = $"";
        //    foreach (Adres a in LijstAdres) {
        //        Lijst += a;
                
        //    }
        //    return Lijst;
        //}
    }
}
