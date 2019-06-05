﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt1
{
    [Serializable]
    class Czasopismo : Produkt
    {
        public string Nr { get; private set; }

        public Czasopismo(string tytul, int ilosc, double cena, string numer) : base(tytul, ilosc, cena) => Nr = numer;
    }
}