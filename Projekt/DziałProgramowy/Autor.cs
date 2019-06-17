﻿using System;

namespace Projekt1
{
    [Serializable]
    class Autor
    {
        public string Imie { get; private set; }
        public string Nazwisko { get; private set; }

        public Autor (string imie, string nazwisko)
        {
            Imie = imie;
            Nazwisko = nazwisko;
        }

        public override string ToString()
        {
            return Imie + " " + Nazwisko;
        }
    }
}

