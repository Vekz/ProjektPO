﻿using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Projekt1
{
    /// <summary>
    /// Logika interfejsu i użycie funkcjonalności Wydawnictwa za pomocą interfejsu
    /// </summary>
    public partial class MainWindow : Window
    {
        private Wydawnictwo Wyd = new Wydawnictwo();

        /// <summary>
        /// Konstruktor głównego okna programu, incicjuje interfejs oraz Wydawnictwo <see cref="Wydawnictwo.Inicjalizacja()"/> i przypisuje ComboBoxy <see cref="Inicjuj()"/>
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            Wyd.Inicjalizacja();
            Inicjuj();
        }

        /// <summary>
        /// Przypisuje ComboBoxom odpowiadające listy z działów Wydawnictwa
        /// </summary>
        private void Inicjuj()
        {
            lista_ksiazek.ItemsSource = Wyd.DzH.produkty;
            lista_autorow.ItemsSource = Wyd.DzP.autorzy;
            lista_umow.ItemsSource = Wyd.DzP.umowy;
        }

        /// <summary>
        /// Wywołuje funkcję ZlecenieZakupu <see cref="DzialHandlowy.ZlecenieZakupu(Produkt, int)"/> wcześniej sprawdzając wprowadzone dane
        /// </summary>
        private void Zamawianie_Click(object sender, RoutedEventArgs e)
        {
            if (ilosc.Text == "Ilość ksiązek do druku/zamówienia." || ilosc.Text == "")
            {
                MessageBox.Show("Podaj poprawną ilość książek.", "Informacja", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Twoje zamówienie jest przetwarzane, proszę czekać.", "Informacja", MessageBoxButton.OK, MessageBoxImage.Information);
                try
                {
                    Wyd.DzH.ZlecenieZakupu((Produkt)lista_ksiazek.SelectedItem, Convert.ToInt32(ilosc.Text));
                }
                catch (TooManyException x)
                {
                    MessageBox.Show("Proszę zamówić ilość jaka jest na stanie!", x.GetType().Name, MessageBoxButton.OK, MessageBoxImage.Error);
                }

                lista_ksiazek.Items.Refresh();
                lista_ksiazek.Items.Refresh();
                ilosc.Text = "Ilość ksiązek do druku/zamówienia.";
            }
        }

        /// <summary>
        /// Wywołuje funkcję ZlecenieDruku <see cref="DzialHandlowy.ZlecenieDruku(Produkt, int)"/> wcześniej sprawdzając wprowadzone dane
        /// </summary>
        private void Drukowanie_Click(object sender, RoutedEventArgs e)
        {
            if (ilosc.Text == "Ilość produktu do druku/zamówienia." || ilosc.Text == "")
            {
                MessageBox.Show("Podaj poprawną ilość książek.", "Informacja", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Zlecenie zostało przekazane do druku, proszę czekać.", "Informacja", MessageBoxButton.OK, MessageBoxImage.Information);
                Wyd.DzH.ZlecenieDruku((Produkt)lista_ksiazek.SelectedItem, Convert.ToInt32(ilosc.Text));
                lista_ksiazek.Items.Refresh();
                lista_ksiazek.Items.Refresh();
                ilosc.Text = "Ilość ksiązek do druku/zamówienia.";
            }
        }

        /// <summary>
        /// Usuwa autora z listy autorów Wydawnictwa, znajdującej się w Dziale Programowym <see cref="DzialProgramowy.UsunAutora(Autor)"/>
        /// </summary>
        private void Usuwanie_a_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Autor usunięty poprawnie.", "Informacja", MessageBoxButton.OK, MessageBoxImage.Information);
            Wyd.DzP.UsunAutora((Autor)lista_autorow.SelectedItem);
            lista_autorow.Items.Refresh();
            lista_autorow.Items.Refresh();
        }

        /// <summary>
        /// Rozwiązuje umowę z autorem, usuwając ją z listy znajdującej się w Dziale Programowym <see cref="DzialProgramowy.RozwiazUmowe(Umowa)"/>
        /// </summary>
        private void Rozwiązywanie_a_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Udało się rozwiązać umowę.", "Informacja", MessageBoxButton.OK, MessageBoxImage.Information);
            Wyd.DzP.RozwiazUmowe((Umowa)lista_umow.SelectedItem);
            lista_umow.Items.Refresh();
            lista_umow.Items.Refresh();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e) { }

        /// <summary>
        /// Sprawdza czy dane wprowadzane pasują do podanego w funkcji Regexa (Należą do liczb 0-9)
        /// </summary>
        private void SprawdzanieInputu(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        /// <summary>
        /// Sprawdza dane wprowadzone do formularza i dodaje autora do listy Działu Programowego <see cref="DzialProgramowy.DodajAutora(Autor)"/>
        /// </summary>
        private void Dodawanie_a_Click(object sender, RoutedEventArgs e)
        {
            if (imie.Text == "Podaj imię" || imie.Text == "" || nazwisko.Text == "Podaj nazwisko" || nazwisko.Text == "")
            {
                MessageBox.Show("Podaj poprawne dane.", "Informacja", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Autor dodany poprawnie.", "Informacja", MessageBoxButton.OK, MessageBoxImage.Information);
                Autor autorzy = new Autor(imie.Text, nazwisko.Text);
                Wyd.DzP.DodajAutora(autorzy);
                lista_autorow.Items.Refresh();
                lista_autorow.Items.Refresh();
                imie.Text = "Podaj imię";
                nazwisko.Text = "Podaj nazwisko";
            }
        }

        /// <summary>
        /// Sprawdza dane wprowadzone do forumlarza i dodaje produkt do listy Działu Handlowego <see cref="DzialHandlowy.ZlecenieDruku(Produkt, int)"/>
        /// </summary>
        private void Dodawanie_k_Click(object sender, RoutedEventArgs e)
        {
            if (tytul.Text == "Podaj tytuł" || tytul.Text == "" || cena.Text == "Podaj cenę" || ilosc1.Text == "Podaj ilość produktu" || rok.Text == "Podaj rok wydania" || cena.Text == "" || ilosc1.Text == "" || rok.Text == "")
            {
                MessageBox.Show("Podaj poprawne dane.", "Informacja", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {

                double c = Convert.ToDouble(cena.Text);
                int r = Convert.ToInt32(rok.Text);
                int i = Convert.ToInt32(ilosc1.Text);


                if (rodzaj_k.Text == "Czasopismo")
                {
                    if (numer.Text == "Podaj nr czasopisma/mies/tyg" || numer.Text == "")
                    {
                        MessageBox.Show("Podaj poprawny numer.", "Informacja", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        Wyd.DzH.ZlecenieDruku(new Czasopismo(tytul.Text, 0, c, numer.Text), i);
                        MessageBox.Show("Książka podana poprawnie.", "Informacja", MessageBoxButton.OK, MessageBoxImage.Information);
                    }

                }
                else if (rodzaj_k.Text == "Miesięcznik")
                {
                    if (numer.Text == "Podaj nr czasopisma/mies/tyg" || numer.Text == "")
                    {
                        MessageBox.Show("Podaj poprawny numer.", "Informacja", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        Wyd.DzH.ZlecenieDruku(new Miesiecznik(tytul.Text, 0, c, numer.Text), i);
                        MessageBox.Show("Książka podana poprawnie.", "Informacja", MessageBoxButton.OK, MessageBoxImage.Information);
                    }

                    }
                else if (rodzaj_k.Text == "Tygodnik")
                {
                    if (numer.Text == "Podaj nr czasopisma/mies/tyg" || numer.Text == "")
                    {
                        MessageBox.Show("Podaj poprawny numer.", "Informacja", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        Wyd.DzH.ZlecenieDruku(new Tygodnik(tytul.Text, 0, c, numer.Text), 9);
                        MessageBox.Show("Książka podana poprawnie.", "Informacja", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
                else if (rodzaj_k.Text == "Książka")
                {
                    if (lista_autorow.SelectedIndex == -1)
                    {
                        MessageBox.Show("Podaj autora.", "Informacja", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        Wyd.DzH.ZlecenieDruku(new Ksiazka((Autor)lista_autorow.SelectedItem, tytul.Text, r, 0, c), i);
                        MessageBox.Show("Książka podana poprawnie.", "Informacja", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
                else if (rodzaj_k.Text == "Romans")
                {
                    if (lista_autorow.SelectedIndex == -1)
                    {
                        MessageBox.Show("Podaj autora.", "Informacja", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        Wyd.DzH.ZlecenieDruku(new Romans((Autor)lista_autorow.SelectedItem, tytul.Text, r, 0, c), i);
                        MessageBox.Show("Książka podana poprawnie.", "Informacja", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
                else if (rodzaj_k.Text == "Album")
                {
                    if (lista_autorow.SelectedIndex == -1)
                    {
                        MessageBox.Show("Podaj autora.", "Informacja", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        Wyd.DzH.ZlecenieDruku(new Album((Autor)lista_autorow.SelectedItem, tytul.Text, r, 0, c), i);
                        MessageBox.Show("Książka podana poprawnie.", "Informacja", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
                else MessageBox.Show("Proszę dodawać istniejący rodzaj książki!", "ERROR", MessageBoxButton.OK, MessageBoxImage.Information);

                lista_ksiazek.Items.Refresh();
                lista_ksiazek.Items.Refresh();

                cena.Text = "Podaj cenę";
                ilosc1.Text = "Podaj ilość książek";
                rok.Text = "Podaj rok wydania";
                tytul.Text = "Podaj tytuł";
                numer.Text = "Podaj nr czasopisma/mies/tyg";
            }

        }

        /// <summary>
        /// W momencie gdy pole tekstowe łapie focus jest czyszczone aby użytkownik nie musiał usuwać ręcznie zawartego "placeholder'a"
        /// </summary>
        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox b = (TextBox)sender;
            b.Text = "";
        }

        /// <summary>
        /// Dodaje umowę o pracę do listy w Dziale Programowym <see cref="DzialProgramowy.ZawrzyjUmoweUOP(UOP)"/>
        /// </summary>
        private void O_prace_Click(object sender, RoutedEventArgs e)
        {
            if (imie_p.Text == "Podaj imię" || imie_p.Text == "" || nazwisko_p.Text == "Podaj nazwisko" || nazwisko_p.Text == "" || pensja_p.Text == "Podaj pensję" || ilosc_m.Text == "Ilość miesięcy" || pensja_p.Text == "" || ilosc_m.Text == "")
            {
                MessageBox.Show("Podaj poprawne dane.", "Informacja", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Umowa dodana poprawnie.", "Informacja", MessageBoxButton.OK, MessageBoxImage.Information);

                Autor autor_p = new Autor(imie_p.Text, nazwisko_p.Text);
                Wyd.DzP.DodajAutora(autor_p);

                lista_autorow.Items.Refresh();
                lista_autorow.Items.Refresh();

                Wyd.DzP.ZawrzyjUmoweUOP(new UOP(autor_p, Convert.ToDouble(pensja_p.Text), Convert.ToInt32(ilosc_m.Text), Wyd));

                lista_umow.Items.Refresh();
                lista_umow.Items.Refresh();

                imie_p.Text = "Podaj imię";
                nazwisko_p.Text = "Podaj nazwisko";
                pensja_p.Text = "Podaj pensję";
                ilosc_m.Text = "Ilość miesięcy";
            }

        }

        /// <summary>
        /// Dodaje umowę o dzieło do listy w Dziale Programowym <see cref="DzialProgramowy.ZawrzyjUmoweUOD(UOD)"/> jednocześnie zlecając utworzenie nowego dzieła <see cref="DzialHandlowy.ZlecenieDruku(Produkt, int)"/>
        /// </summary>
        private void O_dzielo_Click(object sender, RoutedEventArgs e)
        {
            if (imie_d.Text == "Podaj imię" || imie_d.Text == "" || nazwisko_d.Text == "Podaj nazwisko" || nazwisko_d.Text == "" || pensja_d.Text == "Podaj pensję" || pensja_d.Text == "" || tytul.Text == "Podaj tytuł" || tytul.Text == "" || cena.Text == "Podaj cenę"  || rok.Text == "Podaj rok wydania" || cena.Text == "" || rok.Text == "")
            {
                MessageBox.Show("Podaj poprawne dane.", "Informacja", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                double c = Convert.ToDouble(cena.Text);
                int r = Convert.ToInt32(rok.Text);

                Autor autor_d = new Autor(imie_d.Text, nazwisko_d.Text);
                Wyd.DzP.DodajAutora(autor_d);

                lista_autorow.Items.Refresh();
                lista_autorow.Items.Refresh();


                if (rodzaj_k.Text == "Książka")
                {
                    Wyd.DzH.ZlecenieDruku(new Ksiazka(autor_d, tytul.Text, r, 0, c), 0);
                    Wyd.DzP.ZawrzyjUmoweUOD(new UOD(autor_d, Convert.ToDouble(pensja_d.Text), new Ksiazka(autor_d, tytul.Text, r, 0, c)));
                    MessageBox.Show("Umowa dodana poprawnie.", "Informacja", MessageBoxButton.OK, MessageBoxImage.Information);

                }
                else if (rodzaj_k.Text == "Romans")
                {
                    Wyd.DzH.ZlecenieDruku(new Romans(autor_d, tytul.Text, r, 0, c), 0);
                    Wyd.DzP.ZawrzyjUmoweUOD(new UOD(autor_d, Convert.ToDouble(pensja_d.Text), new Romans(autor_d, tytul.Text, r, 0, c)));
                    MessageBox.Show("Umowa dodana poprawnie.", "Informacja", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else if (rodzaj_k.Text == "Album")
                {
                    Wyd.DzH.ZlecenieDruku(new Album(autor_d, tytul.Text, r, 0, c), 0);
                    Wyd.DzP.ZawrzyjUmoweUOD(new UOD(autor_d, Convert.ToDouble(pensja_d.Text), new Album(autor_d, tytul.Text, r, 0, c)));
                    MessageBox.Show("Umowa dodana poprawnie.", "Informacja", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else MessageBox.Show("Proszę dodawać istniejący rodzaj książki!", "ERROR", MessageBoxButton.OK, MessageBoxImage.Information);

                lista_ksiazek.Items.Refresh();
                lista_ksiazek.Items.Refresh();

                lista_umow.Items.Refresh();
                lista_umow.Items.Refresh();

                imie_d.Text = "Podaj imię";
                nazwisko_d.Text = "Podaj nazwisko";
                pensja_d.Text = "Podaj pensję";
                cena.Text = "Podaj cenę";
                ilosc1.Text = "Podaj ilość książek";
                rok.Text = "Podaj rok wydania";
                tytul.Text = "Podaj tytuł";
            }
        }

        /// <summary>
        /// Używając mechanizmu serializacji zapisuje drzewo obiektów do pliku
        /// </summary>
        private void Zapisz(object sender, RoutedEventArgs e)
        {
            using (Stream stream = File.Open("data.dat", FileMode.Create, FileAccess.Write))
            {
                BinaryFormatter formatter = new BinaryFormatter();

                formatter.Serialize(stream, Wyd);
            }
            Wyd = null;
            Wyd = new Wydawnictwo();
            Wyd.Inicjalizacja();
            Inicjuj();
        }

        /// <summary>
        /// Używając mechanizmu deserializacji odczytuje drzewo obiektów z pliku
        /// </summary>
        private void Wczytaj(object sender, RoutedEventArgs e)
        {
            using (Stream stream = File.Open("data.dat", FileMode.Open, FileAccess.Read))
            {
                BinaryFormatter formatter = new BinaryFormatter();

                Wyd = null;
                Wyd = (Wydawnictwo)formatter.Deserialize(stream);
                Wyd.DzH._wyd = Wyd;
            }
            Inicjuj();
        }

        /// <summary>
        /// Dodaje nowego autora do listy autorów w Dziale Programowym <see cref="DzialProgramowy.ZawrzyjUmoweUOP(UOP)"/> i zleca mu napisanie dzieła <see cref="UOP.Zlecenie(Ksiazka)"/>
        /// </summary>
        private void O_prace_p_Click(object sender, RoutedEventArgs e)
        {
            if (imie_p.Text == "Podaj imię" || imie_p.Text == "" || nazwisko_p.Text == "Podaj nazwisko" || nazwisko_p.Text == "" || pensja_p.Text == "Podaj pensję" || pensja_p.Text == "" || ilosc_m.Text == "Ilość miesięcy" || ilosc_m.Text == "" || tytul.Text == "" || tytul.Text == "Podaj tytuł" || cena.Text == "Podaj cenę" || cena.Text == "" || rok.Text == "Podaj rok wydania" || rok.Text == "")
            {
                MessageBox.Show("Podaj poprawne dane.", "Informacja", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                double c = Convert.ToDouble(cena.Text);
                int r = Convert.ToInt32(rok.Text);


                Autor autor_p = new Autor(imie_p.Text, nazwisko_p.Text);
                Wyd.DzP.DodajAutora(autor_p);

                UOP oP = new UOP(autor_p, Convert.ToDouble(pensja_p.Text), Convert.ToInt32(ilosc_m.Text), Wyd);
                Wyd.DzP.ZawrzyjUmoweUOP(oP);

                lista_autorow.Items.Refresh();
                lista_autorow.Items.Refresh();

                if (rodzaj_k.Text == "Książka")
                {
                    oP.Zlecenie(new Ksiazka(autor_p, tytul.Text, r, 0, c));
                    MessageBox.Show("Umowa dodana poprawnie.", "Informacja", MessageBoxButton.OK, MessageBoxImage.Information);

                }
                else if (rodzaj_k.Text == "Romans")
                {
                    oP.Zlecenie(new Romans(autor_p, tytul.Text, r, 0, c));
                    MessageBox.Show("Umowa dodana poprawnie.", "Informacja", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else if (rodzaj_k.Text == "Album")
                {
                    oP.Zlecenie(new Album(autor_p, tytul.Text, r, 0, c));
                    MessageBox.Show("Umowa dodana poprawnie.", "Informacja", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else MessageBox.Show("Proszę dodawać rodzaj książki jaki istnieje!", "ERROR", MessageBoxButton.OK, MessageBoxImage.Information);



                lista_umow.Items.Refresh();
                lista_umow.Items.Refresh();

                lista_ksiazek.Items.Refresh();
                lista_ksiazek.Items.Refresh();

                imie_p.Text = "Podaj imię";
                nazwisko_p.Text = "Podaj nazwisko";
                pensja_p.Text = "Podaj pensję";
                ilosc_m.Text = "Ilość miesięcy";
                cena.Text = "Podaj cenę";
                ilosc1.Text = "Podaj ilość książek";
                rok.Text = "Podaj rok wydania";
                tytul.Text = "Podaj tytuł";
            }

        }
    }
}
