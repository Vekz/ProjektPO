﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt1
{
    [Serializable]
    /// <summary>
    /// Klasa autorów wydawnictwa.
    /// </summary>
    /// <remarks>
    /// Klasa przechowuje imię i nazwisko autora.
    /// </remarks>
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

