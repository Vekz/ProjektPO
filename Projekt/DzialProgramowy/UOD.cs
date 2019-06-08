using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt1
{
    [Serializable]
    class UOD : Umowa
    {
        private double pensja { get; private set; }
        private Ksiazka ksiazka { get; private set; }

        public UOD(Autor autor, double pensja, Ksiazka ksiazka) : base(autor)
        {
            this.pensja = pensja;
            this.ksiazka = ksiazka;
        }
    }
}
