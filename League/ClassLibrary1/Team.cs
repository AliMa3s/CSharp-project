using System;
using System.Collections.Generic;

namespace ClassLibrary1 {
    public class Team {
        public int Stamnummer { get; private set; }
        public string Naam { get; private set; }
        public string Bijnaam { get; private set; }
        private List<Speler> _spelers = new List<Speler>();

        internal Team(int stamnummer, string naam) {
            ZetStamnummer(stamnummer);
            ZetNaam(naam);
        }

        public void ZetStamnummer(int stamnummer) {
            if (stamnummer <= 0) throw new TeamException("ZetStamnummer");
            Stamnummer = stamnummer;
        }
        public void ZetNaam(string naam) {
            if (string.IsNullOrWhiteSpace(naam)) throw new TeamException("ZetNaam");
            Naam = naam;
        }
        public void ZetBijnaam(string bijnaam) {
            if (string.IsNullOrWhiteSpace(bijnaam)) throw new TeamException("ZetBijnaam");
            Bijnaam = bijnaam;
        }
        public bool HeeftSpeler(Speler speler) {
            if (_spelers.Contains(speler)) return true;
            return false;
        }
        internal void VoegSpelerToe(Speler speler) {
            if (_spelers.Contains(speler)) {
                throw new TeamException("VoegSpelerToe");
            } else {
                _spelers.Add(speler);
                if (speler.Team != this)
                    speler.ZetTeam(this);
            }
        }
        internal void VerwijderSpeler(Speler speler) {
            if (!_spelers.Contains(speler)) {
                throw new TeamException("VerwijderSpeler");
            } else {
                if (speler.Team == this)
                    speler.VerwijderTeam();
                _spelers.Remove(speler);
            }
        }
        public IReadOnlyList<Speler> Spelers() {
            return _spelers.AsReadOnly();
        }
        public override string ToString() {
            return $"[Team]{Stamnummer},{Naam},{Bijnaam}";
        }
        public void Show() {
            Console.WriteLine("------Team-------");
            Console.WriteLine(this);
            foreach (Speler s in _spelers) {
                Console.WriteLine(s);
            }
        }
        public override bool Equals(object obj) {
            return obj is Team team &&
                   Stamnummer == team.Stamnummer;
        }
        public override int GetHashCode() {
            return HashCode.Combine(Stamnummer);
        }
    }
}