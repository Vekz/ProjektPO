using System;

namespace Projekt1
{
    [Serializable]
    class Album : Ksiazka
    {
        public Album(Autor autor, string tytul, int rok, int ilosc, double cena) : base(autor, tytul, rok, ilosc, cena) { }
    }
}
