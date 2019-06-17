using System;

namespace Projekt1
{
    /// <summary>
    /// Klasa Tygodnika, dziedziczy z Czasopisma
    /// </summary>
    [Serializable]
    class Tygodnik : Czasopismo
    {
        public Tygodnik(string tytul, int ilosc, double cena, string numer) : base(tytul, ilosc, cena, numer) { }

        public override string ToString()
        {
            return base.ToString() + " | Tygodnik";
        }
    }
}
