using System;

namespace Projekt1
{
    [Serializable]
    abstract class Produkt
    {
        public string Tytul { get; private set; }
        public int StMag { get; set; }
        public double Cena { get; private set; }

        public Produkt(string tytul, int ilosc, double cena)
        {
            Tytul = tytul;
            StMag = ilosc;
            Cena = cena;
        }

    }
}
