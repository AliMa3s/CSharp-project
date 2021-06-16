using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace XunitsTestTeamsManager {
   public class UnitTestSpeler {
        [Theory]
        [InlineData(10,"naam","Testnaam","Testnaam")]
        [InlineData(10,"naam","Testnaam    ","Testnaam")]
        public void Test_ZetNaam_valid(int id, string naam, string newNaam, string resNaam) {
            Speler s = new Speler(id, naam);
            s.ZetNaam(newNaam);
            Assert.Equal(resNaam, s.Naam);
        }
        [Theory]
        [InlineData(10,"naam", " ")]
        [InlineData(10,"naam", " \n    ")]
        [InlineData(10,"naam", null)]
        public void Test_ZetNaaminvalid(int id, string naam, string newNaam) {
            Speler s = new Speler(id, naam);
            Assert.Throws<SpelerException>(() => s.ZetNaam(newNaam));
            Assert.Equal(naam, s.Naam);
        }

        [Fact]
        public void Test_Zetnaam() {
            Speler s = new Speler(10, "naam");
            Team t = new Team(1 ,"Team1");
            s.ZetTeam(t);
            Assert.Equal(t, s.Team);
            Assert.Contains(s, t.Spelers());
            Assert.True(t.HeeftSpeler(s));

        }
        [Theory]
        [InlineData(99)]
        [InlineData(1)]

        public void ZetRugnummer_Rugnummer(int rugnummer) {
            Speler s = new Speler(11, "Ali");
            s.ZetRugnummer(rugnummer);
            Assert.Equal(rugnummer, s.Rugnummer);
        }
        [Theory]
        [InlineData (11, "AliA",0)]
        [InlineData (11, "AliA",100)]
        [InlineData (11, "AliA",-2)]
        public void ZetRugnummer_invalid(int id, string spelernaam, int nieuweRugnummer) {
            Speler s = new Speler(id, spelernaam);
            s.ZetRugnummer(90);
            var ex = Assert.Throws<SpelerException>(() => s.ZetRugnummer(nieuweRugnummer));
            Assert.Equal("ZetRugnummer", ex.Message);
            Assert.Equal(90, s.Rugnummer);
        }
    }
}
