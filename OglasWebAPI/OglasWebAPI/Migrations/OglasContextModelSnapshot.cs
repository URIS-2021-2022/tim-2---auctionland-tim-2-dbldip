﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OglasWebAPI.Entities.DataContext;

namespace OglasWebAPI.Migrations
{
    [DbContext(typeof(OglasContext))]
    partial class OglasContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("OglasWebAPI.Entities.Oglas", b =>
                {
                    b.Property<Guid>("OglasId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DatumObjave")
                        .HasColumnType("datetime2");

                    b.Property<string>("Mesto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Oblast")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Oglasivac")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PredmetJavneProdaje")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RokObjave")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("SluzbeniListId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("OglasId");

                    b.HasIndex("SluzbeniListId");

                    b.ToTable("Oglas");

                    b.HasData(
                        new
                        {
                            OglasId = new Guid("bae63925-7db1-488a-88fd-afd5c88140b1"),
                            DatumObjave = new DateTime(2020, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Mesto = "Mesto 1",
                            Oblast = "Oblast 1",
                            Oglasivac = "Oglasivac 1",
                            PredmetJavneProdaje = "Predmet javne prodaje 1",
                            RokObjave = new DateTime(2022, 1, 31, 18, 32, 34, 443, DateTimeKind.Local).AddTicks(9383),
                            SluzbeniListId = new Guid("a72ba918-f982-4647-a474-e2a030d4db42")
                        },
                        new
                        {
                            OglasId = new Guid("dc0869ed-ea89-47a0-b2da-de9f60418f62"),
                            DatumObjave = new DateTime(2020, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Mesto = "Mesto 2",
                            Oblast = "Oblast 2",
                            Oglasivac = "Oglasivac 2",
                            PredmetJavneProdaje = "Predmet javne prodaje 2",
                            RokObjave = new DateTime(2022, 1, 31, 18, 32, 34, 444, DateTimeKind.Local).AddTicks(1300),
                            SluzbeniListId = new Guid("d4d339ad-f616-4c2a-a095-b6f74b139521")
                        },
                        new
                        {
                            OglasId = new Guid("2aebb81a-2954-40a3-b70d-89d77626a7c4"),
                            DatumObjave = new DateTime(2020, 7, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Mesto = "Mesto 3",
                            Oblast = "Oblast 3",
                            Oglasivac = "Oglasivac 3",
                            PredmetJavneProdaje = "Predmet javne prodaje 3",
                            RokObjave = new DateTime(2022, 1, 31, 18, 32, 34, 444, DateTimeKind.Local).AddTicks(1329),
                            SluzbeniListId = new Guid("09e79dbf-0679-4d8f-a15c-9aad2c86acfa")
                        });
                });

            modelBuilder.Entity("OglasWebAPI.Entities.SluzbeniList", b =>
                {
                    b.Property<Guid>("SluzbeniListId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Broj")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Datum")
                        .HasColumnType("datetime2");

                    b.Property<string>("Opis")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SluzbeniListId");

                    b.ToTable("SluzbeniList");

                    b.HasData(
                        new
                        {
                            SluzbeniListId = new Guid("a72ba918-f982-4647-a474-e2a030d4db42"),
                            Broj = "mm13jj",
                            Datum = new DateTime(2022, 1, 31, 18, 32, 34, 431, DateTimeKind.Local).AddTicks(6186),
                            Opis = "Opis sluzbenog lista"
                        },
                        new
                        {
                            SluzbeniListId = new Guid("d4d339ad-f616-4c2a-a095-b6f74b139521"),
                            Broj = "ijkl11",
                            Datum = new DateTime(2022, 1, 31, 18, 32, 34, 434, DateTimeKind.Local).AddTicks(5013),
                            Opis = "Opis sluzbenog lista je super"
                        },
                        new
                        {
                            SluzbeniListId = new Guid("09e79dbf-0679-4d8f-a15c-9aad2c86acfa"),
                            Broj = "aa331d",
                            Datum = new DateTime(2022, 1, 31, 18, 32, 34, 434, DateTimeKind.Local).AddTicks(5063),
                            Opis = "Opis sluzbenog lista je odlican"
                        });
                });

            modelBuilder.Entity("OglasWebAPI.Entities.Oglas", b =>
                {
                    b.HasOne("OglasWebAPI.Entities.SluzbeniList", "sluzbeniList")
                        .WithMany()
                        .HasForeignKey("SluzbeniListId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("sluzbeniList");
                });
#pragma warning restore 612, 618
        }
    }
}