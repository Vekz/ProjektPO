using System;

namespace Projekt1
{
    /// <summary>
    /// Klasa umów zawartych z autorami.
    /// </summary>
    /// <remarks>
    /// Klasa przechowuje obiekt autora, z którym zawarta jest umowa.
    /// </remarks>
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
