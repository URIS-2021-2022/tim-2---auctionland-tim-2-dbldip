using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppUserWebAPI.Entities
{
    public class AppUserContext : DbContext
    {
        private readonly IConfiguration configuration;

        public AppUserContext(DbContextOptions options, IConfiguration configuration) : base(options)
        {
            this.configuration = configuration;
        }

        public DbSet<TypeOfUser> Types { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("UsersDb"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TypeOfUser>()
                .HasData(new
                {
                    typeOfUserId = Guid.Parse("6ba863f6-0692-4cac-9233-c37d45c077ec"),
                    typeOfUser = "Operater"
                });
            modelBuilder.Entity<TypeOfUser>()
                .HasData(new
                {
                    typeOfUserId = Guid.Parse("e9a14b65-9576-4d72-91c3-216fe76c8454"),
                    typeOfUser = "Tehnicki sekretar"
                });
            modelBuilder.Entity<TypeOfUser>()
                .HasData(new
                {
                    typeOfUserId = Guid.Parse("b27196e7-3ffd-4b72-b201-1366052b2f71"),
                    typeOfUser = "Prva komisija"
                });
            modelBuilder.Entity<TypeOfUser>()
                .HasData(new
                {
                    typeOfUserId = Guid.Parse("8e4314fd-413e-4974-a6ea-c34ac02c2eb9"),
                    typeOfUser = "Superuser"
                });
            modelBuilder.Entity<TypeOfUser>()
                .HasData(new
                {
                    typeOfUserId = Guid.Parse("d9257584-a4fd-4503-9755-aa7684399a34"),
                    typeOfUser = "Operater Nadmetanja"
                });
            modelBuilder.Entity<TypeOfUser>()
                .HasData(new
                {
                    typeOfUserId = Guid.Parse("4426b5ab-8829-4c84-9b0a-2bd15dbe2a47"),
                    typeOfUser = "Licitant"
                });
            modelBuilder.Entity<TypeOfUser>()
                .HasData(new
                {
                    typeOfUserId = Guid.Parse("592fc1b8-6b01-4bde-a65b-5bdcd65d19d3"),
                    typeOfUser = "Menadzer"
                });
            modelBuilder.Entity<TypeOfUser>()
                .HasData(new
                {
                    typeOfUserId = Guid.Parse("f6be0101-3d5b-425a-8987-cd5bcfb22fbb"),
                    typeOfUser = "Administrator"
                });
        }
    }
}
