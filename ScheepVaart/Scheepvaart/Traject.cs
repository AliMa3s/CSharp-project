using System;
using System.Collections.Generic;
using System.Text;
using Scheepvaart.ExceptionsHandeling;

namespace Scheepvaart {
    public class Traject {
        private List<Haven> _havens; //un
        
        //Eerste constructor zonder parameters
        public Traject() {
            _havens = new List<Haven>();
        }
        //Tweede constructor met list parameters
        public Traject(List<Haven> havens) {
            if (havens == null) throw new TrajectException("Haven lijst mag niet null zijn");
            _havens = havens;
        }
        // Haven is gelijk aan _haven index 
        public Haven this[int index] => _havens[index];
        //om te berekenen dat count niet 0 is voor exception te gooien
        public int Count => _havens.Count;
        //Add Haven
        public void VoegToe(Haven haven) => _havens.Add(haven);
        //Verwijder Haven
        public void Verwijder(Haven haven) => _havens.Remove(haven);

        public override string ToString() {
            return string.Join('|', _havens);
        }
    }
}
