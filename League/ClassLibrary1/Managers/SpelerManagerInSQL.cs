using ClassLibrary1.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using TeamsManager.Managers;

namespace ClassLibrary1.Managers {
   public class SpelerManagerInSQL : ISpelerManager {
        private string connectionString;
        private ILeague league;

        public SpelerManagerInSQL(string connectionString, ILeague league) {
            this.connectionString = connectionString;
            this.league = league;
        }
        private SqlConnection getConnection() {
            SqlConnection connection = new SqlConnection(connectionString);
            return connection;
        }
        public Speler RegistreerSpeler(string naam, int? lengte, int? gewicht) {
            try {
                Speler s = VoegSpelerToe(naam, lengte, gewicht);
                return s;
            } catch (Exception ex) {
                throw new SpelerManagerException("registreerSpeler", ex);
            }
        }
        private Speler VoegSpelerToe(string naam, int? lengte, int? gewicht) {
            SqlConnection connection = getConnection();
            string query = "INSERT INTO dbo.Speler(naam,lengte,gewicht) output INSERTED.ID VALUES(@naam,@lengte,@gewicht)";

            using (SqlCommand command = connection.CreateCommand()) {
                connection.Open();
                try {
                    command.Parameters.Add(new SqlParameter("@naam", SqlDbType.NVarChar));
                    command.Parameters.Add(new SqlParameter("@lengte", SqlDbType.Int));
                    command.Parameters.Add(new SqlParameter("@gewicht", SqlDbType.Int));

                    command.CommandText = query;
                    command.Parameters["@naam"].Value = naam;
                    if (lengte == null)
                        command.Parameters["@lengte"].Value = DBNull.Value;
                    else
                        command.Parameters["@lengte"].Value = lengte;
                    if (gewicht == null)
                        command.Parameters["@gewicht"].Value = DBNull.Value;
                    else
                        command.Parameters["@gewicht"].Value = gewicht;
                    int newID = (int)command.ExecuteScalar();
                    return new Speler(newID, naam, lengte, gewicht);
                } catch (Exception ex) {
                    throw new SpelerManagerException("VoegSpelerToe", ex);
                } finally {
                    connection.Close();
                }
            }
        }
        public Speler SelecteerSpeler(string naam) {
            SqlConnection connection = getConnection();
            string query = "SELECT * FROM dbo.speler WHERE naam=@naam";
            using (SqlCommand command = connection.CreateCommand()) {
                command.Parameters.Add(new SqlParameter("@naam", SqlDbType.NVarChar));
                command.CommandText = query;
                command.Parameters["@naam"].Value = naam;
                connection.Open();
                try {
                    IDataReader reader = command.ExecuteReader(); //of SqlDataReader
                    reader.Read();
                    Team team = null;
                    if (!reader.IsDBNull(reader.GetOrdinal("teamid"))) {
                        team = league.SelecteerTeam((int)reader["teamid"]);
                    }
                    Speler speler;
                    int? lengte = null;
                    if (!reader.IsDBNull(reader.GetOrdinal("lengte"))) lengte = (int?)reader["lengte"];
                    int? gewicht = null;
                    if (!reader.IsDBNull(reader.GetOrdinal("gewicht"))) gewicht = (int?)reader["gewicht"];
                    if (team == null)
                        speler = new Speler((int)reader["id"], (string)reader["naam"], lengte, gewicht);
                    else
                        speler = new Speler((int)reader["id"], (string)reader["naam"], team, lengte, gewicht);
                    if (!reader.IsDBNull(reader.GetOrdinal("rugnummer")))
                        speler.ZetRugnummer((int)reader["rugnummer"]);
                    reader.Close();
                    return speler;
                } catch (Exception ex) {
                    throw new SpelerManagerException("selecteerSpeler", ex);
                } finally {
                    connection.Close();
                }
            }
        }
        public IReadOnlyList<Speler> SelecteerSpelers() {
            List<Speler> spelers = new List<Speler>();
            SqlConnection connection = getConnection();
            string query = "SELECT * FROM dbo.speler";
            using (SqlCommand command = connection.CreateCommand()) {
                command.CommandText = query;
                connection.Open();
                try {
                    IDataReader reader = command.ExecuteReader(); //of SqlDataReader
                    while (reader.Read()) {
                        Team team = null;
                        if (!reader.IsDBNull(reader.GetOrdinal("teamid"))) {
                            team = league.SelecteerTeam((int)reader["teamid"]);
                        }
                        Speler speler;
                        int? lengte = null;
                        if (!reader.IsDBNull(reader.GetOrdinal("lengte"))) lengte = (int?)reader["lengte"];
                        int? gewicht = null;
                        if (!reader.IsDBNull(reader.GetOrdinal("gewicht"))) gewicht = (int?)reader["gewicht"];
                        if (team == null)
                            speler = new Speler((int)reader["id"], (string)reader["naam"], lengte, gewicht);
                        else
                            speler = new Speler((int)reader["id"], (string)reader["naam"], team, lengte, gewicht);
                        if (!reader.IsDBNull(reader.GetOrdinal("rugnummer")))
                            speler.ZetRugnummer((int)reader["rugnummer"]);
                        spelers.Add(speler);
                    }
                    reader.Close();
                    return spelers;
                } catch (Exception ex) {
                    throw new SpelerManagerException("selecteerSpelers", ex);
                } finally {
                    connection.Close();
                }
            }
        }
        public IReadOnlyList<Transfer> SelecteerTransfers() {
            List<Transfer> transfers = new List<Transfer>();
            SqlConnection connection = getConnection();
            string query = "SELECT * FROM dbo.transfer";
            using (SqlCommand command = connection.CreateCommand()) {
                connection.Open();
                try {
                    command.CommandText = query;
                    IDataReader reader = command.ExecuteReader(); //of SqlDataReader
                    while (reader.Read()) {
                        int id = (int)reader["id"];
                        int prijs = (int)reader["prijs"];
                        int spelerId = (int)reader["spelerid"];
                        Team oudTeam = null;
                        Team nieuwTeam = null;
                        if (!reader.IsDBNull(reader.GetOrdinal("oudteamid"))) {
                            oudTeam = league.SelecteerTeam((int)reader["oudteamid"]);
                        }
                        if (!reader.IsDBNull(reader.GetOrdinal("nieuwteamid"))) {
                            nieuwTeam = league.SelecteerTeam((int)reader["nieuwteamid"]);
                        }
                        Speler speler = SelecteerSpeler(spelerId);
                        Transfer t = new Transfer(id, speler, nieuwTeam, oudTeam, prijs);
                        transfers.Add(t);
                    }
                    return transfers;
                } catch (Exception ex) {
                    throw new SpelerManagerException("selecteerTransfers", ex);
                } finally {
                    connection.Close();
                }
            }
        }
        private void MaakTransfer(Transfer transfer, Speler speler) {
            SqlConnection connection = getConnection();
            connection.Open();
            SqlTransaction transaction = connection.BeginTransaction();
            try {
                SchrijfTransfer(transfer, connection, transaction);
                UpdateSpeler(speler, connection, transaction);
                transaction.Commit();
            } catch (Exception ex) {
                transaction.Rollback();
                throw new SpelerManagerException("MaakTransfer", ex);
            } finally {
                connection.Close();
            }
        }
        public void TransfereerSpeler(Speler speler, Team naarTeam, int prijs) {
            if (speler == null) throw new SpelerManagerException("transferSpeler");
            if (prijs < 0) throw new SpelerManagerException("transferSpeler");
            if ((speler.Team == null) && (naarTeam == null)) throw new SpelerManagerException("transferSpeler");
            Transfer transfer = new Transfer(speler, prijs);
            try {
                if (naarTeam != null) {
                    if (speler.Team != null) transfer.ZetOudTeam(speler.Team);
                    transfer.ZetNieuwTeam(naarTeam);
                    speler.ZetTeam(naarTeam);
                } else {
                    speler.VerwijderTeam();
                }
                MaakTransfer(transfer, speler);
            } catch (Exception ex) {
                throw new SpelerManagerException("TransfereerSpeler", ex);
            }
        }
        private int SchrijfTransfer(Transfer transfer, SqlConnection sqlconnection = null, SqlTransaction transaction = null) {
            SqlConnection connection;
            if (sqlconnection is null)
                connection = getConnection();
            else connection = sqlconnection;
            string query = "INSERT INTO dbo.Transfer(spelerid,prijs,oudteamid,nieuwteamid) "
                + "output INSERTED.ID VALUES(@spelerid,@prijs,@oudteamid,@nieuwteamid)";

            using (SqlCommand command = connection.CreateCommand()) {
                if (transaction != null) command.Transaction = transaction;
                if (connection.State != ConnectionState.Open) connection.Open();
                try {
                    command.Parameters.Add(new SqlParameter("@spelerid", SqlDbType.Int));
                    command.Parameters.Add(new SqlParameter("@prijs", SqlDbType.Int));
                    command.Parameters.Add(new SqlParameter("@oudteamid", SqlDbType.Int));
                    command.Parameters.Add(new SqlParameter("@nieuwteamid", SqlDbType.Int));
                    command.CommandText = query;
                    command.Parameters["@spelerid"].Value = transfer.Speler.Id;
                    command.Parameters["@prijs"].Value = transfer.Prijs;
                    if (transfer.OudTeam == null)
                        command.Parameters["@oudteamid"].Value = DBNull.Value;
                    else
                        command.Parameters["@oudteamid"].Value = transfer.OudTeam.Stamnummer;
                    if (transfer.NieuwTeam == null)
                        command.Parameters["@nieuwteamid"].Value = DBNull.Value;
                    else
                        command.Parameters["@nieuwteamid"].Value = transfer.NieuwTeam.Stamnummer;
                    int newID = (int)command.ExecuteScalar();
                    return newID;
                } catch (Exception ex) {
                    throw new SpelerManagerException("SchrijfTransfer", ex);
                } finally {
                    if (sqlconnection is null) connection.Close();
                }
            }
        }
        private bool HeeftSpeler(int spelerId) {
            SqlConnection connection = getConnection();
            string query = "Select count(*) FROM dbo.Speler WHERE id=@id";

            using (SqlCommand command = connection.CreateCommand()) {
                connection.Open();
                try {
                    command.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
                    command.CommandText = query;
                    command.Parameters["@id"].Value = spelerId;
                    int n = (int)command.ExecuteScalar();
                    if (n > 0) return true; else return false;
                } catch (Exception ex) {
                    throw new SpelerManagerException("HeeftSpeler", ex);
                } finally {
                    connection.Close();
                }
            }
        }
        public void VerwijderSpeler(Speler speler) {
            try {
                if (!HeeftSpeler(speler.Id)) {
                    throw new SpelerManagerException("VerwijderSpeler");
                } else {
                    DeleteSpeler(speler.Id);
                }
            } catch (Exception ex) {
                throw new SpelerManagerException("VerwijderSpeler", ex);
            }
        }
        public void VerwijderSpeler(int spelerId) {
            try {
                if (!HeeftSpeler(spelerId)) {
                    throw new SpelerManagerException("VerwijderSpeler");
                } else {
                    DeleteSpeler(spelerId);
                }
            } catch (Exception ex) {
                throw new SpelerManagerException("VerwijderSpeler", ex);
            }
        }
        private void DeleteSpeler(int spelerId) {
            SqlConnection connection = getConnection();
            string query = "DELETE FROM dbo.Speler WHERE id=@id";
            using (SqlCommand command = connection.CreateCommand()) {
                connection.Open();
                try {
                    command.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
                    command.CommandText = query;
                    command.Parameters["@id"].Value = spelerId;
                    int n = command.ExecuteNonQuery();
                    if (n != 1) throw new SpelerManagerException("Deleted more than 1 row");
                } catch (Exception ex) {
                    throw new SpelerManagerException("DeleteSpeler", ex);
                } finally {
                    connection.Close();
                }
            }
        }
        public Speler SelecteerSpeler(int spelerId) {
            SqlConnection connection = getConnection();
            string query = "SELECT * FROM dbo.speler WHERE id=@id";
            using (SqlCommand command = connection.CreateCommand()) {
                command.CommandText = query;
                SqlParameter paramId = new SqlParameter();
                paramId.ParameterName = "@id";
                paramId.DbType = DbType.String;
                paramId.Value = spelerId;
                command.Parameters.Add(paramId);
                connection.Open();
                try {
                    IDataReader reader = command.ExecuteReader(); //of SqlDataReader
                    reader.Read();
                    Team team = null;
                    if (!reader.IsDBNull(reader.GetOrdinal("teamid"))) {
                        team = league.SelecteerTeam((int)reader["teamid"]);
                    }
                    Speler speler;
                    int? lengte = null;
                    if (!reader.IsDBNull(reader.GetOrdinal("lengte"))) lengte = (int?)reader["lengte"];
                    int? gewicht = null;
                    if (!reader.IsDBNull(reader.GetOrdinal("gewicht"))) gewicht = (int?)reader["gewicht"];
                    if (team == null)
                        speler = new Speler((int)reader["id"], (string)reader["naam"], lengte, gewicht);
                    else
                        speler = new Speler((int)reader["id"], (string)reader["naam"], team, lengte, gewicht);
                    if (!reader.IsDBNull(reader.GetOrdinal("rugnummer")))
                        speler.ZetRugnummer((int)reader["rugnummer"]);

                    reader.Close();
                    return speler;
                } catch (Exception ex) {
                    throw new SpelerManagerException("selecteerSpeler", ex);
                } finally {
                    connection.Close();
                }
            }
        }
        public IReadOnlyList<Transfer> SelecteerTransfers(int spelerId) {
            List<Transfer> transfers = new List<Transfer>();
            SqlConnection connection = getConnection();
            Speler speler = SelecteerSpeler(spelerId);
            string query = "SELECT * FROM dbo.transfer WHERE spelerid=@spelerid";
            using (SqlCommand command = connection.CreateCommand()) {
                command.Parameters.Add(new SqlParameter("@spelerid", SqlDbType.Int));
                command.CommandText = query;
                command.Parameters["@spelerid"].Value = spelerId;
                connection.Open();
                try {
                    IDataReader reader = command.ExecuteReader(); //of SqlDataReader
                    while (reader.Read()) {
                        int id = (int)reader["id"];
                        int prijs = (int)reader["prijs"];
                        Team oudTeam = null;
                        Team nieuwTeam = null;
                        if (!reader.IsDBNull(reader.GetOrdinal("oudteamid"))) {
                            oudTeam = league.SelecteerTeam((int)reader["oudteamid"]);
                        }
                        if (!reader.IsDBNull(reader.GetOrdinal("nieuwteamid"))) {
                            nieuwTeam = league.SelecteerTeam((int)reader["nieuwteamid"]);
                        }
                        Transfer t = new Transfer(id, speler, nieuwTeam, oudTeam, prijs);
                        transfers.Add(t);
                    }
                    return transfers;
                } catch (Exception ex) {
                    throw new SpelerManagerException("selecteerTransfers", ex);
                } finally {
                    connection.Close();
                }
            }
        }
        public void UpdateSpeler(Speler speler) {
            UpdateSpeler(speler);
        }
        private void UpdateSpeler(Speler speler, SqlConnection sqlconnection = null, SqlTransaction transaction = null) {
            SqlConnection connection;
            if (sqlconnection is null)
                connection = getConnection();
            else connection = sqlconnection;
            string query = "UPDATE speler SET naam=@naam, rugnummer=@rugnummer,lengte=@lengte,"
                + "gewicht=@gewicht,teamid=@teamid WHERE id=@id";

            using (SqlCommand command = connection.CreateCommand()) {
                if (transaction != null) command.Transaction = transaction;
                if (connection.State != ConnectionState.Open) connection.Open();
                try {
                    command.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
                    command.Parameters.Add(new SqlParameter("@naam", SqlDbType.NVarChar));
                    command.Parameters.Add(new SqlParameter("@lengte", SqlDbType.Int));
                    command.Parameters.Add(new SqlParameter("@gewicht", SqlDbType.Int));
                    command.Parameters.Add(new SqlParameter("@rugnummer", SqlDbType.Int));
                    command.Parameters.Add(new SqlParameter("@teamid", SqlDbType.Int));

                    command.CommandText = query;
                    command.Parameters["@id"].Value = speler.Id;
                    command.Parameters["@naam"].Value = speler.Naam;
                    if (speler.Lengte == null)
                        command.Parameters["@lengte"].Value = DBNull.Value;
                    else
                        command.Parameters["@lengte"].Value = speler.Lengte;
                    if (speler.Gewicht == null)
                        command.Parameters["@gewicht"].Value = DBNull.Value;
                    else
                        command.Parameters["@gewicht"].Value = speler.Gewicht;
                    if (speler.Rugnummer == null)
                        command.Parameters["@rugnummer"].Value = DBNull.Value;
                    else
                        command.Parameters["@rugnummer"].Value = speler.Rugnummer;
                    if (speler.Team == null)
                        command.Parameters["@teamid"].Value = DBNull.Value;
                    else
                        command.Parameters["@teamid"].Value = speler.Team.Stamnummer;
                    command.ExecuteNonQuery();
                } catch (Exception ex) {
                    throw new SpelerManagerException("UpdateSpeler", ex);
                } finally {
                    if (sqlconnection is null) connection.Close();
                }
            }
        }
    }
}
