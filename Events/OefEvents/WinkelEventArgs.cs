using System;
using System.Collections.Generic;
using System.Text;

namespace OefEvents {
    public class WinkelEventArgs {
        public Bestelling bestelling { get; set; }
        public WinkelEventArgs(Bestelling b) {
            bestelling = b;
        }
    }
}
