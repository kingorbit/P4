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

namespace WPFHarmonogram
{
    /// <summary>
    /// Logika interakcji dla klasy DodajEtap.xaml
    /// </summary>
    public partial class DodajEtap : Window
    {
        public MainWindow Mainwindow { get; set; }
        public DodajEtap(MainWindow mainwindow)
        {
            InitializeComponent();
            this.Mainwindow = mainwindow;
        }

    private void dodajetapBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(nazwaetap.Text))
            {
                MessageBox.Show("Podaj nazwe Etapu Produkcji!", "Błąd!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                Etap k = new Etap(nazwaetap.Text);
                Mainwindow.db.Etapy.Add(k);
                Mainwindow.db.SaveChanges();
                Mainwindow.Load();
                Mainwindow.IsEnabled = true;
                this.Close();
            }
        }
    }
}
