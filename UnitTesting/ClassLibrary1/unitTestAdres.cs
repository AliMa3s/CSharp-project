using AdresSysteem;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace xunitTestProjectAdresSystem {
   public class unitTestAdres {
        [Fact]
        public void Test_ctr_valid() {
            //arrange
            string gemeente = "Gent";
            string straat = "kerkstraat";
            string huisnr = "12b";

            //act
            Adres a = new Adres(gemeente, straat, huisnr);
            //assert
            Assert.Equal(Gemeente.Gent, a.GemeenteNaam);
            Assert.Equal(9000, a.Postcode);
            Assert.Equal(straat, a.Straatnaam);
            Assert.Equal(huisnr, a.Huisnummer);

        }
        [Theory]
        [InlineData("Gent", "kerkstraat", "14b", Gemeente.Gent, 9000)]
        [InlineData("Aalst", "kerkstraat", "14b", Gemeente.Aalst, 9300)]
        [InlineData("Lokeren", "kerkstraat", "14b", Gemeente.Lokeren, 9160)]
        [InlineData("gent", "kerkstraat", "1", Gemeente.Gent, 9000)]
        [InlineData("aalst", "kerkstraat", "14b", Gemeente.Aalst, 9300)]
        [InlineData("lokeren", "kerk", "14b", Gemeente.Lokeren, 9160)]
        public void Test_ctr_valid_withTheory(string gemeentenaam,string straat, string huisnr, Gemeente gemeente, int postcode) {
            Adres a = new Adres(gemeentenaam, straat, huisnr);
            Assert.Equal(gemeente, a.GemeenteNaam);
            Assert.Equal(postcode, a.Postcode);
            Assert.Equal(straat, a.Straatnaam);
            Assert.Equal(huisnr, a.Huisnummer);
        }

        [Theory]
        [InlineData("Geent")]
        [InlineData("Alst")]
        [InlineData(" ")]
        [InlineData(null)]

        public void Test_ctr_invalid_gemeentenaam(string gemeentenaam) {
            Adres a;
            var ex = Assert.Throws<GemeenteException>(() => a = new Adres(gemeentenaam, "kerkstraat", "6"));
                Assert.Equal("Gemeentenaam invalid", ex.Message);
        }
        [Theory]
        [InlineData("")]
        [InlineData("  ")]
        [InlineData(null)]
        [InlineData(" \n ")]
        public void Test_ctr_invalid_straatnaam(string straatnaam) {
            Adres a;
            string huisnr = "12";
            string gemeentenaam = "Aalst";

            var ex = Assert.Throws<StraatnaamException>(() => a = new Adres(gemeentenaam, straatnaam, huisnr));
                Assert.Equal("Straatnaam invalid", ex.Message);
                Assert.Equal(straatnaam, ex.Data["straatnaam"]);
                Assert.Equal(huisnr, ex.Data["huisnummer"]);
                Assert.Equal(gemeentenaam, ex.Data["gemeente"]);
        }
        [Theory]
        [InlineData("")]
        [InlineData("  ")]
        [InlineData(null)]
        [InlineData("b12")]
        [InlineData("-12")]
        public void Test_ctr_invalid_huisnr(string huisnr) {
            string gemeentenaam = "Aalst";
            string straatnaam = "boomstraat";
            Adres a;
            var ex = Assert.Throws<HuisnummerException>(() => a = new Adres(gemeentenaam, straatnaam, huisnr));
            Assert.Equal("Straatnaam invalid", ex.Message);
            Assert.Equal(straatnaam, ex.Data["straatnaam"]);
            Assert.Equal(huisnr, ex.Data["huisnummer"]);
            Assert.Equal(gemeentenaam, ex.Data["gemeente"]);
        }
        [Fact]
        public void Test_PrintPostAdresOpLijn() {
            string gemeente = "Gent";
            string straat = "kerkstraat";
            string huisnr = "12b";
            int postcode = 9000;
            Adres a = new Adres(gemeente, straat, huisnr);
            string res = a.PrintPostAdresOpLijn();
            Assert.DoesNotContain("\n", res);
            Assert.DoesNotContain("\r", res);
            Assert.DoesNotContain(gemeente, res);
            Assert.DoesNotContain(straat, res);
            Assert.DoesNotContain(huisnr, res);
            Assert.DoesNotContain(postcode.ToString(), res);
        }
        [Fact]
        public void Test_PrintPostAdres() {
            string gemeente = "Gent";
            string straat = "kerkstraat";
            string huisnr = "12b";
            int postcode = 9000;
            Adres a = new Adres(gemeente, straat, huisnr);
            string res = a.PrintPostAdresOpLijn();
            Assert.Contains("\n", res);
            Assert.Contains(gemeente, res);
            Assert.Contains(straat, res);
            Assert.Contains(huisnr, res);
            Assert.Contains(postcode.ToString(), res);
        }
    }
}
