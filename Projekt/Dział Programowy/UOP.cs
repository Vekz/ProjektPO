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

        /*Sypie błędy wtf
        public Ksiazka Zlecenie()
        {
            //intro pink panther:  ogarnąć co to ma w sumie robić
        }
        */

        public override string ToString()
        {
            return "UOP" + Autor + " " + Pensja + " " + IloscMsc;
        }
    }
}
