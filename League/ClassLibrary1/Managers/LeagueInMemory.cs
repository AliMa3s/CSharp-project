using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace TeamsManager.Managers
{
    public class LeagueInMemory //: ILeague
    {
        private List<Team> _teams=new List<Team>();

        private void VoegTeamToe(Team team)
        {
            if (_teams.Contains(team)) throw new LeagueException("VoegTeamToe");
            _teams.Add(team);
        }
        public void VerwijderTeam(Team team)
        {
            if (!_teams.Contains(team)) throw new LeagueException("VerwijderTeam");
            _teams.Remove(team);
        }
        public Team SelecteerTeam(int stamnummer)
        {
            if (_teams.Any(x => x.Stamnummer == stamnummer)) return _teams.Find(x => x.Stamnummer == stamnummer);
            throw new LeagueException("SelecteerTeam");
        }
        public Team SelecteerTeam(string naam)
        {
            if (_teams.Any(x => x.Naam == naam)) return _teams.Find(x => x.Naam == naam);
            throw new LeagueException("SelecteerTeam");
        }
        public IReadOnlyList<Team> SelecteerTeams()
        {
            return _teams.AsReadOnly();
        }
        public Team RegistreerTeam(int stamnummer,string naam)
        {
            try
            {
                Team team = new Team(stamnummer, naam);
                VoegTeamToe(team);
                return team;
            }
            catch(Exception ex)
            {
                throw new LeagueException("RegistreerTeam", ex);
            }
        }
    }
}
