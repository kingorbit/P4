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

namespace Lab8
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool click = false;
        public MainWindow()
        {
            InitializeComponent();
        }
   

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var r = new Random();

            this.Resources["myfill"] = new SolidColorBrush(Color.FromArgb(
          0xFF,
          (byte)r.Next(255),
          (byte)r.Next(255),
          (byte)r.Next(255)));

            click = !click; ;
            if (click)
                this.Resources["size"] = 35.0;
            else this.Resources["size"] = 15.0;
        }
    }
    }

