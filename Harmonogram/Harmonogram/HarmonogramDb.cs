using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

class HarmonogramDb : DbContext
{
    public HarmonogramDb()
    {
        Database.EnsureCreated();
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Harmonogram2;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
    }
    public DbSet<Zlecenie> Zlecenia { get; set; }
    public DbSet<Pracownik> Pracownicy { get; set; }
}
