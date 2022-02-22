using AuctionAPI.Entities.ConnectionClasses;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuctionAPI.Entities
{
    public class AuctionContext : DbContext
    {
        public AuctionContext(DbContextOptions<AuctionContext> options, IEntityTypeConfiguration configuration) : base(options)
        {
            this.configuration = configuration;
        }

        public DbSet<AuctionWithoutLists> Auctions { get; set; }
        public DbSet<AuctionPublicBiddingConnection> AuctionPublicBidding { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("AuctionsDb"));
        }

        /*
        protected override void OnModelCreating(ModelBuilder builder)
        {
            //builder.Entity<AuctionCreation>()
            //    .HasData(new
            //    {
            //        auctionId = Guid.Parse("cac0e0a2-852a-4265-ac71-49c25fb5559b"),
            //        auctionNumber = 1,
            //        auctionYear = 2022,
            //        biddingDate = DateTime.Now.AddDays(-10),
            //        limit = 20000,
            //        priceStep = 2,
            //        naturalPersonDocumentList = "",
            //        legalPersonDocumentList = "",
            //        publicBidding = Guid.Parse("56A7CFF5-CB0A-46B8-BFC1-93DB415FEEB4"),
            //        registryClosingDate = DateTime.Now.AddDays(-1)
            //    }, new
            //    {
            //        auctionId = Guid.Parse("2ff32eb3-a7a1-4e8b-a9e1-8ec51f3eca4c"),
            //        auctionNumber = 2,
            //        auctionYear = 2022,
            //        biddingDate = DateTime.Now.AddDays(-12),
            //        limit = 20000,
            //        priceStep = 2,
            //        naturalPersonDocumentList = "",
            //        legalPersonDocumentList = "",
            //        publicBidding = Guid.Parse("6849BBBE-5798-4C04-AA20-58DE420AA578"),
            //        registryClosingDate = DateTime.Now.AddDays(-3)
            //    }); 
            // Treba dodati vise prema vise javne nabavke i spojiti sa licitacijom
        }
        */

    }
}
