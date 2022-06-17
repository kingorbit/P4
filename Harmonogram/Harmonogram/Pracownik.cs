using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
class Pracownik
{
    public int Id { get; set; }
    public string Imie { get; set; }
    public string Nazwisko { get; set; }
    public string Email { get; set; }
    public ICollection<Zlecenie> Zlecenia { get; set; }
    public override string ToString()
    {
        return $"{Imie} {Nazwisko} {Email}";
    }
}
//INSERT INTO Pracownicy(Imie, Nazwisko, Email)
//VALUES('Marek', 'Wajdzik', 'wajdzik@onet.pl');