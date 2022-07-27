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
using System.Windows.Shapes;
using System.Text.RegularExpressions;

namespace WPFHarmonogram
{
    /// <summary>
    /// Logika interakcji dla klasy DodajZlecenie.xaml
    /// </summary>
    public partial class DodajZlecenie : Window
    {
        public MainWindow Mainwindow { get; set; }

        public DodajZlecenie(MainWindow mainwindow)
        {
            InitializeComponent();

            Mainwindow = mainwindow;

        }
    private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
             Regex regex = new Regex("[^0-9]+");
               e.Handled = regex.IsMatch(e.Text);
         }
    private void dodajBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(nazwaz.Text) || (string.IsNullOrEmpty(iloscz.Text))  || string.IsNullOrEmpty(wartoscz.Text))
            {
                MessageBox.Show("Musisz wypełnić wszystkie pola!", "Błąd!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                int Iloscz = int.Parse(iloscz.Text);
                float Wartoscz = float.Parse(wartoscz.Text);
                Zlecenie k = new Zlecenie(nazwaz.Text, Iloscz, Wartoscz) ;
                Mainwindow.db.Zlecenia.Add(k);
                Mainwindow.db.SaveChanges();
                Mainwindow.Load();
                Mainwindow.IsEnabled = true;
                this.Close();
            }
        }
    }
}
