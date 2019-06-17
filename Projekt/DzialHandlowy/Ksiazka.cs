using System;

namespace Projekt1
{
    /// <summary>
    /// Klasa 'rodzic' dla wszystkich rodzajów ksiażek i tomów posiadających autora
    /// </summary>
    [Serializable]
    class Ksiazka : Produkt
    {
        public Autor Autor { get; private set; }
        public int Rok { get; private set; }

        /// <summary>
        /// Tworzy obiekt książki
        /// </summary>
        /// <param name="autor"> Autor dzieła </param>
        /// <param name="tytul"> Tytuł dzieła </param>
        /// <param name="rok"> Rok wydania </param>
        /// <param name="ilosc"> Stan magazynowy </param>
        /// <param name="cena"> Cena </param>
        public Ksiazka(Autor autor, string tytul, int rok, int ilosc, double cena) : base(tytul, ilosc, cena)
        {
            Autor = autor;
            Rok = rok;
        }

        public override string ToString()
        {
            return Autor + " - '" + Tytul + "' " + " | Rok: " + Rok + " | Ilość: " + StMag + " | " + Cena + "zł";
        }
    }
}
