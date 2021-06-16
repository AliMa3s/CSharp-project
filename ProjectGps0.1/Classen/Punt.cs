using System;
using System.Collections.Generic;
using System.Text;

namespace Classen {
    public class Punt {
        public double XCoord { get; set; }
        public double YCoord { get; set; }

        public Punt(double xCoord, double yCoord) {
            XCoord = xCoord;
            YCoord = yCoord;
        }

        public override bool Equals(object obj) {
            return obj is Punt punt &&
                   XCoord == punt.XCoord &&
                   YCoord == punt.YCoord;
        }

        public override int GetHashCode() {
            return HashCode.Combine(XCoord, YCoord);
        }
        public static bool operator ==(Punt p1, Punt p2) {
            if ((Math.Abs(p1.XCoord - p2.XCoord) < 0.001) && (Math.Abs(p1.YCoord - p2.YCoord) < 0.001)) return true;
            else return false;
        }
        public static bool operator !=(Punt p1, Punt p2) {
            if ((Math.Abs(p1.XCoord - p2.XCoord) < 0.001) && (Math.Abs(p1.YCoord - p2.YCoord) < 0.001)) return false;
            else return true;
        }
        //public static bool operator == (Punt p1 , Punt p2) {
        //    if((Math.Abs(p1.XCoord- p2.XCoord) x<0.001)&&(Math.Abs(p1.YCoord - p2.y) < 0.001)) return true;
        //    else return false;
        //}
    }
}
