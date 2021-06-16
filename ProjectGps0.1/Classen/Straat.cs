using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Classen {
   public class Straat {
        public int StraatId { get; set; }
        public string StraatNaam { get; set; }
        public double Lengte { get; set; }
        public List<Segmant> Segementen { get; set; }
        public List<Knoop> Knopen{ get; set; }

        public Straat(int straatId, string straatNaam, List<Segmant> segementen) {
            StraatId = straatId;
            StraatNaam = straatNaam;
            Segementen = segementen;
            //LINQ paak beginknop en eindknoop zet in de lijst 
            Knopen = segementen.Select(e => e.BeginKnoop).Union(segementen.Select(e => e.EindKnoop)).ToList();
        }

    }
}
