// <auto-generated />
using System;
using CommissionWebAPI.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CommissionWebAPI.Migrations
{
    [DbContext(typeof(CommissionContext))]
    partial class CommissionContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CommissionWebAPI.Entities.Commission", b =>
                {
                    b.Property<Guid>("CommissionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool?>("IsDelete")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<Guid>("PresidentId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("CommissionId");

                    b.HasIndex("PresidentId");

                    b.ToTable("Commissions");

                    b.HasData(
                        new
                        {
                            CommissionId = new Guid("aa5ce9dc-1534-472d-8d9b-63cc87ca5a39"),
                            PresidentId = new Guid("7845cc32-71e2-4336-bb3c-11e6b3699673")
                        });
                });

            modelBuilder.Entity("CommissionWebAPI.Entities.Members", b =>
                {
                    b.Property<Guid>("CommissionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PersonId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("CommissionId", "PersonId");

                    b.ToTable("Members");

                    b.HasData(
                        new
                        {
                            CommissionId = new Guid("aa5ce9dc-1534-472d-8d9b-63cc87ca5a39"),
                            PersonId = new Guid("1499bf05-df8c-465d-895c-bcc5633a40dd")
                        },
                        new
                        {
                            CommissionId = new Guid("aa5ce9dc-1534-472d-8d9b-63cc87ca5a39"),
                            PersonId = new Guid("7d60cc93-0ba3-475b-a36b-f203ebb3281b")
                        });
                });

            modelBuilder.Entity("CommissionWebAPI.Entities.Person", b =>
                {
                    b.Property<Guid>("PersonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PersonId");

                    b.ToTable("Persons");

                    b.HasData(
                        new
                        {
                            PersonId = new Guid("7845cc32-71e2-4336-bb3c-11e6b3699673"),
                            Name = "Nikola",
                            Role = "President",
                            Surname = "Bikar"
                        },
                        new
                        {
                            PersonId = new Guid("7d60cc93-0ba3-475b-a36b-f203ebb3281b"),
                            Name = "Jovan",
                            Role = "Ucesnik",
                            Surname = "Jovanic"
                        },
                        new
                        {
                            PersonId = new Guid("1499bf05-df8c-465d-895c-bcc5633a40dd"),
                            Name = "Marko",
                            Role = "Ucesnik",
                            Surname = "Parcetic"
                        });
                });

            modelBuilder.Entity("CommissionWebAPI.Entities.Commission", b =>
                {
                    b.HasOne("CommissionWebAPI.Entities.Person", "President")
                        .WithMany()
                        .HasForeignKey("PresidentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("President");
                });
#pragma warning restore 612, 618
        }
    }
}
