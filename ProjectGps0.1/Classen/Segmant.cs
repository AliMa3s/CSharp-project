using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Classen {
   public class Segmant {
        public int SegmentId { get; private set; }
        public List<Punt> Punten { get; private set; }
        public Knoop BeginKnoop { get; private set; }
        public Knoop EindKnoop { get; private set; }
        public List<Punt> Vertices { get; private set; }


        public Segmant(int segmentId, List<Punt> punten, Knoop beginKnoop, Knoop eindKnoop) {
            SetSegmentId(segmentId);
            SetPunten(punten);
            SetBeginKnoop(beginKnoop);
            SetEindKnoop(eindKnoop);
            this.Vertices = Vertices; // if it gives error put in ur constructor

        }

        public void SetSegmentId(int id) {
            if(id <= 0 ) {
            throw new SegmentException($"Segment {id} moet groter zijn dan 0!");
            } else {
                SegmentId = id;
            }
        }

        public void SetBeginKnoop(Knoop beginknoop) {
            if (beginknoop == null) { throw new SegmentException($"Knoop {beginknoop} mag niet null zijn!"); }
                if (beginknoop == EindKnoop) { throw new SegmentException($"Begin en Eindknoop mogen niet hetzelfde zijn!"); }
            if (beginknoop == BeginKnoop) { throw new SegmentException($"Beginknoop bestaal al!"); } 
            if (Punten != null && Punten[0] != beginknoop.Punt) { throw new SegmentException($"Geometrie klopt niet!"); } 
                BeginKnoop = beginknoop;
        }
        public void SetEindKnoop(Knoop eindknoop) {
            if (eindknoop == null) { throw new SegmentException($"Knoop {eindknoop} mag niet null zijn!"); }
            if (eindknoop == BeginKnoop) { throw new SegmentException($"Begin en Eindknoop mogen niet hetzelfde zijn!"); }
            if (eindknoop == EindKnoop) { throw new SegmentException($"Eindknoop bestaal al!"); }
            if (Punten[Punten.Count - 1] != eindknoop.Punt && Punten != null) { throw new SegmentException($"Geometrie klopt niet!"); }
            EindKnoop = eindknoop;
        }

        public void SetPunten(List<Punt> punten) {
            if (punten == null) { throw new SegmentException($"Punten mag niet leeg zijn!"); }
            if (punten.Count < 2) { throw new SegmentException($"Punten mag niet kleiner dan 2 zijn!"); }
            if (BeginKnoop.Punt != punten[0] && BeginKnoop != null) { throw new SegmentException($"Eerste punt mag niet verschillen!"); }
            if (EindKnoop.Punt != punten[punten.Count - 1] && EindKnoop != null) { throw new SegmentException($"Laatste punt mag niet verschillen!"); }
            //LINQ
            if (punten.GroupBy(p => p).Any(x => x.Count() > 1)) { throw new SegmentException($"Punten mag slechts een keer voorkomen!"); }
            Punten = punten;
        }
        public double lengte() {
            double l = 0.0;
            for (int i = 1; i < Punten.Count; i++) {
                l += Math.Sqrt(Math.Pow(Punten[i - 1].XCoord - Punten[i].XCoord, 2) + Math.Pow(Punten[i - 1].YCoord - Punten[i].YCoord, 2));
            }
            return l;
        }
    }
}
