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
        private Autor autor { get; private set; }

        public Umowa(Autor autor)
        {
            this.autor = autor;
        }
    }
}
