﻿// <auto-generated />
using System;
using LiceWebAPI.Entities.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LiceWebAPI.Migrations
{
    [DbContext(typeof(LiceContext))]
    [Migration("20220221125705_MigrationLice")]
    partial class MigrationLice
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LiceWebAPI.Entities.FizickoLice", b =>
                {
                    b.Property<Guid>("LiceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AdresaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("BrojRacuna")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BrojTelefona")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BrojTelefona2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Jmbg")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prezime")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LiceId");

                    b.ToTable("FizickaLica");

                    b.HasData(
                        new
                        {
                            LiceId = new Guid("05b6200f-d5ac-4dce-93e6-9cd5942831a3"),
                            AdresaId = new Guid("1c989ee3-13b2-4d3b-abeb-c4e6343eace7"),
                            BrojRacuna = "908 ‑ 10501123 ‑ 97",
                            BrojTelefona = "0694534321",
                            BrojTelefona2 = "0694004321",
                            Email = "filip@gmail.com",
                            Ime = "Filip",
                            Prezime = "Ivanic"
                        });
                });

            modelBuilder.Entity("LiceWebAPI.Entities.KontaktOsoba", b =>
                {
                    b.Property<Guid>("KontaktOsobaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Funkcija")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prezime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefon")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("KontaktOsobaId");

                    b.ToTable("KontaktOsoba");

                    b.HasData(
                        new
                        {
                            KontaktOsobaId = new Guid("c53b78f6-6b51-46f9-b673-7f7fdf67d6fe"),
                            Funkcija = "Funkcija 1",
                            Ime = "Andrija",
                            Prezime = "Matic",
                            Telefon = "0641525365"
                        },
                        new
                        {
                            KontaktOsobaId = new Guid("91af15c5-2aeb-454d-8ac2-af535783444f"),
                            Funkcija = "Funkcija 2",
                            Ime = "Marko",
                            Prezime = "Petrovic",
                            Telefon = "0691567485"
                        },
                        new
                        {
                            KontaktOsobaId = new Guid("76473679-fea2-48b1-8dd9-8eace3511f33"),
                            Funkcija = "Funkcija 3",
                            Ime = "Nemanja",
                            Prezime = "Lukic",
                            Telefon = "0617854963"
                        });
                });

            modelBuilder.Entity("LiceWebAPI.Entities.PravnoLice", b =>
                {
                    b.Property<Guid>("LiceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AdresaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("BrojRacuna")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BrojTelefona")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BrojTelefona2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Faks")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("KontaktOsobaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Maticnibroj")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Naziv")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LiceId");

                    b.HasIndex("KontaktOsobaId");

                    b.ToTable("PravnaLica");
                });

            modelBuilder.Entity("LiceWebAPI.Entities.PravnoLice", b =>
                {
                    b.HasOne("LiceWebAPI.Entities.KontaktOsoba", "KontaktOsoba")
                        .WithMany()
                        .HasForeignKey("KontaktOsobaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("KontaktOsoba");
                });
#pragma warning restore 612, 618
        }
    }
}
