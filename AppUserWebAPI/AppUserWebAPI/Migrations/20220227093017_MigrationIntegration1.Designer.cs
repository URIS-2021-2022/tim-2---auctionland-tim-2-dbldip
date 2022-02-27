﻿// <auto-generated />
using System;
using AppUserWebAPI.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AppUserWebAPI.Migrations
{
    [DbContext(typeof(AppUserContext))]
    [Migration("20220227093017_MigrationIntegration1")]
    partial class MigrationIntegration1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AppUserWebAPI.Entities.AppUser", b =>
                {
                    b.Property<Guid>("appUserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("appUserLastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("appUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("appUserPassword")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("appUserUsername")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("typeOfUser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("typeOfUserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("appUserId");

                    b.ToTable("AppUsers");
                });

            modelBuilder.Entity("AppUserWebAPI.Entities.TypeOfUser", b =>
                {
                    b.Property<Guid>("typeOfUserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("typeOfUser")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("typeOfUserId");

                    b.ToTable("Types");

                    b.HasData(
                        new
                        {
                            typeOfUserId = new Guid("6ba863f6-0692-4cac-9233-c37d45c077ec"),
                            typeOfUser = "Operater"
                        },
                        new
                        {
                            typeOfUserId = new Guid("e9a14b65-9576-4d72-91c3-216fe76c8454"),
                            typeOfUser = "Tehnicki sekretar"
                        },
                        new
                        {
                            typeOfUserId = new Guid("b27196e7-3ffd-4b72-b201-1366052b2f71"),
                            typeOfUser = "Prva komisija"
                        },
                        new
                        {
                            typeOfUserId = new Guid("8e4314fd-413e-4974-a6ea-c34ac02c2eb9"),
                            typeOfUser = "Superuser"
                        },
                        new
                        {
                            typeOfUserId = new Guid("d9257584-a4fd-4503-9755-aa7684399a34"),
                            typeOfUser = "Operater Nadmetanja"
                        },
                        new
                        {
                            typeOfUserId = new Guid("4426b5ab-8829-4c84-9b0a-2bd15dbe2a47"),
                            typeOfUser = "Licitant"
                        },
                        new
                        {
                            typeOfUserId = new Guid("592fc1b8-6b01-4bde-a65b-5bdcd65d19d3"),
                            typeOfUser = "Menadzer"
                        },
                        new
                        {
                            typeOfUserId = new Guid("f6be0101-3d5b-425a-8987-cd5bcfb22fbb"),
                            typeOfUser = "Administrator"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
