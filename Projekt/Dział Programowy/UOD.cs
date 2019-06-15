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
        public double Pensja { get; private set; }
        public Ksiazka Ksiazka { get; private set; }

        private Wydawnictwo w = null;

        public UOD(Autor autor, double pensja, Ksiazka ksiazka) : base(autor)
        {
            Pensja = pensja;
            Ksiazka = ksiazka;
        }

        public UOP (Autor autor, double pensja, int iloscMsc) : base(autor)
        {
            Pensja = pensja;
            IloscMsc = iloscMsc;
        }

        public UOP (Wydawnictwo w)
        {
            this.w = w;
        }

        public void Zlecenie (Ksiazka k)    //zmienić na umlu, jeżeli będzie działać
        {
            w.DzH.ZlecenieDruku(k,0);
        }

        public override string ToString()
        {
            return "UOD:" + Autor + " " + Pensja + " " + Ksiazka;
        }
    }
}
