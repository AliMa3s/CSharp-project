using System;
using System.Collections.Generic;
using System.Text;

namespace scheepvaart {
    public class RoroShip : CargoShip {

        public int Cars { get; set; }
        public int Trucks { get; set; }
        public string Lading { get; set; }

        public RoroShip(int lenght, int width, string name, double worth, int cars, int trucks, Lading? lading) {
            Length = lenght;
            Width = width;
            Name = name;
            Worth = worth;
            Cars = cars;
            Trucks = trucks;
            Lading = lading.ToString();
        }
        public override string ToString() {
            return "RoroShip: " + this.Name + " (" + this.Length + "x" + this.Width + "Worth " + this.Worth + " Cars " + this.Cars + " Trucks " + this.Trucks+ ")";
        }
    }
}
