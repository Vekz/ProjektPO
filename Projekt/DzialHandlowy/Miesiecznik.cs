using System;

namespace Projekt1
{
    [Serializable]
    class Miesiecznik : Czasopismo
    {
        public Miesiecznik(string tytul, int ilosc, double cena, string numer) : base(tytul, ilosc, cena, numer) { }

        public override string ToString()
        {
            return base.ToString() + " | Miesiecznik";
        }
    }
}
