﻿// <auto-generated />
using System;
using KupacWebApi.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace KupacWebApi.Migrations
{
    [DbContext(typeof(BuyerContext))]
    partial class BuyerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("KupacWebApi.Entities.AuthorizedPersonWithoutLists", b =>
                {
                    b.Property<Guid>("authorizedPersonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("addressId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("countryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("jmbg")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("surname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("authorizedPersonId");

                    b.HasIndex("addressId");

                    b.HasIndex("countryId");

                    b.ToTable("AuthorizedPeople");
                });

            modelBuilder.Entity("KupacWebApi.Entities.BuyerWithoutLists", b =>
                {
                    b.Property<Guid>("buyerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("banDuration")
                        .HasColumnType("int");

                    b.Property<DateTime>("dateOfBanEnd")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("dateOfBanStart")
                        .HasColumnType("datetime2");

                    b.Property<bool>("hasBan")
                        .HasColumnType("bit");

                    b.Property<Guid?>("personId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("realizedArea")
                        .HasColumnType("int");

                    b.HasKey("buyerId");

                    b.HasIndex("personId");

                    b.ToTable("Buyers");
                });

            modelBuilder.Entity("KupacWebApi.Entities.ConnectionClasses.BuyerPaymentConnection", b =>
                {
                    b.Property<Guid>("buyerPaymentConnectionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("buyerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("payerId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("buyerPaymentConnectionId");

                    b.ToTable("BuyerPayments");
                });

            modelBuilder.Entity("KupacWebApi.Entities.ConnectionClasses.BuyerPersonConnection", b =>
                {
                    b.Property<Guid>("buyerPersonConnectionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("buyerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("personId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("buyerPersonConnectionId");

                    b.ToTable("BuyerPeople");
                });

            modelBuilder.Entity("KupacWebApi.Entities.OtherAgregates.Address", b =>
                {
                    b.Property<Guid>("addressId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("completeAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("townInfo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("addressId");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("KupacWebApi.Entities.OtherAgregates.Country", b =>
                {
                    b.Property<Guid>("countryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("countryName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("countryId");

                    b.ToTable("Country");
                });

            modelBuilder.Entity("KupacWebApi.Entities.OtherAgregates.Person", b =>
                {
                    b.Property<Guid>("personId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("addressId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("personId");

                    b.HasIndex("addressId");

                    b.ToTable("Person");
                });

            modelBuilder.Entity("KupacWebApi.Entities.AuthorizedPersonWithoutLists", b =>
                {
                    b.HasOne("KupacWebApi.Entities.OtherAgregates.Address", "address")
                        .WithMany()
                        .HasForeignKey("addressId");

                    b.HasOne("KupacWebApi.Entities.OtherAgregates.Country", "country")
                        .WithMany()
                        .HasForeignKey("countryId");

                    b.Navigation("address");

                    b.Navigation("country");
                });

            modelBuilder.Entity("KupacWebApi.Entities.BuyerWithoutLists", b =>
                {
                    b.HasOne("KupacWebApi.Entities.OtherAgregates.Person", "person")
                        .WithMany()
                        .HasForeignKey("personId");

                    b.Navigation("person");
                });

            modelBuilder.Entity("KupacWebApi.Entities.OtherAgregates.Person", b =>
                {
                    b.HasOne("KupacWebApi.Entities.OtherAgregates.Address", "address")
                        .WithMany()
                        .HasForeignKey("addressId");

                    b.Navigation("address");
                });
#pragma warning restore 612, 618
        }
    }
}
