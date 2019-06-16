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
        [NonSerialized] private Wydawnictwo _wyd = null;
        public double Pensja { get; private set; }
        public int IloscMsc { get; private set; }
        public UOP (Autor autor, double pensja, int iloscMsc, Wydawnictwo Wyd) : base(autor)
        {
            Pensja = pensja;
            IloscMsc = iloscMsc;
            _wyd = Wyd;
        }
        
        public void Zlecenie(Ksiazka k)    //zmienić na umlu
        {
            _wyd.DzH.ZlecenieDruku(k, 0);
        }
        
        public override string ToString()
        {
            return "UOP: " + Autor + " | Pensja: " + Pensja + " | Il.msc: " + IloscMsc;
        }
    }
}
