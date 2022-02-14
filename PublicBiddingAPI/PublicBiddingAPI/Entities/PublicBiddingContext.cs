using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PublicBiddingAPI.Entities
{
    public class PublicBiddingContext : DbContext
    {
        private readonly IConfiguration configuration;

        public PublicBiddingContext(DbContextOptions options, IConfiguration configuration) : base(options)
        {
            this.configuration = configuration;
        }

        public DbSet<TypeOfPublicBidding> TypesOfPublicBidding { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("PublicBiddingDb"));
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<TypeOfPublicBidding>()
                .HasData(new
                {
                    typeOfPublicBiddingId = Guid.Parse("db2e9db5-16f1-447b-8c6d-3ffcc0277afb"),
                    typeOfPublicBiddingName= "Javno nadmetanje"
                });
            builder.Entity<TypeOfPublicBidding>()
                .HasData(new
                {
                    typeOfPublicBiddingId = Guid.Parse("7d4d747d-e7af-4702-8e4a-cefbf69beccd"),
                    typeOfPublicBiddingName = "Otvaranje zatvorenih ponuda"
                });
            //
        }
    }
}
