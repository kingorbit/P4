﻿using System;
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

namespace P4Z6
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int Liczba { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            Liczba = 0;
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            l1.Content = Liczba++;

        }
    }
}
    

