using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt1
{
    [Serializable]
    class UOP : Umowa
    {
        private double pensja { get; private set; }
        private int iloscMsc { get; private set; }

        public UOP (Autor autor, double pensja, int iloscMsc) : base(autor)
        {
            this.pensja = pensja;
            this.iloscMsc = iloscMsc;
        }

        public Ksiazka Zlecenie()
        {
            //intro pink panther:  ogarnąć co to ma w sumie robić
        }
    }
}
