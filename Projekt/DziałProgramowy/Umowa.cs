using System;

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
