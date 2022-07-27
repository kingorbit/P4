using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFHarmonogram
{
    public class Zlecenie
    {
        public Zlecenie(string nazwa, int ilosc, float wartosc)
        {
            Nazwa = nazwa;
            Ilosc = ilosc;
            Wartosc = wartosc;
        }

        public int Id { get; set; }
        public string Nazwa { get; set; }
        public int Ilosc { get; set; }
        public float Wartosc { get; set; }
        public bool Wtrakcie { get; set; }
       
        public override string ToString()
        {
            return $"{Nazwa} {Ilosc} {Wartosc} {Wtrakcie}";
        }
    }
}

