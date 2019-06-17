using System;
using System.Collections.Generic;

namespace Projekt1
{
    [Serializable]
    class DzialDruku
    {
        private List<Drukarnia> drukarnie = new List<Drukarnia>();

        public DzialDruku()
        {
            drukarnie.Add(new Drukarnia());
            drukarnie.Add(new DrukarniaAlbumow());
            drukarnie.Add(new Drukarnia());
        }

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
