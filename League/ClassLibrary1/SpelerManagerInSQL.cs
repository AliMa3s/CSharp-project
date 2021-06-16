using System;
using System.Collections.Generic;
using System.Data.SqlClient;
/*using System.Text;
using TeamsManager.Managers;
using System.Data;

namespace ClassLibrary1 {
   public class SpelerManagerInSQL {
        private string ConnectionString { get; set; } = @"Data Source=DESKTOP-PS4V4IA\SQLEXPRESS;Initial Catalog=League;Integrated Security=True";
        public SpelerManagerInSQL() {

        }

        public Speler RegisterSpeler(string naam, int? lengte, int? gewicht) {
            try {
                Speler s = VoegSpelerToe(naam, lengte, gewicht);
                return s;
            } catch (Exception ex) {

                throw new SpelerManagerException("Registreer speler foutief", ex);
            }
        }

        private Speler VoegSpelerToe(string naam, int? lengte, int? gewicht) {
            SqlConnection sqc = new SqlConnection(ConnectionString);
            string query = "INSERT INTO dbo.Speler(naam,lengte,gewicht) output INSERTED.ID VALUES(@naam,@lengte,@gewicht)";
            using(SqlCommand command = sqc.CreateCommand()){
                sqc.Open();
                try {

                    command.Parameters.Add(new SqlParameter("@naam", SqlDbType.NVarChar));
                    command.Parameters.Add(new SqlParameter("@lengte", SqlDbType.Int));
                    command.Parameters.Add(new SqlParameter("@gewicht", SqlDbType.Int));
                    command.CommandText = query;
                    command.Parameters["@naam"].Value = naam;
                    if(lengte == null) {
                        command.Parameters["@lengte"].Value = DBNull.Value;
                    } else {
                    command.Parameters["@lengte"].Value = lengte;
                    }
                    if (gewicht == null) {
                        command.Parameters["@gewicht"].Value = DBNull.Value;
                    } else {
                    command.Parameters["@gewicht"].Value = gewicht;
                    }

                    int id = (int) command.ExecuteScalar();

                    return new Speler(id, naam, lengte, gewicht);
                } catch (Exception ex) {

                    throw new SpelerManagerException("Voeg speler toe mislukt", ex);
                } finally {
                    sqc.Close();
                }
                
            }
        }
    }
}
*/