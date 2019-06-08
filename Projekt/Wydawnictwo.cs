using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt1
{
    [Serializable]
    public class Wydawnictwo
    {
        public DzialHandlowy DzH = new DzialHandlowy(this);
        public DzialProgramowy DzP = new DzialProgramowy();
        public DzialDruku DzD = new DzialDruku();

    }
}
