using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c1_gameoflife.model
{
	public class Regeln
	{
		public const int ANZAHL_NACHBARN_GEBURT = 3;
		public const int GRENZE_TOT_VEREINSAMUNG = 2;
		public const int GRENZE_TOT_UEBERBEVOELKERUNG = 3;

		public static sbyte calcStatus(int anzahlnachbarn, sbyte zellenstatus)
		{
			if(zellenstatus == Spielfeld.LEBT && anzahlnachbarn < GRENZE_TOT_VEREINSAMUNG)
			{
				return Spielfeld.STIRBT;
			}
			else if (
				zellenstatus == Spielfeld.LEBT && (
					GRENZE_TOT_VEREINSAMUNG <= anzahlnachbarn && 
					anzahlnachbarn <= GRENZE_TOT_UEBERBEVOELKERUNG
					)
				)
			{
				return Spielfeld.LEBT;
			}
			else if (zellenstatus == Spielfeld.LEBT && anzahlnachbarn > GRENZE_TOT_UEBERBEVOELKERUNG)
			{
				return Spielfeld.STIRBT;
			}
			else if (zellenstatus == Spielfeld.TOT && anzahlnachbarn == ANZAHL_NACHBARN_GEBURT)
			{
				return Spielfeld.GEBURT;
			}
			else
			{
				return Spielfeld.TOT;
			}
		}

		public static void regelnAnwendenSpielfeld(Spielfeld spielfeld)
		{
			for(int y = 0; y < spielfeld.Hoehe; y++)
			{
				for(int x = 0; x < spielfeld.Breite; x++)
				{
					Regeln.regelnAnwendenZelle(spielfeld, x, y);
				}
			}

			spielfeld.parseSpielfeld();
		}

		public static void regelnAnwendenZelle(Spielfeld spielfeld, int x, int y)
		{
			sbyte value = Regeln.calcStatus(
				spielfeld.getAnzahlNachbarn(x, y),
				spielfeld.getPunkt(x, y)
			);

			spielfeld.setPunkt(x, y, value);
		}
	}
}
