using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1 {
   public class Speler {
        internal Speler(int id, string naam) {
            ZetNaam(naam);
            ZetId(id);
        }
        internal Speler(int id, string naam, int? lengte, int? gewicht) : this(id, naam) {
            Lengte = lengte;
            Gewicht = gewicht;
        }
        internal Speler(int id, string naam, Team team, int? lengte, int? gewicht) : this(id, naam, lengte, gewicht) {
            ZetTeam(team);
        }

        public int Id { get; private set; }
        public string Naam { get; private set; }
        public Team Team { get; private set; }
        public int? Rugnummer { get; private set; }
        public int? Lengte { get; private set; }
        public int? Gewicht { get; private set; }

        internal void VerwijderTeam() {
            Team = null;
        }
        public void ZetNaam(string naam) {
            if (string.IsNullOrWhiteSpace(naam)) throw new SpelerException("ZetNaam");
            Naam = naam.Trim();
        }
        public void ZetLengte(int lengte) {
            if (lengte < 150) throw new SpelerException("ZetLengte");
            Lengte = lengte;
        }
        public void ZetId(int id) {
            if (id <= 0) throw new SpelerException("ZetId");
            Id = id;
        }
        public void ZetGewicht(int gewicht) {
            if (gewicht < 50) throw new SpelerException("ZetGewicht");
            Gewicht = gewicht;
        }
        public void ZetRugnummer(int rugnummer) {
            if ((rugnummer <= 0) || (rugnummer > 99)) throw new SpelerException("ZetRugnummer");
            Rugnummer = rugnummer;
        }
        internal void ZetTeam(Team team) {
            if (team is null) throw new SpelerException("ZetTeam");
            if (team == Team) throw new SpelerException("ZetTeam");
            if (Team != null) {
                if (Team.HeeftSpeler(this)) {
                    Team.VerwijderSpeler(this);
                }
            }
            if (!team.HeeftSpeler(this)) team.VoegSpelerToe(this);
            Team = team;
        }
        public override string ToString() {
            return $"[Speler]{Naam},{Rugnummer},{Lengte},{Gewicht},{Team}";
        }
        public override bool Equals(object obj) {
            return obj is Speler speler &&
                   Naam == speler.Naam;
        }
        public override int GetHashCode() {
            return HashCode.Combine(Naam);
        }
    }
}
