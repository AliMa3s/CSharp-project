using System;
using System.Collections.Generic;
using System.Text;

namespace BridgePatternOpdracht {
   public class Green : Color {
        private string green;

        public override void setColor(string color) {
            this.green = color;
        }

        public override void toonDetails(string shape, string color) {
            var outputColor = "Green";
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"The Shap is {shape} with a color of {outputColor}");
            Console.ResetColor();
        }
    }
}
