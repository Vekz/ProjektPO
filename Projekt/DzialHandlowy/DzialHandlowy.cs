using System;
using System.Collections.Generic;

namespace Projekt1
{
    [Serializable]
    class DzialHandlowy
    {
        private Wydawnictwo _wyd = null;
        private List<Produkt> produkty = new List<Produkt>();

        public DzialHandlowy(Wydawnictwo wyd)
        {
            _wyd = wyd;
        }

        public void ZlecenieZakupu(Produkt P, int ilosc)
        {
            foreach (Produkt e in produkty)
            {
                if(P == e)
                {
                    e.StMag -= ilosc;
                }
            }
        }

        public void ZlecenieDruku(Produkt P, int ilosc)
        {
            if (produkty.Contains(P))
            {
                if (_wyd.DzD.ZlecenieDruku(P))
                {
                    P.StMag += ilosc;
                    return;
                }
            }
            else if (_wyd.DzD.ZlecenieDruku(P))
            {
                P.StMag = ilosc;
                produkty.Add(P);
            }

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
