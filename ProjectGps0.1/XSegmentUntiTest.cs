using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Classen;

namespace UnitTesting {
   public class XSegmentUntiTest {
        [Theory]
        [InlineData(1)]
        [InlineData(1000)]

        public void ZetSegmentID_Valid(int id) {
            List<Punt> punten = new List<Punt>();
            punten.Add(new Punt(1, 5));
            punten.Add(new Punt(7, 14));
            Segmant s = new Segmant(10,punten , new Knoop(3, new Punt(1, 5)),new Knoop(8, new Punt(5,1)));
            s.SetSegmentId(id);
            Assert.Equal(id, s.SegmentId);
        }
    }
}
