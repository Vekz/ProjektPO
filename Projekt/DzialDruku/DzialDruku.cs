using System;
using System.Collections.Generic;

namespace Projekt1
{
    /// <summary>
    /// Dział obsługujący drukarnie i druk
    /// </summary>
    [Serializable]
    class DzialDruku
    {
        private List<Drukarnia> drukarnie = new List<Drukarnia>();

        /// <summary>
        /// Tworzy dział druku zawierający 3 drukarnie - 2 zwyczajne i 1 drukarnię albumów
        /// </summary>
        public DzialDruku()
        {
            drukarnie.Add(new Drukarnia());
            drukarnie.Add(new DrukarniaAlbumow());
            drukarnie.Add(new Drukarnia());
        }

        /// <summary>
        /// Wywoływane przez ZlecenieDruku w Dziale Handlowym <see cref="DzialHandlowy.ZlecenieDruku(Produkt, int)"/>
        /// Na podstawie typu produktu dokonywana jest ocena czy produkt zostanie wydrukowany
        /// </summary>
        /// <param name="a"> Produkt przekazany do druku </param>
        /// <returns> True - jeśli produkt może zostać wydrukowany (jest drukarnia która obsłuży dany typ produktu) </returns>
        public bool ZlecenieDruku(Produkt a)
        {
           if(a is Album)
           {
                foreach (Drukarnia d in drukarnie)
                {
                    if(d is DrukarniaAlbumow)
                    {
                        return true;
                    }
                }
                return false;
           }
           else
           {
                foreach (Drukarnia d in drukarnie)
                {
                    if(d is Drukarnia)
                    {
                        return true;
                    }
                }
                return false;
           }
        }
    }
}
