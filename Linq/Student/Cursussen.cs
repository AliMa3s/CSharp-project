using System;
using System.Collections.Generic;
using System.Text;

namespace Student {
   public class Cursussen {
        public Cursussen(string cursusnaam) {
            this.cursusnaam = cursusnaam;
            
        }

        public Cursussen(string cursusnaam, int id) : this(cursusnaam) {
            this.id = id;
        }

        public string cursusnaam { get; set; }
        public int id { get; set; }
        

        public override string ToString() {
            return $"Cursus [{id}, {cursusnaam}]";
        }
    }
}
