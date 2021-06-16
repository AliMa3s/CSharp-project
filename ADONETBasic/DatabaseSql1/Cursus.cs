using System;
using System.Collections.Generic;
using System.Text;

namespace ADONETsqlserver
{
    public class Cursus
    {
        public Cursus(string cursusnaam) {
            this.cursusnaam = cursusnaam;
        }

        public Cursus(int id, string cursusnaam) {
            this.id = id;
            this.cursusnaam = cursusnaam;
        }

        public int id { get; set; }
        public string cursusnaam { get; set; }
        public override string ToString() {
            return $"Cursus[{id},{cursusnaam}]";
        }
    }
}
