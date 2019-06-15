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
        public double Pensja { get; private set; }
        public int IloscMsc { get; private set; }
        public UOP (Autor autor, double pensja, int iloscMsc) : base(autor)
        {
            Pensja = pensja;
            IloscMsc = iloscMsc;
        }
        /*
        public void Zlecenie(Ksiazka k)    //zmienić na umlu
        {
            w.DzH.ZlecenieDruku(k, 0);
        }
        */
        public override string ToString()
        {
            return "UOP" + Autor + " " + Pensja + " " + IloscMsc;
        }
    }
}
