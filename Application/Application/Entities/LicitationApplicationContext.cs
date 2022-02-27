using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Entities
{
    public class LicitationApplicationContext : DbContext
    {
        private readonly IConfiguration configuration;
        public LicitationApplicationContext(DbContextOptions options, IConfiguration configuration) : base(options)
        {
            this.configuration = configuration;
        }

        public DbSet<LicitationApplication> Applications { get; set; }
        public DbSet<Priority> Priorities { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("ApplicationDB"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Priority>()

                .HasData(new
                {
                    priorityID = Guid.Parse("4d49c029-1739-49d5-911e-0d7477f45b0c"),
                    priorityDescription = "Vlasnik sistema za navodnjavanje"
                });
            modelBuilder.Entity<Priority>()

                .HasData(new
                {
                    priorityID = Guid.Parse("f4762f51-10fc-4f9f-b408-b4267af5b506"),
                    priorityDescription = "Vlasnik zemljista koje se granici sa zemljistem koje se daje u zakup"
                });

            modelBuilder.Entity<Priority>()
  .HasData(new
                {
                    priorityID = Guid.Parse("f7341e41-84b3-48e7-a82c-1a284b709f84"),
                    priorityDescription = " Poljoprivrednik koji je upisan u Registar"
                });

            modelBuilder.Entity<Priority>()

                .HasData(new
                {
                    priorityID = Guid.Parse("f7341e41-84b3-48e7-a82c-1a284b709f83"),
                    priorityDescription = "Vlasnik zemljista koje je najblize zemljistu koje se daje u zakup"
                });
        }

    }
}
