using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParcelaWebAPI.Entities
{
    public class ParcelContext :DbContext
    {
        private readonly IConfiguration configuration;
        public ParcelContext(DbContextOptions options, IConfiguration configuration) : base(options)
        {
            this.configuration = configuration;
        }

        public DbSet<Parcel> Parcels { get; set; }
        public DbSet<CadastralMunicipality> CadastralMunicipalities { get; set; }
        public DbSet<ParcelUser> ParcelUsers { get; set; }
        public DbSet<ParcelPart> ParcelParts { get; set; }
        public DbSet<ProtectedZone> ProtectedZones { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("ParcelsDb"));
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CadastralMunicipality>()
                .HasData(new
                {
                    cadastralMunicipalityId = Guid.Parse("0e0b5e85-f9d8-44e9-8486-6b6702619dc8"),
                    nameOfCadastralMunicipality = "Cantavir"
                });
            modelBuilder.Entity<CadastralMunicipality>()
               .HasData(new
               {
                   cadastralMunicipalityId = Guid.Parse("e15eb4b2-1e6e-44b7-8d74-c2df17ccfc44"),
                   nameOfCadastralMunicipality = "Backi Vinogradi"
               });
            modelBuilder.Entity<CadastralMunicipality>()
               .HasData(new
               {
                   cadastralMunicipalityId = Guid.Parse("944256fc-8589-475b-9be1-17ef6e29380b"),
                   nameOfCadastralMunicipality = "Bikovo"
               });
            modelBuilder.Entity<CadastralMunicipality>()
               .HasData(new
               {
                   cadastralMunicipalityId = Guid.Parse("1554cd0c-bbdd-498c-8a65-88830c99e508"),
                   nameOfCadastralMunicipality = "Djudjin"
               });
            modelBuilder.Entity<CadastralMunicipality>()
               .HasData(new
               {
                   cadastralMunicipalityId = Guid.Parse("f2e91127-6e56-4f15-bfb1-a6e88efc9ebc"),
                   nameOfCadastralMunicipality = "Zednik"
               });
            modelBuilder.Entity<CadastralMunicipality>()
               .HasData(new
               {
                   cadastralMunicipalityId = Guid.Parse("a1e35aa8-449e-4081-b59a-f1ba12fba5e7"),
                   nameOfCadastralMunicipality = "Tavankut"
               });
            modelBuilder.Entity<CadastralMunicipality>()
               .HasData(new
               {
                   cadastralMunicipalityId = Guid.Parse("8532190d-68f8-4465-896f-2a7e652973ce"),
                   nameOfCadastralMunicipality = "Bajmok"
               });
            modelBuilder.Entity<CadastralMunicipality>()
               .HasData(new
               {
                   cadastralMunicipalityId = Guid.Parse("28937834-ea14-44e9-969f-ef27dc9bfe2f"),
                   nameOfCadastralMunicipality = "Donji Grad"
               });
            modelBuilder.Entity<CadastralMunicipality>()
               .HasData(new
               {
                   cadastralMunicipalityId = Guid.Parse("d127347a-431b-4f02-999c-162769a5b3df"),
                   nameOfCadastralMunicipality = "Stari Grad"
               });
            modelBuilder.Entity<CadastralMunicipality>()
               .HasData(new
               {
                   cadastralMunicipalityId = Guid.Parse("a54bee2c-6373-46b9-b25b-d5ba187f7ae5"),
                   nameOfCadastralMunicipality = "Novi Grad"
               });
            modelBuilder.Entity<CadastralMunicipality>()
               .HasData(new
               {
                   cadastralMunicipalityId = Guid.Parse("b1707be4-a980-4cce-a7eb-a3af44ba36fb"),
                   nameOfCadastralMunicipality = "Palic"
               });
            modelBuilder.Entity<ProtectedZone>()
              .HasData(new
              {
                  protectedZoneId = Guid.Parse("b4817195-2be0-4032-9c3b-c4c153a721dd"),
                  level = 1
              });
            modelBuilder.Entity<ProtectedZone>()
              .HasData(new
              {
                  protectedZoneId = Guid.Parse("f7fb9b2f-f2ef-42b7-9920-239424b7fda8"),
                  level = 2
              });

            modelBuilder.Entity<ProtectedZone>()
              .HasData(new
              {
                  protectedZoneId = Guid.Parse("39d4bbf0-355d-4228-b8e6-e74b1a4fa62c"),
                  level = 3
              });

            modelBuilder.Entity<ProtectedZone>()
              .HasData(new
              {
                  protectedZoneId = Guid.Parse("e192ce2d-d31c-4525-b54c-2459483bf2c1"),
                  level = 4
              });



        }
    }
}
