using System;
using System.Collections.Generic;
using System.Text;

namespace BridgePatternOpdracht {
   public class Circle : Shape {
        public Circle(Color color) : base(color) {
            this.type = "Circle";
        }
        public override void setColor(string colorOutput) {
            color.setColor(colorOutput);
        }
    }
}
