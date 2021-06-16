using scheepvaart;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1 {
    public class Fleet : Ship {
        public Dictionary<String, Ship> _ships = new Dictionary<string, Ship>();

        public Fleet(string name) {
            Name = name;
        }
    }
}
