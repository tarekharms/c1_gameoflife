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
			Spielfeld spielfeld = new Spielfeld(5, 5);

			//*
			spielfeld.setPunkt(1, 1, 1);
			spielfeld.setPunkt(2, 1, 1);
			spielfeld.setPunkt(1, 2, 1);
			spielfeld.setPunkt(3, 2, 1);
			spielfeld.setPunkt(2, 2, 1);
			spielfeld.setPunkt(3, 3, 1);
			//*/
			Console.Clear();
			printSpielfeld(spielfeld);

			Console.ReadLine();

			Console.WriteLine("Anzahl Nachbarn P(4,4): " + spielfeld.getAnzahlNachbarn(4, 4));

			Console.ReadLine();
			return;

			for (int i = 0; i < 4; i++)
			{
				spielfeld.setPunkt(i + 1, i, 1);
				Console.Clear();
				printSpielfeld(spielfeld);
				System.Threading.Thread.Sleep(500);
			}

			Console.Read();
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
