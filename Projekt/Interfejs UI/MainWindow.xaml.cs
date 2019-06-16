using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Projekt1
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Wydawnictwo Wyd = new Wydawnictwo();

        public MainWindow()
        {
            InitializeComponent();
            Wyd.Inicjalizacja();
            Inicjuj();
        }

        private void Inicjuj()
        {
            /*
            //TU SIĘ ZACZYNA KOD DO TESTÓW DODAJĄCY PRZYKŁADOWEGO AUTORA I KSIĄŻKI
            Autor Au = new Autor("Artur", "Porowski");

            Wyd.DzH.ZlecenieDruku(new Ksiazka(Au, "Tak i nie", 2019, 0, 30), 250);
            Wyd.DzH.ZlecenieDruku(new Romans(Au, "Siabdabamba", 2018, 0, 30), 300);
            

            Wyd.DzP.DodajAutora(Au);
            //TU SIĘ KOŃCZY TEN KOD| TODO: INTERFEJS DO DODAWANIA AUTORÓW ETC
            */

            lista_ksiazek.ItemsSource = Wyd.DzH.produkty;
            lista_autorow.ItemsSource = Wyd.DzP.autorzy;
            lista_umow.ItemsSource = Wyd.DzP.umowy;
        }

        private void Zamawianie_Click(object sender, RoutedEventArgs e)
        {
            if (ilosc.Text == "Ilość ksiązek do druku/zamówienia.")
            {
                MessageBox.Show("Podaj poprawną ilość książek.", "Informacja", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Twoje zamówienie jest przetwarzane, proszę czekać.", "Informacja", MessageBoxButton.OK, MessageBoxImage.Information);
                Wyd.DzH.ZlecenieZakupu((Produkt)lista_ksiazek.SelectedItem, Convert.ToInt32(ilosc.Text));
                lista_ksiazek.Items.Refresh();
                lista_ksiazek.Items.Refresh();
                ilosc.Text = "Ilość ksiązek do druku/zamówienia.";
            }
        }

        private void Drukowanie_Click(object sender, RoutedEventArgs e)
        {
            if (ilosc.Text == "Ilość ksiązek do druku/zamówienia.")
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

        private void Usuwanie_a_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Autor usunięty poprawnie.", "Informacja", MessageBoxButton.OK, MessageBoxImage.Information);
            Wyd.DzP.UsunAutora((Autor)lista_autorow.SelectedItem);
            lista_autorow.Items.Refresh();
            lista_autorow.Items.Refresh();
        }

        private void Rozwiązywanie_a_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Udało się rozwiązać umowę.", "Informacja", MessageBoxButton.OK, MessageBoxImage.Information);
            Wyd.DzP.RozwiazUmowe((Umowa)lista_umow.SelectedItem);
            lista_umow.Items.Refresh();
            lista_umow.Items.Refresh();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void SprawdzanieInputu(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

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

        private void Dodawanie_k_Click(object sender, RoutedEventArgs e)
        {
            if (tytul.Text == "Podaj tytuł" || tytul.Text == "" || cena.Text == "Podaj cenę" || ilosc1.Text == "Podaj ilość książek" || rok.Text == "Podaj rok wydania")
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
                    if (numer.Text == "Podaj nr czasopisma/mies/tyg")
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
                    if (numer.Text == "Podaj nr czasopisma/mies/tyg")
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
                    if (numer.Text == "Podaj nr czasopisma/mies/tyg")
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
                    Wyd.DzH.ZlecenieDruku(new Ksiazka((Autor)lista_autorow.SelectedItem, tytul.Text, r, 0, c), i);
                    MessageBox.Show("Książka podana poprawnie.", "Informacja", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else if (rodzaj_k.Text == "Romans")
                {
                    Wyd.DzH.ZlecenieDruku(new Romans((Autor)lista_autorow.SelectedItem, tytul.Text, r, 0, c), i);
                    MessageBox.Show("Książka podana poprawnie.", "Informacja", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else if (rodzaj_k.Text == "Album")
                {
                    Wyd.DzH.ZlecenieDruku(new Album((Autor)lista_autorow.SelectedItem, tytul.Text, r, 0, c), i);
                    MessageBox.Show("Książka podana poprawnie.", "Informacja", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else MessageBox.Show("Proszę dodawać rodzaj książki jaki istnieje!", "ERROR", MessageBoxButton.OK, MessageBoxImage.Information);

                lista_ksiazek.Items.Refresh();
                lista_ksiazek.Items.Refresh();

                cena.Text = "Podaj cenę";
                ilosc1.Text = "Podaj ilość książek";
                rok.Text = "Podaj rok wydania";
                tytul.Text = "Podaj tytuł";
                numer.Text = "Podaj nr czasopisma/mies/tyg";
            }

        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox b = (TextBox)sender;
            b.Text = "";
        }

        private void O_prace_Click(object sender, RoutedEventArgs e)
        {
            if (imie_p.Text == "Podaj imię" || imie_p.Text == "" || nazwisko_p.Text == "Podaj nazwisko" || nazwisko_p.Text == "" || pensja_p.Text == "Podaj pensję" || ilosc_m.Text == "Ilość miesięcy")
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

                Wyd.DzP.ZawrzyjUmoweUOP(new UOP(autor_p, Convert.ToDouble(pensja_p.Text), Convert.ToInt32(ilosc_m.Text)));

                lista_umow.Items.Refresh();
                lista_umow.Items.Refresh();

                imie_p.Text = "Podaj imię";
                nazwisko_p.Text = "Podaj nazwisko";
                pensja_p.Text = "Podaj pensję";
                ilosc_m.Text = "Ilość miesięcy";
            }

        }

        private void O_dzielo_Click(object sender, RoutedEventArgs e)
        {
            if (imie_d.Text == "Podaj imię" || imie_d.Text == "" || nazwisko_d.Text == "Podaj nazwisko" || nazwisko_d.Text == "" || pensja_d.Text == "Podaj pensję" || tytul.Text == "Podaj tytuł" || tytul.Text == "" || cena.Text == "Podaj cenę" || ilosc1.Text == "Podaj ilość książek" || rok.Text == "Podaj rok wydania")
            {
                MessageBox.Show("Podaj poprawne dane.", "Informacja", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                double c = Convert.ToDouble(cena.Text);
                int r = Convert.ToInt32(rok.Text);
                int i = Convert.ToInt32(ilosc1.Text);

                MessageBox.Show("Umowa dodana poprawnie.", "Informacja", MessageBoxButton.OK, MessageBoxImage.Information);

                Autor autor_d = new Autor(imie_d.Text, nazwisko_d.Text);
                Wyd.DzP.DodajAutora(autor_d);

                lista_autorow.Items.Refresh();
                lista_autorow.Items.Refresh();


                if (rodzaj_k.Text == "Książka")
                {
                    Wyd.DzH.ZlecenieDruku(new Ksiazka(autor_d, tytul.Text, r, 0, c), i);
                    Wyd.DzP.ZawrzyjUmoweUOD(new UOD(autor_d, Convert.ToDouble(pensja_d.Text), new Ksiazka(autor_d, tytul.Text, r, i, c)));

                }
                else if (rodzaj_k.Text == "Romans")
                {
                    Wyd.DzH.ZlecenieDruku(new Romans(autor_d, tytul.Text, r, 0, c), i);
                    Wyd.DzP.ZawrzyjUmoweUOD(new UOD(autor_d, Convert.ToDouble(pensja_d.Text), new Romans(autor_d, tytul.Text, r, i, c)));
                }
                else if (rodzaj_k.Text == "Album")
                {
                    Wyd.DzH.ZlecenieDruku(new Album(autor_d, tytul.Text, r, 0, c), i);
                    Wyd.DzP.ZawrzyjUmoweUOD(new UOD(autor_d, Convert.ToDouble(pensja_d.Text), new Album(autor_d, tytul.Text, r, i, c)));
                }
                else MessageBox.Show("Proszę dodawać rodzaj książki jaki istnieje!", "ERROR", MessageBoxButton.OK, MessageBoxImage.Information);

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

        private void Zapisz(object sender, RoutedEventArgs e)
        {
            using (Stream stream = File.Open("data.dat", FileMode.Create, FileAccess.Write))
            {
                BinaryFormatter formatter = new BinaryFormatter();

                formatter.Serialize(stream, Wyd);
                stream.Close();
            }
            Wyd = null;
            Wyd = new Wydawnictwo();
            Wyd.Inicjalizacja();
            Inicjuj();
        }

        private void Wczytaj(object sender, RoutedEventArgs e)
        {
            using (Stream stream = File.Open("data.dat", FileMode.Open, FileAccess.Read))
            {
                BinaryFormatter formatter = new BinaryFormatter();

                Wyd = null;
                Wyd = (Wydawnictwo)formatter.Deserialize(stream);
                Wyd.DzH._wyd = Wyd;
                stream.Close();
            }
            Inicjuj();
        }
    }
}
