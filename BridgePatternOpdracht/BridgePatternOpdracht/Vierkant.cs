using System;
using System.Collections.Generic;
using System.Text;

namespace BridgePatternOpdracht {
    class Vierkant : Shape{
        public Vierkant(Color color) : base(color) {
            this.type = "Square";
        }
        public override void setColor(string colorOutput) {
            color.setColor(colorOutput);
        }
    }
}
