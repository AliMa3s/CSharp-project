using System;
using System.Collections.Generic;
using System.Text;

namespace Maatschappij {
   public class CateringOrder {
        private readonly double mealCost = 3.5;
        public string Airport { get; private set; }
        public int NumberOfMeals { get; private set; }
        public DateTime CateringDate { get; private set; }

        public CateringOrder(string airport, int numberOfMeals, DateTime cateringDate) {
            Airport = airport;
            NumberOfMeals = numberOfMeals;
            CateringDate = cateringDate;
        }
        public double Cost() {
            return NumberOfMeals * mealCost;
        }
        public override string ToString() {
            return $"[Order]{Airport};{NumberOfMeals},{CateringDate.ToShortDateString()}";
        }
    }
}
