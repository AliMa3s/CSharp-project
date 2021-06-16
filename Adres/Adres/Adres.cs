using System;
using System.Collections.Generic;
using System.Text;

namespace AdresOef {
    public class Adres {
        public Gemeentes GemeenteNaam { get; private set; }
        private int Postcode;
        public string StraatNaam { get; private set; }
        public string Huisnummer{ get; private set; }

        public string PrintPostAdres() {
            Console.ForegroundColor = ConsoleColor.Magenta;
            return $"{Postcode} {GemeenteNaam} \n{StraatNaam} {Huisnummer}";
        }

        public string PrintPostAdresOpLijn() {
            Console.ForegroundColor = ConsoleColor.Magenta;
            return $"{StraatNaam} {Huisnummer}, {Postcode}-{GemeenteNaam}";
            Console.ResetColor();
        }


        public Adres(string gemeente, string straatnaam, string huisnummer) {
            //Gemeeente
            try {
                GemeenteNaam = (Gemeentes)Enum.Parse(typeof(Gemeentes), gemeente, true);
                switch (GemeenteNaam) {
                    case Gemeentes.Gent: Postcode = 9000; 
                        break;
                    case Gemeentes.Aalst: Postcode = 9300;
                        break;
                    case Gemeentes.Lokeren: Postcode = 9160;
                        break;
                    default:
                        break;
                }
            } catch (Exception ex) {

                throw new GemException("Invalid Gemeente", ex);
            }
            if (string.IsNullOrWhiteSpace(straatnaam)) {
                StraatException ae = new StraatException("Invalid Straat");
                SetExceptionInfo(gemeente, straatnaam, huisnummer,ae);
                throw ae;
            }
            // StraatNummer
            StraatNaam = straatnaam;
            try {
                if (!char.IsDigit(huisnummer.ToCharArray()[0])) {
                    HuisNumException ae = new HuisNumException("Invalid Straat");
                    SetExceptionInfo(gemeente, straatnaam, huisnummer, ae);
                    throw ae;
                }
                Huisnummer = huisnummer;
            } catch (Exception ex) {

                throw new HuisNumException("Invalid huisnummer",ex);
            }
        }

        private void SetExceptionInfo(string gemeente,string straatnaam, string huisnummer, Exception e) {
            e.Data.Add("gemeente", gemeente);
            e.Data.Add("straatnaam", straatnaam);
            e.Data.Add("huisnummer", huisnummer);
        }

        public override bool Equals(object obj) {
            return obj is Adres adres &&
                   GemeenteNaam == adres.GemeenteNaam &&
                   Postcode == adres.Postcode &&
                   StraatNaam == adres.StraatNaam &&
                   Huisnummer == adres.Huisnummer;
        }

        public override int GetHashCode() {
            return HashCode.Combine(GemeenteNaam, Postcode, StraatNaam, Huisnummer);
        }























        //***** MIJNE CODE*******************//
        //public Adres(string gemeente, string straat, string nummer) {
        //    Gemeente = gemeente;
        //    Straat = straat;
        //    HuisNummer = nummer;
        //}
        //public string Gemeente { get; private set; }
        //public string Straat { get; private set; }
        //public string HuisNummer { get; private set; }
        //public int Postcode { get; private set; }
        //public override bool Equals(object obj) {
        //    return obj is Adres adres &&
        //           Gemeente == adres.Gemeente &&
        //           Straat == adres.Straat &&
        //           HuisNummer == adres.HuisNummer;
        //}

        //public override int GetHashCode() {
        //    return HashCode.Combine(Gemeente, Straat, HuisNummer);
        //}

        //public override string ToString() {
        //    return $"{Straat} {HuisNummer}  {Gemeente} \n";

        //}
    }
}
