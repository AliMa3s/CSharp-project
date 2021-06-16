using Classen;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DataReader {
   public class DatabaseInit {

        private string connectionString { get; set; }

        public DatabaseInit(string conectionString) {
            conectionString = connectionString;
        }
            
        public void WriteStraat(List<Straat> straten) {
            //Punten Wegschrijven
            HashSet<PuntDB> puntenDB = new HashSet<PuntDB>();
            puntenDB = straten.SelectMany(e => e.Segementen).SelectMany(e => e.Punten).Distinct()
                .Select(e => new PuntDB(IdGenerator.GetPuntId(),e)).ToHashSet();
            BulkPunten(puntenDB);
            //knopen wegschrijven
            Dictionary<Punt, PuntDB> puntMap = new Dictionary<Punt, PuntDB>();
            puntMap = puntenDB.ToDictionary(e => e.Punt, e=>e);
            HashSet<(int, int)> knopen = new HashSet<(int, int)>();
            knopen = straten.SelectMany(e => e.Knopen).Select(e => (e.KnoopId, puntMap[e.Punt].Id)).ToHashSet();
            WriteKnopenToDB(knopen);
            //straten wegschrijven
            HashSet<(int, string)> straatMap = new HashSet<(int, string)>(); //straatid, straatnaam
            straatMap = straten.Select(e => (e.StraatId, e.StraatNaam)).ToHashSet();
            WriteStratenToDB(straatMap);
            //Segmenten wegschrijven
            HashSet<(int, int,int,int)> segmentMap = new HashSet<(int, int, int, int)>();
            segmentMap = straten.SelectMany(e => e.Segementen).Select(e => (e.SegmentId, e.BeginKnoop.KnoopId,
             e.EindKnoop.KnoopId,(int) e.lengte())).ToHashSet();
            WriteSegmentenToDB(segmentMap);
            //StraatSegement wegschrijven
            HashSet<(int, int)> strsegm = new HashSet<(int,int)>();
            strsegm = straten.SelectMany(x => x.Segementen, (parent, child) => (parent.StraatId, child.SegmentId)).ToHashSet();
            WriteStraatSegmentenToDB(strsegm);
            //Punt Segment wegschrijven
            //HashSet<(int, int, int)> segmentPunt = new HashSet<(int, int, int)>();
            List<(int, int, int)> segmentPunt = new List<(int, int, int)>();
            foreach (var s in straten.SelectMany(e=>e.Segementen)) {
                var sp = s.Punten.Select((e, i) => (s.SegmentId, puntMap[e].Id, i + 1));
                segmentPunt.AddRange(sp);
            }
            WriteSegmentPuntenToDB(segmentPunt.ToHashSet());
        }

        private void BulkPunten(HashSet<PuntDB> puntenDB) {
            using(SqlBulkCopy bc = new SqlBulkCopy(connectionString)) {
                DataTable table = new DataTable();
                table.Columns.Add("id", typeof(int));
                table.Columns.Add("x", typeof(double));
                table.Columns.Add("y", typeof(double));
                foreach (var a in puntenDB) {
                    table.Rows.Add(a.Id, a.Punt.XCoord, a.Punt.YCoord);
                }
                bc.DestinationTableName = "punt";
                bc.WriteToServer(table);

            }
        }
        private void WriteKnopenToDB(HashSet<(int, int)> knp) {
            using (var bulkcopy = new SqlBulkCopy(connectionString)) {
                //schrijf knopen
                DataTable dt = new DataTable("knoop");
                dt.Columns.Add(new DataColumn("id", Type.GetType("System.Int32")));
                dt.Columns.Add(new DataColumn("puntID", Type.GetType("System.Int32")));
                bulkcopy.DestinationTableName = "knoop";
                foreach (var x in knp) {
                    dt.Rows.Add(x.Item1, x.Item2);
                }
                bulkcopy.WriteToServer(dt);
            }
        }
        private void WriteStratenToDB(HashSet<(int, string)> str) {
            using (var bulkcopy = new SqlBulkCopy(connectionString)) {
                //schrijf straten
                DataTable dt = new DataTable("straat");
                dt.Columns.Add(new DataColumn("id", Type.GetType("System.Int32")));
                dt.Columns.Add(new DataColumn("naam", Type.GetType("System.String")));
                bulkcopy.DestinationTableName = "straat";
                foreach (var x in str) {
                    dt.Rows.Add(x.Item1, x.Item2);
                }
                bulkcopy.WriteToServer(dt);
            }
        }
        private void WriteSegmentenToDB(HashSet<(int, int, int, int)> sgm) {
            using (var bulkcopy = new SqlBulkCopy(connectionString)) {
                //schrijf knopen
                DataTable dt = new DataTable("segment");
                dt.Columns.Add(new DataColumn("id", Type.GetType("System.Int32")));
                dt.Columns.Add(new DataColumn("beginknoopID", Type.GetType("System.Int32")));
                dt.Columns.Add(new DataColumn("eindknoopID", Type.GetType("System.Int32")));
                dt.Columns.Add(new DataColumn("lengte", Type.GetType("System.Int32")));
                bulkcopy.DestinationTableName = "segment";
                foreach (var x in sgm) {
                    dt.Rows.Add(x.Item1, x.Item2, x.Item3, x.Item4);
                }
                bulkcopy.WriteToServer(dt);
            }
        }
        private void WriteStraatSegmentenToDB(HashSet<(int, int)> strsgm) {
            using (var bulkcopy = new SqlBulkCopy(connectionString)) {
                //schrijf knopen
                DataTable dt = new DataTable("straatsegment");
                dt.Columns.Add(new DataColumn("straatID", Type.GetType("System.Int32")));
                dt.Columns.Add(new DataColumn("segmentID", Type.GetType("System.Int32")));
                bulkcopy.DestinationTableName = "straatsegment";
                foreach (var x in strsgm) {
                    dt.Rows.Add(x.Item1, x.Item2);
                }
                bulkcopy.WriteToServer(dt);
            }
        }
        private void WriteSegmentPuntenToDB(HashSet<(int, int, int)> sgmptn) {
            using (var bulkcopy = new SqlBulkCopy(connectionString)) {
                //schrijf knopen
                DataTable dt = new DataTable("segmentpunt");
                dt.Columns.Add(new DataColumn("segmentID", Type.GetType("System.Int32")));
                dt.Columns.Add(new DataColumn("puntID", Type.GetType("System.Int32")));
                dt.Columns.Add(new DataColumn("seqnr", Type.GetType("System.Int32")));
                bulkcopy.DestinationTableName = "segmentpunt";
                foreach (var x in sgmptn) {
                    dt.Rows.Add(x.Item1, x.Item2, x.Item3);
                }
                bulkcopy.WriteToServer(dt);
            }
        }
    }
}
