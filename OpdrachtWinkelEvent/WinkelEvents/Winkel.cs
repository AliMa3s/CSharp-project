using System;
using System.Collections.Generic;
using System.Text;

namespace WinkelEvents {
    public class Winkel {
    
        public event EventHandler<WinkelEventArgs> WinkelVerkoop;
        public void VerkoopProduct(Bestelling b) {
            Console.WriteLine($"verkoopproduct - {b}");
            OnWinkelVerkoop(b);
        }

        protected virtual void OnWinkelVerkoop(Bestelling b) {
            WinkelVerkoop?.Invoke(this, new WinkelEventArgs { Bestelling = b });
        }


    }
}
