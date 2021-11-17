using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Threading.Tasks;

using c1_gameoflife.model;

namespace c1_gameoflife.view
{
	interface ISpielfeldRenderer
	{
		void Draw(Spielfeld spielfeld);

		int[] GetClickedCell(Spielfeld spielfeld, Point mousePoint);
	}
}
