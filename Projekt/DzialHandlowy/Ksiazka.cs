using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt1
{
    [Serializable]
    class Ksiazka : Produkt
    {
        public Autor Autor { get; private set; }
        protected int Rok { get; private set; }

        public Ksiazka(string autor, string tytul, int rok, int ilosc, double cena) : base(tytul, ilosc, cena)
        {
            Autor = autor;
            Rok = rok;
        }
    }
}
