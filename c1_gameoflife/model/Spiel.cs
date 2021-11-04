using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Text;
using System.Threading.Tasks;

namespace c1_gameoflife.model
{
	public class Spiel
	{
		private int geschwindigkeit;
		
		public int Geschwindigkeit
		{
			get
			{
				return this.geschwindigkeit;
			}
			set
			{
				this.geschwindigkeit = value;
			}
		}

		private bool play;
		private Thread spielThread;

		public event EventHandler SpielfeldUpdate;

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

		public void Start()
		{
			this.spielThread = new Thread(this.spielLoop);
			this.play = true;
			this.spielThread.Start();
		}

		public void Stop()
		{
			if (!this.play) return; 

			this.play = false;
			this.spielThread.Join();
		}

		private void spielLoop()
		{
			while(this.play)
			{
				this.step();
				Thread.Sleep(200 + 2000 / this.geschwindigkeit);
			}
		}

		protected virtual void OnSpielfeldUpdate(EventArgs e)
		{
			EventHandler handler = this.SpielfeldUpdate;
			handler.Invoke(this, e);
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
			this.OnSpielfeldUpdate(new EventArgs());
        }
	}
}
