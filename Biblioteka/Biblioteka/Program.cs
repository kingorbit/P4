using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;



BibliotekaDb db = new BibliotekaDb();

int opt = 1;

while (opt > 0 && opt < 9)
{
    Console.WriteLine("================== BIBLIOTEKA ==================");
    Console.WriteLine("1 ---> Wyświetl wszystkie książki");
    Console.WriteLine("2 ---> Dodaj nową książkę");
    Console.WriteLine("3 ---> Usuń książkę");
    Console.WriteLine("4 ---> Wyszukaj książke");
    Console.WriteLine("5 ---> Wyświetl autorów");
    Console.WriteLine("6 ---> Dodaj nowego autora");
    Console.WriteLine("7 ---> Usuń autora");
    Console.WriteLine("8 ---> Wyszukaj autorów");
    Console.WriteLine("9 ---> Zakończ");
    Console.WriteLine("================================================");

    if (int.TryParse(Console.ReadLine(), out opt))
    {
        switch (opt)
        {
            case 1:
                Back.showBooks(db);
                break;
            case 2:
                Back.addBook(db);
                break;
            case 3:
                Back.removeBook(db);
                break;
            case 4:
                Back.findBooks(db);
                break;
            case 5:
                Back.showAutors(db);
                break;
            case 6:
                Back.addAutor(db);
                break;
            case 7:
                Back.removeAutor(db);
                break;
            case 8:
                Back.findAutors(db);
                break;
            default:
                break;
        }
    }
    else
    {
        Console.WriteLine("Podałeś numer spoza zakresu.");
    }
}

