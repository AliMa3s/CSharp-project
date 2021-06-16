using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace XunitsTestTeamsManager {
   public class UnitTestTeam {
        private Team team;
        private List<Speler> spelers = new List<Speler>();
        public UnitTestTeam() {
            team = new Team(10, "TestTeamNaam");
            spelers.Add(new Speler(5, "Jeff"));
            spelers.Add(new Speler(6, "Cis"));
            spelers.Add(new Speler(9, "Jules"));
        }

        [Theory]
        [InlineData(10, "naam", "Testnaam", "Testnaam")]
        [InlineData(10, "naam", " Testnaam    ", "Testnaam")]
        public void Test_ZetNaam_valid(int id, string naam, string newNaam, string resNaam) {
            Team t = new Team(id, naam);
            t.ZetNaam(newNaam);
            Assert.Equal(resNaam, t.Naam);
        }
        [Theory]
        [InlineData(5, "Jeff")]
        [InlineData(9, "Jules")]
        public void Test_HeeftSpeler_valid(int id, string naam) {
            foreach (Speler s in spelers) team.VoegSpelerToe(s);
            Speler sp = new Speler(id, naam);
            Assert.True(team.HeeftSpeler(sp));
        }
        [Theory]
        [InlineData(6, "Jeff")]
        [InlineData(5, "Jules")]
        public void Test_HeeftSpeler_invalid(int id, string naam) {
            Assert.False(team.HeeftSpeler(new Speler(id, naam)));
        }
        [Fact]
        public void Test_VoegSpelerToe_valid() {
            team.VoegSpelerToe(spelers[0]);
            Assert.True(team.HeeftSpeler(spelers[0]));
            Assert.Equal(1, team.Spelers().Count);
            Assert.Equal(team, spelers[0].Team);

            team.VoegSpelerToe(spelers[1]);
            Assert.True(team.HeeftSpeler(spelers[0]));
            Assert.True(team.HeeftSpeler(spelers[1]));
            Assert.Equal(2, team.Spelers().Count);
            Assert.Equal(team, spelers[0].Team);
            Assert.Equal(team, spelers[1].Team);
        }
        [Fact]
        public void Test_VoegSpelerToe_invalid() {
            team.VoegSpelerToe(spelers[0]);
            Assert.True(team.HeeftSpeler(spelers[0]));
            Assert.Equal(1, team.Spelers().Count);
            Assert.Equal(team, spelers[0].Team);

            Assert.Throws<TeamException>(() => team.VoegSpelerToe(spelers[0]));
            Assert.Throws<TeamException>(() => team.VoegSpelerToe(null));

            Assert.True(team.HeeftSpeler(spelers[0]));
            Assert.Equal(1, team.Spelers().Count);
            Assert.Equal(team, spelers[0].Team);
        }
    }
}
