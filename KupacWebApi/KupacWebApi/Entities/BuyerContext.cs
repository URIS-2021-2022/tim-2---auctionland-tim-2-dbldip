using KupacWebApi.Entities.ConnectionClasses;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KupacWebApi.Entities
{
    public class BuyerContext : DbContext
    {
        private readonly IConfiguration configuration;
        public BuyerContext(DbContextOptions options, IConfiguration configuration) : base(options)
        {
            this.configuration = configuration;
        }

        public DbSet<BuyerWithoutLists> Buyers { get; set; }
        public DbSet<AuthorizedPersonWithoutLists> AuthorizedPeople { get; set; }
        public DbSet<AuthorizedPersonBuyerConnection> AuthorizedPeopleBuyers { get; set; }
        public DbSet<BuyerAuthorizedPersonConnection> BuyerAuthorizedPeople { get; set; }
        public DbSet<BuyerPaymentConnection> BuyerPayments { get; set; }
        public DbSet<BuyerPersonConnection> BuyerPeople { get; set; }
        public DbSet<BuyerPublicBiddingConnection> BuyerPublicBiddings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("BuyersDb"));
        }
     }
}
