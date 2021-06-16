using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1.Interfaces {
   public interface ILeague {
        Team RegistreerTeam(int stamnummer, string naam);
        Team SelecteerTeam(int stamnummer);
        Team SelecteerTeam(string naam);
        IReadOnlyList<Team> SelecteerTeams();
        void VerwijderTeam(Team team);
        void UpdateTeam(Team team);
    }
}
