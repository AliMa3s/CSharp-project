using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace AdresSysteem
{
    public class Adres
    {
        public Gemeente GemeenteNaam { get; private set; }
        public int Postcode { get; private set; }

        public Adres(string gemeente, string straatnaam, string huisnummer)
        {
            try
            {
                GemeenteNaam = (Gemeente)Enum.Parse(typeof(Gemeente), gemeente, true);
                switch (GemeenteNaam)
                {
                    case Gemeente.Gent: Postcode = 9000; break;
                    case Gemeente.Aalst: Postcode = 9300; break;
                    case Gemeente.Lokeren: Postcode = 9160; break;
                }
            }
            catch (Exception ex)
            {
                throw new GemeenteException("Gemeentenaam invalid", ex);
            }
            if (string.IsNullOrWhiteSpace(straatnaam))
            {
                StraatnaamException ae = new StraatnaamException("Straatnaam invalid");
                ZetxceptionInfo(gemeente, straatnaam, huisnummer, ae);
                throw ae;
            }
            Straatnaam = straatnaam;
            try
            {
                if (!char.IsDigit(huisnummer.ToCharArray()[0]))
                {
                    HuisnummerException ae = new HuisnummerException("huisnummer invalid");
                    ZetxceptionInfo(gemeente, straatnaam, huisnummer, ae);
                    throw ae;
                }
                Huisnummer = huisnummer;
            }
            catch(Exception ex)
            {
                HuisnummerException ae = new HuisnummerException("huisnummer invalid");
                ZetxceptionInfo(gemeente, straatnaam, huisnummer, ae);
                throw ae;
            }
        }
        private void ZetxceptionInfo(string gemeente, string straatnaam, string huisnummer,Exception e)
        {
            e.Data.Add("gemeente", gemeente);
            e.Data.Add("straatnaam", straatnaam);
            e.Data.Add("huisnummer", huisnummer);
        }
        public string Straatnaam { get; private set; }
        public string Huisnummer { get; private set; }
        public string PrintPostAdres()
        {
            return $"{Postcode} {GemeenteNaam} \n{Straatnaam} {Huisnummer}";
        }
        public string PrintPostAdresOpLijn()
        {
            return $"{Straatnaam} {Huisnummer}, {Postcode} - {GemeenteNaam}";
        }

        public override bool Equals(object obj)
        {
            return obj is Adres adres &&
                   GemeenteNaam == adres.GemeenteNaam &&
                   Straatnaam == adres.Straatnaam &&
                   Huisnummer == adres.Huisnummer;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(GemeenteNaam, Straatnaam, Huisnummer);
        }
    }
}
