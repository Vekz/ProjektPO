using System;

namespace Projekt1
{
    [Serializable]
    class UOD : Umowa
    {
        public double Pensja { get; private set; }
        public Ksiazka Ksiazka { get; private set; }

        public UOD(Autor autor, double pensja, Ksiazka ksiazka) : base(autor)
        {
            Pensja = pensja;
            Ksiazka = ksiazka;
        }

        public override string ToString()
        {
            return "UOD: " + Autor + " | Pensja: " + Pensja + " | " + Ksiazka;
        }
    }
}
