using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1 {
  public  class Transfer {
        internal Transfer(int id, Speler speler, int prijs) : this(speler, prijs) {
            ZetId(id);
        }
        internal Transfer(Speler speler, int prijs) {
            ZetSpeler(speler);
            ZetPrijs(prijs);
        }
        internal Transfer(int id, Speler speler, Team nieuwTeam, Team oudTeam, int prijs) : this(id, speler, prijs) {
            //geen garantie op geen null
            NieuwTeam = nieuwTeam;
            OudTeam = oudTeam;
        }

        public int Id { get; private set; }
        public Speler Speler { get; private set; }
        public Team NieuwTeam { get; private set; }
        public Team OudTeam { get; private set; }
        public int Prijs { get; private set; }

        public void ZetSpeler(Speler speler) {
            if (speler is null) throw new TransferException("ZetSpeler");
            Speler = speler;
        }
        public void ZetPrijs(int prijs) {
            if (prijs < 0) throw new TransferException("ZetPrijs");
            Prijs = prijs;
        }
        public void ZetId(int id) {
            if (id <= 0) throw new TransferException("ZetId");
            Id = id;
        }
        public void ZetNieuwTeam(Team team) {
            if (team is null) throw new TransferException("ZetTeam");
            if (team == OudTeam) throw new TransferException("ZetTeam");
            NieuwTeam = team;
        }
        public void ZetOudTeam(Team team) {
            if (team is null) throw new TransferException("ZetTeam");
            if (team == NieuwTeam) throw new TransferException("ZetTeam");
            OudTeam = team;
        }
        public void VerwijderNieuwTeam() {
            if (OudTeam is null) throw new TransferException("VerwijderNieuwTeam"); //minstens 1 team
            NieuwTeam = null;
        }
        public void VerwijderOudTeam() {
            if (NieuwTeam is null) throw new TransferException("VerwijderOudTeam"); //minstens 1 team
            OudTeam = null;
        }
    }
}
