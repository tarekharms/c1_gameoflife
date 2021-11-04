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

		private int breite;
		public int Breite
		{
			get { return this.breite; }
		}

		public int Hoehe
		{
			get { return this.hoehe; }
		}

		private int hoehe;

		public Spielfeld(int breite, int hoehe)
		{
			this.breite = breite;
			this.hoehe = hoehe;

			this.initialise();
		}

		private void initialise()
		{
			this.spielfeld = new sbyte[this.breite, this.hoehe];

			for(int x = 0; x < this.breite; x++)
			{
				for(int y = 0; y < this.hoehe; y++)
				{
					this.spielfeld[x,y] = 0;
				}
			}
		}

		public void fillRandom()
		{
			Random random = new Random();

			for (int x = 0; x < this.breite; x++)
			{
				for (int y = 0; y < this.hoehe; y++)
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
			for(int y = 0; y < this.hoehe; y++)
			{
				for(int x = 0; x < this.breite; x++)
				{
					this.parseZelle(x, y);
				}
			}
		}

		public void parseZelle(int x, int y)
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
				if (x < 0 || x >= this.breite)
					continue;

				for(int y = punktY - 1; y <= punktY + 1; y++)
				{
					if (y < 0 || y >= this.hoehe)
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
