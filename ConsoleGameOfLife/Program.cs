using System;

using c1_gameoflife.model;

namespace ConsoleGameOfLife
{
	class Program
	{
		static void Main(string[] args)
		{
			Spielfeld spielfeld = new Spielfeld(10, 10);

			spielfeld.fillRandom();

			Console.Clear();
			printSpielfeld(spielfeld);

			Console.ReadLine();

			while (true)
			{
				Regeln.regelnAnwendenSpielfeld(spielfeld);
				printSpielfeld(spielfeld);
				Console.ReadLine();
			}

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
