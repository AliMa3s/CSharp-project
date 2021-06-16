using System;
using System.Collections.Generic;
using System.Text;
using Scheepvaart.ExceptionsHandeling;

namespace Scheepvaart {
   public class Haven {
        public Haven(string naam) {
            if (naam == "") throw new HavenException("Haven moet een naam hebben minstens 1 letter.");
            Naam = naam;
        }
        public string Naam { get; set; }
        public override string ToString() {
            return string.Join(',', Naam);
        }
    }
}
