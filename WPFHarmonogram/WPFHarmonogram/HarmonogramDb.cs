using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFHarmonogram
{
    public class HarmonogramDb : DbContext
    {
        public HarmonogramDb()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=WPFHarmonogram;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }

        public DbSet<Zlecenie> Zlecenia { get; set; }
        public DbSet<Etap> Etapy { get; set; }
        public DbSet<Podglad> Podglady { get; set; }
    }
}
