﻿using System;
using System.Collections.Generic;
using System.Linq;
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
        private readonly Wydawnictwo Wyd = new Wydawnictwo();

        public MainWindow()
        {
            InitializeComponent();
            Wyd.Inicjalizacja();

            //TU SIĘ ZACZYNA KOD DO TESTÓW DODAJĄCY PRZYKŁADOWEGO AUTORA I KSIĄŻKI
            Autor Au = new Autor("Artur", "Porowski");
            
            Wyd.DzH.ZlecenieDruku(new Ksiazka(Au, "Tak i nie", 2019, 0, 30), 250);
            Wyd.DzH.ZlecenieDruku(new Romans(Au, "Siabdabamba", 2018, 0, 30), 300);
            //TU SIĘ KOŃCZY TEN KOD| TODO: INTERFEJS DO DODAWANIA AUTORÓW ETC

            Wyd.DzP.DodajAutora(Au);
            lista_ksiazek.ItemsSource = Wyd.DzH.produkty;
            lista_autorow.ItemsSource = Wyd.DzP.autorzy;
            lista_umow.ItemsSource = Wyd.DzP.umowy;

        }

        private void Zamawianie_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Twoje zamówienie jest przetwarzane, proszę czekać.", "Informacja", MessageBoxButton.OK, MessageBoxImage.Information);
            Wyd.DzH.ZlecenieZakupu((Produkt)lista_ksiazek.SelectedItem, Convert.ToInt32(ilosc.Text));
            lista_ksiazek.Items.Refresh();
            lista_ksiazek.Items.Refresh();
            ilosc.Text = "";
        }

        private void Drukowanie_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Zlecenie zostało przekazane do druku, proszę czekać.", "Informacja", MessageBoxButton.OK, MessageBoxImage.Information);
            Wyd.DzH.ZlecenieDruku((Produkt)lista_ksiazek.SelectedItem, Convert.ToInt32(ilosc.Text));
            lista_ksiazek.Items.Refresh();
            lista_ksiazek.Items.Refresh();
            ilosc.Text = "";
        }

        private void Usuwanie_a_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Trwa usuwanie, proszę czekać.", "Informacja", MessageBoxButton.OK, MessageBoxImage.Information);
            Wyd.DzP.UsunAutora((Autor)lista_autorow.SelectedItem);
            lista_autorow.Items.Refresh();
            lista_autorow.Items.Refresh();
        }

        private void Rozwiązywanie_a_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Trwa usuwanie, proszę czekać.", "Informacja", MessageBoxButton.OK, MessageBoxImage.Information);
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
            MessageBox.Show("Trwa dodawanie, proszę czekać.", "Informacja", MessageBoxButton.OK, MessageBoxImage.Information);
            Autor autorzy = new Autor(imie.Text, nazwisko.Text);
            Wyd.DzP.DodajAutora(autorzy);
            lista_autorow.Items.Refresh();
            lista_autorow.Items.Refresh();
            imie.Text = "";
            nazwisko.Text = "";
        }

        private void Dodawanie_k_Click(object sender, RoutedEventArgs e)
        {
            double c = Convert.ToDouble(cena.Text);
            int r = Convert.ToInt32(rok.Text);
            int i = Convert.ToInt32(ilosc1.Text);

            MessageBox.Show("Dodawanie książki, proszę czekać.", "Informacja", MessageBoxButton.OK, MessageBoxImage.Information);

            if (rodzaj_k.Text == "Czasopismo")
            {
                Wyd.DzH.ZlecenieDruku(new Czasopismo(tytul.Text, 0, c, numer.Text), i);

            }
            else if (rodzaj_k.Text == "Miesięcznik")
            {
                Wyd.DzH.ZlecenieDruku(new Miesiecznik(tytul.Text, 0, c, numer.Text), i);

            }
            else if (rodzaj_k.Text == "Tygodnik")
            {
                Wyd.DzH.ZlecenieDruku(new Tygodnik(tytul.Text, 0, c, numer.Text), 9);
            }
            else if (rodzaj_k.Text == "Książka")
            {
                Wyd.DzH.ZlecenieDruku(new Ksiazka((Autor)lista_autorow.SelectedItem, tytul.Text, r, 0, c), i);
            }
            else if (rodzaj_k.Text == "Romans")
            {
                Wyd.DzH.ZlecenieDruku(new Romans((Autor)lista_autorow.SelectedItem, tytul.Text, r, 0, c), i);
            }
            else if (rodzaj_k.Text == "Album")
            {
                Wyd.DzH.ZlecenieDruku(new Album((Autor)lista_autorow.SelectedItem, tytul.Text, r, 0, c), i);
            }
            else MessageBox.Show("Proszę dodawać rodzaj książki jaki istnieje!", "ERROR", MessageBoxButton.OK, MessageBoxImage.Information);

            lista_ksiazek.Items.Refresh();
            lista_ksiazek.Items.Refresh();

            cena.Text = "";
            ilosc1.Text = "";
            rok.Text = "";
            tytul.Text = "";
            numer.Text = "";

        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox b = (TextBox)sender;
            b.Text = "";
        }
    }
}
