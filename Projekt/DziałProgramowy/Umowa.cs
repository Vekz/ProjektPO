using System;

namespace Projekt1
{
    [Serializable]
    /// <summary>
    /// Klasa umów zawartych z autorami.
    /// </summary>
    /// <remarks>
    /// Klasa przechowuje obiekt autora, z którym zawarta jest umowa.
    /// </remarks>
    class Umowa 
    {
        public Autor Autor { get; private set; }

        public Umowa(Autor autor)
        {
            Autor = autor;
        }
    }
}
