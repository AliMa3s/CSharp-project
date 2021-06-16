using System;
using System.Collections.Generic;
using System.Text;

namespace scheepvaart {
    public class Ship {
        public Ship(int length, int width, string name) {
            Length = length;
            Width = width;
            Name = name;
        }
        public Ship() {
            this.Length = 0;
            this.Width = 0;
            Name = "default";
        }
        public int Length { get; set; }
        public int Width { get; set; }
        public string Name { get; set; }

        //public override string toString() {
        //    return $"Ship: {Name}, {Width}, x {Length}";
        //}
                

        public override string ToString() {
            return "Ship: " + this.Name + " (" + this.Length + "x" + this.Width + ")";
        }
    }

    

}
