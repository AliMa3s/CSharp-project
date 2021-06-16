using Classen;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataReader {
   public class PuntDB {
        public int Id { get; private set; }
        public Punt Punt { get; private set; }

        public PuntDB(int id, Punt punt) {
            Id = id;
            Punt = punt;
        }
    }
}
