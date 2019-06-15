using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        public MainWindow()
        {
            InitializeComponent();

            
        }

        private void Zamawianie_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Drukowanie_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Usuwanie_a_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Trwa usuwanie, prosze czekac", "Informacja", MessageBoxButton.OK, MessageBoxImage.Information);
            lista_autorow.Items.Remove(lista_autorow.SelectedItem);
        }

        private void Rozwiązywanie_a_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Trwa usuwanie, prosze czekac", "Informacja", MessageBoxButton.OK, MessageBoxImage.Information);
            lista_umow.Items.Remove(lista_umow.SelectedItem);
        }

    }
}
