using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt1
{
    [Serializable]
    class DzialHandlowy
    {
        private List<Produkt> produkty = new List<Produkt>();

        public void ZlecenieZakupu(Produkt P)
        {

            //TODO: Porównania żeby odejmować z dobrej książki (może się różnić rok wydania etc.)
            foreach (Produkt e in produkty)
            {
                if(e.Tytul == tytul)
                {
                    e.StMag = e.StMag - ilosc;
                    break;
                }
            }
        }

        public void ZlecenieDruku(Produkt P)
        {
            //TODO: Wyższe^
        }

        public String PokazKatalogProduktów()
        {
            string Katalog = "";
            foreach (Produkt e in produkty)
            {
                Katalog += e.Tytul + " | ";
                if (e is Ksiazka K)
                {
                    Katalog += K.Autor + " | " + K.Rok + " | " + K.Cena;
                }
                else if(e is Czasopismo Cz)
                {
                    Katalog += Cz.Nr + " | " + Cz.Cena;
                }
                Katalog += "/n";
            }
            return Katalog;
        }
    }
}
