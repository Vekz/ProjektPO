using System;
using System.Collections.Generic;

namespace Projekt1
{
    /// <summary>
    /// Klasa działu programowego zajmującego się zawieraniem umów oraz autorami.
    /// </summary>
    /// <remarks>
    /// Zawiera metody do zarządzania autorami oraz ich umowami. Przechowuje listę autorów i umów.
    /// </remarks>
    [Serializable]
    class DzialProgramowy
    {
        public List<Autor> autorzy = new List<Autor>();
        public List<Umowa> umowy = new List<Umowa>();
        /// <summary>
        /// Metoda usuwająca autora z listy.
        /// </summary>
        /// <param name="a">Autor, który ma zostać usunięty z listy.</param>
        public void UsunAutora (Autor a)
        {
            autorzy.Remove(a);
        }
        /// <summary>
        /// Metoda dodająca autora do listy.
        /// </summary>
        /// <param name="a">Autor, który ma zostać dodany do listy.</param>
        public void DodajAutora (Autor a)
        {
            autorzy.Add(a);
        }
        /// <summary>
        /// Metoda tworząca spis wszystkich autorów wydawnictwa.
        /// </summary>
        /// <returns>
        /// Spis imion i nazwisk wszystkich autorów wydawnictwa.
        /// </returns>
        public String PrzegladAutorow()
        {
            string KatalogAutorow = "";
            foreach (Autor a in autorzy)
            {
                KatalogAutorow += a.Nazwisko + " " + a.Imie + "\n";
            }
            return KatalogAutorow;
        }
        /// <summary>
        /// Metoda dodająca do listy umów umowę o dzieło.
        /// </summary>
        /// <param name="uod">Obiekt umowy o dzieło.</param>
        public void ZawrzyjUmoweUOD (UOD uod)   //dodać do uml
        {
            umowy.Add(uod);
        }
        /// <summary>
        /// Metoda dodająca do listy umów umowę o pracę.
        /// </summary>
        /// <param name="uop">Obiekt umowy o pracę.</param>
        public void ZawrzyjUmoweUOP (UOP uop)   //dodać do uml
        {
            umowy.Add(uop);
        }
        /// <summary>
        /// Metoda usuwająca z listy umowę.
        /// </summary>
        /// <param name="u">Obiekt umowy do usunięcia.</param>
        public void RozwiazUmowe(Umowa u)
        {
            umowy.Remove(u);
        }
        /// <summary>
        /// Metoda tworząca spis zawartych umów.
        /// </summary>
        /// <returns>
        /// W przypadku umowy o pracę - pensja oraz czas, na który została zawarta umowa. W przypadku umowy o dzieło - pensja oraz pozycja, na którą została zawarta umowa.
        /// </returns>
        public String PrzegladUmow()    //dodac do UML'a
        {
            string KatalogUmow = "";
            foreach (Umowa u in umowy)
            {
                KatalogUmow += u.Autor + " | ";
                if (u is UOP p)
                {
                    KatalogUmow += p.Pensja + " | " + p.IloscMsc;
                }
                else
                {
                    if (u is UOD d)
                    {
                        KatalogUmow += d.Pensja + " | " + d.Ksiazka;
                    }
                }
                KatalogUmow += "\n";
            }
            return KatalogUmow;
        }
    }
}
