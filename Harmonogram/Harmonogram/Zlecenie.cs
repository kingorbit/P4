using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

class Zlecenie
{
    public int Id { get; set; }
    public string Nazwa { get; set; }
    public DateTime DataRozpoczecia { get; set; }
    public DateTime DataZakonczenia { get; set; }
    public int PracownikId { get; set; }
    public Pracownik Pracownik { get; set; }
    public override string ToString()
    {
        return $"ID: {Id} Nazwa: {Nazwa} Rozpoczęte: {DataRozpoczecia} Zakończone: {DataZakonczenia}";
    }
}

//INSERT INTO Zlecenia(Nazwa, DataRozpoczecia, DataZakonczenia, PracownikId)
//VALUES('Aptiv', '2021-10-10 20:00', '2021-10-20 10:00', 1);