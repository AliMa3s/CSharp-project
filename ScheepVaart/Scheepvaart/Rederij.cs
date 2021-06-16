using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Scheepvaart.ExceptionsHandeling;

namespace Scheepvaart {
    // IEnumerable<Vloot> maakt het mogelijk om over vloten in rederij te enumereren
    //IEnumerable in C# is an interface that defines one method, GetEnumerator which returns an IEnumerator interface. 
    //This allows readonly access to a collection then a collection that implements IEnumerable can be used with a for-each statement.
    public class Rederij : IEnumerable<Vloot> {
        private Dictionary<string, Vloot> _vloten;
        private SortedDictionary<string, Haven> _actieveHavens;
        private SortedSet<Haven> havenLijst = new SortedSet<Haven>();
        public Rederij() {
            _vloten = new Dictionary<string, Vloot>();
            _actieveHavens = new SortedDictionary<string, Haven>();
        }
        // loop through collections and return the values 
        public IEnumerator<Vloot> GetEnumerator() {
            return _vloten.Values.GetEnumerator();
        }
        // IEnumurable uses enumerator internaly
        //Return an enumrator thats going to be used to iterate through our collection 
        //if u implement ienumerable to ur class u must have this method else error
        IEnumerator IEnumerable.GetEnumerator() {
            return this.GetEnumerator();
        }
        //Add Vloot
        public void VoegVlootToe(Vloot vloot) {
            if (_vloten.ContainsKey(vloot.Naam)) throw new RederijException("Vloot bestaat al in rederij.");
            _vloten.Add(vloot.Naam, vloot);
        }

        //Remove Vloot
        public void VerwijderVloot(Vloot vloot) {
            if (!_vloten.ContainsKey(vloot.Naam)) throw new RederijException("Vloot bestaat niet in rederij");
            _vloten.Remove(vloot.Naam);
        }

        //Zoek Vloot
        public Vloot ZoekVloot(Vloot vloot) {
            if (_vloten.ContainsKey(vloot.Naam))
                return _vloten[vloot.Naam];
            return null;
        }

        
        //Add havens
        public void VoegHavenToe(string naamHaven) {
            if (_actieveHavens.ContainsKey(naamHaven)) throw new RederijException("Haven is in de lijst van actieve havens");
            Haven nieuweHaven = new Haven(naamHaven);
            _actieveHavens.Add(naamHaven, nieuweHaven);
        }
        //Remove havens
        public void VerwijderHaven(string naamHaven) {
            if (!_actieveHavens.ContainsKey(naamHaven)) throw new RederijException("Haven bestaat niet in actieve havens");
            _actieveHavens.Remove(naamHaven);
        }
        //Alfabetisch volgorde overzicht van havens
        public string OverzichHavensInRederij() {
            if (havenLijst.Count == 0) return null;
            return string.Join(", \n", havenLijst);
        }

        //Verplaats schip in andere vloot
        public void VerplaatsSchip(string schipNaam, string vlootNaam) {
            Schip s;
            foreach (Vloot v in _vloten.Values) {
                s = v.ZoekSchip(schipNaam);
                if (s != null) {
                    v.VerwijderSchip(s);
                    _vloten[vlootNaam].VoegSchipToe(s);
                }
            }
        }
        //Cargo waarde van schepen
        public decimal GeefTotaleCargowaarde() {
            decimal totaal = 0m;
            foreach (KeyValuePair<string, Vloot> vloot in _vloten) {
                foreach (Schip s in vloot.Value) {
                    if (s is Vrachtschip vrachtschip) {
                        totaal += vrachtschip.Cargowaarde;
                    }
                }
            }
            return totaal;
        }
        //Het totaal aantal passagiers
        public int GeefTotaalAantalPassagiers() {
            int totaal = 0;
            foreach (KeyValuePair<string, Vloot> vloot in _vloten) {
                foreach (Schip s in vloot.Value) {
                    if (s is Passagierschip passagierschip) {
                        totaal += passagierschip.AantalPassagiers;
                    }
                }
            }
            return totaal;
        }
        //De tonnage per vloot op te lijsten (van groot naar klein)
        public SortedDictionary<double, List<Vloot>> GeefTonnagePerVloot() {
            // SortedDict sorteert op key
            // List<Vloot> aangezien vloten identieke tonnage kunnen hebben
            SortedDictionary<double, List<Vloot>> output = new SortedDictionary<double, List<Vloot>>();
            if (_vloten.Count == 0) throw new RederijException("Geen vloten aanwezig in rederij");
            foreach (Vloot v in _vloten.Values) {
                double tonnage = 0.0;
                foreach (Schip s in v) {
                    tonnage += s.Tonnage;
                    // check indien vloten zelfde tonnage hebben
                    if (output.ContainsKey(tonnage)) output[tonnage].Add(v);
                    else { output.Add(tonnage, new List<Vloot>() { v }); }
                }
            }
            return output;
        }
        //Het totaal aantal volume die de tankers kunnen vorvoeren
        public double GeefTotaalVolumeTankers() {
            double totaalVolume = 0;
            foreach (KeyValuePair<string, Vloot> vloot in _vloten) {
                foreach (Schip s in vloot.Value) {
                    if (s is Tanker tanker) {
                        totaalVolume += tanker.Volume;
                    }
                }
            }
            return totaalVolume;
        }
        //De beschikbare Sleepboten
        public List<Sleepboot> GeefBeschikbareSleepboten() {
            List<Sleepboot> sleepboten = new List<Sleepboot>();
            foreach (KeyValuePair<string, Vloot> vloot in _vloten) {
                foreach (Schip s in vloot.Value) {
                    if (s is Sleepboot sleepboot) {
                        sleepboten.Add((Sleepboot)s);
                    }
                }
            }
            return sleepboten;
        }
        //Geef info over een bepaald schip
        public Schip GeefSchipInfo(string naam) {
            foreach (KeyValuePair<string, Vloot> vloot in _vloten) {
                if (vloot.Value.BevatSchip(naam)) {
                    return vloot.Value.ZoekSchip(naam);
                }
            }
            return null;
        }




    }
}
