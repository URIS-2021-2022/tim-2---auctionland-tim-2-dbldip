// <auto-generated />
using System;
using KupacWebApi.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace KupacWebApi.Migrations
{
    [DbContext(typeof(BuyerContext))]
    [Migration("20220223041942_finalTest")]
    partial class finalTest
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.Property<string>("jmbg")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("surname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("authorizedPersonId");

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

                    b.Property<int>("realizedArea")
                        .HasColumnType("int");

                    b.HasKey("buyerId");

                    b.ToTable("Buyers");
                });

            modelBuilder.Entity("KupacWebApi.Entities.ConnectionClasses.BuyerAuthorizedPersonConnection", b =>
                {
                    b.Property<Guid>("buyerAuthorizedPersonConnectionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("authorizedPersonId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("buyerId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("buyerAuthorizedPersonConnectionId");

                    b.ToTable("BuyerAuthorizedPeople");
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

            modelBuilder.Entity("KupacWebApi.Entities.ConnectionClasses.BuyerPublicBiddingConnection", b =>
                {
                    b.Property<Guid>("buyerPublicBiddingConnectionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("buyerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("publicBiddingId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("buyerPublicBiddingConnectionId");

                    b.ToTable("BuyerPublicBiddings");
                });
#pragma warning restore 612, 618
        }
    }
}
