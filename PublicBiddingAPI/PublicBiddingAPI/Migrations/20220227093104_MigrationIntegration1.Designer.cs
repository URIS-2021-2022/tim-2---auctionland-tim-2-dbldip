﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PublicBiddingAPI.Entities;

namespace PublicBiddingAPI.Migrations
{
    [DbContext(typeof(PublicBiddingContext))]
    [Migration("20220227093104_MigrationIntegration1")]
    partial class MigrationIntegration1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PublicBiddingAPI.Entities.BestBidder", b =>
                {
                    b.Property<Guid>("bestBidderConnectionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("bestBidderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("publicBiddingId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("bestBidderConnectionId");

                    b.ToTable("BestBidder");
                });

            modelBuilder.Entity("PublicBiddingAPI.Entities.Bidder", b =>
                {
                    b.Property<Guid>("bidderConnectionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("bidderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("publicBiddingId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("bidderConnectionId");

                    b.ToTable("Bidder");
                });

            modelBuilder.Entity("PublicBiddingAPI.Entities.Buyer", b =>
                {
                    b.Property<Guid>("buyerConnectionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("buyerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("publicBiddingId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("buyerConnectionId");

                    b.ToTable("AppliedBuyer");
                });

            modelBuilder.Entity("PublicBiddingAPI.Entities.CadastralMunicipality", b =>
                {
                    b.Property<Guid>("cadastralMuniciplaityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("cadastralMunicipalityName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("cadastralMuniciplaityId");

                    b.ToTable("CadastralMunicipality");
                });

            modelBuilder.Entity("PublicBiddingAPI.Entities.Plot", b =>
                {
                    b.Property<Guid>("plotConnectionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("plotId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("publicBiddingId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("plotConnectionId");

                    b.ToTable("Plot");
                });

            modelBuilder.Entity("PublicBiddingAPI.Entities.PublicBiddingWithoutLists", b =>
                {
                    b.Property<Guid>("publicBiddingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("bestBid")
                        .HasColumnType("float");

                    b.Property<Guid?>("cadastralMunicipalitycadastralMuniciplaityId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("date")
                        .HasColumnType("datetime2");

                    b.Property<double>("deposit")
                        .HasColumnType("float");

                    b.Property<DateTime>("endingTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("excepted")
                        .HasColumnType("bit");

                    b.Property<bool>("isDelete")
                        .HasColumnType("bit");

                    b.Property<double>("leasePeriod")
                        .HasColumnType("float");

                    b.Property<int>("numbOfParticipants")
                        .HasColumnType("int");

                    b.Property<int>("round")
                        .HasColumnType("int");

                    b.Property<double>("startingPricePerHectare")
                        .HasColumnType("float");

                    b.Property<DateTime>("startingTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("typeOfPublicBiddingId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("publicBiddingId");

                    b.HasIndex("cadastralMunicipalitycadastralMuniciplaityId");

                    b.HasIndex("typeOfPublicBiddingId");

                    b.ToTable("PublicBidding");
                });

            modelBuilder.Entity("PublicBiddingAPI.Entities.TypeOfPublicBidding", b =>
                {
                    b.Property<Guid>("typeOfPublicBiddingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("typeOfPublicBiddingName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("typeOfPublicBiddingId");

                    b.ToTable("TypesOfPublicBidding");

                    b.HasData(
                        new
                        {
                            typeOfPublicBiddingId = new Guid("db2e9db5-16f1-447b-8c6d-3ffcc0277afb"),
                            typeOfPublicBiddingName = "Javno nadmetanje"
                        },
                        new
                        {
                            typeOfPublicBiddingId = new Guid("7d4d747d-e7af-4702-8e4a-cefbf69beccd"),
                            typeOfPublicBiddingName = "Otvaranje zatvorenih ponuda"
                        });
                });

            modelBuilder.Entity("PublicBiddingAPI.Entities.PublicBiddingWithoutLists", b =>
                {
                    b.HasOne("PublicBiddingAPI.Entities.CadastralMunicipality", "cadastralMunicipality")
                        .WithMany()
                        .HasForeignKey("cadastralMunicipalitycadastralMuniciplaityId");

                    b.HasOne("PublicBiddingAPI.Entities.TypeOfPublicBidding", "typeOfPublicBidding")
                        .WithMany()
                        .HasForeignKey("typeOfPublicBiddingId");

                    b.Navigation("cadastralMunicipality");

                    b.Navigation("typeOfPublicBidding");
                });
#pragma warning restore 612, 618
        }
    }
}
