using System;

using c1_gameoflife.model;
using c1_gameoflife.interfaces;

namespace ConsoleGameOfLife
{
	class Program
	{
		static void Main(string[] args)
		{
			Spielfeld spielfeld = new Spielfeld(10, 10);
			IRegeln regeln = new RegelnKlassisch();

			spielfeld.fillRandom();

			Console.Clear();
			printSpielfeld(spielfeld);

			Console.ReadLine();

			while (true)
			{
				regeln.regelnAnwendenSpielfeld(spielfeld);
				printSpielfeld(spielfeld);
				Console.ReadLine();
			}

			//Console.ReadLine();
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
