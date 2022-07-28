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

namespace WPFHarmonogram
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public HarmonogramDb db { get; set; }
        
        public MainWindow()
        {
            InitializeComponent();

            db = new HarmonogramDb();

            Load();
        }
        public void Load()
        {
            zleceniagrid.ItemsSource = null;
            zleceniagrid.ItemsSource = db.Zlecenia.ToList();
            etapyGrid.ItemsSource = null;
            etapyGrid.ItemsSource = db.Etapy.ToList();
            podgladGrid.ItemsSource = null;
            podgladGrid.ItemsSource = db.Podglady.ToList();
        }
        private void dodajZlecenieBtn_Click(object sender, RoutedEventArgs e)
        {
            DodajZlecenie dz = new DodajZlecenie(this);
            dz.Show();
        }

        private void usunZlecenieBtn_Click(object sender, RoutedEventArgs e)
        {
            Zlecenie zlecenie = zleceniagrid.SelectedItem as Zlecenie;
            if (zleceniagrid == null && zleceniagrid.SelectedItem is not Zlecenie)
            {
                MessageBox.Show("Musisz wybrać pozycje do usunięcia!", "Błąd!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            if(zlecenie.Wtrakcie == true)
            {
                MessageBox.Show("Zlecenie jest w produkcji wiec nie możesz go usunąć!", "Błąd!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                db.Zlecenia.Remove(zlecenie);
                db.SaveChanges();
                MessageBox.Show("Pomyślnie usunięto zlecenie!", "Zadanie wykonane", MessageBoxButton.OK, MessageBoxImage.Information);
                Load();
            }
        }

        private void dodajEtapBtn_Click(object sender, RoutedEventArgs e)
        {
            DodajEtap de = new DodajEtap(this);
            de.Show();
        }

        private void usunEtapBtn_Click(object sender, RoutedEventArgs e)
        {
            if (etapyGrid.SelectedItem != null && etapyGrid.SelectedItem is Etap)
            {
                Etap etap = etapyGrid.SelectedItem as Etap;
                db.Etapy.Remove(etap);
                db.SaveChanges();
                MessageBox.Show("Pomyślnie usunięto etap!", "Zadanie wykonane", MessageBoxButton.OK, MessageBoxImage.Information);
                Load();
            }
            else
            {
                MessageBox.Show("Musisz wybrać pozycje do usunięcia!", "Błąd!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void startBtn_Click(object sender, RoutedEventArgs e)
        {
            if (zleceniagrid.SelectedItem != null && zleceniagrid.SelectedItem is Zlecenie)
            {
                Zlecenie zlecenie = zleceniagrid.SelectedItem as Zlecenie;
                Rozpocznij rozpocznij = new Rozpocznij(zlecenie, this);
                rozpocznij.Show();
                this.IsEnabled = false;
            }
            else
            {
                MessageBox.Show("Wybierz zlecenie które chcesz rozpocząć!", "Błąd!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void edytujBtn_Click(object sender, RoutedEventArgs e)
        {
            if (podgladGrid.SelectedItem == null && podgladGrid.SelectedItem is not Podglad)
            {
                MessageBox.Show("Wybierz zlecenie z Harmonogramu którego dane chcesz zmienić!", "Błąd!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                Podglad podglad = podgladGrid.SelectedItem as Podglad;
                db.Podglady.Update(podglad);
                podglad.Aktualizacja = DateTime.Now;
                db.SaveChanges();
                MessageBox.Show("Pomyślnie zaktualizowano zlecenie!", "Zadanie wykonane", MessageBoxButton.OK, MessageBoxImage.Information); ;
                Load();
            }
        }
        private void zakonczBtn_Click(object sender, RoutedEventArgs e)
        {
            if (podgladGrid.SelectedItem != null && podgladGrid.SelectedItem is Podglad)
            {
                Podglad podglad = podgladGrid.SelectedItem as Podglad;
                db.Podglady.Remove(podglad);
                podglad.Aktualizacja = DateTime.Now;
                db.SaveChanges();
                MessageBox.Show("Pomyślnie zakończono zlecenie!", "Zadanie wykonane", MessageBoxButton.OK, MessageBoxImage.Information);;
                Load();
            }
            else
            {
                MessageBox.Show("Wybierz zlecenie z Harmonogramu które chcesz zakończyć!", "Błąd!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void edytujZlecenieBtn_Click(object sender, RoutedEventArgs e)
        {
            Zlecenie zlecenie = zleceniagrid.SelectedItem as Zlecenie;
            if (zleceniagrid.SelectedItem == null && zleceniagrid.SelectedItem is not Zlecenie)
            {
                MessageBox.Show("Wybierz zlecenie z tabeli Zlecenia!", "Błąd!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            if (zlecenie.Wtrakcie == true)
            {
                MessageBox.Show("Zlecenie jest w produkcji wiec nie możesz go edytować!", "Błąd!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                db.Zlecenia.Update(zlecenie);
                db.SaveChanges();
                MessageBox.Show("Pomyślnie zaktualizowano zlecenie!", "Zadanie wykonane", MessageBoxButton.OK, MessageBoxImage.Information);
                Load();
            }
        }
    }
}
