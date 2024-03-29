﻿using System;
using System.Collections.Generic;
using System.Text;

namespace bierwinkel {
    public class Drank {
        #region Properties
        public double PrijsPerStuk { get; set; }
        public string Naam { get; set; }
        public Setgrootte MinimumHoeveelheid { get; set; }
        public DrankSpecificatie DrankSpecificatie { get; set; }
        #endregion

        #region Ctor
        public Drank(double prijsPerStuk, string naam, Setgrootte minimumHoeveelheid) {
            // Precondities
            if (prijsPerStuk <= 0) throw new System.Exception("Prijs moet groter zijn dan 0");
            if (string.IsNullOrWhiteSpace(naam)) throw new System.Exception("Naam mag niet leeg zijn");

            // Eigenlijke "werk"
            PrijsPerStuk = prijsPerStuk;
            Naam = naam;
            MinimumHoeveelheid = minimumHoeveelheid;
        }
        #endregion

        #region Methods
        public override string ToString() {
            return $"{PrijsPerStuk}, {Naam}, {MinimumHoeveelheid}, {DrankSpecificatie}";
        }
        #endregion
    }
}
