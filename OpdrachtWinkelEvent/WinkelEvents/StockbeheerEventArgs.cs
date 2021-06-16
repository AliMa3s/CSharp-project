using System;
using System.Collections.Generic;
using System.Text;

namespace WinkelEvents {
   public class StockbeheerEventArgs : EventArgs{
        public Bestelling Bestelling { get; set; }
    }
}
