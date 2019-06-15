using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt1
{
    [Serializable]
    class Romans : Ksiazka
    {
        public Romans(Autor autor, string tytul, int rok, int ilosc, double cena) : base(autor, tytul, rok, ilosc, cena) { }
    }
}
