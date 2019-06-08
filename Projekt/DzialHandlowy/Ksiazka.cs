using System;

namespace Projekt1
{
    [Serializable]
    class Ksiazka : Produkt
    {
        public Autor Autor { get; private set; }
        public int Rok { get; private set; }

        public Ksiazka(Autor autor, string tytul, int rok, int ilosc, double cena) : base(tytul, ilosc, cena)
        {
            Autor = autor;
            Rok = rok;
        }
    }
}
