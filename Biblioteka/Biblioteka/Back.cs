using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

class Back
{

    public static void showBooks(BibliotekaDb db)
    {
        foreach (var k in db.Ksiazki.Include(i => i.Autor))
        {
            Console.WriteLine(k);
        }
    }
    public static void addBook(BibliotekaDb db)
    {
        foreach (var back in db.Autorzy)
        {
            Console.WriteLine(back.Id + ": " + back);
        }

        Console.WriteLine("Wprowadz id autora:");

        if (int.TryParse(Console.ReadLine(), out int id))
        {
            var autor = db.Autorzy.Find(id);

            if (autor != null)
            {
                Console.WriteLine("Podaj tytuł:");
                string tytul = Console.ReadLine();
                int rok = 0;

                Console.WriteLine("Podaj rok wydania:");
                if (int.TryParse(Console.ReadLine(), out rok))
                {
                    Ksiazka k = new Ksiazka()
                    {
                        Tytul = tytul,
                        RokWydania = rok,
                        AutorId = autor.Id
                    };

                    db.Ksiazki.Add(k);
                    db.SaveChanges();
                }
                else
                {
                    Console.WriteLine("Rok musi być liczbą.");
                }

            }
            else
            {
                Console.WriteLine("Brak autora o podanym id.");
            }
        }
        else
        {
            Console.WriteLine("Wprowadzono błędną liczbę");
        }
    }
    public static void removeBook(BibliotekaDb db)
    {
        Console.WriteLine("Wprowadz id książki do usunięcia:");

        if (int.TryParse(Console.ReadLine(), out int id))
        {
            var removed = db.Ksiazki.Find(id);

            if (removed != null)
            {
                db.Ksiazki.Remove(removed);
                db.SaveChanges();
            }
            else
            {
                Console.WriteLine("Brak książki o podanym id.");
            }
        }
    }
    public static void findBooks(BibliotekaDb db)
    {
        Console.WriteLine("Wprowadź szukaną frazę.");
        string fraza = Console.ReadLine();

        var ksiazki = db.Ksiazki.Where(w => w.Tytul.ToLower().Contains(fraza.ToLower())).Include(i => i.Autor);

        foreach (var k in ksiazki)
        {
            Console.WriteLine(k);
        }
    }
    public static void showAutors(BibliotekaDb db)
    {
        foreach (var back in db.Autorzy)
        {
            Console.WriteLine(back.Id + ": " + back);
        }
    }
    public static void addAutor(BibliotekaDb db)
    {
        Console.WriteLine("Podaj imie autora:");
        string imie = Console.ReadLine();
        Console.WriteLine("Podaj nazwisko autora:");
        string nazwisko = Console.ReadLine();

        Autor back = new Autor()
        {
            Imie = imie,
            Nazwisko = nazwisko
        };

        db.Autorzy.Add(back);
        db.SaveChanges();
    }
    public static void removeAutor(BibliotekaDb db)
    {
        Console.WriteLine("Wprowadz id autora do usunięcia:");

        if (int.TryParse(Console.ReadLine(), out int id))
        {
            var removed = db.Autorzy.Find(id);

            if (removed != null)
            {
                db.Autorzy.Remove(removed);
                db.SaveChanges();
            }
            else
            {
                Console.WriteLine("Brak autora o podanym id.");
            }
        }
    }
    public static void findAutors(BibliotekaDb db)
    {
        Console.WriteLine("Wprowadź szukane nazwisko.");
        string fraza = Console.ReadLine();

        var autorzy = db.Autorzy.Where(w => w.Nazwisko.ToLower().Contains(fraza.ToLower())).Include(i => i.Ksiazki);

        foreach (var back in autorzy)
        {
            Console.WriteLine(back);

            Console.WriteLine("Książki należące do tego autora:");

            foreach (var k in back.Ksiazki)
            {
                Console.WriteLine($"{k.Tytul} wyd. {k.RokWydania}");
            }
        }
    }
}

