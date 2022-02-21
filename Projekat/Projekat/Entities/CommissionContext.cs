using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommissionWebAPI.Entities
{
    public class CommissionContext : DbContext
    {
        public CommissionContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Commission> Commissions { get; set; }
        public DbSet<Person> Persons { get; set; }   
        public DbSet<Members> Members { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Person>()
                .HasData(new
                {
                    PersonId = Guid.Parse("7845cc32-71e2-4336-bb3c-11e6b3699673"),
                    Name = "Nikola",
                    Surname = "Bikar",
                    Role = "President"
                });
            builder.Entity<Person>()
                .HasData(new
                {
                    PersonId = Guid.Parse("7d60cc93-0ba3-475b-a36b-f203ebb3281b"),
                    Name = "Jovan",
                    Surname = "Jovanic",
                    Role = "Ucesnik"
                });
            builder.Entity<Person>()
                .HasData(new
                {
                    PersonId = Guid.Parse("1499bf05-df8c-465d-895c-bcc5633a40dd"),
                    Name = "Marko",
                    Surname = "Parcetic",
                    Role = "Ucesnik"
                });
            builder.Entity<Commission>()
                .Property("IsDelete")
                .HasDefaultValue(false);
            builder.Entity<Commission>()
                 .HasData(new
                 {
                     CommissionId = Guid.Parse("aa5ce9dc-1534-472d-8d9b-63cc87ca5a39"),
                     PresidentId = Guid.Parse("7845cc32-71e2-4336-bb3c-11e6b3699673")
                 });
            builder.Entity<Members>().HasKey(x => new { x.CommissionId, x.PersonId});
            builder.Entity<Members>()
                .HasData(new
                {
                    CommissionId = Guid.Parse("aa5ce9dc-1534-472d-8d9b-63cc87ca5a39"),
                    PersonId = Guid.Parse("1499bf05-df8c-465d-895c-bcc5633a40dd")
                });
            builder.Entity<Members>()
                .HasData(new
                {
                    CommissionId = Guid.Parse("aa5ce9dc-1534-472d-8d9b-63cc87ca5a39"),
                    PersonId = Guid.Parse("7d60cc93-0ba3-475b-a36b-f203ebb3281b")
                });
        }
    }
}
