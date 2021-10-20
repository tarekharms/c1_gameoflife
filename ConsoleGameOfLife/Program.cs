using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using c1_gameoflife.model;

namespace ConsoleGameOfLife
{
	class Program
	{
		static void Main(string[] args)
		{
			Spielfeld spielfeld = new Spielfeld(3, 3);

			//*
			spielfeld.setPunkt(2, 0, 1);
			spielfeld.setPunkt(1, 2, 1);
			spielfeld.setPunkt(1, 1, 1);
			spielfeld.setPunkt(2, 1, 1);
			spielfeld.setPunkt(2, 2, 1);
			//*/
			Console.Clear();
			printSpielfeld(spielfeld);

			Console.ReadLine();

			sbyte zellenstatus = Regeln.calcStatus(spielfeld.getAnzahlNachbarn(1, 1), spielfeld.getPunkt(1, 1));
			Console.WriteLine("Status der Zelle ist: " + zellenstatus);


			Console.ReadLine();
		}

		private static void printSpielfeld(Spielfeld spielfeld)
		{
			for(int y = 0; y < spielfeld.Hoehe; y++)
			{
				for(int x = 0; x < spielfeld.Breite; x++)
				{
					Console.Write(spielfeld.getPunkt(x, y) + " ");
				}
				Console.WriteLine();
			}
		}
	}
}
