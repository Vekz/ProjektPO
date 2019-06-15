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

        public void ZawrzyjUmowe(Umowa u)
        {
            umowy.Add(u);
        }

        public void RozwiazUmowe(Umowa u)
        {
            umowy.Remove(u);
        }

        public String PrzegladUmow()    //intro pink panther: dodac tę klasę do UML'a
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
