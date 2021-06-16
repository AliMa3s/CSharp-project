using System;
using System.Collections.Generic;
using System.Text;

namespace scheepvaart {
    public class CruiseShip : Ship {
        public int Passengers { get; set; }

        public CruiseShip(int length, int width, string name, int passengers, Lading? lading) {
            Length = length;
            Width = width;
            Name = name;
            Passengers = passengers;
        }
        public override string ToString() {
            return "CruiseShip: " + this.Name + " (" + this.Length + " x " + this.Width + " Passengers " + this.Passengers +  ")";
        }

    }
}
