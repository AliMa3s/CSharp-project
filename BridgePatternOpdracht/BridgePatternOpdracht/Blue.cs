using System;
using System.Collections.Generic;
using System.Text;

namespace BridgePatternOpdracht {
   public class Blue : Color{
        private string blue;

        public override void setColor(string color) {
            this.blue = color;
        }

        public override void toonDetails(string shape, string color) {
            var outputColor = "Blue";
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"The Shap is {shape} with a color of {outputColor}");
            Console.ResetColor();
        }
    }
}
