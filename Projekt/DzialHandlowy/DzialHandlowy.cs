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

        public void ZlecenieZakupu(string tytul, int ilosc)
        {

            //TODO: Comparison Operators! ^Ta funkcja ma działać na podanym Produkcie
            foreach (Produkt e in produkty)
            {
                if(e.Tytul == tytul)
                {
                    e.StMag = e.StMag - ilosc;
                    break;
                }
            }
        }

        public void ZlecenieDruku()
        {
            //TODO: Wyższe^
        }

        public String PokazKatalogProduktów()
        {
            string Katalog = "";
            foreach (Produkt e in produkty)
            {
                Katalog += e.Tytul + " | ";
                if (e is Ksiazka)
                {
                    Katalog += e.Autor + " | " + e.Rok + " | " + e.Cena;
                }
                else if(e is Czasopismo)
                {
                    Katalog += e.Nr + " | " + e.Cena;
                }
            }
        }
    }
}
