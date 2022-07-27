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
    /// Logika interakcji dla klasy Rozpocznij.xaml
    /// </summary>
    public partial class Rozpocznij : Window
    {
        public MainWindow Mainwindow { get; set; }
        public Zlecenie Zlecenia { get; set; }

        public Rozpocznij(Zlecenie zlecenia, MainWindow mainwindow)
        {
            InitializeComponent();
            Zlecenia = zlecenia;
            Mainwindow = mainwindow;
            etapbox.ItemsSource = Mainwindow.db.Etapy.ToList();
            etapbox.SelectedIndex = 0;
        }
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9:-]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void RozpocznijZlecenie_Click(object sender, RoutedEventArgs e)
        {
            Etap etap = etapbox.SelectedItem as Etap;

            if (etap == null)
            {
                MessageBox.Show("Wybierz Etap Produkcji od którego chcesz rozpocząć!", "Błąd!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            if(string.IsNullOrEmpty(datar.Text) || (string.IsNullOrEmpty(dataz.Text)))
            {
                MessageBox.Show("Wpisz planowa date rozpoczecia i zakonczenia!", "Błąd!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            DateTime datarozpoczecia = DateTime.Parse(datar.Text);
            DateTime datazakonczenia = DateTime.Parse(dataz.Text);
            if (datazakonczenia < datarozpoczecia)
            {
                MessageBox.Show("Planowana data zakończenia musi być pózniejsza niż data rozpoczecia!", "Błąd!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                Podglad podglad = new Podglad(Zlecenia.Id, etap.Id, datarozpoczecia, datazakonczenia);
                Zlecenia.Wtrakcie = true;
                Mainwindow.db.Podglady.Add(podglad);
                Mainwindow.db.SaveChanges();
                Mainwindow.Load();
                this.Close();
                Mainwindow.IsEnabled = true;
            }
        }
    }
}


