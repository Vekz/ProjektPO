using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt1
{
    /// <summary>
    ///  Głowny obiekt Wydawnictwa, zawierający w sobie wszystkie działy i ich funkcjonalności
    /// </summary>
    [Serializable]
    class Wydawnictwo
    {
        public DzialHandlowy DzH;
        public DzialProgramowy DzP;
        public DzialDruku DzD;

        /// <summary>
        /// Funkcja służąca do przypisania nowych działów do Wydawnictwa
        /// </summary>
        public void Inicjalizacja()
        {
            DzH = new DzialHandlowy(this);
            DzP = new DzialProgramowy();
            DzD = new DzialDruku();
        }
    }
}
