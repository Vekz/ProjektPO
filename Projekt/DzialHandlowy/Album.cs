﻿using System;

namespace Projekt1
{
    /// <summary>
    /// Klasa Albumu, dziedziczy z Książki
    /// </summary>
    [Serializable]
    class Album : Ksiazka
    {
        public Album(Autor autor, string tytul, int rok, int ilosc, double cena) : base(autor, tytul, rok, ilosc, cena) { }

        public override string ToString()
        {
            return base.ToString() + " | Album" ;
        }
    }
}
