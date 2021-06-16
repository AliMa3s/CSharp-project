using System;
using System.Collections.Generic;
using System.Text;

namespace BridgePatternOpdracht {
   public class Red : Color {
        private string red;

        public override void setColor(string color) {
            this.red = color;
        }

        public override void toonDetails(string shape, string color) {
            var outputColor = "Red";
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"The Shap is {shape} with a color of {outputColor}");
            Console.ResetColor();
        }
    }
}
