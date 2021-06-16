using System;
using System.Collections.Generic;
using System.Collections;
using Scheepvaart.ExceptionsHandeling;

namespace Scheepvaart {
    // IEnumerable<Vloot> maakt het mogelijk om over vloten in rederij te enumereren
    //IEnumerable in C# is an interface that defines one method, GetEnumerator which returns an IEnumerator interface. 
    //This allows readonly access to a collection then a collection that implements IEnumerable can be used with a for-each statement.
    //IEnumerable loops throught collections
    public class Vloot : IEnumerable<Schip> {
        private Dictionary<string, Schip> _schepen; // ZoekPerformantie + uniek
        public string Naam { get; set; }

        //Constructor
        public Vloot(string naam) {
            if (naam == "") throw new VlootException("Naam van een vloot moet minstens 1 letter hebben.");
            Naam = naam;
            //intialisatie van schepen dictionary
            _schepen = new Dictionary<string, Schip>();
        }
        // loop through schip and return the values 
        public IEnumerator<Schip> GetEnumerator() {
            return _schepen.Values.GetEnumerator();
        }
        // IEnumurable uses enumerator internaly
        //Return an enumrator thats going to be used to iterate through our collection 
        //if u implement ienumerable to ur class u must have this method else error
        IEnumerator IEnumerable.GetEnumerator() {
            return this.GetEnumerator();
        }

        //Voegschip methode
        public void VoegSchipToe(Schip schip) {
            //check if the ship is already in vloot
            if (_schepen.ContainsKey(schip.Naam)) throw new VlootException("Schip bestaat al in vloot.");
            //else add it to collection
            _schepen.Add(schip.Naam, schip);
        }
        //Verwijder methode
        public void VerwijderSchip(Schip schip) {
            // check if ship is in vloot
            if (!_schepen.ContainsKey(schip.Naam)) throw new VlootException("Schip bestaat niet in vloot.");
            //else remove it from collection
            _schepen.Remove(schip.Naam);
        }
        //Of schip in de lijst is
        public bool BevatSchip(string schipnaam) {
            return _schepen.ContainsKey(schipnaam);
        }
        //zoeken van de schip
        public Schip ZoekSchip(string schipNaam) {
            if (!BevatSchip(schipNaam)) return null;
            else return _schepen[schipNaam];
        }
        //Overzicht van schepen
        public string OverzichtSchepenInVloot() {
            if (_schepen.Count == 0) return null;
            return string.Join(", \n", _schepen);
        }
    }
}
