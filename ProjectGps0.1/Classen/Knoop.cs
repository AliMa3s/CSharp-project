using System;
using System.Collections.Generic;
using System.Text;

namespace Classen {
    public class Knoop {
        public int KnoopId { get; set; }
        public Punt Punt { get; set; }

        public Knoop(int knoopId, Punt punt) {
            KnoopId = knoopId;
            Punt = punt;
        }

    }
}
