using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace TeamsManager.Managers
{
    public class SpelerManagerInMemory //: ISpelerManager
    {
        private List<Speler> _spelers = new List<Speler>();
        private List<Transfer> _transfers = new List<Transfer>();
        private int _spelerId = 1;
        private int _transferId = 1;
        public IReadOnlyList<Speler> SelecteerSpelers() {
            return _spelers.AsReadOnly();
        }
        public IReadOnlyList<Transfer> SelecteerTransfers() {
            return _transfers.AsReadOnly();
        }
        private void VoegSpelerToe(Speler speler) {
            if (_spelers.Contains(speler)) {
                throw new SpelerManagerException("VoegSpelerToe");
            } else {
                _spelers.Add(speler);
            }
        }
        public void VerwijderSpeler(Speler speler) {
            if (!_spelers.Contains(speler)) {
                throw new SpelerManagerException("VerwijderSpeler");
            } else {
                _spelers.Remove(speler);
            }
        }
        public void VerwijderSpeler(int spelerId) {
            if (!_spelers.Any(x => x.Id == spelerId)) {
                throw new SpelerManagerException("VerwijderSpeler");
            } else {
                _spelers.Remove(_spelers.Find(x => x.Id == spelerId));
            }
        }
        public Speler SelecteerSpeler(string naam) {
            if (_spelers.Any(x => x.Naam == naam)) return _spelers.Find(x => x.Naam == naam);
            throw new SpelerManagerException("SelecteerSpeler");
        }
        public void TransfereerSpeler(Speler speler, Team naarTeam, int prijs) {
            if (speler == null) throw new SpelerManagerException("transferSpeler");
            if (prijs < 0) throw new SpelerManagerException("transferSpeler");
            if ((speler.Team == null) && (naarTeam == null)) throw new SpelerManagerException("transferSpeler");
            Transfer transfer = new Transfer(_transferId++, speler, prijs);
            if (naarTeam != null) {
                if (speler.Team != null) transfer.ZetOudTeam(speler.Team);
                transfer.ZetNieuwTeam(naarTeam);
                speler.ZetTeam(naarTeam);
            } else {
                //transfer.VerwijderNieuwTeam();
                speler.VerwijderTeam();
            }
            _transfers.Add(transfer);
        }
        public Speler RegistreerSpeler(string naam, int? lengte, int? gewicht) {
            try {
                Speler s = new Speler(_spelerId++, naam);
                if (lengte != null) s.ZetLengte((int)lengte);
                if (gewicht != null) s.ZetGewicht((int)gewicht);
                VoegSpelerToe(s);
                return s;
            } catch (Exception ex) {
                throw new SpelerManagerException("registreerSpeler", ex);
            }
        }
    }
}