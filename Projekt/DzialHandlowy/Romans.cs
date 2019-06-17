using System;

namespace Projekt1
{
    /// <summary>
    /// Klasa Romansu, dziedziczy z Książki
    /// </summary>
    [Serializable]
    class Romans : Ksiazka
    {
        public Romans(Autor autor, string tytul, int rok, int ilosc, double cena) : base(autor, tytul, rok, ilosc, cena) { }

        public override string ToString()
        {
            return base.ToString() + " | Romans";
        }
    }
}
