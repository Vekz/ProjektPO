﻿using System;

namespace Projekt1
{
    /// <summary>
    /// Klasa zawierająca umowy o pracę zawarte z autorami.
    /// </summary>
    /// <remarks>
    /// Klasa przechowuje pensję autora oraz czas, na który ma zawartą umowę. Zawiera metodę do zlecania autorowi napisania konkretnej pozycji. Dziedziczy z umowy.
    /// </remarks>
    [Serializable]
    class UOP : Umowa
    {
        [NonSerialized] private Wydawnictwo _wyd = null;
        public double Pensja { get; private set; }
        public int IloscMsc { get; private set; }
        public UOP (Autor autor, double pensja, int iloscMsc, Wydawnictwo Wyd) : base(autor)
        {
            Pensja = pensja;
            IloscMsc = iloscMsc;
            _wyd = Wyd;
        }
        /// <summary>
        /// Metoda za pomocą której można zlecić autorowi zatrudnionego na umowę o pracę napisanie konkretnej pozycji.
        /// </summary>
        /// <param name="k">Książka, która została zlecona autorowi.</param>
        public void Zlecenie(Ksiazka k)    //zmienić na umlu
        {
            _wyd.DzH.ZlecenieDruku(k, 0);
        }
        
        public override string ToString()
        {
            return "UOP: " + Autor + " | Pensja: " + Pensja + " | Il.msc: " + IloscMsc;
        }
    }
}
