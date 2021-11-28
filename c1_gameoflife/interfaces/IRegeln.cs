using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using c1_gameoflife.model;

namespace c1_gameoflife.interfaces
{
    public interface IRegeln
    {
        void regelnAnwendenSpielfeld(Spielfeld spielfeld);
    }
}
