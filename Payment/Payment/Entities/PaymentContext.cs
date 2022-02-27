using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace PaymentService.Entities
{
    public class PaymentContext : DbContext
    {
        private readonly IConfiguration configuration;

        public PaymentContext(DbContextOptions options, IConfiguration configuration) : base(options)
        {
            this.configuration = configuration;
        }

        public DbSet<Payment> Payments { get; set; }
        public DbSet<ExchangeRate> ExchangeRates { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("PaymentDB"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ExchangeRate>().HasData(new
            {
                exchangeRateId = Guid.NewGuid(),
                currencyName = "EURO",
                currencyCode = "EUR",
                currencyPrice = 117.584
            });

            modelBuilder.Entity<ExchangeRate>().HasData(new
            {
                exchangeRateId = Guid.NewGuid(),
                currencyName = "US Dollar",
                currencyCode = "USD",
                currencyPrice = 103.298
            });

            modelBuilder.Entity<ExchangeRate>().HasData(new
            {
                exchangeRateId = Guid.NewGuid(),
                currencyName = "Swiss Franc",
                currencyCode = "CHF",
                currencyPrice = 111.338
            });

            modelBuilder.Entity<ExchangeRate>().HasData(new
            {
                exchangeRateId = Guid.NewGuid(),
                currencyName = "Pound sterling",
                currencyCode = "GBP",
                currencyPrice = 139.731
            });
        }
    }
}

