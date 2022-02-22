﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PaymentService.Entities;

namespace PaymentService.Migrations
{
    [DbContext(typeof(PaymentContext))]
    partial class PaymentContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PaymentService.Entities.ExchangeRate", b =>
                {
                    b.Property<Guid>("exchangeRateId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("currencyCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("currencyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("currencyPrice")
                        .HasColumnType("float");

                    b.HasKey("exchangeRateId");

                    b.ToTable("ExchangeRates");

                    b.HasData(
                        new
                        {
                            exchangeRateId = new Guid("3ca3cbbe-cd96-48ff-afef-eca304e3c879"),
                            currencyCode = "EUR",
                            currencyName = "EURO",
                            currencyPrice = 117.584
                        },
                        new
                        {
                            exchangeRateId = new Guid("6a92ded7-9994-4417-9727-6101e2508b45"),
                            currencyCode = "USD",
                            currencyName = "US Dollar",
                            currencyPrice = 103.298
                        },
                        new
                        {
                            exchangeRateId = new Guid("15f7392c-d099-48bc-afcb-36ca3ed30c6f"),
                            currencyCode = "CHF",
                            currencyName = "Swiss Franc",
                            currencyPrice = 111.33799999999999
                        },
                        new
                        {
                            exchangeRateId = new Guid("885d2166-d12a-4483-8499-4de05421c8ca"),
                            currencyCode = "GBP",
                            currencyName = "Pound sterling",
                            currencyPrice = 139.73099999999999
                        });
                });

            modelBuilder.Entity("PaymentService.Entities.Payment", b =>
                {
                    b.Property<Guid>("paymentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("accountNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("amount")
                        .HasColumnType("int");

                    b.Property<Guid>("buyerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("currencyCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("currencyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("exchangeRateId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<float>("price")
                        .HasColumnType("real");

                    b.Property<Guid>("publicBiddingId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("referenceNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("paymentId");

                    b.ToTable("Payments");
                });
#pragma warning restore 612, 618
        }
    }
}
