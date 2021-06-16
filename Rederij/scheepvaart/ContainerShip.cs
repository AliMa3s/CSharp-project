using System;
using System.Collections.Generic;
using System.Text;

namespace scheepvaart {
    public class Containership : CargoShip {
        public int Capacity { get; set; }

        public Containership(int length, int width, string name, double worth, int capacity, Lading? lading) {
            Length = length;
            Width = width;
            Name = name;
            Worth = worth;
            Capacity = capacity;
        }
        public override string ToString() {
            return "ContainerShip: " + this.Name + " (" + this.Length + "x" + this.Width + "Worth " + this.Worth + " Capacity " + this.Capacity + ")";
        }
    }
}
