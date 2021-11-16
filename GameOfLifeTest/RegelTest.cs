using System;
using Xunit;
using c1_gameoflife.model;

namespace GameOfLifeTest
{
    public class RegelTest
    {
        [Theory]
        [InlineData(feldlebt0, Spielfeld.TOT)]
        [InlineData(feldlebt1, Spielfeld.TOT)]
        [InlineData(feldlebt2, Spielfeld.LEBT)]
        [InlineData(feldlebt3, Spielfeld.LEBT)]
        [InlineData(feldlebt4, Spielfeld.TOT)]
        [InlineData(feldlebt5, Spielfeld.TOT)]
        [InlineData(feldlebt6, Spielfeld.TOT)]
        [InlineData(feldlebt7, Spielfeld.TOT)]
        [InlineData(feldlebt8, Spielfeld.TOT)]
        [InlineData(feldtot0, Spielfeld.TOT)]
        [InlineData(feldtot1, Spielfeld.TOT)]
        [InlineData(feldtot2, Spielfeld.TOT)]
        [InlineData(feldtot3, Spielfeld.LEBT)]
        [InlineData(feldtot4, Spielfeld.TOT)]
        [InlineData(feldtot5, Spielfeld.TOT)]
        [InlineData(feldtot6, Spielfeld.TOT)]
        [InlineData(feldtot7, Spielfeld.TOT)]
        [InlineData(feldtot8, Spielfeld.TOT)]
        public void zellenRegelTest(string feld, sbyte status)
        {
            Spielfeld spielfeld = parseFromString(feld);
            Regeln.regelnAnwendenSpielfeld(spielfeld);

            Assert.Equal(status, spielfeld.getPunkt(1, 1));            
        }

        private const string feldlebt0 = "000010000";
        private const string feldlebt1 = "100010000";
        private const string feldlebt2 = "110010000";
        private const string feldlebt3 = "111010000";
        private const string feldlebt4 = "111110000";
        private const string feldlebt5 = "111111000";
        private const string feldlebt6 = "111111100";
        private const string feldlebt7 = "111111110";
        private const string feldlebt8 = "111111111";

        private const string feldtot0 = "000000000";
        private const string feldtot1 = "100000000";
        private const string feldtot2 = "110000000";
        private const string feldtot3 = "111000000";
        private const string feldtot4 = "111100000";
        private const string feldtot5 = "111101000";
        private const string feldtot6 = "111101100";
        private const string feldtot7 = "111101110";
        private const string feldtot8 = "111101111";

        private static Spielfeld parseFromString(string spielfeldString)
        {
            Spielfeld spielfeld = new Spielfeld(3, 3);

            for(int x = 0; x < 3; x++)
            {
                for(int y = 0; y < 3; y++)
                {
                    sbyte value = sbyte.Parse(spielfeldString[y * 3 + x].ToString());
                    spielfeld.setPunkt(x, y, value);
                }
            }

            return spielfeld;
        }
        
    }
}
