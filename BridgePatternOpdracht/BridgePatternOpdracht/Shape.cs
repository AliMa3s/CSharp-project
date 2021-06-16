using System;
using System.Collections.Generic;
using System.Text;

namespace BridgePatternOpdracht {
   public abstract class Shape {
        public readonly Color color;
        public string type;
        public string outputColor;

        public Shape(Color color) {
            this.color = color;
        }
        public void toonDetails() {
            color.toonDetails(type, outputColor);
        }
        public abstract void setColor(string color);
    }
}
