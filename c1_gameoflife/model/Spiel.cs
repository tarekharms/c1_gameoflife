using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c1_gameoflife.model
{
	public class Spiel
	{
		private int geschwindigkeit;

		private bool play;

		private Spielfeld spielfeld;
		public Spielfeld Spielfeld
		{
			get
			{
				return this.spielfeld;
			}
		}

		
		public Spiel()
		{
			this.geschwindigkeit = 10;
			this.play = false;
		}

		public Spielfeld neuesSpiel(int breite, int hoehe)
		{
			this.spielfeld = new Spielfeld(breite, hoehe);

			return this.spielfeld;
		}

		public Spielfeld neuesSpielZufaellig(int breite, int hoehe)
		{
			this.spielfeld = new Spielfeld(breite, hoehe);
			this.spielfeld.fillRandom();
			return this.spielfeld;
		}

		public void step()
        {
			Regeln.regelnAnwendenSpielfeld(spielfeld);
        }
	}
}
