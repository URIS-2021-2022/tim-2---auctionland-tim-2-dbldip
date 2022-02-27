
using AuctionAPI.Entities.ManyToMany;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuctionAPI.Entities
{
    /// <summary>
    /// Licitacije DB Context
    /// </summary>
    public class AuctionContext : DbContext
    {
        private readonly IConfiguration configuration;

        /// <summary>
        /// Konstruktor Licitacija Context
        /// </summary>
        /// <param name="options">Opcije</param>
        /// <param name="configuration">Konfiguracija</param>
        public AuctionContext(DbContextOptions options, IConfiguration configuration) : base(options)
        {
            this.configuration = configuration;
        }

        /// <summary>
        /// Db za licitacije
        /// </summary>
        public DbSet<AuctionWithoutLists> Auctions { get; set; }

        /// <summary>
        /// Db za many-to-many licitacija-javnoNadmetanje
        /// </summary>
        public DbSet<AuctionPublicBidding> AuctionPublicBidding { get; set; }

        /// <summary>
        /// Metoda u kojoj se konfiguriše konekcioni string za SQL bazu
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("AuctionsDb"));
        }

        /// <summary>
        /// Unos inicijalni podataka u bazu
        /// </summary>
        /// <param name="builder">Omogućava unošenje i podešavanje podataka u toku kreiranja modela</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //Povezivanje veze više prema više licitacija sa javnim nadmetanjem
            // i podešavanje kaskadnog brisanja
            modelBuilder.Entity<AuctionPublicBidding>()
                .HasOne(apb => apb.auction)
                .WithMany()
                .HasForeignKey(apb => apb.auctionId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            //Kreiranje primarnog ključa za APB
            modelBuilder.Entity<AuctionPublicBidding>()
                .HasKey(apb => new { apb.auctionId, apb.publicBiddingId });



            modelBuilder.Entity<AuctionWithoutLists>()
                .HasData(
                new
                {
                    auctionId = Guid.Parse("cac0e0a2-852a-4265-ac71-49c25fb5559b"),
                    auctionNumber = 1,
                    auctionYear = 2022,
                    biddingDate = DateTime.Now.AddDays(-10),
                    limit = 20000,
                    priceStep = 2,
                    
                    registryClosingDate = DateTime.Now.AddDays(-1)
                }, 
                new
                {
                    auctionId = Guid.Parse("2ff32eb3-a7a1-4e8b-a9e1-8ec51f3eca4c"),
                    auctionNumber = 2,
                    auctionYear = 2022,
                    biddingDate = DateTime.Now.AddDays(-12),
                    limit = 20000,
                    priceStep = 2,
                    registryClosingDate = DateTime.Now.AddDays(-3)
                },
                new
                {
                    auctionId = Guid.Parse("fb96a27d-f87f-49b5-98f3-ef6b57e84c3c"),
                    auctionNumber = 3,
                    auctionYear = 2022,
                    biddingDate = DateTime.Now.AddDays(-11),
                    limit = 20000,
                    priceStep = 4,
                    registryClosingDate = DateTime.Now.AddDays(-2)
                });

            modelBuilder.Entity<AuctionPublicBidding>()
                .HasData(
                new
                {
                    auctionId = Guid.Parse("cac0e0a2-852a-4265-ac71-49c25fb5559b"),
                    publicBiddingId = Guid.Parse("56A7CFF5-CB0A-46B8-BFC1-93DB415FEEB4")
                },
                new
                {
                    auctionId = Guid.Parse("cac0e0a2-852a-4265-ac71-49c25fb5559b"),
                    publicBiddingId = Guid.Parse("6849BBBE-5798-4C04-AA20-58DE420AA578"),
                }, new
                {
                    auctionId = Guid.Parse("2ff32eb3-a7a1-4e8b-a9e1-8ec51f3eca4c"),
                    publicBiddingId = Guid.Parse("B195C4C2-2B26-40AD-8FF6-C212474ACC83")
                });

        }
        

    }
}
