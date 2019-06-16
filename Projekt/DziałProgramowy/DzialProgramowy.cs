using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt1
{
    [Serializable]
    class DzialProgramowy
    {
        public List<Autor> autorzy = new List<Autor>();
        public List<Umowa> umowy = new List<Umowa>();

        public void UsunAutora (Autor a)
        {
            autorzy.Remove(a);
        }

        public void DodajAutora (Autor a)
        {
            autorzy.Add(a);
        }

        public String PrzegladAutorow()
        {
            string KatalogAutorow = "";
            foreach (Autor a in autorzy)
            {
                KatalogAutorow += a.Nazwisko + " " + a.Imie + "\n";
            }
            return KatalogAutorow;
        }

        public void ZawrzyjUmoweUOD (UOD uod)   //dodać do uml
        {
            umowy.Add(uod);
        }

        public void ZawrzyjUmoweUOP (UOP uop)   //dodać do uml
        {
            umowy.Add(uop);
        }

        public void RozwiazUmowe(Umowa u)
        {
            umowy.Remove(u);
        }

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
