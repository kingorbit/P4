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
        Console.WriteLine("Podaj id Pracownika:");
        foreach (var back in db.Pracownicy)
        {
            Console.WriteLine("ID: " + back.Id + " " + back);
        }
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            var pracownik = db.Pracownicy.Find(id);

            if (pracownik != null)
            {
                Console.WriteLine("Podaj nazwe zlecenia:");
                string nazwa = Console.ReadLine();
                DateTime datarozpoczecia;
                Console.WriteLine("Podaj date rozpoczecia:");
                Console.WriteLine("Pamiętaj aby data była w formacie: YYYY-MM-DD HH:MM:SS");
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
                    Console.WriteLine("Zlecenie zostało dodane do Harmonogramu.");
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
    public static void closeOrder(HarmonogramDb db)
    {
        foreach (var k in db.Zlecenia)
        {
            Console.WriteLine(k);
        }
        Console.WriteLine("Podaj id zlecenia");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var zlecenie = db.Zlecenia.Find(id);
                if (zlecenie != null)
                {
                    Console.WriteLine("Wpisz date zakonczenia");
                    Console.WriteLine("Pamiętaj aby data była w formacie: YYYY-MM-DD HH:MM:SS");
                    DateTime datazakonczenia = DateTime.Parse(Console.ReadLine());
                    Zlecenie k = new Zlecenie()
                    {
                        //Id = id,
                        DataZakonczenia = datazakonczenia,
                        Nazwa = zlecenie.Nazwa,
                        DataRozpoczecia = zlecenie.DataRozpoczecia,
                        PracownikId = zlecenie.PracownikId
                    };

                    db.Zlecenia.Update(k);
                    db.SaveChanges();
                    Console.WriteLine("Pomyślnie zakończono zlecenie.");
                }
                else
                {
                    Console.WriteLine("Brak zlecenia o podanym ID.");
                };
            }
    }
    public static void removeOrder(HarmonogramDb db)
    {
        Console.WriteLine("Podaj id zlecenia do usunięcia:");
        foreach (var k in db.Zlecenia)
        {
            Console.WriteLine(k);
        }

        if (int.TryParse(Console.ReadLine(), out int id))
        {
            var removed = db.Zlecenia.Find(id);

            if (removed != null)
            {
                db.Zlecenia.Remove(removed);
                db.SaveChanges();
                Console.WriteLine("Zlecenie zostało usunięte z Harmonogramu.");
            }
            else
            {
                Console.WriteLine("Brak Zlecenia o podanym id.");
            }
        }
    }

    public static void findOrder(HarmonogramDb db)
    {
        Console.WriteLine("Wprowadź nazwe zlecenia które chce odszukać.");
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
            Console.WriteLine("ID: " + back.Id + " " + back);
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
        Console.WriteLine("Pracownik został dodany do Harmonogramu.");
    }
    public static void removeEmploye(HarmonogramDb db)
    {
        foreach (var back in db.Pracownicy)
        {
            Console.WriteLine("ID: " + back.Id + " " + back);
        }
        Console.WriteLine("Wprowadz id pracownika do usunięcia:");

        if (int.TryParse(Console.ReadLine(), out int id))
        {
            var removed = db.Pracownicy.Find(id);

            if (removed != null)
            {
                db.Pracownicy.Remove(removed);
                db.SaveChanges();
                Console.WriteLine("Pracownik usunięty z Harmonogramu");
            }
            else
            {
                Console.WriteLine("Brak pracownika o podanym id.");
            }
        }
    }
    public static void findEmployers(HarmonogramDb db)
    {

        Console.WriteLine("Wprowadź email pracownika");
        string fraza = Console.ReadLine();

        var pracownicy = db.Pracownicy.Where(w => w.Email.ToLower().Contains(fraza.ToLower())).Include(i => i.Zlecenia);

        foreach (var back in pracownicy)
        {
            Console.WriteLine(back);

            Console.WriteLine("Zlecenia w których brał udział pracownik: ");

            foreach (var k in back.Zlecenia)
            {
                Console.WriteLine($"{k.Nazwa} data rozpoczęcia: {k.DataRozpoczecia} data zakończenia: {k.DataZakonczenia}");
            }
        }
    }
    public static void changeEmail(HarmonogramDb db)
    {
        foreach (var back in db.Pracownicy)
        {
            Console.WriteLine("ID: " + back.Id + " " + back);
        }
        Console.WriteLine("Podaj id pracownika");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            var pracownik = db.Pracownicy.Find(id);
            if (pracownik != null)
            {
                Console.WriteLine("Wpisz nowy email");
                string email = Console.ReadLine();
                Pracownik k = new Pracownik()
                {
                    //Id = id,
                    Imie = pracownik.Imie,
                    Nazwisko = pracownik.Nazwisko,
                    Email = email
                };
                db.Pracownicy.Update(k);
                db.SaveChanges();
                Console.WriteLine("Pomyślnie zmienione email");
            }
            else
            {
                Console.WriteLine("Brak pracownika o podanym ID.");
            }
        }
    }
};

