using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt1
{
    [Serializable]
    class Miesiecznik : Czasopismo
    {
        public Miesiecznik(string tytul, int ilosc, double cena, string numer) : base(tytul, ilosc, cena, numer);
    }
}
