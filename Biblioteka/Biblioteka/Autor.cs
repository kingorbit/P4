using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
class Autor
{
    public int Id { get; set; }
    public string Imie { get; set; }
    public string Nazwisko { get; set; }
    public ICollection<Ksiazka> Ksiazki { get; set; }
    public override string ToString()
    {
        return $"{Imie} {Nazwisko}";
    }
}
