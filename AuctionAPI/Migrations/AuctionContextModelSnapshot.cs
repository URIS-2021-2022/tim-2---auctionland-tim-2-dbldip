﻿// <auto-generated />
using System;
using AuctionAPI.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AuctionAPI.Migrations
{
    [DbContext(typeof(AuctionContext))]
    partial class AuctionContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AuctionAPI.Entities.AuctionWithoutLists", b =>
                {
                    b.Property<Guid>("auctionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("auctionNumber")
                        .HasColumnType("int");

                    b.Property<int>("auctionYear")
                        .HasColumnType("int");

                    b.Property<DateTime>("biddingDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("limit")
                        .HasColumnType("int");

                    b.Property<int>("priceStep")
                        .HasColumnType("int");

                    b.Property<DateTime>("registryClosingDate")
                        .HasColumnType("datetime2");

                    b.HasKey("auctionId");

                    b.ToTable("Auctions");
                });

            modelBuilder.Entity("AuctionAPI.Entities.ConnectionClasses.AuctionPublicBiddingConnection", b =>
                {
                    b.Property<Guid>("auctionPublicBiddingConnectionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("buyerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("publicBiddingId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("auctionPublicBiddingConnectionId");

                    b.ToTable("AuctionPublicBidding");
                });
#pragma warning restore 612, 618
        }
    }
}
