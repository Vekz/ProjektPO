using System;
using System.Collections.Generic;

namespace Projekt1
{
    /// <summary>
    /// Dział zajmujący się zlecaniem sprzedaży i druku, przetrzymuje listę produktów
    /// </summary>
    [Serializable]
    class DzialHandlowy
    {

        [NonSerialized] public Wydawnictwo _wyd = null;
        public List<Produkt> produkty = new List<Produkt>();

        /// <summary>
        /// Tworzy obiekt Działu Handlowego
        /// </summary>
        /// <param name="Wyd"> Obiekt rodzica - Wydawnictwa, aby mieć dostęp do metod innych działów </param>
        public DzialHandlowy(Wydawnictwo Wyd)
        {
            _wyd = Wyd;
        }

        /// <summary>
        /// Zleca zakup produktu wybranego z listy, odejmuje podaną ilość od stanu magazynowego produktu
        /// </summary>
        /// <param name="P"></param>
        /// <param name="ilosc"></param>
        public void ZlecenieZakupu(Produkt P, int ilosc)
        {
            foreach (Produkt e in produkty)
            {
                if(P == e)
                {
                    if (e.StMag < ilosc)
                    {
                        throw new TooManyException();
                    }
                    else
                    {
                        e.StMag -= ilosc;
                    }
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
