using System;

namespace Projekt1
{
    [Serializable]
    /// <summary>
    /// Klasa umów o dzieło zawartych z autorami.
    /// </summary>
    /// <remarks>
    /// Klasa przechowuje obiekt książki, na którą autor ma umowę oraz jego pensję.
    /// </remarks>
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
