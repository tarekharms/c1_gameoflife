using System.IO;
using System.Collections.Generic;
using System.Text;

namespace c1_gameoflife.model
{
    public class SavegameHandler
    {
        public static void save(Spielfeld spielfeld, string filePath)
        {
            List<string> lines = new List<string>();

            for(int y = 0; y < spielfeld.Hoehe; y++)
            {
                string line = "";

                for(int x = 0; x < spielfeld.Breite; x++)
                {
                    line += spielfeld.getPunkt(x, y);
                }

                lines.Add(line);
            }

            File.WriteAllLines(filePath, lines, Encoding.ASCII);
        }

        public static Spielfeld load(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);
            Spielfeld spielfeld = new Spielfeld(lines[0].Length, lines.Length);

            for(int y = 0; y < lines.Length; y++)
            {
                for(int x = 0; x < lines[0].Length; x++)
                {
                    sbyte value = sbyte.Parse(lines[y][x].ToString());
                    spielfeld.setPunkt(x, y, value);
                }
            }

            return spielfeld;
        }
    }
}
