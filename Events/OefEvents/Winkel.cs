using System;
using System.Collections.Generic;
using System.Text;

namespace OefEvents {
    public class Winkel {
        public event EventHandler<WinkelEventArgs> ProductVerkocht;

        public void VerkoopProduct(Bestelling b) {
            onProductVerkocht(b);
        }
        protected virtual void onProductVerkocht(Bestelling b) {
            ProductVerkocht?.Invoke(this, new WinkelEventArgs(b));
        }
    }
}
