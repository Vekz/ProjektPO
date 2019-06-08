using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt1
{
    [Serializable]
    class Umowa
    {
        public Autor Autor { get; private set; }

        public Umowa(Autor autor)
        {
            Autor = autor;
        }
    }
}
