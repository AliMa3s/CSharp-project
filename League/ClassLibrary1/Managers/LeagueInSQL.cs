using ClassLibrary1.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using TeamsManager.Managers;
using System.Data;

namespace ClassLibrary1.Managers {
   public class LeagueInSQL : ILeague {
        private string connectionString;
        public LeagueInSQL(string connectionString) {
            this.connectionString = connectionString;
        }
        private SqlConnection getConnection() {
            SqlConnection connection = new SqlConnection(connectionString);
            return connection;
        }

        public Team RegistreerTeam(int stamnummer, string naam) {
            try {
                Team team = new Team(stamnummer, naam);
                VoegTeamToe(team);
                return team;
            } catch (Exception ex) {
                throw new LeagueException("RegistreerTeam", ex);
            }
        }
        private void VoegTeamToe(Team team) {
            SqlConnection connection = getConnection();
            string query = "INSERT INTO dbo.Team(stamnummer,naam,bijnaam) VALUES(@stamnummer,@naam,@bijnaam)";

            using (SqlCommand command = connection.CreateCommand()) {
                connection.Open();
                try {
                    command.Parameters.Add(new SqlParameter("@naam", SqlDbType.NVarChar));
                    command.Parameters.Add(new SqlParameter("@stamnummer", SqlDbType.Int));
                    command.Parameters.Add(new SqlParameter("@bijnaam", SqlDbType.NVarChar));

                    command.CommandText = query;
                    command.Parameters["@naam"].Value = team.Naam;
                    command.Parameters["@stamnummer"].Value = team.Stamnummer;
                    if (team.Bijnaam == null)
                        command.Parameters["@bijnaam"].Value = DBNull.Value;
                    else
                        command.Parameters["@bijnaam"].Value = team.Bijnaam;
                    command.ExecuteNonQuery();
                } catch (Exception ex) {
                    throw new LeagueException("VoegTeamToe", ex);
                } finally {
                    connection.Close();
                }
            }
        }
        public Team SelecteerTeam(int stamnummer) {
            SqlConnection connection = getConnection();
            string query = "SELECT t1.stamnummer,t1.naam as ploegnaam,t1.bijnaam,t2.* "
                + "FROM [dbo].[Team] t1 left join [dbo].[speler] t2 on t1.Stamnummer = t2.teamid "
                + "WHERE stamnummer=@stamnummer";
            using (SqlCommand command = connection.CreateCommand()) {
                command.Parameters.Add(new SqlParameter("@stamnummer", SqlDbType.Int));
                command.CommandText = query;
                command.Parameters["@stamnummer"].Value = stamnummer;
                connection.Open();
                try {
                    Team team = null;
                    IDataReader reader = command.ExecuteReader(); //of SqlDataReader
                    while (reader.Read()) {
                        if (team == null) {
                            string naam = (string)reader["ploegnaam"];
                            string bijnaam = null;
                            if (!reader.IsDBNull(reader.GetOrdinal("bijnaam"))) bijnaam = (string)reader["bijnaam"];
                            team = new Team(stamnummer, naam);
                            if (bijnaam != null) team.ZetBijnaam(bijnaam);
                        }
                        if (!reader.IsDBNull(reader.GetOrdinal("id"))) {
                            int? lengte = null;
                            if (!reader.IsDBNull(reader.GetOrdinal("lengte"))) lengte = (int?)reader["lengte"];
                            int? gewicht = null;
                            if (!reader.IsDBNull(reader.GetOrdinal("gewicht"))) gewicht = (int?)reader["gewicht"];
                            Speler speler = new Speler((int)reader["id"], (string)reader["naam"], team, lengte, gewicht);
                            if (!reader.IsDBNull(reader.GetOrdinal("rugnummer")))
                                speler.ZetRugnummer((int)reader["rugnummer"]);
                        }
                    }
                    reader.Close();
                    return team;
                } catch (Exception ex) {
                    throw new SpelerManagerException("selecteerTeam", ex);
                } finally {
                    connection.Close();
                }
            }
        }
        public Team SelecteerTeam(string ploegnaam) {
            SqlConnection connection = getConnection();
            string query = "SELECT t1.stamnummer,t1.naam as ploegnaam,t1.bijnaam,t2.* FROM [dbo].[Team] t1 left join [dbo].[speler] t2 on t1.Stamnummer = t2.teamid WHERE t1.naam=@naam";
            using (SqlCommand command = connection.CreateCommand()) {
                command.Parameters.Add(new SqlParameter("@naam", SqlDbType.NVarChar));
                command.CommandText = query;
                command.Parameters["@naam"].Value = ploegnaam;
                connection.Open();
                try {
                    Team team = null;
                    IDataReader reader = command.ExecuteReader(); //of SqlDataReader
                    while (reader.Read()) {
                        if (team == null) {
                            string naam = (string)reader["ploegnaam"];
                            string bijnaam = null;
                            if (!reader.IsDBNull(reader.GetOrdinal("bijnaam"))) bijnaam = (string)reader["bijnaam"];
                            team = new Team((int)reader["stamnummer"], ploegnaam);
                            if (bijnaam != null) team.ZetBijnaam(bijnaam);
                        }
                        if (!reader.IsDBNull(reader.GetOrdinal("id"))) {
                            int? lengte = null;
                            if (!reader.IsDBNull(reader.GetOrdinal("lengte"))) lengte = (int?)reader["lengte"];
                            int? gewicht = null;
                            if (!reader.IsDBNull(reader.GetOrdinal("gewicht"))) gewicht = (int?)reader["gewicht"];
                            Speler speler = new Speler((int)reader["id"], (string)reader["naam"], team, lengte, gewicht);
                            if (!reader.IsDBNull(reader.GetOrdinal("rugnummer"))) speler.ZetRugnummer((int)reader["rugnummer"]);
                        }
                    }
                    reader.Close();
                    return team;
                } catch (Exception ex) {
                    throw new SpelerManagerException("selecteerTeam", ex);
                } finally {
                    connection.Close();
                }
            }
        }
        public IReadOnlyList<Team> SelecteerTeams() {
            List<Team> teams = new List<Team>();
            SqlConnection connection = getConnection();
            string query = "SELECT t1.stamnummer,t1.naam as ploegnaam,t1.bijnaam,t2.* FROM [dbo].[Team] t1 left join [dbo].[speler] t2 on t1.Stamnummer = t2.teamid";
            using (SqlCommand command = connection.CreateCommand()) {
                command.CommandText = query;
                connection.Open();
                try {
                    Team team = null;
                    int stamnummer;
                    IDataReader reader = command.ExecuteReader(); //of SqlDataReader
                    while (reader.Read()) {
                        stamnummer = (int)reader["stamnummer"];
                        if ((team == null) || (team.Stamnummer != stamnummer)) {
                            string naam = (string)reader["ploegnaam"];
                            string bijnaam = null;
                            if (!reader.IsDBNull(reader.GetOrdinal("bijnaam"))) bijnaam = (string)reader["bijnaam"];
                            team = new Team(stamnummer, naam);
                            if (bijnaam != null) team.ZetBijnaam(bijnaam);
                            teams.Add(team);
                        }
                        if (!reader.IsDBNull(reader.GetOrdinal("id"))) {
                            int? lengte = null;
                            if (!reader.IsDBNull(reader.GetOrdinal("lengte"))) lengte = (int?)reader["lengte"];
                            int? gewicht = null;
                            if (!reader.IsDBNull(reader.GetOrdinal("gewicht"))) gewicht = (int?)reader["gewicht"];
                            Speler speler = new Speler((int)reader["id"], (string)reader["naam"], team, lengte, gewicht);
                            if (!reader.IsDBNull(reader.GetOrdinal("rugnummer"))) speler.ZetRugnummer((int)reader["rugnummer"]);
                        }
                    }
                    reader.Close();
                    return teams.AsReadOnly();
                } catch (Exception ex) {
                    throw new SpelerManagerException("selecteerTeams", ex);
                } finally {
                    connection.Close();
                }
            }
        }
        public void VerwijderTeam(Team team) {
            if (team is null) throw new LeagueException("VerwijderTeam");
            if (team.Spelers().Count > 0) throw new LeagueException("VerwijderTeam");
            SqlConnection connection = getConnection();
            string query = "DELETE FROM dbo.Team WHERE stamnummer=@stamnummer";

            using (SqlCommand command = connection.CreateCommand()) {
                connection.Open();
                try {
                    command.Parameters.Add(new SqlParameter("@stamnummer", SqlDbType.Int));
                    command.CommandText = query;
                    command.Parameters["@stamnummer"].Value = team.Stamnummer;
                    command.ExecuteNonQuery();
                } catch (Exception ex) {
                    throw new SpelerManagerException("VerwijderTeam", ex);
                } finally {
                    connection.Close();
                }
            }
        }
        public void UpdateTeam(Team team) {
            SqlConnection connection = getConnection();
            string query = "UPDATE team SET naam=@naam, bijnaam=@bijnaam WHERE stamnummer=@stamnummer";
            using (SqlCommand command = connection.CreateCommand()) {
                connection.Open();
                try {
                    command.Parameters.Add(new SqlParameter("@stamnummer", SqlDbType.Int));
                    command.Parameters.Add(new SqlParameter("@naam", SqlDbType.NVarChar));
                    command.Parameters.Add(new SqlParameter("@bijnaam", SqlDbType.NVarChar));
                    command.CommandText = query;
                    command.Parameters["@stamnummer"].Value = team.Stamnummer;
                    command.Parameters["@naam"].Value = team.Naam;
                    if (team.Bijnaam == null)
                        command.Parameters["@bijnaam"].Value = DBNull.Value;
                    else
                        command.Parameters["@bijnaam"].Value = team.Bijnaam;
                    command.ExecuteNonQuery();
                } catch (Exception ex) {
                    throw new LeagueException("UpdateTeam", ex);
                } finally {
                    connection.Close();
                }
            }
        }


    }
}
