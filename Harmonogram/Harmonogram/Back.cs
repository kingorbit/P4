using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

class Back
{

    public static void showOrder(HarmonogramDb db)
    { 
        foreach (var k in db.Zlecenia)
        {
            Console.WriteLine(k);
        }
    }
    public static void addOrder(HarmonogramDb db)
    {
        foreach (var back in db.Pracownicy)
        {
            Console.WriteLine(back.Id + ": " + back);
        }

        Console.WriteLine("Wprowadz id Pracownika:");

        if (int.TryParse(Console.ReadLine(), out int id))
        {
            var pracownik = db.Pracownicy.Find(id);

            if (pracownik != null)
            {
                Console.WriteLine("Podaj nazwe zlecenia:");
                string nazwa = Console.ReadLine();
                DateTime datarozpoczecia;
                Console.WriteLine("Podaj date rozpoczecia:");
                if (DateTime.TryParse(Console.ReadLine(), out datarozpoczecia))
                {
                    Zlecenie k = new Zlecenie()
                    {
                        Nazwa = nazwa,
                        DataRozpoczecia = datarozpoczecia,
                        PracownikId = pracownik.Id
                    };
                    db.Zlecenia.Add(k);
                    db.SaveChanges();
                }
                else
                {
                    Console.WriteLine("Data rozpoczecia musi być liczbą");
                }

            }
            else
            {
                Console.WriteLine("Brak pracownika o podanym id.");
            }
        }
        else
        {
            Console.WriteLine("Wprowadzono błędną date");
        }
    }
    public static void endOrder(HarmonogramDb db) 
    {
        Console.WriteLine("Podaj nazwe zlecenia:");
        string nazwa = Console.ReadLine();
        DateTime datazakonczenia;
        Console.WriteLine("Podaj date zakonczenia:");
        if (DateTime.TryParse(Console.ReadLine(), out datazakonczenia))
        {
            Zlecenie k = new Zlecenie()
            {
                Nazwa = nazwa,
                DataZakonczenia = datazakonczenia
            };
            db.Zlecenia.Add(k);
            db.SaveChanges();
        }
        else
        {
            Console.WriteLine("Data rozpoczecia musi być liczbą");
        }
    }
    public static void removeOrder(HarmonogramDb db) 
    {
        Console.WriteLine("Wprowadz id zlecenia do usunięcia:");

        if (int.TryParse(Console.ReadLine(), out int id))
        {
            var removed = db.Zlecenia.Find(id);

            if (removed != null)
            {
                db.Zlecenia.Remove(removed);
                db.SaveChanges();
            }
            else
            {
                Console.WriteLine("Brak Zlecenia o podanym id.");
            }
        }
    }

    public static void findOrder(HarmonogramDb db) 
    {
        Console.WriteLine("Wprowadź szukaną frazę.");
        string fraza = Console.ReadLine();

        var zlecenia = db.Zlecenia.Where(w => w.Nazwa.ToLower().Contains(fraza.ToLower())).Include(i => i.Pracownik);

        foreach (var k in zlecenia)
        {
            Console.WriteLine(k);
        }
    }
    public static void showEmploye(HarmonogramDb db) 
    {
        foreach (var back in db.Pracownicy)
        {
            Console.WriteLine(back.Id + ": " + back);
        }
    }
    
    public static void addEmploye(HarmonogramDb db)  
    {
        Console.WriteLine("Podaj imie pracownika:");
        string imie = Console.ReadLine();
        Console.WriteLine("Podaj nazwisko pracownika:");
        string nazwisko = Console.ReadLine();
        Console.WriteLine("Podaj email pracownika:");
        string email = Console.ReadLine();
     
        Pracownik back = new Pracownik()
        {
            Imie = imie,
            Nazwisko = nazwisko,
            Email = email,   
        };

        db.Pracownicy.Add(back);
        db.SaveChanges();
    }
    public static void removeEmploye(HarmonogramDb db) 
    {
        Console.WriteLine("Wprowadz id pracownika do usunięcia:");

        if (int.TryParse(Console.ReadLine(), out int id))
        {
            var removed = db.Pracownicy.Find(id);

            if (removed != null)
            {
                db.Pracownicy.Remove(removed);
                db.SaveChanges();
            }
            else
            {
                Console.WriteLine("Brak pracownika o podanym id.");
            }
        }
    }
    public static void findEmployers(HarmonogramDb db) 
    {
        Console.WriteLine("Wprowadź nazwisko pracownika");
        string fraza = Console.ReadLine();

        var pracownicy = db.Pracownicy.Where(w => w.Nazwisko.ToLower().Contains(fraza.ToLower())).Include(i => i.Zlecenia);

        foreach (var back in pracownicy)
        {
            Console.WriteLine(back);

            Console.WriteLine("Zlecenia w których brał udział pracownik: ");

            foreach (var k in back.Zlecenia)
            {
                Console.WriteLine($"{k.Nazwa} rozpoczęte: {k.DataRozpoczecia} zakończone: {k.DataZakonczenia}");
            }
        }
    }
}

