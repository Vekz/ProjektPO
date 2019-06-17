using System;

namespace Projekt1
{
    /// <summary>
    /// Klasa 'rodzic' dla każdego rodzaju czasopisma, które są dzielone na numery i nie posiadają autora
    /// </summary>
    [Serializable]
    class Czasopismo : Produkt
    {
        public string Nr { get; private set; }

        /// <summary>
        /// Tworzy obiekt czasopisma
        /// </summary>
        /// <param name="tytul"> Tytuł czasopisma </param>
        /// <param name="ilosc"> Stan magazynowy </param>
        /// <param name="cena"> Cena </param>
        /// <param name="numer"> Numer czasopisma </param>
        public Czasopismo(string tytul, int ilosc, double cena, string numer) : base(tytul, ilosc, cena) => Nr = numer;

        public override string ToString()
        {
            return "'" + Tytul + "' " + " | Nr: " + Nr + " | Ilość: " + StMag + " | " + Cena + "zł";
        }
    }
}
