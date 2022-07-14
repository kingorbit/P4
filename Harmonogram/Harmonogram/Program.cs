using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;



HarmonogramDb db = new HarmonogramDb();

int opt = 1;

while (opt > 0 && opt < 11)
{
    Console.WriteLine("================== Harmonogram Zleceń Produkcyjnych ==================");
    Console.WriteLine("1 ---> Wyświetl wszystkie zlecenia");
    Console.WriteLine("2 ---> Dodaj nowe zlecenie");
    Console.WriteLine("3 ---> Zakończ zlecenie");
    Console.WriteLine("4 ---> Usuń zlecenie");
    Console.WriteLine("5 ---> Wyszukaj zlecenie po nazwie");
    Console.WriteLine("6 ---> Wyświetl wszystkich pracowników");
    Console.WriteLine("7 ---> Dodaj nowego pracownika");
    Console.WriteLine("8 ---> Usuń pracownika");
    Console.WriteLine("9 ---> Znajdz pracownika po emailu");
    Console.WriteLine("10 --> Zmień email pracownika");
    Console.WriteLine("11 --> Wyjdz z aplikacji");
    Console.WriteLine("======================================================================");

    if (int.TryParse(Console.ReadLine(), out opt))
    {
        switch (opt)
        {
            case 1:
                Back.showOrder(db);
                break;
            case 2:
                Back.addOrder(db);
                break;
            case 3:
                Back.closeOrder(db);
                break;
            case 4:
                Back.removeOrder(db);
                break;
            case 5:
                Back.findOrder(db);
                break;
            case 6:
                Back.showEmploye(db);
                break;
            case 7:
                Back.addEmploye(db) ;
                break;
            case 8:
                Back.removeEmploye(db);
                break;
            case 9:
                Back.findEmployers(db);
                break;
            case 10:
                Back.changeEmail(db);
                break;
            default:
                break;
        }
    }
    else
    {
        Console.WriteLine("Podałeś błędny numer!");
    }
}

