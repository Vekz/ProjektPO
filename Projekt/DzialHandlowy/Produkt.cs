using System;

namespace Projekt1
{
    /// <summary>
    /// Klasa abstrakcyjna będąca rodzicem dla każdego typu produktu znajdującego się w Wydawnictwie
    /// </summary>
    [Serializable]
    abstract class Produkt
    {
        public string Tytul { get; private set; }
        public int StMag { get; set; }
        public double Cena { get; private set; }

        /// <summary>
        /// Tworzy obiekt produktu z określonym tytułem, stanem magazynowym i ceną, używane w konstruktorach klas dziedziczących
        /// </summary>
        /// <param name="tytul"> Tytuł produktu </param>
        /// <param name="ilosc"> Stan magazynowy produktu </param>
        /// <param name="cena"> Cena produktu </param>
        public Produkt(string tytul, int ilosc, double cena)
        {
            Tytul = tytul;
            StMag = ilosc;
            Cena = cena;
        }

    }
}
