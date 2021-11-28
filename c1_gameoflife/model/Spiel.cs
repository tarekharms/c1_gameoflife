using System;
using System.Threading;

using c1_gameoflife.interfaces;

namespace c1_gameoflife.model
{
	public class Spiel
	{
		private int geschwindigkeit;

		private int generation;
		public int Generation
        {
			get
            {
				return this.generation;
            }
        }
		
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
		private bool locked = false;
		private Thread spielThread;

		public event EventHandler SpielfeldUpdate;

		private IRegeln regelwerk;
		private Spielfeld spielfeld;
		public Spielfeld Spielfeld
		{
			get
			{
				return this.spielfeld;
			}
            set
            {
				this.spielfeld = value;
            }
		}


		public Spiel(IRegeln regelwerk)
		{
			this.regelwerk = regelwerk;
			this.geschwindigkeit = 10;
			this.generation = 0;
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
				if (this.locked) continue;

				this.step(); 
				Thread.Sleep(100 + 1500 / this.geschwindigkeit);
			}
		}

		public void Lock()
		{
			this.locked = true;
		}

		public void Unlock()
		{
			this.locked = false;
		}

		protected virtual void OnSpielfeldUpdate(EventArgs e)
		{
			EventHandler handler = this.SpielfeldUpdate;
			handler.Invoke(this, e);
		}

		public Spielfeld neuesSpiel(int breite, int hoehe)
		{
			this.spielfeld = new Spielfeld(breite, hoehe);
			this.generation = 0;

			return this.spielfeld;
		}

		public Spielfeld neuesSpielZufaellig(int breite, int hoehe)
		{
			this.spielfeld = new Spielfeld(breite, hoehe);
			this.spielfeld.fillRandom();
			this.generation = 0;
			return this.spielfeld;
		}

		public void step()
		{
			this.generation++;
			this.regelwerk.regelnAnwendenSpielfeld(spielfeld);
			this.OnSpielfeldUpdate(new EventArgs());
        }
	}
}
