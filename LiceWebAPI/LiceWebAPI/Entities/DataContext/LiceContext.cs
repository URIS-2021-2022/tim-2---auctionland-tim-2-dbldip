using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiceWebAPI.Entities.DataContext
{
    public class LiceContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public LiceContext(DbContextOptions options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        public DbSet<KontaktOsoba> KontaktOsoba { get; set; }
        public DbSet<FizickoLice> FizickoLice { get; set; }
        public DbSet<PravnoLice> PravnoLice { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("LiceDB"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //KONTAKT OSOBA
            modelBuilder.Entity<KontaktOsoba>()
                .HasData(new
                {
                    KontaktOsobaId = Guid.Parse("C53B78F6-6B51-46F9-B673-7F7FDF67D6FE"),
                    Ime = "Andrija",
                    Prezime = "Matic",
                    Funkcija = "Funkcija 1",
                    Telefon = "0641525365"
                },
                new
                {
                    KontaktOsobaId = Guid.Parse("91AF15C5-2AEB-454D-8AC2-AF535783444F"),
                    Ime = "Marko",
                    Prezime = "Petrovic",
                    Funkcija = "Funkcija 2",
                    Telefon = "0691567485"
                },
                new
                {
                    KontaktOsobaId = Guid.Parse("76473679-FEA2-48B1-8DD9-8EACE3511F33"),
                    Ime = "Nemanja",
                    Prezime = "Lukic",
                    Funkcija = "Funkcija 3",
                    Telefon = "0617854963"
                }
                );

            modelBuilder.Entity<FizickoLice>()
                .HasData(new
                {
                    LiceId = Guid.Parse("05B6200F-D5AC-4DCE-93E6-9CD5942831A3"),
                    Ime = "Filip",
                    Prezime = "Ivanic",
                    Jmbg = "1253627363526",
                    BrojTelefona = "0694534321",
                    BrojTelefona2 = "0694004321",
                    Email = "filip@gmail.com",
                    BrojRacuna = "908 ‑ 10501123 ‑ 97",
                    AdresaId = Guid.Parse("1C989EE3-13B2-4D3B-ABEB-C4E6343EACE7")
                }
                );
        }
    }
}
