using System;
using System.Collections.Generic;
using System.Text;

namespace scheepvaart {
    public class CargoShip : Ship {
        public CargoShip(int length, int width, string name, double worth) 
            {
            Length = length;
            Width = width;
            Name = name;
            Worth = worth;
        }
        public double Worth { get; set; }

        public CargoShip() {
            this.Worth = 0;
        }
        public override string ToString() {
            return "CargoShip: " + this.Name + " (" + this.Length + "x" + this.Width + "Worth " + this.Worth +  ")";
        }


    }

   
}
