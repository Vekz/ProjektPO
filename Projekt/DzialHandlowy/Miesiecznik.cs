using System;

namespace Projekt1
{
    /// <summary>
    /// Klasa Miesięcznika, dziedziczy z Czasopisma
    /// </summary>
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
