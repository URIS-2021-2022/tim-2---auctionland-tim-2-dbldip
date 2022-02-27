using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OglasWebAPI.Entities.DataContext 
{
    public class OglasContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public OglasContext(DbContextOptions options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        public DbSet<SluzbeniList> SluzbeniList { get; set; }
        public DbSet<Oglas> Oglas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("OglasDB"));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //SLUZBENI LIST
            modelBuilder.Entity<SluzbeniList>()
                .HasData(new
                {
                    SluzbeniListId = Guid.Parse("A72BA918-F982-4647-A474-E2A030D4DB42"),
                    Broj = "mm13jj",
                    Datum = DateTime.Now,
                    Opis = "Opis sluzbenog lista"
                },
                new
                {
                    SluzbeniListId = Guid.Parse("D4D339AD-F616-4C2A-A095-B6F74B139521"),
                    Broj = "ijkl11",
                    Datum = DateTime.Now,
                    Opis = "Opis sluzbenog lista je super"
                },
                new
                {
                    SluzbeniListId = Guid.Parse("09E79DBF-0679-4D8F-A15C-9AAD2C86ACFA"),
                    Broj = "aa331d",
                    Datum = DateTime.Now,
                    Opis = "Opis sluzbenog lista je odlican"
                }
                );


            //OGLAS
            modelBuilder.Entity<Oglas>()
                .HasData(new
                {
                    OglasId = Guid.Parse("BAE63925-7DB1-488A-88FD-AFD5C88140B1"),
                    DatumObjave = DateTime.Parse("2020-05-15"),
                    RokObjave = DateTime.Now,
                    Mesto = "Mesto 1",
                    Oglasivac = "Oglasivac 1",
                    Oblast = "Oblast 1",
                    PredmetJavneProdaje = "Predmet javne prodaje 1",
                    SluzbeniListId = Guid.Parse("A72BA918-F982-4647-A474-E2A030D4DB42")
                },
                new
                {
                    OglasId = Guid.Parse("DC0869ED-EA89-47A0-B2DA-DE9F60418F62"),
                    DatumObjave = DateTime.Parse("2020-06-25"),
                    RokObjave = DateTime.Now,
                    Mesto = "Mesto 2",
                    Oglasivac = "Oglasivac 2",
                    Oblast = "Oblast 2",
                    PredmetJavneProdaje = "Predmet javne prodaje 2",
                    SluzbeniListId = Guid.Parse("D4D339AD-F616-4C2A-A095-B6F74B139521")
                },
                new
                {
                    OglasId = Guid.Parse("2AEBB81A-2954-40A3-B70D-89D77626A7C4"),
                    DatumObjave = DateTime.Parse("2020-07-13"),
                    RokObjave = DateTime.Now,
                    Mesto = "Mesto 3",
                    Oglasivac = "Oglasivac 3",
                    Oblast = "Oblast 3",
                    PredmetJavneProdaje = "Predmet javne prodaje 3",
                    SluzbeniListId = Guid.Parse("09E79DBF-0679-4D8F-A15C-9AAD2C86ACFA")
                }
                );
        }
    }

}
