using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt1
{
    [Serializable]
    class Wydawnictwo
    {
        public DzialHandlowy DzH;
        public DzialProgramowy DzP;
        public DzialDruku DzD;

        public void Inicjalizacja()
        {
            DzH = new DzialHandlowy(this);
            DzP = new DzialProgramowy(this);
            DzD = new DzialDruku();
        }
    }
}
