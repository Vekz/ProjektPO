using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                foreach (DrukarniaAlbumow d in drukarnie) return true;
                return false;
            }

           else
            {
                return true;
            }
        }
    }
}
