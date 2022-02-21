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
                            exchangeRateId = new Guid("e84030f1-de4e-4fe6-b955-47be91a93e83"),
                            currencyCode = "EUR",
                            currencyName = "EURO",
                            currencyPrice = 117.584
                        },
                        new
                        {
                            exchangeRateId = new Guid("51a3727e-b756-4d0d-a3d5-cf230f4b0ee4"),
                            currencyCode = "USD",
                            currencyName = "US Dollar",
                            currencyPrice = 103.298
                        },
                        new
                        {
                            exchangeRateId = new Guid("782d8e54-15c2-419b-b97f-7eedf9334acb"),
                            currencyCode = "CHF",
                            currencyName = "Swiss Franc",
                            currencyPrice = 111.33799999999999
                        },
                        new
                        {
                            exchangeRateId = new Guid("fe607c65-fcd0-4874-b960-fba53af94fbf"),
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

                    b.Property<int>("banDuration")
                        .HasColumnType("int");

                    b.Property<double>("bestBid")
                        .HasColumnType("float");

                    b.Property<Guid>("bestBidder")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("buyerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("currencyCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("currencyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("date")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("dateOfBanEnd")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("dateOfBanStart")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("endingTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("exchangeRateId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("hasBan")
                        .HasColumnType("bit");

                    b.Property<double>("leasePeriod")
                        .HasColumnType("float");

                    b.Property<float>("price")
                        .HasColumnType("real");

                    b.Property<Guid>("publicBiddingId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("realizedArea")
                        .HasColumnType("int");

                    b.Property<string>("referenceNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("startingTime")
                        .HasColumnType("datetime2");

                    b.HasKey("paymentId");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("PaymentService.Entities.Plot", b =>
                {
                    b.Property<Guid>("plotId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("paymentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("plot")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("plotId");

                    b.HasIndex("paymentId");

                    b.ToTable("Plots");
                });

            modelBuilder.Entity("PaymentService.Entities.Plot", b =>
                {
                    b.HasOne("PaymentService.Entities.Payment", null)
                        .WithMany("plots")
                        .HasForeignKey("paymentId");
                });

            modelBuilder.Entity("PaymentService.Entities.Payment", b =>
                {
                    b.Navigation("plots");
                });
#pragma warning restore 612, 618
        }
    }
}
