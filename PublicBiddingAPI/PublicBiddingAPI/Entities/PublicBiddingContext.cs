using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

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
        public DbSet<PublicBiddingWithoutLists> PublicBidding { get; set; }
        public DbSet<Bidder> Bidder{ get; set; }
        public DbSet<Buyer> AppliedBuyer{ get; set; }
        public DbSet<Plot> Plot{ get; set; }
        public DbSet<BestBidder> BestBidder { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("PublicBiddingDb"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TypeOfPublicBidding>()
                .HasData(new
                {
                    typeOfPublicBiddingId = Guid.Parse("db2e9db5-16f1-447b-8c6d-3ffcc0277afb"),
                    typeOfPublicBiddingName= "Javno nadmetanje"
                });
            modelBuilder.Entity<TypeOfPublicBidding>()
                .HasData(new
                {
                    typeOfPublicBiddingId = Guid.Parse("7d4d747d-e7af-4702-8e4a-cefbf69beccd"),
                    typeOfPublicBiddingName = "Otvaranje zatvorenih ponuda"
                });
            //
        }
    }
}
