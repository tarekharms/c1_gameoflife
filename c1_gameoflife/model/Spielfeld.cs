using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c1_gameoflife.model
{
	public class Spielfeld
	{
		public const sbyte TOT = 0;
		public const sbyte LEBT = 1;
		public const sbyte STIRBT = 2;
		public const sbyte GEBURT = 3;

		private sbyte[,] spielfeld;

		public int Breite
		{
			get { return this.spielfeld.GetLength(0); }
		}

		public int Hoehe
		{
			get { return this.spielfeld.GetLength(1); }
		}


		public Spielfeld(int breite, int hoehe)
		{
			this.spielfeld = new sbyte[breite, hoehe];

			for (int x = 0; x < breite; x++)
			{
				for (int y = 0; y < hoehe; y++)
				{
					this.spielfeld[x, y] = 0;
				}
			}
		}

		public void fillRandom()
		{
			Random random = new Random();

			for (int x = 0; x < this.Breite; x++)
			{
				for (int y = 0; y < this.Hoehe; y++)
				{
					this.spielfeld[x, y] = (sbyte)random.Next(0, 2);
				}
			}
		}

		public sbyte getPunkt(int x, int y)
		{
			return this.spielfeld[x, y];
		}

		public void setPunkt(int x, int y, sbyte value)
		{
			this.spielfeld[x, y] = value;
		}

		public sbyte changePunkt(int x , int y)
		{
			if(this.spielfeld[x, y] == Spielfeld.LEBT)
			{
				this.spielfeld[x, y] = Spielfeld.TOT;
			}
			else if(this.spielfeld[x, y] == Spielfeld.TOT)
			{
				this.spielfeld[x, y] = Spielfeld.LEBT;
			}

			return this.spielfeld[x, y];
		}

		public void parseSpielfeld()
		{
			for(int y = 0; y < this.Hoehe; y++)
			{
				for(int x = 0; x < this.Breite; x++)
				{
					this.parseZelle(x, y);
				}
			}
		}

		private void parseZelle(int x, int y)
		{
			if (this.spielfeld[x, y] == GEBURT)
			{
				this.spielfeld[x, y] = LEBT;
			}
			else if (this.spielfeld[x, y] == STIRBT)
			{
				this.spielfeld[x, y] = TOT;
			}
		}

		public int getAnzahlNachbarn(int punktX, int punktY)
		{
			int anzahlNachbarn = 0;

			for(int x = punktX - 1; x <= punktX + 1; x++)
			{
				if (x < 0 || x >= this.Breite)
					continue;

				for(int y = punktY - 1; y <= punktY + 1; y++)
				{
					if (y < 0 || y >= this.Hoehe)
						continue;
					else if (x == punktX && y == punktY)
						continue;

					if (this.getPunkt(x, y) == 1 || this.getPunkt(x, y) == 2)
						anzahlNachbarn++;
				}
			}

			return anzahlNachbarn;
		}
	}
}
