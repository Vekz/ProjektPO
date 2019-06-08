using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt1
{
    [Serializable]
    class Autor
    {
        public string Imie { get; private set; }
        public string Nazwisko { get; private set; }

        public Autor (string imie, string nazwisko)
        {
            I*mie = imie;
            Nazwisko = nazwisko;
        }
    }
}

