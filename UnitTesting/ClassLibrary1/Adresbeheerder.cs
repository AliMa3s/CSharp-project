using System;
using System.Collections.Generic;
using System.Text;

namespace AdresSysteem
{
    public class Adresbeheerder
    {
        public List<Adres> Adressen = new List<Adres>();
        public void VoegAdresToe(Adres adres)
        {
            if (Adressen.Contains(adres)) throw new AdresbeheerderException("Adres bestaat al");
            Adressen.Add(adres);
        }
        public void PrintAdresssen()
        {
            foreach(Adres a in Adressen)
            {
                Console.WriteLine(a.PrintPostAdresOpLijn());
            }
        }
    }
}
