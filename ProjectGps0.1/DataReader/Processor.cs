using Classen;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DataReader {
   public class Processor {
        //id is de straatnaam id in bestand
        public Dictionary<int, string> Straatnamen { get; set; } = new Dictionary<int, string>();
        public List<Straat> Straten { get; private set; } = new List<Straat>();
        
        public Processor() {

        }
        public void LeesBestanden(string path, string bestandstraatnaam, string bestandwegendata) {
            Dictionary<int, Knoop> knoopMap = new Dictionary<int, Knoop>(); //int is knoop ID
            Dictionary<int, List<Segmant>> segementMap = new Dictionary<int, List<Segmant>>(); //int straatID
            
            using (StreamReader sr = new StreamReader(Path.Combine(path, bestandstraatnaam))) {
                string lijn;
                sr.ReadLine();
                while((lijn = sr.ReadLine()) != null){
                    string[] lijnArr = lijn.Split(";");
                    int id = int.Parse(lijnArr[0]);
                    string straatnaam = lijnArr[1].Trim();
                    Straatnamen.Add(id, straatnaam);
                }
            }
            using(StreamReader sr = new StreamReader(Path.Combine(path, bestandwegendata))) {
                string lijn;
                sr.ReadLine();
                while ((lijn = sr.ReadLine()) != null) {
                    string[] lijnArr = lijn.Split(";");
                    int wegsegmentid = Int32.Parse(lijnArr[0]);
                    string geoString = lijnArr[1];
                    int beginwegknoopid = Int32.Parse(lijnArr[4]);
                    int eindwegknoopid = Int32.Parse(lijnArr[5]);
                    int lStraatId = Int32.Parse(lijnArr[6]);
                    int rStraatId = Int32.Parse(lijnArr[7]);
                    if (lStraatId == -9 && rStraatId == -9) continue; //Als tijdens lezen -9 dit continue ga naar begin van lus
                    geoString = geoString.Substring(geoString.IndexOf("(") + 1, geoString.IndexOf(")") - geoString.IndexOf("(") - 1);
                    string[] xyParen = geoString.Split(",");
                    List<Punt> punten = new List<Punt>();
                    foreach (String i in xyParen) {
                        string[] xy = i.Trim().Split(" ");
                        double x = double.Parse(xy[0].Replace(".",","));
                        double y = double.Parse(xy[0].Replace(".", ","));
                        
                        punten.Add(new Punt(x, y));
                    }
                    //Dictionaries opvullen
                    if (!knoopMap.ContainsKey(beginwegknoopid)) { knoopMap.Add(beginwegknoopid, (new Knoop(beginwegknoopid, punten[0]))); }
                    if (!knoopMap.ContainsKey(eindwegknoopid)) { knoopMap.Add(eindwegknoopid, (new Knoop(eindwegknoopid, punten[punten.Count -1]))); }

                    Segmant segment = new Segmant(wegsegmentid, punten, knoopMap[beginwegknoopid], knoopMap[eindwegknoopid]);
                    if (segementMap.ContainsKey(lStraatId)) {
                        if (!segementMap[lStraatId].Contains(segment)) { segementMap[lStraatId].Add(segment); }
                    } else {
                        segementMap.Add(lStraatId, new List<Segmant>());
                        segementMap[lStraatId].Add(segment);
                    }
                    
                    if (segementMap.ContainsKey(rStraatId)) {
                        if (!segementMap[rStraatId].Contains(segment)) { segementMap[rStraatId].Add(segment); }
                    } else {
                        segementMap.Add(rStraatId, new List<Segmant>());
                        segementMap[rStraatId].Add(segment);
                    }
                    
                }

            }
            foreach (int i in segementMap.Keys) {
                Straat s = new Straat(IdGenerator.GetStraatId(), Straatnamen[i], segementMap[i]);
                Straten.Add(s);
            }
            //Vertices is bij mij punten

        }

    }
}
