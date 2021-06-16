using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Text;

namespace Verwerking {
    public class AdresData {
        //Lezen van pad en het maken 
        public AdresData() {
            //mechanism for ASP.NET apps to get configuration values from external sources.
            // path is nodig, als geen path applicatie moet stoppen , als verandering in json reload.
            var Source = new ConfigurationBuilder().AddJsonFile($"Files.json", optional: false, reloadOnChange: true);
            
            //maken van key en values
            var getSource = Source.Build();
            zip = getSource["Zip"];
            pad = getSource["Pad"];

            padUitZip = getSource["PadUitZip"];
            maakFolder(padUitZip);


            padResultaat = getSource["PadResultaat"];
            maakFolder(padResultaat);
            padFileOutput = getSource["PadFileNaam"];
        }
        private string pad;
        private string zip;
        private string padUitZip;
        private string padResultaat;
        private string padFileOutput;
        //maken van directory
        public void maakFolder(string pad) {
            if (!Directory.Exists(pad)) {
                Directory.CreateDirectory(pad);
                Console.WriteLine($"Folder gemaakt op dir:\"{pad}\"");
            }
        }
        //maken van folder en subfolder// maakfolder van provincies
        void maakFolder(string pad, string subdir) {
            string f = Path.Combine(pad, subdir);
            DirectoryInfo d = new DirectoryInfo(pad);

            if (!Directory.Exists(f))
                d.CreateSubdirectory(subdir);
            Console.WriteLine($"Folder gemaakt dir:\"{subdir}\" at:\"{pad}\"");

        }
        //maak txt file van alle adressen in de folder provincie //kijk onder voor de uitroep
        public void maakTxt(string pad, string naam, SortedSet<string> gesortedSet) {
            string tekstpad = Path.Combine(pad, naam);
            using (StreamWriter sw = new StreamWriter(tekstpad, true)) {
                foreach (var h in gesortedSet) {
                    sw.WriteLine(h.ToString());
                }
            }
        }
        // maak adresinfo.txt kijk onder voor de uitreop
        public void schrijfLijsttxt(string lijst) {
            string pad = Path.Combine(padResultaat, padFileOutput);
            using (StreamWriter sw = new StreamWriter(pad, true)) {
                sw.Write(lijst);
            }
        }

        ////De zipfile Adresbestand uitzippen 
        //public static void Uitzipper(string zipPad) {
        //    ZipFile.ExtractToDirectory(zipPad + @"\AdresBestanden.zip", $"{zipPad}AdresBestanden");
        //}

        //uitzip de documented van adresbestand 
        public void UitZip() {
            string zipPad = Path.Combine(pad, zip);
            using (ZipArchive arc = ZipFile.Open(zipPad, ZipArchiveMode.Read)) {
                foreach (ZipArchiveEntry e in arc.Entries) {
                    e.ExtractToFile(padUitZip + "\\" + e.Name);
                }
            }

        }

        //Lezen van het documetenten 
        private Dictionary<int, GemeenteProvincie> DataProcess() {
            var Lezer = new ConfigurationBuilder().AddJsonFile($"Files.json", optional: false, reloadOnChange: true);
            var docs = Lezer.Build();
            //Het provincieID
            //Hashset collectie van unique element
            HashSet<int> provincieIds = new HashSet<int>();
            //lees van provincies check files.json De file PronvincieIDSVlanderen.csv
            using (StreamReader p = new StreamReader(Path.Combine(padUitZip, docs["provincies"]))) {
                string lijn = p.ReadLine();
                string[] a = lijn.Split(','); //Split 
                foreach (var x in a) {
                    provincieIds.Add(int.Parse(x));
                }
            }

            Dictionary<int, GemeenteProvincie> GemeenteEnProvincie = new Dictionary<int, GemeenteProvincie>();
            //provincieinfo lezen check json De file Provincieinfo.csv
            using (StreamReader gpr = new StreamReader(Path.Combine(padUitZip, docs["provincieInfo"]))) {
                string lijn; int provincie;
                while ((lijn = gpr.ReadLine()) != null) {
                    string[] arrayX = lijn.Split(';');
                    //check arraryindex 1 provincieid out provincie, en array 2 taalcode is nl 
                    if (int.TryParse(arrayX[1], out provincie) && arrayX[2] == "nl") {
                        //als provincie id heeft provincie 
                        if (provincieIds.Contains(provincie)) {
                            //steek in dictionary gemeenteenprovince de index3(naam province)
                            GemeenteEnProvincie.Add(int.Parse(arrayX[0]), new GemeenteProvincie(arrayX[3]));
                        }
                    }
                }
            }
            //Gemeente lezen check json de file Gemeentenaam.csv
            using (StreamReader gem = new StreamReader(Path.Combine(padUitZip, docs["gemeentenaam"]))) {
                string lijn; int gemeenteID;
                while ((lijn = gem.ReadLine()) != null) {
                    string[] arrayG = lijn.Split(';');
                    //check na split arrayindex1 gemeente id out gemeenteid int, en taalcode = nl
                    if (int.TryParse(arrayG[1], out gemeenteID) && arrayG[2] == "nl") {
                        //als Gemeenteenpeovincie dictionary heeft gemeenteid
                        if (GemeenteEnProvincie.ContainsKey(gemeenteID)) {
                            //dan gemeente id = gemeentenaam
                            GemeenteEnProvincie[gemeenteID].Gemeente = arrayG[3];
                        }
                    }
                }
            }
            //straatengemeente lezen check json de file straatnaamId_gementenaamId.csv
            Dictionary<int, int> straatEnGemeente = new Dictionary<int, int>();
            using (StreamReader pgs = new StreamReader(Path.Combine(padUitZip, docs["straatnaamgemeente"]))) {
                string lijn; int gemdID, straatID;
                while ((lijn = pgs.ReadLine()) != null) {
                    string[] arrayH = lijn.Split(';');
                    //check index0 out straatid && index 1 ou gemid
                    if (int.TryParse(arrayH[0], out straatID) && int.TryParse(arrayH[1], out gemdID)) {
                        //Als Dictionary Gemeenteen province heeft gemID
                        if (GemeenteEnProvincie.ContainsKey(gemdID)) {
                            //steek straatid en gemid in straatEnGemeente dictionary
                            straatEnGemeente.Add(straatID, gemdID);
                        }
                    }
                }
            }
            //straatnamen lezen check json de file Straatnamen.csv
            using (StreamReader st = new StreamReader(Path.Combine(padUitZip, docs["straatnaam"]))) {
                string lijn; int straatID;
                while ((lijn = st.ReadLine()) != null) {
                    string[] arrayS = lijn.Split(';');
                    //als index0 out straat id
                    if (int.TryParse(arrayS[0], out straatID)) {
                        // straatenGemeente Dictionary heeft de straat id
                        if (straatEnGemeente.ContainsKey(straatID)) {
                            //dan is o gelijk aan straatid
                            int o = straatEnGemeente[straatID];
                            // als gemeenteenprovincie heeft o 
                            if (GemeenteEnProvincie.ContainsKey(o)) {
                                //dan voeg index1 straat namen in GemeenteEnProvincie Dictionary
                                GemeenteEnProvincie[o].StraatNaam.Add(arrayS[1]);
                            }
                        }
                    }
                }
            }

            return GemeenteEnProvincie;

        }

        public void Verwerk() {
            foreach (var a in DataProcess()) {
                string gemeente = a.Value.Gemeente + ".txt";
                string provincie = a.Value.Provincie;
                SortedSet<string> straat = a.Value.StraatNaam; //sorteren 

                schrijfLijsttxt(a.Value.ToString());// maak adresinfo.txt
                maakFolder(padResultaat, provincie);// maakfolder van provincies
                //pad, get provincie, gemeente en straat//maak txt file van alle adressen in de folder provincie
                maakTxt(Path.Combine(padResultaat, provincie), gemeente, straat);
            }
        }

        public void Verwijder() {
            //check json voor padUitzip
            if (Directory.Exists(padUitZip)) {
                Console.WriteLine($"Verwijderen folder {padUitZip}");
                Directory.Delete(padUitZip, true);
            }
            //check json voor padresultaat
            if (Directory.Exists(padResultaat)) {
                Console.WriteLine($"Verwijderen Folder {padResultaat}");
                Directory.Delete(padResultaat, true);
            }
        }
    }
}
