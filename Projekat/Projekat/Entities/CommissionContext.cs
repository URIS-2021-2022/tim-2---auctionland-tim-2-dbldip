using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekat.Entities
{
    public class CommissionContext : DbContext
    {
        private readonly IConfiguration configuration;

        public CommissionContext(DbContextOptions<CommissionContext> options, IConfiguration configuration) : base(options)
        {
            this.configuration = configuration;
        }

        //tako ce se zvati tabela i polja ce se poklapati sa definisanim unutar entities
        public DbSet<Commission> Commissions { get; set; }
        public DbSet<Person> Persons { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("CommissionDB"));
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<Commission>(b =>
            {
                b.HasData(new
                {
                    CommissionId = Guid.Parse("aa5ce9dc-1534-472d-8d9b-63cc87ca5a39")
                });

                b.OwnsOne(e => e.President).HasData(new
                {
                    CommissionId = Guid.Parse("aa5ce9dc-1534-472d-8d9b-63cc87ca5a39"),
                    PersonId = Guid.Parse("7845cc32-71e2-4336-bb3c-11e6b3699673"),
                    Name = "Nikola",
                    Surname = "Bikar",
                    Role = "President"
                });

                b.OwnsMany(e => e.Members).HasData(new
                {
                    CommissionId = Guid.Parse("aa5ce9dc-1534-472d-8d9b-63cc87ca5a39"),
                    PersonId = Guid.Parse("7d60cc93-0ba3-475b-a36b-f203ebb3281b"),
                    Name = "Jovan",
                    Surname = "Jovanovic",
                    Role = "Ucesnik"
                });

                b.OwnsMany(e => e.Members).HasData(new
                {
                    CommissionId = Guid.Parse("aa5ce9dc-1534-472d-8d9b-63cc87ca5a39"),
                    PersonId = Guid.Parse("4244b81e-2a10-40f7-9102-e1b34192eae3"),
                    Name = "Marko",
                    Surname = "Markovic",
                    Role = "Ucesnik"
                });
            });

        }
    }
}
