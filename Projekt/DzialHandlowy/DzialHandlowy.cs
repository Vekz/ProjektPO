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
        /// <param name="Wyd"> Obiekt rodzica - Wydawnictwa <see cref="Wydawnictwo"/>, aby mieć dostęp do metod innych działów </param>
        public DzialHandlowy(Wydawnictwo Wyd)
        {
            _wyd = Wyd;
        }

        /// <summary>
        /// Zleca zakup produktu wybranego z listy, odejmuje podaną ilość od stanu magazynowego produktu
        /// </summary>
        /// <param name="P"> Produkt zamawiany </param>
        /// <param name="ilosc"> Ilość produktów do usunięcia ze stanu magazynowego </param>
        /// <exception cref="TooManyException"> Wyrzucone gdy drugi parametr jest większy od stanu magazynowego produktu </exception>
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

        /// <summary>
        /// Zleca druk produktu wybranego z listy, dodaje podaną ilość do stanu magazynowego produktu
        /// </summary>
        /// <param name="P"> Produkt drukowany </param>
        /// <param name="ilosc"> Ilość produktów do dodania do stanu magazynowego </param>
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

        /// <summary>
        /// Tworzy string zawierający katalog produktów [NIE UŻYWANE W GRAFICZNEJ WERSJI PROGRAMU]
        /// </summary>
        /// <returns> String z opisem całej listy produktów </returns>
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
