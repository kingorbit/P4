using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFHarmonogram
{
    public class Etap
    {
        public int Id { get; set; }

        public string Nazwa { get; set; }

        public Etap(string nazwa)
        {
            Nazwa = nazwa;
        }

        public override string ToString()
        {
            return $"{Nazwa}";
        }
    }
}