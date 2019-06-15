﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt1
{
    [Serializable]
    class DzialProgramowy
    {
        private List<Autor> autorzy = new List<Autor>();
        private List<Umowa> umowy = new List<Umowa>();

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
                KatalogAutorow += a.nazwisko + " " + a.imie + "\n";
            }
            return KatalogAutorow;
        }

        public void ZawrzyjUmowe()
        {
            //intro pink panther: ogarnąć co tu jest arguemntem a co typem, wtf i czy to ma tylko dodawać do listy umowę
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
                KatalogUmow += u.autor + " | ";
                if (u is UOP p)
                {
                    KatalogUmow += p.pensja + " | " + p.iloscMsc;
                }
                else
                {
                    if (u is UOD d)
                    {
                        KatalogUmow += d.pensja + " | " + d.ksiazka;
                    }
                }
                KatalogUmow += "\n";
            }
            return KatalogUmow;
        }
    }
}