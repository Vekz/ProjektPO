using System;
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
        Wydawnictwo Wyd;

        public MainWindow()
        {
            InitializeComponent();
            Wyd = new Wydawnictwo();
            Wyd.Inicjalizacja();

            //TU SIĘ ZACZYNA KOD DO TESTÓW DODAJĄCY PRZYKŁADOWEGO AUTORA I KSIĄŻKI
            Autor Au = new Autor("Artur", "Porowski");
            Wyd.DzH.ZlecenieDruku(new Ksiazka(Au, "Tak i nie", 2019, 0, 30), 250);
            Wyd.DzH.ZlecenieDruku(new Ksiazka(Au, "Siabdabamba", 2018, 0, 30), 300);

            Wyd.DzP.DodajAutora(Au);
            //TU SIĘ KOŃCZY TEN KOD| TODO: INTERFEJS DO DODAWANIA AUTORÓW ETC

            lista_ksiazek.ItemsSource = Wyd.DzH.produkty;
            lista_autorow.ItemsSource = Wyd.DzP.autorzy;
            lista_umow.ItemsSource = Wyd.DzP.umowy;
        }

        private void Zamawianie_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Twoje zamowienie jest przetwarzane, prosze czekac", "Informacja", MessageBoxButton.OK, MessageBoxImage.Information);
            Wyd.DzH.ZlecenieZakupu((Produkt)lista_ksiazek.SelectedItem, Convert.ToInt32(ilosc.Text));
            lista_ksiazek.Items.Refresh();
            lista_ksiazek.Items.Refresh();
            ilosc.Text = "";
        }

        private void Drukowanie_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Zlecenie zostało przekazane do druku, prosze czekac", "Informacja", MessageBoxButton.OK, MessageBoxImage.Information);
            Wyd.DzH.ZlecenieDruku((Produkt)lista_ksiazek.SelectedItem, Convert.ToInt32(ilosc.Text));
            lista_ksiazek.Items.Refresh();
            lista_ksiazek.Items.Refresh();
            ilosc.Text = "";
        }

        private void Usuwanie_a_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Trwa usuwanie, prosze czekac", "Informacja", MessageBoxButton.OK, MessageBoxImage.Information);
            Wyd.DzP.UsunAutora((Autor)lista_autorow.SelectedItem);
            lista_autorow.Items.Refresh();
            lista_autorow.Items.Refresh();
        }

        private void Rozwiązywanie_a_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Trwa usuwanie, prosze czekac", "Informacja", MessageBoxButton.OK, MessageBoxImage.Information);
            Wyd.DzP.RozwiazUmowe((Umowa)lista_umow.SelectedItem);
            lista_umow.Items.Refresh();
            lista_umow.Items.Refresh();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e) { }

        private void SprawdzanieInputu(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
