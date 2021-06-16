using System;
using System.Collections.Generic;
using System.Text;

namespace Maatschappij {
   public class Airplane {

        public string Name { get; private set; }
        public double FuelCostPerPersonPer100km { get; private set; }
        public int AvailableSeats { get; private set; }
        public double Speed { get; private set; }

        public Airplane(string name, double fuelCostPerPersonPer100km, int availableSeats, double speed) {
            Name = name;
            FuelCostPerPersonPer100km = fuelCostPerPersonPer100km;
            AvailableSeats = availableSeats;
            Speed = speed;
        }

        public override string ToString() {
            return $"[Airplane] {Name},{AvailableSeats},{Speed},{FuelCostPerPersonPer100km}";
        }
    }
}
